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
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Security.AccessControl;
    using System.Security.Principal;
    using System.Threading;
    using Properties;
    using ProtoBuf;
    using static System.FormattableString;

    /// <summary>
    /// Provides a class for performing file actions in the configuration folder.
    /// </summary>
    /// <seealso cref="IConfigurationFileService" />
    public sealed class ConfigurationFileService : IConfigurationFileService
    {
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

#pragma warning disable SA1625 // Element documentation must not be copied and pasted
        /// <inheritdoc/>
        /// <exception cref="IOException">The path to a configuration file is not known, or an error
        /// occurred while opening a configuration file.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required
        /// permissions to access a configuration file.</exception>
        /// <exception cref="SecurityException">The caller does not have the required
        /// permissions to access a configuration file.</exception>
        /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example,
        /// it is on an unmapped drive).</exception>
        /// <exception cref="TimeoutException">Timed out waiting for access to a configuration
        /// file.</exception>
#pragma warning restore SA1625 // Element documentation must not be copied and pasted
        public ConfigurationImageItem CopyBackgroundImage(string backgroundImageFilePath)
        {
            Func<ConfigurationImageItem> copyBackgroundImageAction = () =>
            {
                Directory.CreateDirectory(this.ConfigPath);
                this.DeleteOldBackgrounds();
                var newBackgroundImageFileName =
                    Resources.ConfigurationBackgroundImageFileName +
                    Path.GetExtension(backgroundImageFilePath);
                var newBackgroundImageFilePath =
                    Path.Combine(this.ConfigPath, newBackgroundImageFileName);
                File.Copy(backgroundImageFilePath, newBackgroundImageFilePath, true);
                var originalFileName = Path.GetFileName(backgroundImageFilePath);
                return new ConfigurationImageItem(newBackgroundImageFilePath, originalFileName);
            };
            return PerformMutuallyExclusiveConfigFileAction(copyBackgroundImageAction);
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
        public ConfigurationImageItem CopyScreensaverImage(
            string screensaverImageFilePath,
            int screensaverImageIndex)
        {
            Func<ConfigurationImageItem> copyScreensaverImageAction = () =>
            {
                Directory.CreateDirectory(this.ConfigImagesPath);
                var newImageFileName =
                    $"{screensaverImageIndex:D3}" +
                    Path.GetExtension(screensaverImageFilePath);
                var newscreensaverImagePath = Path.Combine(
                    this.ConfigImagesPath,
                    newImageFileName);
                File.Copy(screensaverImageFilePath, newscreensaverImagePath, true);
                var originalFileName = Path.GetFileName(screensaverImageFilePath);
                return new ConfigurationImageItem(newscreensaverImagePath, originalFileName);
            };
            return PerformMutuallyExclusiveConfigFileAction(copyScreensaverImageAction);
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
        public void RemoveScreensaverImage(string screensaverImageFilePath)
        {
            Action removeScreensaverImageAction = () =>
            {
                if (Path.GetDirectoryName(screensaverImageFilePath).Equals(
                this.ConfigImagesPath, StringComparison.OrdinalIgnoreCase))
                {
                    File.Delete(screensaverImageFilePath);
                }
            };
            PerformMutuallyExclusiveConfigFileAction(removeScreensaverImageAction);
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

        private void DeleteOldBackgrounds()
        {
            var configDirectoryInfo = new DirectoryInfo(this.ConfigPath);
            var backgroundFiles = configDirectoryInfo.EnumerateFiles(
                Resources.ConfigurationBackgroundImageFileName + ".*");
            foreach (var backgroundFile in backgroundFiles)
            {
                backgroundFile.Delete();
            }
        }
    }
}
