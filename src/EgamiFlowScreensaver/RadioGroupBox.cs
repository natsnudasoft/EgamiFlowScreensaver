// <copyright file="RadioGroupBox.cs" company="natsnudasoft">
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

namespace Natsnudasoft.EgamiFlowScreensaver
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    /// <summary>
    /// Extends the <see cref="GroupBox"/> control with the capability of exposing a value from the
    /// <see cref="Control.Tag"/> property of a currently selected <see cref="RadioButton"/> within
    /// the group.
    /// </summary>
    /// <seealso cref="GroupBox" />
    public class RadioGroupBox : GroupBox
    {
        private readonly List<RadioButton> radioButtons;
        private int selectedRadioIndex;

        /// <summary>
        /// Initializes a new instance of the <see cref="RadioGroupBox"/> class.
        /// </summary>
        public RadioGroupBox()
        {
            this.radioButtons = new List<RadioButton>();
        }

        /// <summary>
        /// Occurs when the index of the selected radio in this <see cref="RadioGroupBox"/> changes.
        /// </summary>
        public event EventHandler SelectedRadioIndexChanged;

        /// <summary>
        /// Gets or sets the index of the <see cref="RadioButton"/> that is currently selected in
        /// this <see cref="RadioGroupBox"/>.
        /// </summary>
        public int SelectedRadioIndex
        {
            get => this.selectedRadioIndex;
            set
            {
                if (value >= 0 && value < this.radioButtons.Count)
                {
                    if (value != this.selectedRadioIndex)
                    {
                        this.radioButtons[value].Checked = true;
                        this.selectedRadioIndex = value;
                        this.OnSelectedRadioIndexChanged();
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the value that represents the <see cref="RadioButton"/> that is currently
        /// selected in this <see cref="RadioGroupBox"/>.
        /// </summary>
        public object SelectedRadioValue
        {
            get => this.radioButtons[this.selectedRadioIndex].Tag;
            set => this.SelectedRadioIndex = this.radioButtons.FindIndex(r => value.Equals(r.Tag));
        }

        /// <inheritdoc/>
        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            if (e.Control is RadioButton radioButton)
            {
                var radioButtonIndex = this.radioButtons.Count;
                this.radioButtons.Add(radioButton);
                radioButton.CheckedChanged += (sender, _) =>
                {
                    this.RadioButtonCheckedChanged((RadioButton)sender, radioButtonIndex);
                };
            }
        }

        private void RadioButtonCheckedChanged(RadioButton radioButton, int newIndex)
        {
            if (radioButton.Checked)
            {
                this.SelectedRadioIndex = newIndex;
            }
        }

        private void OnSelectedRadioIndexChanged()
        {
            this.SelectedRadioIndexChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}