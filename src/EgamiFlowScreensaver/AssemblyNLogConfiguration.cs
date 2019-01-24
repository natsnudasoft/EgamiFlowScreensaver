// <copyright file="AssemblyNLogConfiguration.cs" company="natsnudasoft">
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
    using System.Reflection;
    using System.Xml;
    using Natsnudasoft.NatsnudaLibrary;
    using NLog.Config;

    /// <summary>
    /// Defines a class for loading NLog configurations from embedded content in a specified
    /// <see cref="Assembly"/>.
    /// </summary>
    public class AssemblyNLogConfiguration
    {
        private readonly Assembly configAssembly;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyNLogConfiguration"/> class.
        /// </summary>
        /// <param name="configAssembly">The <see cref="Assembly"/> to retrieve embedded content
        /// from.</param>
        /// <exception cref="ArgumentNullException"><paramref name="configAssembly"/> is
        /// <see langword="null"/>.</exception>
        public AssemblyNLogConfiguration(Assembly configAssembly)
        {
            ParameterValidation.IsNotNull(configAssembly, nameof(configAssembly));

            this.configAssembly = configAssembly;
        }

        /// <summary>
        /// Loads an NLog configuration from the embedded resource with the specified name.
        /// </summary>
        /// <param name="configurationName">The fully scoped name of the embedded resource
        /// containing the configuration.</param>
        /// <returns>A <see cref="LoggingConfiguration"/> loaded from an embedded resource.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="configurationName"/> is
        /// <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="configurationName"/> is empty.
        /// </exception>
        public LoggingConfiguration LoadConfiguration(string configurationName)
        {
            ParameterValidation.IsNotNull(configurationName, nameof(configurationName));
            ParameterValidation.IsNotEmpty(configurationName, nameof(configurationName));

            using (var configStream = this.configAssembly
                .GetManifestResourceStream(configurationName))
            using (var configXmlReader = XmlReader.Create(configStream))
            {
                return new XmlLoggingConfiguration(configXmlReader, null);
            }
        }
    }
}