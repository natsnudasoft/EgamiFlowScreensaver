// <copyright file="INativeMethods.cs" company="natsnudasoft">
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
    /// Interface for communicating with native methods imported via
    /// <see cref="DllImportAttribute"/>.
    /// </summary>
    public interface INativeMethods
    {
        /// <summary>
        /// Changes an attribute of the specified window. The function also sets a value at the
        /// specified offset in the extra window memory.
        /// </summary>
        /// <param name="windowHandle">A handle to the window.</param>
        /// <param name="index">The zero-based offset to the value to be set. Valid values are in
        /// the range zero through the number of bytes of extra window memory, minus the size of a
        /// LONG_PTR. To set any other value, specify one of the values from
        /// <see cref="WindowLongFlags"/>.</param>
        /// <param name="newValue">The replacement value.</param>
        /// <returns>The previous value of the specified offset if the function succeeds; otherwise
        /// <see cref="IntPtr.Zero"/>.</returns>
        IntPtr SetWindowLongPtr(HandleRef windowHandle, int index, IntPtr newValue);

        /// <summary>
        /// Gets the client area of the window identified by the specified handle.
        /// </summary>
        /// <param name="windowHandle">A handle to the window.</param>
        /// <returns>A <see cref="SystemRectangle"/> defining the client area retrieved.</returns>
        SystemRectangle GetClientRect(IntPtr windowHandle);

        /// <summary>
        /// Changes the position and dimensions of the window identified by the specified handle.
        /// </summary>
        /// <param name="windowHandle">A handle to the window.</param>
        /// <param name="x">The new position of the x coordinate of the window.</param>
        /// <param name="y">The new position of the y coordinate of the window.</param>
        /// <param name="width">The new width of the window.</param>
        /// <param name="height">The new height of the window.</param>
        /// <param name="repaint"><see langword="true"/> if the window is to be repainted;
        /// otherwise, <see langword="false"/>.</param>
        /// <returns><see langword="true"/> if the function succeeds; otherwise,
        /// <see langword="false"/>.</returns>
        bool MoveWindow(IntPtr windowHandle, int x, int y, int width, int height, bool repaint);

        /// <summary>
        /// Changes the parent window of the child window identified by the specified handle.
        /// </summary>
        /// <param name="childWindowHandle">A handle to the child window.</param>
        /// <param name="parentWindowHandle">A handle to the new parent window. If this parameter is
        /// <see langword="null"/>, the desktop window becomes the new parent window. If this
        /// parameter is <see cref="NativeConstants.HWND_MESSAGE"/>, the child window becomes a
        /// message-only window.</param>
        /// <returns>A handle to the previous parent window if the function succeeds; otherwise,
        /// <see langword="null"/>.</returns>
        IntPtr SetParent(IntPtr childWindowHandle, IntPtr parentWindowHandle);

        /// <summary>
        /// Gets the parent window of the child window identified by the specified handle..
        /// </summary>
        /// <param name="childWindowHandle">A handle to the child window.</param>
        /// <returns>A handle to the parent window.</returns>
        IntPtr GetParent(IntPtr childWindowHandle);

        /// <summary>
        /// Brings the thread that created the specified window into the foreground and activates
        /// the window.
        /// </summary>
        /// <param name="windowHandle">A handle to the window.</param>
        /// <returns><see langword="true"/> if the window was brought to the front; otherwise,
        /// <see langword="false"/>.</returns>
        bool SetForegroundWindow(IntPtr windowHandle);
    }
}