// <copyright file="NativeMethods.cs" company="natsnudasoft">
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
    using System.Runtime.InteropServices;
    using SystemRectangle = System.Drawing.Rectangle;

    /// <summary>
    /// Implements native methods imported via <see cref="DllImportAttribute"/>.
    /// </summary>
    /// <seealso cref="INativeMethods" />
    internal sealed partial class NativeMethods : INativeMethods
    {
        /// <inheritdoc/>
        public IntPtr SetWindowLongPtr(HandleRef windowHandle, int index, IntPtr newValue)
        {
            if (IntPtr.Size == 8)
            {
                return SetWindowLongPtr64(windowHandle, index, newValue);
            }
            else
            {
                return new IntPtr(SetWindowLong32(windowHandle, index, newValue.ToInt32()));
            }
        }

        /// <inheritdoc/>
        public SystemRectangle GetClientRect(IntPtr windowHandle)
        {
            GetClientRect(windowHandle, out RECT rect);
            return rect;
        }

        /// <inheritdoc/>
        public bool MoveWindow(
            IntPtr windowHandle,
            int x,
            int y,
            int width,
            int height,
            bool repaint)
        {
            return MoveWindowInternal(windowHandle, x, y, width, height, repaint);
        }

        /// <inheritdoc/>
        public IntPtr SetParent(IntPtr childWindowHandle, IntPtr parentWindowHandle)
        {
            return SetParentInternal(childWindowHandle, parentWindowHandle);
        }

        /// <inheritdoc/>
        public IntPtr GetParent(IntPtr childWindowHandle)
        {
            return GetParentInternal(childWindowHandle);
        }

        /// <inheritdoc/>
        public bool SetForegroundWindow(IntPtr windowHandle)
        {
            return SetForegroundWindowInternal(windowHandle);
        }

#pragma warning disable CC0021 // Use nameof
        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        private static extern int SetWindowLong32(HandleRef hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr")]
        private static extern IntPtr SetWindowLongPtr64(
            HandleRef hWnd,
            int nIndex,
            IntPtr dwNewLong);

        [DllImport("user32.dll")]
        private static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll", EntryPoint = "MoveWindow", SetLastError = true)]
        private static extern bool MoveWindowInternal(
            IntPtr hWnd,
            int X,
            int Y,
            int nWidth,
            int nHeight,
            bool bRepaint);

        [DllImport("user32.dll", EntryPoint = "SetParent", SetLastError = true)]
        private static extern IntPtr SetParentInternal(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", EntryPoint = "GetParent")]
        private static extern IntPtr GetParentInternal(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow", SetLastError = true)]
        private static extern bool SetForegroundWindowInternal(IntPtr hWnd);
#pragma warning restore CC0021 // Use nameof
    }
}
