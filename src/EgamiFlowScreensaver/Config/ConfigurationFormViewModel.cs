// <copyright file="ConfigurationFormViewModel.cs" company="natsnudasoft">
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
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using Natsnudasoft.NatsnudaLibrary;
    using Properties;

    /// <summary>
    /// Provides a class for managing the state of the backing values for the current state of
    /// configuration for a <see cref="ScreensaverGame"/>.
    /// </summary>
    /// <seealso cref="ObservableBase" />
    /// <seealso cref="IDisposable" />
    public sealed class ConfigurationFormViewModel : ObservableBase, IDisposable
    {
        private readonly IConfigurationFileService configurationFileService;
        private readonly BindingList<ConfigurationImageItem> images;
        private int selectedImageIndex = -1;
        private Image selectedImagePreview;
        private BackgroundMode backgroundMode;
        private float imageEmitRate;
        private int maxImageEmitCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationFormViewModel"/> class.
        /// </summary>
        /// <param name="configurationFileService">The configuration file service to use to
        /// perform operations in the configuration directory.</param>
        public ConfigurationFormViewModel(IConfigurationFileService configurationFileService)
        {
            ParameterValidation.IsNotNull(
                configurationFileService,
                nameof(configurationFileService));

            this.configurationFileService = configurationFileService;
            this.images = new BindingList<ConfigurationImageItem>
            {
                AllowNew = false,
                RaiseListChangedEvents = true
            };
        }

        /// <summary>
        /// Gets the collection of image items as defined by the current configuration.
        /// </summary>
        public IBindingList Images => this.images;

        /// <summary>
        /// Gets or sets the index of the image item that is selected in the image items collection.
        /// </summary>
        public int SelectedImageIndex
        {
            get => this.selectedImageIndex;
            set
            {
                this.Set(ref this.selectedImageIndex, value);
                this.OnPropertyChanged(nameof(this.IsImageSelected));
                this.UpdateImagePreview();
            }
        }

        /// <summary>
        /// Gets a value indicating whether an image item is selected in the current image items
        /// collection.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if an image item is selected; otherwise, <see langword="false"/>.
        /// </value>
        public bool IsImageSelected
        {
            get => this.selectedImageIndex != -1;
        }

        /// <summary>
        /// Gets or sets the preview image of the currently selected image item.
        /// </summary>
        public Image SelectedImagePreview
        {
            get => this.selectedImagePreview;
            set => this.Set(ref this.selectedImagePreview, value);
        }

        /// <summary>
        /// Gets or sets the value of the background mode as defined by the current configuration.
        /// </summary>
        public BackgroundMode BackgroundMode
        {
            get => this.backgroundMode;
            set => this.Set(ref this.backgroundMode, value);
        }

        /// <summary>
        /// Gets or sets the rate that images will be emitted (per second) as defined by the current
        /// configuration.
        /// </summary>
        public float ImageEmitRate
        {
            get => this.imageEmitRate;
            set => this.Set(ref this.imageEmitRate, value);
        }

        /// <summary>
        /// Gets or sets the maximum number of images that will be emitted as defined by the current
        /// configuration.
        /// </summary>
        public int MaxImageEmitCount
        {
            get => this.maxImageEmitCount;
            set => this.Set(ref this.maxImageEmitCount, value);
        }

        /// <summary>
        /// Gets the colour of the background of the screensaver if in
        /// <see cref="BackgroundMode.SolidColor"/> as defined by the current configuration.
        /// </summary>
        public Color BackgroundColor { get; private set; }

        /// <summary>
        /// Gets the background image of the screensaver if in <see cref="BackgroundMode.Image"/> as
        /// defined by the current configuration.
        /// </summary>
        public ConfigurationImageItem BackgroundImage { get; private set; }

        /// <summary>
        /// Displays a dialog allowing a new image to be added to the image item collection.
        /// </summary>
        /// <param name="owner">The window that will own any dialogs that will be displayed.</param>
        public void AddImage(IWin32Window owner)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = @"Image Files (*.bmp, *.jpg, *.jpeg, *.png) | *.bmp; *.jpg;
 *.jpeg; *.png|All Files|*.*";
                openFileDialog.DefaultExt = ".png";
                if (openFileDialog.ShowDialog(owner) == DialogResult.OK)
                {
                    var imageItem = this.configurationFileService.CopyScreensaverImage(
                        openFileDialog.FileName,
                        this.Images.Count);
                    var addedIndex = this.Images.Add(imageItem);
                    this.SelectedImageIndex = addedIndex;
                }
            }
        }

        /// <summary>
        /// Removes the currently selected image item from the image item collection.
        /// </summary>
        public void RemoveSelectedImage()
        {
            if (this.SelectedImageIndex >= 0 && this.SelectedImageIndex < this.Images.Count)
            {
                var selectedImage = this.images[this.SelectedImageIndex];
                this.Images.RemoveAt(this.SelectedImageIndex);
                this.SelectedImagePreview?.Dispose();
                this.configurationFileService.RemoveScreensaverImage(selectedImage.ImageFilePath);
            }
        }

        /// <summary>
        /// Displays a dialog allowing the colour of the background to be selected.
        /// </summary>
        /// <param name="owner">The window that will own any dialogs that will be displayed.</param>
        public void ChooseBackgroundColor(IWin32Window owner)
        {
            using (var colorDialog = new ColorDialog())
            {
                colorDialog.AnyColor = true;
                colorDialog.FullOpen = true;
                colorDialog.Color = this.BackgroundColor;
                if (colorDialog.ShowDialog(owner) == DialogResult.OK)
                {
                    this.BackgroundColor = colorDialog.Color;
                }
            }
        }

        /// <summary>
        /// Displays a dialog allowing an image to chosen as the background.
        /// </summary>
        /// <param name="owner">The window that will own any dialogs that will be displayed.</param>
        public void ChooseBackgroundImage(IWin32Window owner)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = @"Image Files (*.bmp, *.jpg, *.jpeg, *.png) | *.bmp; *.jpg;
 *.jpeg; *.png|All Files|*.*";
                openFileDialog.DefaultExt = ".png";
                if (openFileDialog.ShowDialog(owner) == DialogResult.OK)
                {
                    this.BackgroundImage =
                        this.configurationFileService.CopyBackgroundImage(openFileDialog.FileName);
                }
            }
        }

        /// <summary>
        /// Reads the configuration from disk and synchronises the properties with this view model.
        /// </summary>
        public void ReadSettingsFromDisk()
        {
            var screensaverConfiguration = this.configurationFileService.Open();
            this.BackgroundMode = screensaverConfiguration.BackgroundMode;
            this.BackgroundColor = screensaverConfiguration.BackgroundColor;
            this.BackgroundImage = screensaverConfiguration.BackgroundImage;
            this.ImageEmitRate = screensaverConfiguration.ImageEmitRate;
            this.MaxImageEmitCount = screensaverConfiguration.MaxImageEmitCount;
            this.Images.Clear();
            foreach (var configurationImageItem in screensaverConfiguration.Images)
            {
                this.Images.Add(configurationImageItem);
            }
        }

        /// <summary>
        /// Commits the relevant properties of this view model to the configuration file on disk.
        /// </summary>
        public void CommitSettingsToDisk()
        {
            var screensaverConfiguration = new ScreensaverConfiguration
            {
                BackgroundMode = this.BackgroundMode,
                BackgroundColor = this.BackgroundColor,
                BackgroundImage = this.BackgroundImage,
                ImageEmitRate = this.ImageEmitRate,
                MaxImageEmitCount = this.MaxImageEmitCount
            };
            foreach (var configurationImageItem in this.images)
            {
                screensaverConfiguration.Images.Add(configurationImageItem);
            }

            this.configurationFileService.Save(screensaverConfiguration);
        }

        /// <summary>
        /// Validates that the relevant properties of this view model contain valid values to commit
        /// to disk.
        /// </summary>
        /// <param name="owner">The window that will own any dialogs that will be displayed.</param>
        /// <returns><see langword="true"/> if the view model is valid; otherwise
        /// <see langword="false"/>.</returns>
        public bool Validate(IWin32Window owner)
        {
            var validated = true;
            if (this.BackgroundMode == BackgroundMode.Image)
            {
                if (this.BackgroundImage == null)
                {
                    MessageBox.Show(
                        owner,
                        Resources.ChooseABackgroundImageText,
                        Resources.ChooseABackgroundImageCaption,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    validated = false;
                }
            }

            return validated;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.selectedImagePreview?.Dispose();
            }
        }

        private void UpdateImagePreview()
        {
            this.SelectedImagePreview?.Dispose();
            if (this.SelectedImageIndex >= 0 && this.SelectedImageIndex < this.Images.Count)
            {
                var filePath = this.images[this.SelectedImageIndex].ImageFilePath;
                try
                {
                    this.SelectedImagePreview = Image.FromFile(filePath);
                }
                catch (FileNotFoundException)
                {
                    this.SelectedImagePreview = null;
                }
            }
            else
            {
                this.SelectedImagePreview = null;
            }
        }
    }
}
