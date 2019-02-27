namespace Natsnudasoft.EgamiFlowScreensaver.Config
{
    partial class AlphaChangeBehaviorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Reliability",
            "CA2000:Dispose objects before losing scope",
            Justification = "This is auto generated code.")]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Panel panel2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlphaChangeBehaviorForm));
            System.Windows.Forms.GroupBox configurationGroupBox;
            System.Windows.Forms.Label startAlphaLabel;
            System.Windows.Forms.Label endAlphaLabel;
            System.Windows.Forms.Label transitionTimeLabel;
            System.Windows.Forms.Panel panel1;
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.endTransitionAlphaLabel = new System.Windows.Forms.Label();
            this.endTransitionAlphaNumericUpDownWheel = new Natsnudasoft.EgamiFlowScreensaver.NumericUpDownWheel();
            this.endTransitionTimeLabel = new System.Windows.Forms.Label();
            this.endTransitionTimeNumericUpDownWheel = new Natsnudasoft.EgamiFlowScreensaver.NumericUpDownWheel();
            this.horizontalSplitterLabel = new System.Windows.Forms.Label();
            this.endTransitionEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.startAlphaNumericUpDownWheel = new Natsnudasoft.EgamiFlowScreensaver.NumericUpDownWheel();
            this.endAlphaNumericUpDownWheel = new Natsnudasoft.EgamiFlowScreensaver.NumericUpDownWheel();
            this.transitionTimeNumericUpDownWheel = new Natsnudasoft.EgamiFlowScreensaver.NumericUpDownWheel();
            this.configurationToolTip = new System.Windows.Forms.ToolTip(this.components);
            panel2 = new System.Windows.Forms.Panel();
            configurationGroupBox = new System.Windows.Forms.GroupBox();
            startAlphaLabel = new System.Windows.Forms.Label();
            endAlphaLabel = new System.Windows.Forms.Label();
            transitionTimeLabel = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            panel2.SuspendLayout();
            configurationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.endTransitionAlphaNumericUpDownWheel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endTransitionTimeNumericUpDownWheel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startAlphaNumericUpDownWheel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endAlphaNumericUpDownWheel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transitionTimeNumericUpDownWheel)).BeginInit();
            panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(this.okButton);
            panel2.Controls.Add(this.cancelButton);
            resources.ApplyResources(panel2, "panel2");
            panel2.Name = "panel2";
            // 
            // okButton
            // 
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.Name = "okButton";
            this.configurationToolTip.SetToolTip(this.okButton, resources.GetString("okButton.ToolTip"));
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Name = "cancelButton";
            this.configurationToolTip.SetToolTip(this.cancelButton, resources.GetString("cancelButton.ToolTip"));
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // configurationGroupBox
            // 
            resources.ApplyResources(configurationGroupBox, "configurationGroupBox");
            configurationGroupBox.Controls.Add(this.endTransitionAlphaLabel);
            configurationGroupBox.Controls.Add(this.endTransitionAlphaNumericUpDownWheel);
            configurationGroupBox.Controls.Add(this.endTransitionTimeLabel);
            configurationGroupBox.Controls.Add(this.endTransitionTimeNumericUpDownWheel);
            configurationGroupBox.Controls.Add(this.horizontalSplitterLabel);
            configurationGroupBox.Controls.Add(this.endTransitionEnabledCheckBox);
            configurationGroupBox.Controls.Add(startAlphaLabel);
            configurationGroupBox.Controls.Add(this.startAlphaNumericUpDownWheel);
            configurationGroupBox.Controls.Add(endAlphaLabel);
            configurationGroupBox.Controls.Add(this.endAlphaNumericUpDownWheel);
            configurationGroupBox.Controls.Add(transitionTimeLabel);
            configurationGroupBox.Controls.Add(this.transitionTimeNumericUpDownWheel);
            configurationGroupBox.Name = "configurationGroupBox";
            configurationGroupBox.TabStop = false;
            // 
            // endTransitionAlphaLabel
            // 
            resources.ApplyResources(this.endTransitionAlphaLabel, "endTransitionAlphaLabel");
            this.endTransitionAlphaLabel.Name = "endTransitionAlphaLabel";
            this.configurationToolTip.SetToolTip(this.endTransitionAlphaLabel, resources.GetString("endTransitionAlphaLabel.ToolTip"));
            // 
            // endTransitionAlphaNumericUpDownWheel
            // 
            resources.ApplyResources(this.endTransitionAlphaNumericUpDownWheel, "endTransitionAlphaNumericUpDownWheel");
            this.endTransitionAlphaNumericUpDownWheel.DecimalPlaces = 5;
            this.endTransitionAlphaNumericUpDownWheel.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.endTransitionAlphaNumericUpDownWheel.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.endTransitionAlphaNumericUpDownWheel.Name = "endTransitionAlphaNumericUpDownWheel";
            // 
            // endTransitionTimeLabel
            // 
            resources.ApplyResources(this.endTransitionTimeLabel, "endTransitionTimeLabel");
            this.endTransitionTimeLabel.Name = "endTransitionTimeLabel";
            this.configurationToolTip.SetToolTip(this.endTransitionTimeLabel, resources.GetString("endTransitionTimeLabel.ToolTip"));
            // 
            // endTransitionTimeNumericUpDownWheel
            // 
            resources.ApplyResources(this.endTransitionTimeNumericUpDownWheel, "endTransitionTimeNumericUpDownWheel");
            this.endTransitionTimeNumericUpDownWheel.DecimalPlaces = 2;
            this.endTransitionTimeNumericUpDownWheel.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.endTransitionTimeNumericUpDownWheel.Maximum = new decimal(new int[] {
            604800000,
            0,
            0,
            0});
            this.endTransitionTimeNumericUpDownWheel.Name = "endTransitionTimeNumericUpDownWheel";
            // 
            // horizontalSplitterLabel
            // 
            resources.ApplyResources(this.horizontalSplitterLabel, "horizontalSplitterLabel");
            this.horizontalSplitterLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.horizontalSplitterLabel.Name = "horizontalSplitterLabel";
            // 
            // endTransitionEnabledCheckBox
            // 
            resources.ApplyResources(this.endTransitionEnabledCheckBox, "endTransitionEnabledCheckBox");
            this.endTransitionEnabledCheckBox.Name = "endTransitionEnabledCheckBox";
            this.configurationToolTip.SetToolTip(this.endTransitionEnabledCheckBox, resources.GetString("endTransitionEnabledCheckBox.ToolTip"));
            this.endTransitionEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // startAlphaLabel
            // 
            resources.ApplyResources(startAlphaLabel, "startAlphaLabel");
            startAlphaLabel.Name = "startAlphaLabel";
            this.configurationToolTip.SetToolTip(startAlphaLabel, resources.GetString("startAlphaLabel.ToolTip"));
            // 
            // startAlphaNumericUpDownWheel
            // 
            resources.ApplyResources(this.startAlphaNumericUpDownWheel, "startAlphaNumericUpDownWheel");
            this.startAlphaNumericUpDownWheel.DecimalPlaces = 5;
            this.startAlphaNumericUpDownWheel.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.startAlphaNumericUpDownWheel.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.startAlphaNumericUpDownWheel.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.startAlphaNumericUpDownWheel.Name = "startAlphaNumericUpDownWheel";
            // 
            // endAlphaLabel
            // 
            resources.ApplyResources(endAlphaLabel, "endAlphaLabel");
            endAlphaLabel.Name = "endAlphaLabel";
            this.configurationToolTip.SetToolTip(endAlphaLabel, resources.GetString("endAlphaLabel.ToolTip"));
            // 
            // endAlphaNumericUpDownWheel
            // 
            resources.ApplyResources(this.endAlphaNumericUpDownWheel, "endAlphaNumericUpDownWheel");
            this.endAlphaNumericUpDownWheel.DecimalPlaces = 5;
            this.endAlphaNumericUpDownWheel.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.endAlphaNumericUpDownWheel.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.endAlphaNumericUpDownWheel.Name = "endAlphaNumericUpDownWheel";
            this.endAlphaNumericUpDownWheel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // transitionTimeLabel
            // 
            resources.ApplyResources(transitionTimeLabel, "transitionTimeLabel");
            transitionTimeLabel.Name = "transitionTimeLabel";
            this.configurationToolTip.SetToolTip(transitionTimeLabel, resources.GetString("transitionTimeLabel.ToolTip"));
            // 
            // transitionTimeNumericUpDownWheel
            // 
            resources.ApplyResources(this.transitionTimeNumericUpDownWheel, "transitionTimeNumericUpDownWheel");
            this.transitionTimeNumericUpDownWheel.DecimalPlaces = 2;
            this.transitionTimeNumericUpDownWheel.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.transitionTimeNumericUpDownWheel.Maximum = new decimal(new int[] {
            604800000,
            0,
            0,
            0});
            this.transitionTimeNumericUpDownWheel.Name = "transitionTimeNumericUpDownWheel";
            // 
            // panel1
            // 
            panel1.Controls.Add(configurationGroupBox);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // AlphaChangeBehaviorForm
            // 
            this.AcceptButton = this.okButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.Controls.Add(panel1);
            this.Controls.Add(panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AlphaChangeBehaviorForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            panel2.ResumeLayout(false);
            configurationGroupBox.ResumeLayout(false);
            configurationGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.endTransitionAlphaNumericUpDownWheel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endTransitionTimeNumericUpDownWheel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startAlphaNumericUpDownWheel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endAlphaNumericUpDownWheel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transitionTimeNumericUpDownWheel)).EndInit();
            panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ToolTip configurationToolTip;
        private System.Windows.Forms.Button cancelButton;
        private NumericUpDownWheel transitionTimeNumericUpDownWheel;
        private NumericUpDownWheel startAlphaNumericUpDownWheel;
        private NumericUpDownWheel endAlphaNumericUpDownWheel;
        private System.Windows.Forms.Label endTransitionTimeLabel;
        private NumericUpDownWheel endTransitionTimeNumericUpDownWheel;
        private System.Windows.Forms.Label horizontalSplitterLabel;
        private System.Windows.Forms.CheckBox endTransitionEnabledCheckBox;
        private NumericUpDownWheel endTransitionAlphaNumericUpDownWheel;
        private System.Windows.Forms.Label endTransitionAlphaLabel;
    }
}