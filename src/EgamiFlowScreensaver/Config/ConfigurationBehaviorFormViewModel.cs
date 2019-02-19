// <copyright file="ConfigurationBehaviorFormViewModel.cs" company="natsnudasoft">
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
    using System.Windows.Forms;

    /// <summary>
    /// Provides an abstract base class encapsulating a view model used for configuring various
    /// behaviours that can be attached to image items.
    /// </summary>
    public abstract class ConfigurationBehaviorFormViewModel : ObservableBase
    {
        /// <summary>
        /// Updates the current state of this view model that represents a behaviour based on the
        /// specified configuration behaviour.
        /// </summary>
        /// <param name="behavior">A <see cref="ConfigurationBehavior"/> that will be used to update
        /// this view model.</param>
        public abstract void UpdateFromBehavior(ConfigurationBehavior behavior);

        /// <summary>
        /// Creates a configuration behaviour object that encapsulates the current state of
        /// configuration for the behaviour this view model represents.
        /// </summary>
        /// <returns>A <see cref="ConfigurationBehavior"/> encapsulating the current configuration
        /// state of the behaviour.</returns>
        public abstract ConfigurationBehavior CreateBehavior();

        /// <summary>
        /// Validates that the relevant properties of this view model contain valid values to commit
        /// to the underlying storage.
        /// </summary>
        /// <param name="owner">The window that will own any dialogs that will be displayed.</param>
        /// <returns><see langword="true"/> if the view model is valid; otherwise
        /// <see langword="false"/>.</returns>
        public abstract bool Validate(IWin32Window owner);
    }
}