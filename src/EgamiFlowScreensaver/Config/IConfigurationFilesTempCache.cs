// <copyright file="IConfigurationFilesTempCache.cs" company="natsnudasoft">
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
    /// <summary>
    /// Provides an interface defining methods to cache screensaver configuration files to a
    /// temporary directory.
    /// </summary>
    public interface IConfigurationFilesTempCache
    {
        /// <summary>
        /// Sets the current background image in the cache.
        /// </summary>
        /// <param name="backgroundImageFilePath">The file path of the background image to cache.
        /// </param>
        /// <param name="originalFileName">The original name of the image file.</param>
        /// <returns>A <see cref="ConfigurationImageItem"/> describing the path to the cached
        /// background image.</returns>
        ConfigurationImageItem SetBackgroundImage(
            string backgroundImageFilePath,
            string originalFileName);

        /// <summary>
        /// Adds a screensaver image to the cache.
        /// </summary>
        /// <param name="screensaverImageFilePath">The file path of the screensaver image to cache.
        /// </param>
        /// <param name="originalFileName">The original name of the image file.</param>
        /// <returns>A <see cref="ConfigurationImageItem"/> describing the path to the cached
        /// screensaver image.</returns>
        ConfigurationImageItem AddScreensaverImage(
            string screensaverImageFilePath,
            string originalFileName);

        /// <summary>
        /// Removes a screensaver image from the cache.
        /// </summary>
        /// <param name="screensaverImageFilePath">The file path to the screensaver image in the
        /// cache.</param>
        void RemoveScreensaverImage(string screensaverImageFilePath);

        /// <summary>
        /// Clears the cache.
        /// </summary>
        void Clear();
    }
}