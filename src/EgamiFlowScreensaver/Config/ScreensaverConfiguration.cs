// <copyright file="ScreensaverConfiguration.cs" company="natsnudasoft">
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
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using ProtoBuf;

    /// <summary>
    /// Provides a configuration structure for a <see cref="ScreensaverGame"/>.
    /// </summary>
    [ProtoContract]
    public sealed class ScreensaverConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScreensaverConfiguration"/> class.
        /// </summary>
        public ScreensaverConfiguration()
        {
            this.Images = new List<ConfigurationImageItem>();
        }

        /// <summary>
        /// Gets the collection of the description of the images that will be used in a
        /// <see cref="ScreensaverGame"/>.
        /// </summary>
        [ProtoMember(1)]
        public IList<ConfigurationImageItem> Images { get; }

        /// <summary>
        /// Gets or sets the background mode that will be used in a <see cref="ScreensaverGame"/>.
        /// </summary>
        [ProtoMember(2)]
        [DefaultValue(BackgroundMode.Desktop)]
        public BackgroundMode BackgroundMode { get; set; }

        /// <summary>
        /// Gets or sets the background image scale mode describing how to scale the background
        /// image in a <see cref="ScreensaverGame"/>.
        /// </summary>
        [ProtoMember(7, IsRequired = false)]
        [DefaultValue(ImageScaleMode.Center)]
        public ImageScaleMode BackgroundImageScaleMode { get; set; }

        /// <summary>
        /// Gets or sets the background colour that will be used in a <see cref="ScreensaverGame"/>
        /// if it is in <see cref="BackgroundMode.SolidColor"/> mode.
        /// </summary>
        public Color BackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the background image that will be used in a <see cref="ScreensaverGame"/>
        /// if it is in <see cref="BackgroundMode.Image"/> mode.
        /// </summary>
        [ProtoMember(4)]
        public ConfigurationImageItem BackgroundImage { get; set; }

        /// <summary>
        /// Gets or sets the rate that images will be emitted in a <see cref="ScreensaverGame"/>.
        /// </summary>
        [ProtoMember(5)]
        [DefaultValue(30f)]
        public float ImageEmitRate { get; set; } = 30f;

        /// <summary>
        /// Gets or sets the maximum number of images that will be emitted in a
        /// <see cref="ScreensaverGame"/>.
        /// </summary>
        [ProtoMember(6)]
        [DefaultValue(400)]
        public int MaxImageEmitCount { get; set; } = 400;

        /// <summary>
        /// Gets or sets the location that images will be emitted in a
        /// <see cref="ScreensaverGame"/>.
        /// </summary>
        [ProtoMember(8, IsRequired = false)]
        [DefaultValue(ImageEmitLocation.RandomCorner)]
        public ImageEmitLocation ImageEmitLocation { get; set; }

        /// <summary>
        /// Gets or sets the X coordinate of the emit location if it is in
        /// <see cref="ImageEmitLocation.Custom"/> mode.
        /// </summary>
        [ProtoMember(9, IsRequired = false)]
        public int CustomImageEmitLocationX { get; set; }

        /// <summary>
        /// Gets or sets the Y coordinate of the emit location if it is in
        /// <see cref="ImageEmitLocation.Custom"/> mode.
        /// </summary>
        [ProtoMember(10, IsRequired = false)]
        public int CustomImageEmitLocationY { get; set; }

        [ProtoMember(3, DataFormat = DataFormat.FixedSize)]
        private int BackgroundColorSerialized
        {
            get { return this.BackgroundColor.ToArgb(); }
            set { this.BackgroundColor = Color.FromArgb(value); }
        }
    }
}