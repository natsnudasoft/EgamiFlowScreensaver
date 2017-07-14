// <copyright file="IConfigurationFileService.cs" company="natsnudasoft">
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
    using System.Collections.Generic;

    /// <summary>
    /// Provides an interface describing operations that can be performed in relation to the
    /// configuration folder.
    /// </summary>
    public interface IConfigurationFileService
    {
        /// <summary>
        /// Gets the path to the configuration folder.
        /// </summary>
        string ConfigPath { get; }

        /// <summary>
        /// Gets the path to the configuration file.
        /// </summary>
        string ConfigFilePath { get; }

        /// <summary>
        /// Gets the path to the configuration images folder.
        /// </summary>
        string ConfigImagesPath { get; }

        /// <summary>
        /// Reads the configuration file from disk.
        /// </summary>
        /// <returns>A <see cref="ScreensaverConfiguration"/> representing the values from the
        /// configuration file.</returns>
        ScreensaverConfiguration Open();

        /// <summary>
        /// Saves the specified configuration values to disk.
        /// </summary>
        /// <param name="screensaverConfiguration">The <see cref="ScreensaverConfiguration"/>
        /// representing the values to save to the configuration file.</param>
        void Save(ScreensaverConfiguration screensaverConfiguration);

        /// <summary>
        /// Commits the specified background image in a cache to the configuration directory.
        /// </summary>
        /// <param name="backgroundImageItem">The background image item describing the path to the
        /// cached background image that is being committed.</param>
        /// <returns>A <see cref="ConfigurationImageItem"/> describing the path to the background
        /// image that was committed to the configuration directory.</returns>
        ConfigurationImageItem CommitCachedBackgroundImage(
            ConfigurationImageItem backgroundImageItem);

        /// <summary>
        /// Commits the specified screensaver images in a cache to the configuration directory.
        /// </summary>
        /// <param name="screensaverImageItems">A collection of screensaver image items describing
        /// the paths to the cached screensaver images that are being committed.</param>
        /// <returns>A collection of instances of <see cref="ConfigurationImageItem"/> describing
        /// the paths to the screensaver images that were committed to the configuration directory.
        /// </returns>
        IList<ConfigurationImageItem> CommitCachedScreensaverImages(
            IReadOnlyList<ConfigurationImageItem> screensaverImageItems);

        /// <summary>
        /// Deletes any old background images in the configuration folder.
        /// </summary>
        void DeleteOldBackgroundImages();
    }
}