// <copyright file="ScreensaverSettingsAdapterForm.cs" company="natsnudasoft">
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
    using System.Windows.Forms;
    using Natsnudasoft.NatsnudaLibrary;

    /// <summary>
    /// Provides a class for integrating a form with the screensaver settings window so that a
    /// configuration form can be shown as a dialog of the window.
    /// </summary>
    /// <seealso cref="Form" />
    public sealed class ScreensaverSettingsAdapterForm : Form
    {
        private readonly INativeMethods nativeMethods;
        private readonly ConfigurationForm configForm;
        private readonly IntPtr screensaverSettingsHandle;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScreensaverSettingsAdapterForm"/> class.
        /// </summary>
        /// <param name="nativeMethods">The native methods service.</param>
        /// <param name="configForm">The configuration form to show as a child of the screensaver
        /// settings window.</param>
        /// <param name="screensaverSettingsChildHandle">The screensaver settings child handle.
        /// </param>
        public ScreensaverSettingsAdapterForm(
            INativeMethods nativeMethods,
            ConfigurationForm configForm,
            IntPtr screensaverSettingsChildHandle)
        {
            ParameterValidation.IsNotNull(nativeMethods, nameof(nativeMethods));
            ParameterValidation.IsNotNull(configForm, nameof(configForm));

            this.nativeMethods = nativeMethods;
            this.configForm = configForm;
            this.SuspendLayout();
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.Shown += this.ScreensaverSettingsAdapterFormShown;
            this.screensaverSettingsHandle =
                nativeMethods.GetParent(screensaverSettingsChildHandle);
            var screensaverSettingsBounds =
                nativeMethods.GetClientRect(this.screensaverSettingsHandle);
            screensaverSettingsBounds.Inflate(-2, -2);
            this.WindowState = FormWindowState.Minimized;
            nativeMethods.MoveWindow(
                this.Handle,
                screensaverSettingsBounds.X,
                screensaverSettingsBounds.Y,
                screensaverSettingsBounds.Width,
                screensaverSettingsBounds.Height,
                false);
            nativeMethods.SetParent(this.Handle, this.screensaverSettingsHandle);
            this.ResumeLayout(false);
        }

        private void ScreensaverSettingsAdapterFormShown(object sender, EventArgs e)
        {
            this.Visible = false;
            this.configForm.ShowDialog(this);
            this.DialogResult = DialogResult.Cancel;
            this.Close();
            this.nativeMethods.SetForegroundWindow(this.screensaverSettingsHandle);
        }
    }
}
