// <copyright file="ImageEmitDetails.cs" company="natsnudasoft">
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
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Natsnudasoft.EgamiFlowScreensaver.Config;
    using Natsnudasoft.NatsnudaLibrary;

    /// <summary>
    /// Provides an abstract base class describing the capability of creating image items for a
    /// <see cref="ScreensaverImageEmitter" />.
    /// </summary>
    /// <seealso cref="ScreensaverImageItem"/>
    public abstract class ImageEmitDetails : IImageEmitDetails
    {
        /// <summary>
        /// Represents the possible range of the position in one direction that an image should be
        /// emitted at by a <see cref="ScreensaverImageEmitter" />.
        /// </summary>
        protected const int PositionDistribution = 5;

        /// <summary>
        /// Represents the possible range of the position in both directions that an image should be
        /// emitted at by a <see cref="ScreensaverImageEmitter" />.
        /// </summary>
        protected const int TwoPositionDistribution = PositionDistribution * 2;

        private readonly List<Func<IScreensaverImageItemBehavior>> behaviorFactories;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageEmitDetails" /> class.
        /// </summary>
        /// <param name="screensaverArea">The description of the area of the screensaver.</param>
        /// <param name="screensaverConfiguration">The <see cref="ScreensaverConfiguration"/>
        /// representing the configured state of the screensaver.</param>
        /// <param name="behaviorFactories">A collection of factories that define how to create
        /// behaviours that will be attached to any images emitted by a
        /// <see cref="ScreensaverImageEmitter"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="screensaverArea"/>,
        /// <paramref name="screensaverConfiguration"/>, or <paramref name="behaviorFactories"/>
        /// is <see langword="null"/>.</exception>
        protected ImageEmitDetails(
            ScreensaverArea screensaverArea,
            ScreensaverConfiguration screensaverConfiguration,
            IEnumerable<Func<IScreensaverImageItemBehavior>> behaviorFactories)
            : this(screensaverArea, screensaverConfiguration, behaviorFactories, new Random())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageEmitDetails" /> class.
        /// </summary>
        /// <param name="screensaverArea">The description of the area of the screensaver.</param>
        /// <param name="screensaverConfiguration">The <see cref="ScreensaverConfiguration"/>
        /// representing the configured state of the screensaver.</param>
        /// <param name="behaviorFactories">A collection of factories that define how to create
        /// behaviours that will be attached to any images emitted by a
        /// <see cref="ScreensaverImageEmitter"/>.</param>
        /// <param name="random">A pseudo-random number generator that can be used to generate
        /// randomness in the <see cref="ImageEmitDetails"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="screensaverArea"/>,
        /// <paramref name="screensaverConfiguration"/>, <paramref name="behaviorFactories"/>, or
        /// <paramref name="random"/> is <see langword="null"/>.</exception>
        protected ImageEmitDetails(
            ScreensaverArea screensaverArea,
            ScreensaverConfiguration screensaverConfiguration,
            IEnumerable<Func<IScreensaverImageItemBehavior>> behaviorFactories,
            Random random)
        {
            ParameterValidation.IsNotNull(screensaverArea, nameof(screensaverArea));
            ParameterValidation
                .IsNotNull(screensaverConfiguration, nameof(screensaverConfiguration));
            ParameterValidation.IsNotNull(behaviorFactories, nameof(behaviorFactories));
            ParameterValidation.IsNotNull(random, nameof(random));

            this.ScreensaverArea = screensaverArea;
            this.ScreensaverConfiguration = screensaverConfiguration;
            this.Random = random;
            this.behaviorFactories =
                new List<Func<IScreensaverImageItemBehavior>>(behaviorFactories);
        }

        /// <inheritdoc/>
        public float ImageEmitRate
        {
            get => this.ScreensaverConfiguration.ImageEmitRate;
        }

        /// <inheritdoc/>
        public int MaxImageEmitCount
        {
            get => this.ScreensaverConfiguration.MaxImageEmitCount;
        }

        /// <inheritdoc/>
        public bool IsInfiniteImageEmitMode
        {
            get => this.ScreensaverConfiguration.IsInfiniteImageEmitMode;
        }

        /// <inheritdoc/>
        public TimeSpan ImageEmitLifetime
        {
            get => this.ScreensaverConfiguration.ImageEmitLifetime;
        }

        /// <inheritdoc/>
        public IEnumerable<Func<IScreensaverImageItemBehavior>> BehaviorFactories
        {
            get => this.behaviorFactories;
        }

        /// <summary>
        /// Gets a value describing the area of the screensaver.
        /// </summary>
        protected ScreensaverArea ScreensaverArea { get; }

        /// <summary>
        /// Gets the <see cref="Config.ScreensaverConfiguration"/> representing the configured
        /// state of the screensaver.
        /// </summary>
        protected ScreensaverConfiguration ScreensaverConfiguration { get; }

        /// <summary>
        /// Gets a pseudo-random number generator that can be used to generate randomness in the
        /// <see cref="ImageEmitDetails"/>.
        /// </summary>
        protected Random Random { get; }

        /// <inheritdoc/>
        public abstract ScreensaverImageItem CreateScreensaverImageItem(Texture2D texture);

        /// <inheritdoc/>
        public virtual void InsertDefaultBehaviorFactories()
        {
            this.behaviorFactories.InsertRange(0, this.CreateDefaultImageEmitBehaviorFactories());
        }

        /// <summary>
        /// Creates a default moving behaviour factory that will be applied to this
        /// <see cref="ImageEmitDetails"/>.
        /// </summary>
        /// <returns>The moving behaviour factory that was created.</returns>
        protected virtual Func<IScreensaverImageItemBehavior> CreateDefaultMovingBehaviorFactory()
        {
            IScreensaverImageItemBehavior CreateDefaultMovingBehavior()
            {
                const float minSpeed = MovingScreensaverImageItemBehavior.DefaultMinSpeed;
                const float maxSpeed = MovingScreensaverImageItemBehavior.DefaultMaxSpeed;
                var speed = new Vector2(
                    this.Random.NextFloat(minSpeed, maxSpeed),
                    this.Random.NextFloat(minSpeed, maxSpeed));
                this.RandomlyNegateSpeed(ref speed);
                return new MovingScreensaverImageItemBehavior(this.ScreensaverArea, speed);
            }

            return CreateDefaultMovingBehavior;
        }

        /// <summary>
        /// Randomly negates the X and Y components of a speed <see cref="Vector2" />.
        /// </summary>
        /// <param name="speed">The speed value that will have its' X and Y components randomly
        /// negated.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Design",
            "CA1045:DoNotPassTypesByReference",
            MessageId = "0#",
            Justification = "We allow this here for performance.")]
        protected void RandomlyNegateSpeed(ref Vector2 speed)
        {
            if (this.Random.Next(0, 2) == 0)
            {
                speed.X = -speed.X;
            }

            if (this.Random.Next(0, 2) == 0)
            {
                speed.Y = -speed.Y;
            }
        }

        private Func<IScreensaverImageItemBehavior> CreateDefaultLifetimeBehaviorFactory()
        {
            IScreensaverImageItemBehavior CreateDefaultLifetimeBehavior()
            {
                return new LifetimeScreensaverImageItemBehavior(
                    this.ScreensaverArea,
                    this.ImageEmitLifetime);
            }

            return CreateDefaultLifetimeBehavior;
        }

        private IEnumerable<Func<IScreensaverImageItemBehavior>>
            CreateDefaultImageEmitBehaviorFactories()
        {
            if (this.ScreensaverConfiguration.IsInfiniteImageEmitMode)
            {
                yield return this.CreateDefaultLifetimeBehaviorFactory();
            }

            yield return this.CreateDefaultMovingBehaviorFactory();
        }
    }
}