namespace Natsnudasoft.EgamiFlowScreensaver.Config
{
    partial class RotationChangeBehaviorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RotationChangeBehaviorForm));
            System.Windows.Forms.GroupBox configurationGroupBox;
            System.Windows.Forms.Label transitionTimeLabel;
            System.Windows.Forms.Label endRotationLabel;
            System.Windows.Forms.Label startRotationLabel;
            System.Windows.Forms.Panel panel1;
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.transitionTimeNumericUpDownWheel = new Natsnudasoft.EgamiFlowScreensaver.NumericUpDownWheel();
            this.randomlyInvertRotationCheckBox = new System.Windows.Forms.CheckBox();
            this.endRotationNumericUpDownWheel = new Natsnudasoft.EgamiFlowScreensaver.NumericUpDownWheel();
            this.startRotationNumericUpDownWheel = new Natsnudasoft.EgamiFlowScreensaver.NumericUpDownWheel();
            this.configurationToolTip = new System.Windows.Forms.ToolTip(this.components);
            panel2 = new System.Windows.Forms.Panel();
            configurationGroupBox = new System.Windows.Forms.GroupBox();
            transitionTimeLabel = new System.Windows.Forms.Label();
            endRotationLabel = new System.Windows.Forms.Label();
            startRotationLabel = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            panel2.SuspendLayout();
            configurationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transitionTimeNumericUpDownWheel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endRotationNumericUpDownWheel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startRotationNumericUpDownWheel)).BeginInit();
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
            configurationGroupBox.Controls.Add(transitionTimeLabel);
            configurationGroupBox.Controls.Add(this.transitionTimeNumericUpDownWheel);
            configurationGroupBox.Controls.Add(this.randomlyInvertRotationCheckBox);
            configurationGroupBox.Controls.Add(endRotationLabel);
            configurationGroupBox.Controls.Add(this.endRotationNumericUpDownWheel);
            configurationGroupBox.Controls.Add(startRotationLabel);
            configurationGroupBox.Controls.Add(this.startRotationNumericUpDownWheel);
            configurationGroupBox.Name = "configurationGroupBox";
            configurationGroupBox.TabStop = false;
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
            // randomlyInvertRotationCheckBox
            // 
            resources.ApplyResources(this.randomlyInvertRotationCheckBox, "randomlyInvertRotationCheckBox");
            this.randomlyInvertRotationCheckBox.Name = "randomlyInvertRotationCheckBox";
            this.configurationToolTip.SetToolTip(this.randomlyInvertRotationCheckBox, resources.GetString("randomlyInvertRotationCheckBox.ToolTip"));
            this.randomlyInvertRotationCheckBox.UseVisualStyleBackColor = true;
            // 
            // endRotationLabel
            // 
            resources.ApplyResources(endRotationLabel, "endRotationLabel");
            endRotationLabel.Name = "endRotationLabel";
            this.configurationToolTip.SetToolTip(endRotationLabel, resources.GetString("endRotationLabel.ToolTip"));
            // 
            // endRotationNumericUpDownWheel
            // 
            resources.ApplyResources(this.endRotationNumericUpDownWheel, "endRotationNumericUpDownWheel");
            this.endRotationNumericUpDownWheel.DecimalPlaces = 2;
            this.endRotationNumericUpDownWheel.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.endRotationNumericUpDownWheel.Maximum = new decimal(new int[] {
            360000,
            0,
            0,
            0});
            this.endRotationNumericUpDownWheel.Minimum = new decimal(new int[] {
            360000,
            0,
            0,
            -2147483648});
            this.endRotationNumericUpDownWheel.Name = "endRotationNumericUpDownWheel";
            // 
            // startRotationLabel
            // 
            resources.ApplyResources(startRotationLabel, "startRotationLabel");
            startRotationLabel.Name = "startRotationLabel";
            this.configurationToolTip.SetToolTip(startRotationLabel, resources.GetString("startRotationLabel.ToolTip"));
            // 
            // startRotationNumericUpDownWheel
            // 
            resources.ApplyResources(this.startRotationNumericUpDownWheel, "startRotationNumericUpDownWheel");
            this.startRotationNumericUpDownWheel.DecimalPlaces = 2;
            this.startRotationNumericUpDownWheel.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.startRotationNumericUpDownWheel.Maximum = new decimal(new int[] {
            360000,
            0,
            0,
            0});
            this.startRotationNumericUpDownWheel.Minimum = new decimal(new int[] {
            360000,
            0,
            0,
            -2147483648});
            this.startRotationNumericUpDownWheel.Name = "startRotationNumericUpDownWheel";
            // 
            // panel1
            // 
            panel1.Controls.Add(configurationGroupBox);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // RotationChangeBehaviorForm
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
            this.Name = "RotationChangeBehaviorForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            panel2.ResumeLayout(false);
            configurationGroupBox.ResumeLayout(false);
            configurationGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transitionTimeNumericUpDownWheel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endRotationNumericUpDownWheel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startRotationNumericUpDownWheel)).EndInit();
            panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ToolTip configurationToolTip;
        private System.Windows.Forms.Button cancelButton;
        private NumericUpDownWheel startRotationNumericUpDownWheel;
        private NumericUpDownWheel endRotationNumericUpDownWheel;
        private System.Windows.Forms.CheckBox randomlyInvertRotationCheckBox;
        private NumericUpDownWheel transitionTimeNumericUpDownWheel;
    }
}