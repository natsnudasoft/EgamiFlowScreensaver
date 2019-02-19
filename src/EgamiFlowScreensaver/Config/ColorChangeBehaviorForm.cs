// <copyright file="ColorChangeBehaviorForm.cs" company="natsnudasoft">
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
    /// one colour value to another over a specified time frame.
    /// </summary>
    /// <seealso cref="Form" />
    public partial class ColorChangeBehaviorForm : Form
    {
        private readonly ColorChangeBehaviorFormViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorChangeBehaviorForm" /> class.
        /// </summary>
        /// <param name="viewModel">The view model to bind to.</param>
        /// <exception cref="ArgumentNullException"><paramref name="viewModel" /> is
        /// <see langword="null"/>.</exception>
        public ColorChangeBehaviorForm(ColorChangeBehaviorFormViewModel viewModel)
        {
            ParameterValidation.IsNotNull(viewModel, nameof(viewModel));

            this.viewModel = viewModel;
            this.InitializeComponent();

            this.chooseStartColorButton.Click += (sender, e) =>
            {
                this.viewModel.ChooseStartColor(this);
            };

            this.chooseEndColorButton.Click += (sender, e) =>
            {
                this.viewModel.ChooseEndColor(this);
            };

            this.transitionTimeNumericUpDownWheel.DataBindings.Add(
                nameof(NumericUpDown.Value),
                this.viewModel,
                nameof(ColorChangeBehaviorFormViewModel.TransitionTime),
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