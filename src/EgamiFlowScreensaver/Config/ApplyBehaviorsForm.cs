// <copyright file="ApplyBehaviorsForm.cs" company="natsnudasoft">
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
    using System.Linq;
    using System.Windows.Forms;
    using Natsnudasoft.NatsnudaLibrary;

    /// <summary>
    /// A configuration form to allow the application and configuration of various behaviours that
    /// will be applied to image items.
    /// </summary>
    /// <seealso cref="Form" />
    public partial class ApplyBehaviorsForm : Form
    {
        private readonly ApplyBehaviorsFormViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplyBehaviorsForm" /> class.
        /// </summary>
        /// <param name="viewModel">The view model to bind to.</param>
        /// <exception cref="ArgumentNullException"><paramref name="viewModel" /> is
        /// <see langword="null"/>.</exception>
        public ApplyBehaviorsForm(ApplyBehaviorsFormViewModel viewModel)
        {
            ParameterValidation.IsNotNull(viewModel, nameof(viewModel));

            this.viewModel = viewModel;
            this.InitializeComponent();

            var imageItemBehaviorTypeSource = Enum
                .GetValues(typeof(ConfigurationBehaviorType))
                .Cast<ConfigurationBehaviorType>()
                .Select(m => new DataSourceDisplayValue<ConfigurationBehaviorType>(
                    EnumHelper.GetEnumDisplayName(m), m))
                .ToArray();
            this.availableBehaviorsCheckedListBox.DataSource = imageItemBehaviorTypeSource;
            this.availableBehaviorsCheckedListBox.DisplayMember =
                nameof(DataSourceDisplayValue<ConfigurationBehaviorType>.DisplayValue);
            this.availableBehaviorsCheckedListBox.ValueMember =
                nameof(DataSourceDisplayValue<ConfigurationBehaviorType>.Value);
            this.availableBehaviorsCheckedListBox.DataBindings.Add(
                nameof(CheckedListBox.SelectedValue),
                this.viewModel,
                nameof(ApplyBehaviorsFormViewModel.SelectedBehaviorType),
                true,
                DataSourceUpdateMode.OnPropertyChanged);
            this.UpdateCheckedBehaviors();
            this.UpdateCanConfigureSelectedBehavior();
            this.availableBehaviorsCheckedListBox.ItemCheck += (sender, e) =>
            {
                this.BeginInvoke((MethodInvoker)this.UpdateCanConfigureSelectedBehavior);
                var setEnabledBehaviors =
                    (Action<IEnumerable<ConfigurationBehaviorType>>)this.viewModel
                    .SetEnabledBehaviors;
                var enabledBehaviorTypes = this.availableBehaviorsCheckedListBox.CheckedItems
                    .Cast<DataSourceDisplayValue<ConfigurationBehaviorType>>()
                    .Select(b => b.Value);
                this.BeginInvoke(setEnabledBehaviors, enabledBehaviorTypes);
            };
            this.availableBehaviorsCheckedListBox.SelectedIndexChanged += (sender, e) =>
            {
                this.UpdateCanConfigureSelectedBehavior();
            };

            this.behaviorDescriptionLabel.DataBindings.Add(
                nameof(Label.Text),
                this.viewModel,
                nameof(ApplyBehaviorsFormViewModel.SelectedBehaviorDescription));
            this.viewModel.UpdateBehaviorDescription();

            this.configureSelectedBehaviorButton.DataBindings.Add(
                nameof(Button.Enabled),
                this.viewModel,
                nameof(ApplyBehaviorsFormViewModel.CanConfigureSelectedBehavior));
            this.configureSelectedBehaviorButton.Click += (sender, e) =>
            {
                this.viewModel.ConfigureBehavior(this);
            };

            this.okButton.Click += (sender, e) =>
            {
                this.okButton.Focus();
                this.DialogResult = DialogResult.OK;
            };
        }

        private void UpdateCheckedBehaviors()
        {
            var enabledBehaviors = this.viewModel.EnabledBehaviorTypes.ToHashSet();
            var behaviorTypesWithIndex = this.availableBehaviorsCheckedListBox.Items
                .Cast<DataSourceDisplayValue<ConfigurationBehaviorType>>()
                .Select((b, i) => new { BehaviorType = b.Value, Index = i })
                .ToArray();
            foreach (var behaviorTypeWithIndex in behaviorTypesWithIndex)
            {
                if (enabledBehaviors.Contains(behaviorTypeWithIndex.BehaviorType))
                {
                    this.availableBehaviorsCheckedListBox.SetItemChecked(
                        behaviorTypeWithIndex.Index,
                        true);
                }
            }
        }

        private void UpdateCanConfigureSelectedBehavior()
        {
            var index = this.availableBehaviorsCheckedListBox.SelectedIndex;
            var canConfigureSelectedBehavior = false;
            if (index >= 0 && index <= this.availableBehaviorsCheckedListBox.Items.Count)
            {
                canConfigureSelectedBehavior =
                    this.availableBehaviorsCheckedListBox.GetItemChecked(index);
            }

            this.viewModel.CanConfigureSelectedBehavior = canConfigureSelectedBehavior;
        }
    }
}