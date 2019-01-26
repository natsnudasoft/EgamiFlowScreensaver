// <copyright file="NumericUpDownWheel.cs" company="natsnudasoft">
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
    using System.Windows.Forms;
    using Natsnudasoft.NatsnudaLibrary;

    /// <summary>
    /// Provides a class to fix mouse wheel scrolling on a <see cref="NumericUpDown"/>.
    /// </summary>
    /// <seealso cref="NumericUpDown" />
    public class NumericUpDownWheel : NumericUpDown
    {
        /// <inheritdoc/>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            ParameterValidation.IsNotNull(e, nameof(e));

            var alreadyHandled = false;
            if (e is HandledMouseEventArgs handledMouseEventArgs)
            {
                alreadyHandled = handledMouseEventArgs.Handled;
                handledMouseEventArgs.Handled = true;
            }

            if (!alreadyHandled)
            {
                if (e.Delta < 0)
                {
                    this.DownButton();
                }
                else if (e.Delta > 0)
                {
                    this.UpButton();
                }

                base.OnMouseWheel(e);
            }
        }
    }
}