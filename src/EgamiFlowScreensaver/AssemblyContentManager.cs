// <copyright file="AssemblyContentManager.cs" company="natsnudasoft">
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
    using System.IO;
    using System.Reflection;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Natsnudasoft.NatsnudaLibrary;

    /// <summary>
    /// Defines a content manager which will load content from embedded resources within a specified
    /// <see cref="Assembly"/>.
    /// </summary>
    /// <seealso cref="ContentManager" />
    public class AssemblyContentManager : ContentManager
    {
        private readonly Assembly contentAssembly;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyContentManager"/> class.
        /// </summary>
        /// <param name="contentAssembly">The assembly to retrieve embedded content from.</param>
        /// <param name="serviceProvider">The service provider for the currently running
        /// <see cref="Game"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="contentAssembly"/> is
        /// <see langword="null"/>.</exception>
        public AssemblyContentManager(Assembly contentAssembly, IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            ParameterValidation.IsNotNull(contentAssembly, nameof(contentAssembly));

            this.contentAssembly = contentAssembly;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyContentManager"/> class.
        /// </summary>
        /// <param name="contentAssembly">The assembly to retrieve embedded content from.</param>
        /// <param name="serviceProvider">The service provider for the currently running
        /// <see cref="Game"/>.</param>
        /// <param name="rootDirectory">The root directory to search for content within the
        /// specified assembly.</param>
        /// <exception cref="ArgumentNullException"><paramref name="contentAssembly"/> is
        /// <see langword="null"/>.</exception>
        public AssemblyContentManager(
            Assembly contentAssembly,
            IServiceProvider serviceProvider,
            string rootDirectory)
            : base(serviceProvider, rootDirectory)
        {
            ParameterValidation.IsNotNull(contentAssembly, nameof(contentAssembly));

            this.contentAssembly = contentAssembly;
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException"><paramref name="assetName"/> is
        /// <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="assetName"/> is
        /// empty.</exception>
        /// <exception cref="ContentLoadException">The embedded content file could not be found, or
        /// the embedded content file could not be loaded.</exception>
        protected override Stream OpenStream(string assetName)
        {
            ParameterValidation.IsNotNull(assetName, nameof(assetName));
            ParameterValidation.IsNotEmpty(assetName, nameof(assetName));

            try
            {
                var embeddedAssetPath = Path.Combine(this.RootDirectory, assetName) + ".xnb";
                embeddedAssetPath = ConvertPathToEmbeddedResourcePath(embeddedAssetPath);
                return this.contentAssembly
                    .GetManifestResourceStream(typeof(AssemblyContentManager), embeddedAssetPath);
            }
            catch (FileLoadException ex)
            {
                throw new ContentLoadException(
                    "The embedded content file could not be loaded.",
                    ex);
            }
            catch (FileNotFoundException ex)
            {
                throw new ContentLoadException("The embedded content file was not found.", ex);
            }
            catch (Exception ex)
            {
                throw new ContentLoadException("Embedded content stream error.", ex);
            }
        }

        private static string ConvertPathToEmbeddedResourcePath(string path)
        {
            var embeddedResourcePath = path.Replace('\\', '.');
            embeddedResourcePath = embeddedResourcePath.Replace('/', '.');
            embeddedResourcePath = embeddedResourcePath.Replace(Path.PathSeparator, '.');
            return embeddedResourcePath;
        }
    }
}