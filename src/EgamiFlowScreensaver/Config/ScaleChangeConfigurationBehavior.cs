// <copyright file="ScaleChangeConfigurationBehavior.cs" company="natsnudasoft">
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
    using System.ComponentModel;
    using Natsnudasoft.EgamiFlowScreensaver.Properties;
    using ProtoBuf;

    /// <summary>
    /// Provides a class for managing the current state of configuration for a scale change
    /// behaviour.
    /// </summary>
    /// <seealso cref="ConfigurationBehavior" />
    [ProtoContract]
    public sealed class ScaleChangeConfigurationBehavior : ConfigurationBehavior
    {
        private const long DefaultTransitionTime = 1000 * TimeSpan.TicksPerMillisecond;
        private const long DefaultEndTransitionTime = 750 * TimeSpan.TicksPerMillisecond;

        /// <inheritdoc/>
        public override ConfigurationBehaviorType ConfigurationBehaviorType
        {
            get => ConfigurationBehaviorType.ScaleChange;
        }

        /// <inheritdoc/>
        public override string Description
        {
            get => Resources.ScaleChangeBehaviorDescription;
        }

        /// <summary>
        /// Gets or sets the scale along the x axis that the behaviour should start from.
        /// </summary>
        [ProtoMember(1)]
        public float StartScaleX { get; set; }

        /// <summary>
        /// Gets or sets the scale along the y axis that the behaviour should start from.
        /// </summary>
        [ProtoMember(2)]
        public float StartScaleY { get; set; }

        /// <summary>
        /// Gets or sets the scale along the x axis that the behaviour should finish at.
        /// </summary>
        [ProtoMember(3)]
        [DefaultValue(1f)]
        public float EndScaleX { get; set; } = 1f;

        /// <summary>
        /// Gets or sets the scale along the y axis that the behaviour should finish at.
        /// </summary>
        [ProtoMember(4)]
        [DefaultValue(1f)]
        public float EndScaleY { get; set; } = 1f;

        /// <summary>
        /// Gets or sets the time that the behaviour transition should take.
        /// </summary>
        public TimeSpan TransitionTime { get; set; } = new TimeSpan(DefaultTransitionTime);

        /// <summary>
        /// Gets or sets a value indicating whether or not the ending transition will be enabled for
        /// the image item this behaviour is attached to.
        /// </summary>
        /// <value><see langword="true"/> if the ending transition will be enabled for the image
        /// item this behaviour is attached to; otherwise <see langword="false"/>.</value>
        [ProtoMember(6, IsRequired = false)]
        public bool EndTransitionEnabled { get; set; }

        /// <summary>
        /// Gets or sets the scale value along the x axis that the behaviour will finish at when the
        /// image item it is attached to is being destroyed.
        /// </summary>
        [ProtoMember(7, IsRequired = false)]
        public float EndTransitionScaleX { get; set; }

        /// <summary>
        /// Gets or sets the scale value along the y axis that the behaviour will finish at when the
        /// image item it is attached to is being destroyed.
        /// </summary>
        [ProtoMember(8, IsRequired = false)]
        public float EndTransitionScaleY { get; set; }

        /// <summary>
        /// Gets or sets the time that the behaviour will take to transition when the image item
        /// it is attached to is being destroyed.
        /// </summary>
        public TimeSpan EndTransitionTime { get; set; } = new TimeSpan(DefaultEndTransitionTime);

        [ProtoMember(5)]
        [DefaultValue(DefaultTransitionTime)]
        private long TransitionTimeSerialized
        {
            get => this.TransitionTime.Ticks;
            set => this.TransitionTime = new TimeSpan(value);
        }

        [ProtoMember(9, IsRequired = false)]
        [DefaultValue(DefaultEndTransitionTime)]
        private long EndTransitionTimeSerialized
        {
            get => this.EndTransitionTime.Ticks;
            set => this.EndTransitionTime = new TimeSpan(value);
        }
    }
}