namespace Natsnudasoft.EgamiFlowScreensaver.Config
{
    partial class ColorChangeBehaviorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorChangeBehaviorForm));
            System.Windows.Forms.GroupBox configurationGroupBox;
            System.Windows.Forms.Label transitionTimeLabel;
            System.Windows.Forms.Panel panel1;
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.chooseEndColorButton = new System.Windows.Forms.Button();
            this.chooseStartColorButton = new System.Windows.Forms.Button();
            this.transitionTimeNumericUpDownWheel = new Natsnudasoft.EgamiFlowScreensaver.NumericUpDownWheel();
            this.configurationToolTip = new System.Windows.Forms.ToolTip(this.components);
            panel2 = new System.Windows.Forms.Panel();
            configurationGroupBox = new System.Windows.Forms.GroupBox();
            transitionTimeLabel = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            panel2.SuspendLayout();
            configurationGroupBox.SuspendLayout();
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
            configurationGroupBox.Controls.Add(transitionTimeLabel);
            configurationGroupBox.Controls.Add(this.chooseEndColorButton);
            configurationGroupBox.Controls.Add(this.chooseStartColorButton);
            configurationGroupBox.Controls.Add(this.transitionTimeNumericUpDownWheel);
            configurationGroupBox.Name = "configurationGroupBox";
            configurationGroupBox.TabStop = false;
            // 
            // transitionTimeLabel
            // 
            resources.ApplyResources(transitionTimeLabel, "transitionTimeLabel");
            transitionTimeLabel.Name = "transitionTimeLabel";
            this.configurationToolTip.SetToolTip(transitionTimeLabel, resources.GetString("transitionTimeLabel.ToolTip"));
            // 
            // chooseEndColorButton
            // 
            resources.ApplyResources(this.chooseEndColorButton, "chooseEndColorButton");
            this.chooseEndColorButton.Name = "chooseEndColorButton";
            this.configurationToolTip.SetToolTip(this.chooseEndColorButton, resources.GetString("chooseEndColorButton.ToolTip"));
            this.chooseEndColorButton.UseVisualStyleBackColor = true;
            // 
            // chooseStartColorButton
            // 
            resources.ApplyResources(this.chooseStartColorButton, "chooseStartColorButton");
            this.chooseStartColorButton.Name = "chooseStartColorButton";
            this.configurationToolTip.SetToolTip(this.chooseStartColorButton, resources.GetString("chooseStartColorButton.ToolTip"));
            this.chooseStartColorButton.UseVisualStyleBackColor = true;
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
            // ColorChangeBehaviorForm
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
            this.Name = "ColorChangeBehaviorForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            panel2.ResumeLayout(false);
            configurationGroupBox.ResumeLayout(false);
            configurationGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transitionTimeNumericUpDownWheel)).EndInit();
            panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ToolTip configurationToolTip;
        private System.Windows.Forms.Button cancelButton;
        private NumericUpDownWheel transitionTimeNumericUpDownWheel;
        private System.Windows.Forms.Button chooseEndColorButton;
        private System.Windows.Forms.Button chooseStartColorButton;
    }
}