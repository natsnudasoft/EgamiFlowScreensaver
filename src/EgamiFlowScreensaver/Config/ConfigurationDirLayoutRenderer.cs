﻿// <copyright file="ConfigurationDirLayoutRenderer.cs" company="natsnudasoft">
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
    using System.Text;
    using Natsnudasoft.NatsnudaLibrary;
    using NLog;
    using NLog.LayoutRenderers;

    /// <summary>
    /// Provides a <see cref="LayoutRenderer"/> to retrieve the path of the configuration directory.
    /// </summary>
    /// <seealso cref="LayoutRenderer" />
    [LayoutRenderer("ConfigDir")]
    public sealed class ConfigurationDirLayoutRenderer : LayoutRenderer
    {
        private readonly IConfigurationFileService configFileService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationDirLayoutRenderer"/> class.
        /// </summary>
        public ConfigurationDirLayoutRenderer()
            : this(new ConfigurationFileService())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationDirLayoutRenderer"/> class.
        /// </summary>
        /// <param name="configFileService">The configuration file service to use to retrieve the
        /// configuration directory.</param>
        /// <exception cref="ArgumentNullException"><paramref name="configFileService"/> is
        /// <see langword="null"/>.</exception>
        public ConfigurationDirLayoutRenderer(IConfigurationFileService configFileService)
        {
            ParameterValidation.IsNotNull(configFileService, nameof(configFileService));

            this.configFileService = configFileService;
        }

        /// <inheritdoc/>
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            builder.Append(this.configFileService.ConfigPath);
        }
    }
}
