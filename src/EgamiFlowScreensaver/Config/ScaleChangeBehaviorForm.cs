// <copyright file="ScaleChangeBehaviorForm.cs" company="natsnudasoft">
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
    using System.Windows.Forms;
    using Natsnudasoft.NatsnudaLibrary;

    /// <summary>
    /// A form allowing configuration of a behaviour that causes an image item to transition from
    /// one alpha scale to another over a specified time frame.
    /// </summary>
    /// <seealso cref="Form" />
    public partial class ScaleChangeBehaviorForm : Form
    {
        private readonly ScaleChangeBehaviorFormViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScaleChangeBehaviorForm" /> class.
        /// </summary>
        /// <param name="viewModel">The view model to bind to.</param>
        /// <exception cref="ArgumentNullException"><paramref name="viewModel" /> is
        /// <see langword="null"/>.</exception>
        public ScaleChangeBehaviorForm(ScaleChangeBehaviorFormViewModel viewModel)
        {
            ParameterValidation.IsNotNull(viewModel, nameof(viewModel));

            this.viewModel = viewModel;
            this.InitializeComponent();

            this.startScaleXNumericUpDownWheel.DataBindings.Add(
                nameof(NumericUpDown.Value),
                this.viewModel,
                nameof(ScaleChangeBehaviorFormViewModel.StartScaleX),
                true);

            this.startScaleYNumericUpDownWheel.DataBindings.Add(
                nameof(NumericUpDown.Value),
                this.viewModel,
                nameof(ScaleChangeBehaviorFormViewModel.StartScaleY),
                true);

            this.endScaleXNumericUpDownWheel.DataBindings.Add(
                nameof(NumericUpDown.Value),
                this.viewModel,
                nameof(ScaleChangeBehaviorFormViewModel.EndScaleX),
                true);

            this.endScaleYNumericUpDownWheel.DataBindings.Add(
                nameof(NumericUpDown.Value),
                this.viewModel,
                nameof(ScaleChangeBehaviorFormViewModel.EndScaleY),
                true);

            this.transitionTimeNumericUpDownWheel.DataBindings.Add(
                nameof(NumericUpDown.Value),
                this.viewModel,
                nameof(ScaleChangeBehaviorFormViewModel.TransitionTime),
                true);

            this.endTransitionEnabledCheckBox.DataBindings.Add(
                nameof(CheckBox.Enabled),
                this.viewModel,
                nameof(ScaleChangeBehaviorFormViewModel.IsInfiniteImageEmitMode));
            this.endTransitionEnabledCheckBox.DataBindings.Add(
                nameof(CheckBox.Checked),
                this.viewModel,
                nameof(ScaleChangeBehaviorFormViewModel.EndTransitionEnabled),
                false,
                DataSourceUpdateMode.OnPropertyChanged);

            this.endTransitionScaleLabel.DataBindings.Add(
                nameof(Label.Enabled),
                this.viewModel,
                nameof(AlphaChangeBehaviorFormViewModel.EndTransitionEnabled));

            this.endTransitionScaleXNumericUpDownWheel.DataBindings.Add(
                nameof(NumericUpDownWheel.Enabled),
                this.viewModel,
                nameof(ScaleChangeBehaviorFormViewModel.EndTransitionEnabled));
            this.endTransitionScaleXNumericUpDownWheel.DataBindings.Add(
                nameof(NumericUpDownWheel.Value),
                this.viewModel,
                nameof(ScaleChangeBehaviorFormViewModel.EndTransitionScaleX),
                true);

            this.endTransitionScaleYNumericUpDownWheel.DataBindings.Add(
                nameof(NumericUpDownWheel.Enabled),
                this.viewModel,
                nameof(ScaleChangeBehaviorFormViewModel.EndTransitionEnabled));
            this.endTransitionScaleYNumericUpDownWheel.DataBindings.Add(
                nameof(NumericUpDownWheel.Value),
                this.viewModel,
                nameof(ScaleChangeBehaviorFormViewModel.EndTransitionScaleY),
                true);

            this.endTransitionTimeLabel.DataBindings.Add(
                nameof(Label.Enabled),
                this.viewModel,
                nameof(ScaleChangeBehaviorFormViewModel.EndTransitionEnabled));

            this.endTransitionTimeNumericUpDownWheel.DataBindings.Add(
                nameof(NumericUpDownWheel.Enabled),
                this.viewModel,
                nameof(ScaleChangeBehaviorFormViewModel.EndTransitionEnabled));
            this.endTransitionTimeNumericUpDownWheel.DataBindings.Add(
                nameof(NumericUpDownWheel.Value),
                this.viewModel,
                nameof(ScaleChangeBehaviorFormViewModel.EndTransitionTime),
                true);

            this.okButton.Click += (sender, e) =>
            {
                if (this.viewModel.Validate(this))
                {
                    this.okButton.Focus();
                    this.DialogResult = DialogResult.OK;
                }
            };
        }
    }
}