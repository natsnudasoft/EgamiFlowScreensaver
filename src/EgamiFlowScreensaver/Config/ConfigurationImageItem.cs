// <copyright file="ConfigurationImageItem.cs" company="natsnudasoft">
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
    using Natsnudasoft.NatsnudaLibrary;
    using ProtoBuf;

    /// <summary>
    /// Provides a class describing the location of a copied image file and its original file name.
    /// </summary>
    [ProtoContract]
    public sealed class ConfigurationImageItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationImageItem"/> class.
        /// </summary>
        /// <param name="imageFilePath">The path to the image file.</param>
        /// <param name="originalFileName">The original name of the image file.</param>
        public ConfigurationImageItem(string imageFilePath, string originalFileName)
        {
            ParameterValidation.IsNotNull(imageFilePath, nameof(imageFilePath));
            ParameterValidation.IsNotEmpty(imageFilePath, nameof(imageFilePath));
            ParameterValidation.IsNotNull(originalFileName, nameof(originalFileName));
            ParameterValidation.IsNotEmpty(originalFileName, nameof(originalFileName));

            this.ImageFilePath = imageFilePath;
            this.OriginalFileName = originalFileName;
        }

        private ConfigurationImageItem()
        {
        }

        /// <summary>
        /// Gets the path to the image file.
        /// </summary>
        [ProtoMember(1)]
        public string ImageFilePath { get; }

        /// <summary>
        /// Gets the original name of the image file.
        /// </summary>
        [ProtoMember(2)]
        public string OriginalFileName { get; }
    }
}
