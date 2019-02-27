// <copyright file="ApplyBehaviorsFormViewModel.cs" company="natsnudasoft">
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
    using Natsnudasoft.EgamiFlowScreensaver.Properties;
    using Natsnudasoft.NatsnudaLibrary;

    /// <summary>
    /// Provides a class for managing the state of the backing values for the current state of
    /// configuration for applying behaviours to a screensaver.
    /// </summary>
    /// <seealso cref="ObservableBase" />
    public sealed class ApplyBehaviorsFormViewModel : ObservableBase
    {
        private readonly IBehaviorConfigurationFactory behaviorConfigurationFactory;
        private readonly IBehaviorConfigurationFormFactory behaviorConfigurationFormFactory;
        private readonly ILifetimeDetails lifetimeDetails;
        private readonly Dictionary<ConfigurationBehaviorType, ConfigurationBehavior> behaviors;
        private readonly HashSet<ConfigurationBehaviorType> enabledBehaviorTypes;

        private ConfigurationBehaviorType selectedBehaviorType;
        private string selectedBehaviorDescription;
        private bool canConfigureSelectedBehavior;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplyBehaviorsFormViewModel"/> class.
        /// </summary>
        /// <param name="behaviors">A collection of existing behaviour configurations that this
        /// view model will manage.</param>
        /// <param name="behaviorConfigurationFactory">A factory to be used to create any behaviour
        /// configurations needed by this view model.</param>
        /// <param name="behaviorConfigurationFormFactory">A factory to be used to create any
        /// behaviour configuration forms needed by this view model.</param>
        /// <param name="lifetimeDetails">The current lifetime settings of any images emitted.
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="behaviorConfigurationFactory"/>,
        /// <paramref name="behaviorConfigurationFormFactory"/>, or
        /// <paramref name="lifetimeDetails"/> is <see langword="null"/>.</exception>
        public ApplyBehaviorsFormViewModel(
            IEnumerable<ConfigurationBehavior> behaviors,
            IBehaviorConfigurationFactory behaviorConfigurationFactory,
            IBehaviorConfigurationFormFactory behaviorConfigurationFormFactory,
            ILifetimeDetails lifetimeDetails)
        {
            ParameterValidation.IsNotNull(
                behaviorConfigurationFactory,
                nameof(behaviorConfigurationFactory));
            ParameterValidation.IsNotNull(
                behaviorConfigurationFormFactory,
                nameof(behaviorConfigurationFormFactory));
            ParameterValidation.IsNotNull(lifetimeDetails, nameof(lifetimeDetails));

            this.behaviorConfigurationFactory = behaviorConfigurationFactory;
            this.behaviorConfigurationFormFactory = behaviorConfigurationFormFactory;
            this.lifetimeDetails = lifetimeDetails;
            this.behaviors = behaviors.ToDictionary(b => b.ConfigurationBehaviorType);
            this.enabledBehaviorTypes = new HashSet<ConfigurationBehaviorType>(behaviors
                .Where(b => b.Enabled)
                .Select(b => b.ConfigurationBehaviorType));
        }

        /// <summary>
        /// Gets or sets the currently selected behaviour type.
        /// </summary>
        public ConfigurationBehaviorType SelectedBehaviorType
        {
            get => this.selectedBehaviorType;
            set
            {
                this.Set(ref this.selectedBehaviorType, value);
                this.UpdateBehaviorDescription();
            }
        }

        /// <summary>
        /// Gets or sets the description of the currently selected behaviour type.
        /// </summary>
        public string SelectedBehaviorDescription
        {
            get => this.selectedBehaviorDescription;
            set => this.Set(ref this.selectedBehaviorDescription, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the currently selected behaviour can be
        /// configured.
        /// </summary>
        public bool CanConfigureSelectedBehavior
        {
            get => this.canConfigureSelectedBehavior;
            set => this.Set(ref this.canConfigureSelectedBehavior, value);
        }

        /// <summary>
        /// Gets a collection of behaviours that this view model is managing.
        /// </summary>
        public IReadOnlyCollection<ConfigurationBehavior> Behaviors
        {
            get => this.behaviors.Values;
        }

        /// <summary>
        /// Gets a list of behaviours that have been enabled in this view models lifetime.
        /// </summary>
        public IReadOnlyCollection<ConfigurationBehaviorType> EnabledBehaviorTypes
        {
            get => this.enabledBehaviorTypes;
        }

        /// <summary>
        /// Updates the currently selected behaviour description based on the currently selected
        /// behaviour.
        /// </summary>
        public void UpdateBehaviorDescription()
        {
            var behavior = this.GetOrCreateBehavior(this.SelectedBehaviorType);
            this.SelectedBehaviorDescription = behavior.Description;
        }

        /// <summary>
        /// Sets which behaviours are currently enabled based on a collection of behaviour types.
        /// </summary>
        /// <param name="newEnabledBehaviorTypes">A collection of behaviour types that are currently
        /// enabled.</param>
        /// <exception cref="ArgumentNullException"><paramref name="newEnabledBehaviorTypes"/> is
        /// <see langword="null"/>.</exception>
        public void SetEnabledBehaviors(
            IEnumerable<ConfigurationBehaviorType> newEnabledBehaviorTypes)
        {
            ParameterValidation.IsNotNull(newEnabledBehaviorTypes, nameof(newEnabledBehaviorTypes));

            this.enabledBehaviorTypes.Clear();
            foreach (var behaviorType in newEnabledBehaviorTypes)
            {
                this.GetOrCreateBehavior(behaviorType);
                this.enabledBehaviorTypes.Add(behaviorType);
            }
        }

        /// <summary>
        /// Synchronizes the enabled state of underlying behaviour configurations with the
        /// behaviours that have been enabled in this view model.
        /// </summary>
        public void SynchronizeEnabledBehaviors()
        {
            foreach (var behavior in this.Behaviors)
            {
                behavior.Enabled = false;
            }

            foreach (var behaviorType in this.enabledBehaviorTypes)
            {
                var behavior = this.GetOrCreateBehavior(behaviorType);
                behavior.Enabled = true;
            }
        }

        /// <summary>
        /// Displays a dialog allowing the selected behaviour to be configured if a configuration
        /// form is available.
        /// </summary>
        /// <param name="owner">The window that will own any dialogs that will be displayed.</param>
        /// <exception cref="ArgumentNullException"><paramref name="owner" /> is
        /// <see langword="null" />.</exception>
        public void ConfigureBehavior(IWin32Window owner)
        {
            ParameterValidation.IsNotNull(owner, nameof(owner));

            var behaviorType = this.SelectedBehaviorType;
            var behavior = this.GetOrCreateBehavior(behaviorType);
            if (this.behaviorConfigurationFormFactory.TryCreate(
                behaviorType,
                this.lifetimeDetails,
                out var behaviorForm,
                out var behaviorFormViewModel))
            {
                using (behaviorForm)
                {
                    behaviorFormViewModel.UpdateFromBehavior(behavior);
                    if (behaviorForm.ShowDialog(owner) == DialogResult.OK)
                    {
                        this.behaviors[behaviorType] = behaviorFormViewModel.CreateBehavior();
                    }
                }
            }
            else
            {
                MessageBox.Show(
                    owner,
                    Resources.NoConfigurationFormForBehaviorText,
                    Resources.NoConfigurationFormForBehaviorCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private ConfigurationBehavior GetOrCreateBehavior(ConfigurationBehaviorType behaviorType)
        {
            if (!this.behaviors.TryGetValue(behaviorType, out var behavior))
            {
                behavior = this.behaviorConfigurationFactory.Create(behaviorType);
                this.behaviors[behaviorType] = behavior;
            }

            return behavior;
        }
    }
}