// <copyright file="Program.cs" company="natsnudasoft">
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
    using System.Windows.Forms;
    using Natsnudasoft.EgamiFlowScreensaver.Config;

    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">The arguments passed to the application.</param>
        [STAThread]
        public static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                var command = args[0].ToLower().Trim().Substring(0, 2);
                switch (command)
                {
                    case "/c":
                        ShowConfig(GetHandleArg(args));
                        break;
                    case "/p":
                        ShowPreview(GetHandleArg(args));
                        break;
                    case "/s":
                        ShowScreensaver();
                        break;
                }
            }
            else
            {
#if DEBUG
                if (ShowConfig(IntPtr.Zero) == DialogResult.OK)
                {
                    ShowScreensaver();
                }
#else
                ShowConfig(IntPtr.Zero);
#endif
            }
        }

        private static IntPtr GetHandleArg(string[] args)
        {
            var handleArgString = args[0].Length > 3 ? args[0].Substring(3) : string.Empty;
            if (handleArgString != string.Empty && int.TryParse(handleArgString, out int handle))
            {
                return (IntPtr)handle;
            }
            else
            {
                return (IntPtr)int.Parse(args[1]);
            }
        }

        private static DialogResult ShowConfig(IntPtr screensaverSettingsChildHandle)
        {
            Application.EnableVisualStyles();
            var configurationFileService = new ConfigurationFileService();
            using (var viewModel = new ConfigurationFormViewModel(configurationFileService))
            {
                viewModel.ReadSettingsFromDisk();
                var nativeMethods = new NativeMethods();
                if (screensaverSettingsChildHandle != IntPtr.Zero)
                {
                    using (var configForm = new ConfigurationForm(viewModel, false))
                    using (var screensaverSettingsAdapterForm = new ScreensaverSettingsAdapterForm(
                        nativeMethods,
                        configForm,
                        screensaverSettingsChildHandle))
                    {
                        configForm.StartPosition = FormStartPosition.Manual;
                        configForm.Location = screensaverSettingsAdapterForm.Location;
                        screensaverSettingsAdapterForm.ShowDialog();
                        if (configForm.DialogResult == DialogResult.OK)
                        {
                            viewModel.CommitSettingsToDisk();
                        }

                        return configForm.DialogResult;
                    }
                }
                else
                {
                    using (var configForm = new ConfigurationForm(viewModel, true))
                    {
                        if (configForm.ShowDialog() == DialogResult.OK)
                        {
                            viewModel.CommitSettingsToDisk();
                        }

                        return configForm.DialogResult;
                    }
                }
            }
        }

        private static void ShowPreview(IntPtr previewHandle)
        {
            using (var game = new ScreensaverGame(previewHandle))
            {
                game.Run();
            }
        }

        private static void ShowScreensaver()
        {
            using (var game = new ScreensaverGame())
            {
                game.Run();
            }
        }
    }
}
