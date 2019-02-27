// <copyright file="DataSourceDisplayValue.cs" company="natsnudasoft">
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

    /// <summary>
    /// Provides a simple class that can be used to provide a display value and underlying value as
    /// a binding source.
    /// </summary>
    /// <typeparam name="T">The <see cref="Type"/> that the display value of this data source
    /// is representing.</typeparam>
    public sealed class DataSourceDisplayValue<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataSourceDisplayValue{T}"/> class.
        /// </summary>
        /// <param name="displayValue">The display value that represents how to display the
        /// specified value.</param>
        /// <param name="value">The underlying value that will be used as a binding source.</param>
        public DataSourceDisplayValue(string displayValue, T value)
        {
            this.DisplayValue = displayValue;
            this.Value = value;
        }

        /// <summary>
        /// Gets the display value that represents how to display the value of this data source.
        /// </summary>
        public string DisplayValue { get; }

        /// <summary>
        /// Gets the underlying value that is to be used as a binding source.
        /// </summary>
        public T Value { get; }
    }
}