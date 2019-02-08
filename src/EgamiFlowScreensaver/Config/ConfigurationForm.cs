// <copyright file="ConfigurationForm.cs" company="natsnudasoft">
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
    using System.Linq;
    using System.Windows.Forms;
    using Natsnudasoft.EgamiFlowScreensaver.Properties;
    using Natsnudasoft.NatsnudaLibrary;

    /// <summary>
    /// The configuration form to manage the settings of a <see cref="ScreensaverGame"/>.
    /// </summary>
    /// <seealso cref="Form" />
    public partial class ConfigurationForm : Form
    {
        private readonly ConfigurationFormViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationForm"/> class.
        /// </summary>
        /// <param name="viewModel">The view model to bind to.</param>
        /// <param name="isIndependentWindow">Whether or not the <see cref="ConfigurationForm"/> is
        /// being opened as an independent window or as part of the screensaver settings window.
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="viewModel"/> is
        /// empty.</exception>
#pragma warning disable MEN003 // Method is too long
        public ConfigurationForm(ConfigurationFormViewModel viewModel, bool isIndependentWindow)
#pragma warning restore MEN003 // Method is too long
        {
            ParameterValidation.IsNotNull(viewModel, nameof(viewModel));

            this.viewModel = viewModel;
            this.InitializeComponent();
            if (isIndependentWindow)
            {
                this.ShowInTaskbar = true;
            }

            this.imagePreviewPictureBox.DataBindings.Add(
                nameof(PictureBox.Image),
                this.viewModel,
                nameof(ConfigurationFormViewModel.SelectedImagePreview),
                true);

            this.imagesListBox.DataSource = this.viewModel.Images;
            this.imagesListBox.DisplayMember = nameof(ConfigurationImageItem.OriginalFileName);
            var selectedImageIndexBinding = new Binding(
                nameof(ListBox.SelectedIndex),
                this.viewModel,
                nameof(ConfigurationFormViewModel.SelectedImageIndex),
                true,
                DataSourceUpdateMode.OnPropertyChanged);
            this.imagesListBox.DataBindings.Add(selectedImageIndexBinding);
            this.imagesListBox.BindingContext[this.viewModel.Images].CurrentChanged +=
                (sender, e) =>
            {
                this.BeginInvoke(new MethodInvoker(selectedImageIndexBinding.WriteValue));
            };

            this.addImageButton.Click += (sender, e) =>
            {
                this.viewModel.AddImage(this);
            };

            this.removeImageButton.DataBindings.Add(
                nameof(Button.Enabled),
                this.viewModel,
                nameof(ConfigurationFormViewModel.IsImageSelected));
            this.removeImageButton.Click += (sender, e) =>
            {
                this.viewModel.RemoveSelectedImage(this);
            };

            this.chooseCustomEmitLocationButton.DataBindings.Add(
                nameof(Button.Enabled),
                this.viewModel,
                nameof(ConfigurationFormViewModel.IsCustomImageEmitLocation));
            this.chooseCustomEmitLocationButton.Click += (sender, e) =>
            {
                this.viewModel.ChooseCustomEmitLocation(this);
            };

            this.chooseColorButton.DataBindings.Add(
                nameof(Button.Enabled),
                this.solidColorRadioButton,
                nameof(RadioButton.Checked));
            this.chooseImageButton.DataBindings.Add(
                nameof(Button.Enabled),
                this.imageRadioButton,
                nameof(RadioButton.Checked));

            this.backgroundImageScaleModeComboBox.DataBindings.Add(
                nameof(ComboBox.Enabled),
                this.imageRadioButton,
                nameof(RadioButton.Checked));
            var imageScaleModeSource = Enum.GetValues(typeof(ImageScaleMode))
                .Cast<ImageScaleMode>()
                .Select(m => new DataSourceDisplayValue<ImageScaleMode>(
                    EnumHelper.GetEnumDisplayName(m), m))
                .ToArray();
            this.backgroundImageScaleModeComboBox.DataSource = imageScaleModeSource;
            this.backgroundImageScaleModeComboBox.DisplayMember =
                nameof(DataSourceDisplayValue<ImageScaleMode>.DisplayValue);
            this.backgroundImageScaleModeComboBox.ValueMember =
                nameof(DataSourceDisplayValue<ImageScaleMode>.Value);
            this.backgroundImageScaleModeComboBox.DataBindings.Add(
                nameof(ComboBox.SelectedValue),
                this.viewModel,
                nameof(ConfigurationFormViewModel.BackgroundImageScaleMode),
                true,
                DataSourceUpdateMode.OnPropertyChanged);

            var imageEmitLocationSource = Enum.GetValues(typeof(ImageEmitLocation))
                .Cast<ImageEmitLocation>()
                .Select(m => new DataSourceDisplayValue<ImageEmitLocation>(
                    EnumHelper.GetEnumDisplayName(m), m))
                .ToArray();
            this.imageEmitLocationComboBox.DataSource = imageEmitLocationSource;
            this.imageEmitLocationComboBox.DisplayMember =
                nameof(DataSourceDisplayValue<ImageEmitLocation>.DisplayValue);
            this.imageEmitLocationComboBox.ValueMember =
                nameof(DataSourceDisplayValue<ImageEmitLocation>.Value);
            this.imageEmitLocationComboBox.DataBindings.Add(
                nameof(ComboBox.SelectedValue),
                this.viewModel,
                nameof(ConfigurationFormViewModel.ImageEmitLocation),
                true,
                DataSourceUpdateMode.OnPropertyChanged);

            this.chooseColorButton.Click += (sender, e) =>
            {
                this.viewModel.ChooseBackgroundColor(this);
            };

            this.chooseImageButton.Click += (sender, e) =>
            {
                this.viewModel.ChooseBackgroundImage(this);
            };

            this.backgroundRadioGroupBox.DataBindings.Add(
                nameof(RadioGroupBox.SelectedRadioValue),
                this.viewModel,
                nameof(ConfigurationFormViewModel.BackgroundMode),
                true,
                DataSourceUpdateMode.OnPropertyChanged);

            this.imageEmitRateNumericUpDown.DataBindings.Add(
                nameof(NumericUpDown.Value),
                this.viewModel,
                nameof(ConfigurationFormViewModel.ImageEmitRate),
                true);

            this.maxImageEmitCountNumericUpDown.DataBindings.Add(
                nameof(NumericUpDown.Value),
                this.viewModel,
                nameof(ConfigurationFormViewModel.MaxImageEmitCount),
                true);

            this.okButton.Click += (sender, e) =>
            {
                this.okButton.Focus();
                if (this.viewModel.Validate(this) &&
                    this.viewModel.CommitSettingsToDisk(this))
                {
                    this.DialogResult = DialogResult.OK;
                }
            };
        }

        /// <inheritdoc/>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            bool retry;
            do
            {
                retry = false;
                if (!this.viewModel.ReadSettingsFromDisk(this))
                {
                    var readSettingsErrorDialogResult = MessageBox.Show(
                        this,
                        Resources.ConfigurationReadSettingsErrorMessage,
                        Resources.ConfigurationReadSettingsErrorCaption,
                        MessageBoxButtons.AbortRetryIgnore,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button3);
                    switch (readSettingsErrorDialogResult)
                    {
                        case DialogResult.Abort:
                            retry = false;
                            this.DialogResult = DialogResult.Abort;
                            break;
                        case DialogResult.Retry:
                            retry = true;
                            break;
                        case DialogResult.Ignore:
                        default:
                            retry = false;
                            break;
                    }
                }
            }
            while (retry);
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.components?.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}