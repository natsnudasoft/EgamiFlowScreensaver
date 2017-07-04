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
        /// Copies the image file at the specified path to the configuration folder.
        /// </summary>
        /// <param name="backgroundImageFilePath">The path to the background image to copy.</param>
        /// <returns>A <see cref="ConfigurationImageItem"/> describing the image item that was
        /// copied.</returns>
        ConfigurationImageItem CopyBackgroundImage(string backgroundImageFilePath);

        /// <summary>
        /// Copies the image file at the specified path to the configuration images folder.
        /// </summary>
        /// <param name="screensaverImageFilePath">The path to the image to copy.</param>
        /// <param name="screensaverImageIndex">The index of the screensaver image in a screensaver
        /// image item collection.</param>
        /// <returns>A <see cref="ConfigurationImageItem"/> describing the image item that was
        /// copied.</returns>
        ConfigurationImageItem CopyScreensaverImage(
            string screensaverImageFilePath,
            int screensaverImageIndex);

        /// <summary>
        /// Removes the image file at the specified path in the configuration images folder from
        /// disk.
        /// </summary>
        /// <param name="screensaverImageFilePath">The path to the image to remove.</param>
        void RemoveScreensaverImage(string screensaverImageFilePath);
    }
}