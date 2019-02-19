namespace Natsnudasoft.EgamiFlowScreensaver.Config
{
    partial class ScaleChangeBehaviorForm
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
            System.Windows.Forms.GroupBox configurationGroupBox;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScaleChangeBehaviorForm));
            System.Windows.Forms.Label endScaleLabel;
            System.Windows.Forms.Label startScaleLabel;
            System.Windows.Forms.Label transitionTimeLabel;
            System.Windows.Forms.Panel panel2;
            System.Windows.Forms.Panel panel1;
            this.endScaleYNumericUpDownWheel = new Natsnudasoft.EgamiFlowScreensaver.NumericUpDownWheel();
            this.endScaleXNumericUpDownWheel = new Natsnudasoft.EgamiFlowScreensaver.NumericUpDownWheel();
            this.yCoordinateLabel = new System.Windows.Forms.Label();
            this.xCoordinateLabel = new System.Windows.Forms.Label();
            this.startScaleYNumericUpDownWheel = new Natsnudasoft.EgamiFlowScreensaver.NumericUpDownWheel();
            this.startScaleXNumericUpDownWheel = new Natsnudasoft.EgamiFlowScreensaver.NumericUpDownWheel();
            this.transitionTimeNumericUpDownWheel = new Natsnudasoft.EgamiFlowScreensaver.NumericUpDownWheel();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.configurationToolTip = new System.Windows.Forms.ToolTip(this.components);
            configurationGroupBox = new System.Windows.Forms.GroupBox();
            endScaleLabel = new System.Windows.Forms.Label();
            startScaleLabel = new System.Windows.Forms.Label();
            transitionTimeLabel = new System.Windows.Forms.Label();
            panel2 = new System.Windows.Forms.Panel();
            panel1 = new System.Windows.Forms.Panel();
            configurationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.endScaleYNumericUpDownWheel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endScaleXNumericUpDownWheel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startScaleYNumericUpDownWheel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startScaleXNumericUpDownWheel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transitionTimeNumericUpDownWheel)).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // configurationGroupBox
            // 
            resources.ApplyResources(configurationGroupBox, "configurationGroupBox");
            configurationGroupBox.Controls.Add(this.endScaleYNumericUpDownWheel);
            configurationGroupBox.Controls.Add(endScaleLabel);
            configurationGroupBox.Controls.Add(this.endScaleXNumericUpDownWheel);
            configurationGroupBox.Controls.Add(this.yCoordinateLabel);
            configurationGroupBox.Controls.Add(this.xCoordinateLabel);
            configurationGroupBox.Controls.Add(this.startScaleYNumericUpDownWheel);
            configurationGroupBox.Controls.Add(startScaleLabel);
            configurationGroupBox.Controls.Add(this.startScaleXNumericUpDownWheel);
            configurationGroupBox.Controls.Add(transitionTimeLabel);
            configurationGroupBox.Controls.Add(this.transitionTimeNumericUpDownWheel);
            configurationGroupBox.Name = "configurationGroupBox";
            configurationGroupBox.TabStop = false;
            // 
            // endScaleYNumericUpDownWheel
            // 
            this.endScaleYNumericUpDownWheel.DecimalPlaces = 5;
            this.endScaleYNumericUpDownWheel.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            resources.ApplyResources(this.endScaleYNumericUpDownWheel, "endScaleYNumericUpDownWheel");
            this.endScaleYNumericUpDownWheel.Name = "endScaleYNumericUpDownWheel";
            // 
            // endScaleLabel
            // 
            resources.ApplyResources(endScaleLabel, "endScaleLabel");
            endScaleLabel.Name = "endScaleLabel";
            this.configurationToolTip.SetToolTip(endScaleLabel, resources.GetString("endScaleLabel.ToolTip"));
            // 
            // endScaleXNumericUpDownWheel
            // 
            this.endScaleXNumericUpDownWheel.DecimalPlaces = 5;
            this.endScaleXNumericUpDownWheel.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            resources.ApplyResources(this.endScaleXNumericUpDownWheel, "endScaleXNumericUpDownWheel");
            this.endScaleXNumericUpDownWheel.Name = "endScaleXNumericUpDownWheel";
            // 
            // yCoordinateLabel
            // 
            resources.ApplyResources(this.yCoordinateLabel, "yCoordinateLabel");
            this.yCoordinateLabel.Name = "yCoordinateLabel";
            // 
            // xCoordinateLabel
            // 
            resources.ApplyResources(this.xCoordinateLabel, "xCoordinateLabel");
            this.xCoordinateLabel.Name = "xCoordinateLabel";
            // 
            // startScaleYNumericUpDownWheel
            // 
            this.startScaleYNumericUpDownWheel.DecimalPlaces = 5;
            this.startScaleYNumericUpDownWheel.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            resources.ApplyResources(this.startScaleYNumericUpDownWheel, "startScaleYNumericUpDownWheel");
            this.startScaleYNumericUpDownWheel.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.startScaleYNumericUpDownWheel.Name = "startScaleYNumericUpDownWheel";
            // 
            // startScaleLabel
            // 
            resources.ApplyResources(startScaleLabel, "startScaleLabel");
            startScaleLabel.Name = "startScaleLabel";
            this.configurationToolTip.SetToolTip(startScaleLabel, resources.GetString("startScaleLabel.ToolTip"));
            // 
            // startScaleXNumericUpDownWheel
            // 
            this.startScaleXNumericUpDownWheel.DecimalPlaces = 5;
            this.startScaleXNumericUpDownWheel.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            resources.ApplyResources(this.startScaleXNumericUpDownWheel, "startScaleXNumericUpDownWheel");
            this.startScaleXNumericUpDownWheel.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.startScaleXNumericUpDownWheel.Name = "startScaleXNumericUpDownWheel";
            // 
            // transitionTimeLabel
            // 
            resources.ApplyResources(transitionTimeLabel, "transitionTimeLabel");
            transitionTimeLabel.Name = "transitionTimeLabel";
            this.configurationToolTip.SetToolTip(transitionTimeLabel, resources.GetString("transitionTimeLabel.ToolTip"));
            // 
            // transitionTimeNumericUpDownWheel
            // 
            this.transitionTimeNumericUpDownWheel.DecimalPlaces = 2;
            this.transitionTimeNumericUpDownWheel.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            resources.ApplyResources(this.transitionTimeNumericUpDownWheel, "transitionTimeNumericUpDownWheel");
            this.transitionTimeNumericUpDownWheel.Maximum = new decimal(new int[] {
            604800000,
            0,
            0,
            0});
            this.transitionTimeNumericUpDownWheel.Name = "transitionTimeNumericUpDownWheel";
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
            // panel1
            // 
            panel1.Controls.Add(configurationGroupBox);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // ScaleChangeBehaviorForm
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
            this.Name = "ScaleChangeBehaviorForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            configurationGroupBox.ResumeLayout(false);
            configurationGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.endScaleYNumericUpDownWheel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endScaleXNumericUpDownWheel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startScaleYNumericUpDownWheel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startScaleXNumericUpDownWheel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transitionTimeNumericUpDownWheel)).EndInit();
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ToolTip configurationToolTip;
        private System.Windows.Forms.Button cancelButton;
        private NumericUpDownWheel startScaleXNumericUpDownWheel;
        private NumericUpDownWheel transitionTimeNumericUpDownWheel;
        private NumericUpDownWheel endScaleYNumericUpDownWheel;
        private NumericUpDownWheel endScaleXNumericUpDownWheel;
        private System.Windows.Forms.Label yCoordinateLabel;
        private System.Windows.Forms.Label xCoordinateLabel;
        private NumericUpDownWheel startScaleYNumericUpDownWheel;
    }
}