// <copyright file="ObservableBase.cs" company="natsnudasoft">
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
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Provides an abstract base for classes which require observable properties.
    /// </summary>
    /// <seealso cref="INotifyPropertyChanged" />
    /// <seealso cref="INotifyPropertyChanging" />
    public abstract class ObservableBase : INotifyPropertyChanged, INotifyPropertyChanging
    {
        /// <inheritdoc/>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <inheritdoc/>
        public event PropertyChangingEventHandler PropertyChanging;

        /// <summary>
        /// Assigns the specified new value to the specified backing field of a property,
        /// raising the PropertyChanged and PropertyChanging events as necessary.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of the property.</typeparam>
        /// <param name="field">The backing field of the property.</param>
        /// <param name="newValue">The new value of the backing field of the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns><see langword="true"/> if the property was changed; <see langword="false"/>
        /// if the new value was equal to the old value of the backing field.</returns>
        protected bool Set<T>(
            ref T field,
            T newValue,
            [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, newValue))
            {
                return false;
            }

            this.OnPropertyChanging(propertyName);
            field = newValue;
            this.OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// Called when the value of a property changes.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Called when the value of a property is changing.
        /// </summary>
        /// <param name="propertyName">The name of the property that is changing.</param>
        protected virtual void OnPropertyChanging(string propertyName)
        {
            this.PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
        }
    }
}
