// <copyright file="CustomEmitLocationForm.cs" company="natsnudasoft">
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
    /// A configuration form allowing the user to specify a custom location to emit images from.
    /// </summary>
    /// <seealso cref="Form" />
    public partial class CustomEmitLocationForm : Form
    {
        private readonly CustomEmitLocationFormViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomEmitLocationForm" /> class.
        /// </summary>
        /// <param name="viewModel">The view model to bind to.</param>
        /// <exception cref="ArgumentNullException"><paramref name="viewModel" /> is
        /// <see langword="null"/>.</exception>
        public CustomEmitLocationForm(CustomEmitLocationFormViewModel viewModel)
        {
            ParameterValidation.IsNotNull(viewModel, nameof(viewModel));

            this.viewModel = viewModel;
            this.InitializeComponent();

            this.positionXNumericUpDown.DataBindings.Add(
                nameof(NumericUpDown.Value),
                this.viewModel,
                nameof(CustomEmitLocationFormViewModel.CustomImageEmitLocationX),
                true);

            this.positionYNumericUpDown.DataBindings.Add(
                nameof(NumericUpDown.Value),
                this.viewModel,
                nameof(CustomEmitLocationFormViewModel.CustomImageEmitLocationY),
                true);

            this.okButton.Click += (sender, e) =>
            {
                this.okButton.Focus();
                this.DialogResult = DialogResult.OK;
            };
        }
    }
}