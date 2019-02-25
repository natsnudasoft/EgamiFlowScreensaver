// <copyright file="ColorChangeConfigurationBehavior.cs" company="natsnudasoft">
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
    using System.Drawing;
    using Natsnudasoft.EgamiFlowScreensaver.Properties;
    using ProtoBuf;

    /// <summary>
    /// Provides a class for managing the current state of configuration for a colour change
    /// behaviour.
    /// </summary>
    /// <seealso cref="ConfigurationBehavior" />
    [ProtoContract]
    public sealed class ColorChangeConfigurationBehavior : ConfigurationBehavior
    {
        private const long DefaultTransitionTime = 5000 * TimeSpan.TicksPerMillisecond;
        private const long DefaultEndTransitionTime = 1000 * TimeSpan.TicksPerMillisecond;

        /// <inheritdoc/>
        public override ConfigurationBehaviorType ConfigurationBehaviorType
        {
            get => ConfigurationBehaviorType.ColorChange;
        }

        /// <inheritdoc/>
        public override string Description
        {
            get => Resources.ColorChangeBehaviorDescription;
        }

        /// <summary>
        /// Gets or sets the colour that the behaviour should start from.
        /// </summary>
        public Color StartColor { get; set; } = Color.White;

        /// <summary>
        /// Gets or sets the colour that the behaviour should finish at.
        /// </summary>
        public Color EndColor { get; set; } = Color.White;

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
        [ProtoMember(4, IsRequired = false)]
        public bool EndTransitionEnabled { get; set; }

        /// <summary>
        /// Gets or sets the colour that the behaviour will finish at when the image item it is
        /// attached to is being destroyed.
        /// </summary>
        public Color EndTransitionColor { get; set; } = Color.White;

        /// <summary>
        /// Gets or sets the time that the behaviour will take to transition when the image item
        /// it is attached to is being destroyed.
        /// </summary>
        public TimeSpan EndTransitionTime { get; set; } = new TimeSpan(DefaultEndTransitionTime);

        [ProtoMember(1, DataFormat = DataFormat.FixedSize)]
        private int StartColorSerialized
        {
            get => this.StartColor.ToArgb();
            set => this.StartColor = Color.FromArgb(value);
        }

        [ProtoMember(2, DataFormat = DataFormat.FixedSize)]
        private int EndColorSerialized
        {
            get => this.EndColor.ToArgb();
            set => this.EndColor = Color.FromArgb(value);
        }

        [ProtoMember(3)]
        [DefaultValue(DefaultTransitionTime)]
        private long TransitionTimeSerialized
        {
            get => this.TransitionTime.Ticks;
            set => this.TransitionTime = new TimeSpan(value);
        }

        [ProtoMember(5, DataFormat = DataFormat.FixedSize, IsRequired = false)]
        private int EndTransitionColorSerialized
        {
            get => this.EndTransitionColor.ToArgb();
            set => this.EndTransitionColor = Color.FromArgb(value);
        }

        [ProtoMember(6, IsRequired = false)]
        [DefaultValue(DefaultEndTransitionTime)]
        private long EndTransitionTimeSerialized
        {
            get => this.EndTransitionTime.Ticks;
            set => this.EndTransitionTime = new TimeSpan(value);
        }
    }
}