// <copyright file="BackgroundMode.cs" company="natsnudasoft">
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
    /// <summary>
    /// Represents the background mode for a <see cref="ScreensaverGame"/>.
    /// </summary>
    public enum BackgroundMode
    {
        /// <summary>
        /// Represents the option for a background that is a screen capture of the desktop.
        /// </summary>
        Desktop,

        /// <summary>
        /// Represents the option for a background that is a solid colour.
        /// </summary>
        SolidColor,

        /// <summary>
        /// Represents the option for a background that is an image.
        /// </summary>
        Image
    }
}