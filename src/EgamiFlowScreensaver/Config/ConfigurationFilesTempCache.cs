// <copyright file="ConfigurationFilesTempCache.cs" company="natsnudasoft">
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
    using System.Security;
    using NLog;
    using static System.FormattableString;

    /// <summary>
    /// Provides a class to cache screensaver configuration files to a temporary directory.
    /// </summary>
    public sealed class ConfigurationFilesTempCache : IConfigurationFilesTempCache
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        private static readonly string TempPath = Path.Combine(
            Path.GetTempPath(),
            typeof(Program).Assembly.GetCustomAttribute<GuidAttribute>().Value);

        private readonly HashSet<string> tempPathsToDelete;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationFilesTempCache"/> class.
        /// </summary>
        public ConfigurationFilesTempCache()
        {
            this.tempPathsToDelete = new HashSet<string>();
        }

#pragma warning disable SA1625 // Element documentation must not be copied and pasted
        /// <inheritdoc/>
        /// <exception cref="IOException">The path to the file is not known, or an error occurred
        /// while opening the file.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required
        /// permissions to access the file.</exception>
        /// <exception cref="SecurityException">The caller does not have the required
        /// permissions to access the file.</exception>
        /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example,
        /// it is on an unmapped drive).</exception>
#pragma warning restore SA1625 // Element documentation must not be copied and pasted
        public ConfigurationImageItem SetBackgroundImage(
            string backgroundImageFilePath,
            string originalFileName)
        {
            var tempBackgroundImageFilePath = CopyFileToTempFilePath(backgroundImageFilePath);
            this.tempPathsToDelete.Add(tempBackgroundImageFilePath);
            return new ConfigurationImageItem(tempBackgroundImageFilePath, originalFileName);
        }

#pragma warning disable SA1625 // Element documentation must not be copied and pasted
        /// <inheritdoc/>
        /// <exception cref="IOException">The path to the file is not known, or an error occurred
        /// while opening the file.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required
        /// permissions to access the file.</exception>
        /// <exception cref="SecurityException">The caller does not have the required
        /// permissions to access the file.</exception>
        /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example,
        /// it is on an unmapped drive).</exception>
#pragma warning restore SA1625 // Element documentation must not be copied and pasted
        public ConfigurationImageItem AddScreensaverImage(
            string screensaverImageFilePath,
            string originalFileName)
        {
            var tempScreensaverImageFilePath = CopyFileToTempFilePath(screensaverImageFilePath);
            this.tempPathsToDelete.Add(tempScreensaverImageFilePath);
            return new ConfigurationImageItem(tempScreensaverImageFilePath, originalFileName);
        }

        /// <inheritdoc/>
        /// <exception cref="IOException">The path to the file is not known, or an error occurred
        /// while opening the file.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required
        /// permissions to access the file.</exception>
        /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example,
        /// it is on an unmapped drive).</exception>
        public void RemoveScreensaverImage(string screensaverImageFilePath)
        {
            if (TryRemoveTempFilePath(screensaverImageFilePath))
            {
                this.tempPathsToDelete.Remove(screensaverImageFilePath);
            }
            else
            {
                this.tempPathsToDelete.Add(screensaverImageFilePath);
            }
        }

        /// <inheritdoc/>
        /// <exception cref="IOException">The path to the file is not known, or an error occurred
        /// while opening the file.</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required
        /// permissions to access the file.</exception>
        /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example,
        /// it is on an unmapped drive).</exception>
        public void Clear()
        {
            this.tempPathsToDelete.RemoveWhere(TryRemoveTempFilePath);
        }

        private static string CopyFileToTempFilePath(string originalFilePath)
        {
            Directory.CreateDirectory(TempPath);
            var tempFileName =
                Path.ChangeExtension(Path.GetRandomFileName(), Path.GetExtension(originalFilePath));
            var tempFilePath = Path.Combine(TempPath, tempFileName);
            File.Copy(originalFilePath, tempFilePath, true);
            new FileInfo(tempFilePath).Attributes |= FileAttributes.Temporary;
            return tempFilePath;
        }

        private static bool TryRemoveTempFilePath(string tempFilePath)
        {
            var result = false;
            if (!string.IsNullOrEmpty(tempFilePath))
            {
                try
                {
                    File.Delete(tempFilePath);
                    result = true;
                }
                catch (Exception ex)
                {
                    Logger.Warn(ex, Invariant($"Could not delete temp path at '{tempFilePath}'."));
                }
            }
            else
            {
                result = true;
            }

            return result;
        }
    }
}
