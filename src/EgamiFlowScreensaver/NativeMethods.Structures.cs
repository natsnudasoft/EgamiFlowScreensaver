// <copyright file="NativeMethods.Structures.cs" company="natsnudasoft">
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
    using System.Globalization;
    using System.Runtime.InteropServices;
    using SystemPoint = System.Drawing.Point;
    using SystemRectangle = System.Drawing.Rectangle;
    using SystemSize = System.Drawing.Size;

    /// <content>
    /// Defines native structures for native methods imported via <see cref="DllImportAttribute"/>.
    /// </content>
    internal sealed partial class NativeMethods
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;

            public RECT(int left, int top, int right, int bottom)
            {
                this.Left = left;
                this.Top = top;
                this.Right = right;
                this.Bottom = bottom;
            }

            public RECT(SystemRectangle r)
                : this(r.Left, r.Top, r.Right, r.Bottom)
            {
            }

            public int X
            {
                get
                {
                    return this.Left;
                }

                set
                {
                    this.Right -= this.Left - value;
                    this.Left = value;
                }
            }

            public int Y
            {
                get
                {
                    return this.Top;
                }

                set
                {
                    this.Bottom -= this.Top - value;
                    this.Top = value;
                }
            }

            public int Width
            {
                get { return this.Right - this.Left; }
                set { this.Right = value + this.Left; }
            }

            public int Height
            {
                get { return this.Bottom - this.Top; }
                set { this.Bottom = value + this.Top; }
            }

            public SystemPoint Location
            {
                get
                {
                    return new SystemPoint(this.Left, this.Top);
                }

                set
                {
                    this.X = value.X;
                    this.Y = value.Y;
                }
            }

            public SystemSize Size
            {
                get
                {
                    return new SystemSize(this.Width, this.Height);
                }

                set
                {
                    this.Width = value.Width;
                    this.Height = value.Height;
                }
            }

            public static implicit operator SystemRectangle(RECT r)
            {
                return new SystemRectangle(r.Left, r.Top, r.Width, r.Height);
            }

            public static implicit operator RECT(SystemRectangle r)
            {
                return new RECT(r);
            }

            public static bool operator ==(RECT r1, RECT r2)
            {
                return r1.Equals(r2);
            }

            public static bool operator !=(RECT r1, RECT r2)
            {
                return !r1.Equals(r2);
            }

            public bool Equals(RECT r)
            {
                return r.Left == this.Left &&
                    r.Top == this.Top &&
                    r.Right == this.Right &&
                    r.Bottom == this.Bottom;
            }

            public override bool Equals(object obj)
            {
                var result = false;
                if (obj is RECT)
                {
                    result = this.Equals((RECT)obj);
                }
                else if (obj is SystemRectangle)
                {
                    result = this.Equals(new RECT((SystemRectangle)obj));
                }

                return result;
            }

            public override int GetHashCode()
            {
                return ((SystemRectangle)this).GetHashCode();
            }

            public override string ToString()
            {
                return string.Format(
                    CultureInfo.CurrentCulture,
                    "{{Left={0},Top={1},Right={2},Bottom={3}}}",
                    this.Left,
                    this.Top,
                    this.Right,
                    this.Bottom);
            }
        }
    }
}