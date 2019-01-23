// <copyright file="ConfigurationFileService.cs" company="natsnudasoft">
// Copyright (c) Adrian John Dunstan. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

namespace Natsnudasoft.EgamiFlowScreensaver.Config
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Security.AccessControl;
    using System.Security.Principal;
    using System.Threading;
    using NLog;
    using Properties;
    using ProtoBuf;
    using static System.FormattableString;

    /// <summary>
    /// Provides a class for performing file actions in the configuration folder.
    /// </summary>
    /// <seealso cref="IConfigurationFileService" />
    public sealed class ConfigurationFileService : IConfigurationFileService
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        private static readonly TimeSpan ConfigFileTimeout = TimeSpan.FromSeconds(3);
        private static readonly Lazy<Mutex> LazyConfigFileMutex =
            new Lazy<Mutex>(CreateConfigFileMutex);

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationFileService"/> class.
        /// </summary>
        public ConfigurationFileService()
        {
            this.ConfigPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                Resources.ConfigurationFolderName);
            this.ConfigFilePath = Path.Combine(
                this.ConfigPath,
                Resources.ConfigurationFileName);
            this.ConfigImagesPath = Path.Combine(
                this.ConfigPath,
                Resources.ConfigurationImagesFolderName);
        }

        /// <inheritdoc/>
        public string ConfigPath { get; }

        /// <inheritdoc/>
        public string ConfigFilePath { get; }

        /// <inheritdoc/>
        public string ConfigImagesPath { get; }

        /// <inheritdoc/>
        /// <exception cref="IOException">The path to a configuration file is not known, or an error
        /// occurred while opening a configuration file.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required
        /// permissions to access a configuration file.</exception>
        /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example,
        /// it is on an unmapped drive).</exception>
        /// <exception cref="ProtoException">There was an error de-serializing the configuration
        /// file.</exception>
        /// <exception cref="TimeoutException">Timed out waiting for access to a configuration
        /// file.</exception>
        public ScreensaverConfiguration Open()
        {
            ScreensaverConfiguration screensaverConfiguration = null;
            Action openAction = () =>
            {
                Directory.CreateDirectory(this.ConfigPath);
                using (var stream = File.Open(
                    this.ConfigFilePath,
                    FileMode.OpenOrCreate,
                    FileAccess.Read))
                {
                    screensaverConfiguration =
                        Serializer.Deserialize<ScreensaverConfiguration>(stream);
                }
            };
            PerformMutuallyExclusiveConfigFileAction(openAction);
            if (screensaverConfiguration == null)
            {
                screensaverConfiguration = new ScreensaverConfiguration();
            }

            return screensaverConfiguration;
        }

        /// <inheritdoc/>
        /// <exception cref="IOException">The path to a configuration file is not known, or an error
        /// occurred while opening a configuration file.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required
        /// permissions to access a configuration file.</exception>
        /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example,
        /// it is on an unmapped drive).</exception>
        /// <exception cref="ProtoException">There was an error serializing the configuration
        /// file.</exception>
        /// <exception cref="TimeoutException">Timed out waiting for access to a configuration
        /// file.</exception>
        public void Save(ScreensaverConfiguration screensaverConfiguration)
        {
            Action saveAction = () =>
            {
                Directory.CreateDirectory(this.ConfigPath);
                using (var stream = File.Open(
                    this.ConfigFilePath,
                    FileMode.Create,
                    FileAccess.Write))
                {
                    Serializer.Serialize(stream, screensaverConfiguration);
                }
            };
            PerformMutuallyExclusiveConfigFileAction(saveAction);
        }

        /// <inheritdoc/>
        /// <exception cref="IOException">The path to a configuration file is not known, or an error
        /// occurred while opening a configuration file.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required
        /// permissions to access a configuration file.</exception>
        /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example,
        /// it is on an unmapped drive).</exception>
        /// <exception cref="TimeoutException">Timed out waiting for access to a configuration
        /// file.</exception>
        public ConfigurationImageItem CommitCachedBackgroundImage(
            ConfigurationImageItem backgroundImageItem)
        {
            Func<ConfigurationImageItem> commitBackgroundImageAction = () =>
            {
                Directory.CreateDirectory(this.ConfigPath);
                this.DeleteOldBackgroundImagesInternal();
                var newBackgroundImageFileName =
                    Resources.ConfigurationBackgroundImageFileName +
                    Path.GetExtension(backgroundImageItem.OriginalFileName);
                var newBackgroundImageFilePath =
                    Path.Combine(this.ConfigPath, newBackgroundImageFileName);
                File.Copy(backgroundImageItem.ImageFilePath, newBackgroundImageFilePath, true);
                return new ConfigurationImageItem(
                    newBackgroundImageFilePath,
                    backgroundImageItem.OriginalFileName);
            };
            return PerformMutuallyExclusiveConfigFileAction(commitBackgroundImageAction);
        }

        /// <inheritdoc/>
        /// <exception cref="IOException">The path to a configuration file is not known, or an error
        /// occurred while opening a configuration file.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required
        /// permissions to access a configuration file.</exception>
        /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example,
        /// it is on an unmapped drive).</exception>
        /// <exception cref="TimeoutException">Timed out waiting for access to a configuration
        /// file.</exception>
        public void DeleteOldBackgroundImages()
        {
            Action clearOldBackgroundImagesAction = () =>
            {
                Directory.CreateDirectory(this.ConfigPath);
                this.DeleteOldBackgroundImagesInternal();
            };
            PerformMutuallyExclusiveConfigFileAction(clearOldBackgroundImagesAction);
        }

        /// <inheritdoc/>
        /// <exception cref="IOException">The path to a configuration file is not known, or an error
        /// occurred while opening a configuration file.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required
        /// permissions to access a configuration file.</exception>
        /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example,
        /// it is on an unmapped drive).</exception>
        /// <exception cref="TimeoutException">Timed out waiting for access to a configuration
        /// file.</exception>
        public IList<ConfigurationImageItem> CommitCachedScreensaverImages(
            IReadOnlyList<ConfigurationImageItem> screensaverImageItems)
        {
            Func<IList<ConfigurationImageItem>> commitScreensaverImageAction = () =>
            {
                Directory.CreateDirectory(this.ConfigImagesPath);
                this.DeleteOldScreensaverImages();
                var committedScreensaverImageItems =
                    new ConfigurationImageItem[screensaverImageItems.Count];
                for (int i = 0; i < screensaverImageItems.Count; ++i)
                {
                    committedScreensaverImageItems[i] =
                        this.CommitCachedScreensaverImage(screensaverImageItems[i], i);
                }

                return committedScreensaverImageItems;
            };
            return PerformMutuallyExclusiveConfigFileAction(commitScreensaverImageAction);
        }

        private static void PerformMutuallyExclusiveConfigFileAction(Action action)
        {
            if (action != null)
            {
                PerformMutuallyExclusiveConfigFileAction(() =>
                {
                    action();
                    return false;
                });
            }
        }

        private static T PerformMutuallyExclusiveConfigFileAction<T>(Func<T> action)
        {
            if (action != null)
            {
                var configFileMutex = LazyConfigFileMutex.Value;
                var hasHandle = false;
                try
                {
                    try
                    {
                        hasHandle = configFileMutex.WaitOne(ConfigFileTimeout, false);
                        if (!hasHandle)
                        {
                            throw new TimeoutException(
                                "Timeout waiting for configuration file access.");
                        }
                    }
                    catch (AbandonedMutexException)
                    {
                        hasHandle = true;
                    }

                    return action();
                }
                finally
                {
                    if (hasHandle)
                    {
                        configFileMutex.ReleaseMutex();
                    }
                }
            }

            return default(T);
        }

        private static Mutex CreateConfigFileMutex()
        {
            var appGuid = typeof(Program).Assembly.GetCustomAttribute<GuidAttribute>().Value;
            var mutexId = Invariant($"Global\\{{{appGuid}}}");
            var allowEveryoneRule = new MutexAccessRule(
                new SecurityIdentifier(WellKnownSidType.WorldSid, null),
                MutexRights.FullControl,
                AccessControlType.Allow);
            var securitySettings = new MutexSecurity();
            securitySettings.AddAccessRule(allowEveryoneRule);
            return new Mutex(false, mutexId, out _, securitySettings);
        }

        private ConfigurationImageItem CommitCachedScreensaverImage(
            ConfigurationImageItem screensaverImageItem,
            int screensaverImageIndex)
        {
            var newImageFileName =
                $"{screensaverImageIndex:D3}" +
                Path.GetExtension(screensaverImageItem.OriginalFileName);
            var newScreensaverImagePath = Path.Combine(this.ConfigImagesPath, newImageFileName);
            File.Copy(screensaverImageItem.ImageFilePath, newScreensaverImagePath, true);
            return new ConfigurationImageItem(
                newScreensaverImagePath,
                screensaverImageItem.OriginalFileName);
        }

        private void DeleteOldBackgroundImagesInternal()
        {
            var configDirectoryInfo = new DirectoryInfo(this.ConfigPath);
            var backgroundImageFiles = configDirectoryInfo.EnumerateFiles(
                Resources.ConfigurationBackgroundImageFileName + ".*");
            foreach (var backgroundImageFile in backgroundImageFiles)
            {
                backgroundImageFile.Delete();
            }
        }

        private void DeleteOldScreensaverImages()
        {
            var configDirectoryInfo = new DirectoryInfo(this.ConfigImagesPath);
            var screensaverImageFiles = configDirectoryInfo.EnumerateFiles();
            foreach (var screensaverImageFile in screensaverImageFiles)
            {
                screensaverImageFile.Delete();
            }
        }
    }
}