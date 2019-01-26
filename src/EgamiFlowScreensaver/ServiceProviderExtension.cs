// <copyright file="ServiceProviderExtension.cs" company="natsnudasoft">
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
    using Natsnudasoft.NatsnudaLibrary;

    /// <summary>
    /// Provides extension methods to <see cref="IServiceProvider"/>.
    /// </summary>
    /// <seealso cref="IServiceProvider"/>
    public static class ServiceProviderExtension
    {
        /// <summary>
        /// Gets the service object of the specified type.
        /// </summary>
        /// <typeparam name="T">Specifies the type of service object to get.</typeparam>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>A service object of type <typeparamref name="T"/>, or <see langword="null"/> if
        /// there is no service object of type <typeparamref name="T"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="serviceProvider"/> is
        /// <see langword="null"/>.</exception>
        public static T GetService<T>(this IServiceProvider serviceProvider)
        {
            ParameterValidation.IsNotNull(serviceProvider, nameof(serviceProvider));

            return (T)serviceProvider.GetService(typeof(T));
        }
    }
}