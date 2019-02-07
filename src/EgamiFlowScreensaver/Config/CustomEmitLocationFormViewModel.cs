// <copyright file="CustomEmitLocationFormViewModel.cs" company="natsnudasoft">
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
    /// <summary>
    /// Provides a class for managing the state of the backing values for specifying a custom image
    /// emit location.
    /// </summary>
    /// <seealso cref="ObservableBase" />
    public sealed class CustomEmitLocationFormViewModel : ObservableBase
    {
        private int positionX;
        private int positionY;

        /// <summary>
        /// Gets or sets the X coordinate of the custom emit location.
        /// </summary>
        public int CustomImageEmitLocationX
        {
            get => this.positionX;
            set => this.Set(ref this.positionX, value);
        }

        /// <summary>
        /// Gets or sets the Y coordinate of the custom emit location.
        /// </summary>
        public int CustomImageEmitLocationY
        {
            get => this.positionY;
            set => this.Set(ref this.positionY, value);
        }
    }
}