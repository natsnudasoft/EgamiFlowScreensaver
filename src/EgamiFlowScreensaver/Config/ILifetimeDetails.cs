// <copyright file="ILifetimeDetails.cs" company="natsnudasoft">
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
    /// Provides an interface encapsulating the state of the current lifetime settings of any images
    /// that will be emitted by the screensaver.
    /// </summary>
    public interface ILifetimeDetails
    {
        /// <summary>
        /// Gets a value indicating whether or not images will be emitted infinitely.
        /// </summary>
        /// <value><see langword="true"/> if images should be emitted infinitely; otherwise
        /// <see langword="false"/>.</value>
        bool IsInfiniteImageEmitMode { get; }

        /// <summary>
        /// Gets the time that emitted images should live for (in milliseconds).
        /// </summary>
        /// <remarks>This setting is only used if <see cref="IsInfiniteImageEmitMode"/> is
        /// <see langword="true"/>.</remarks>
        double ImageEmitLifetime { get; }
    }
}