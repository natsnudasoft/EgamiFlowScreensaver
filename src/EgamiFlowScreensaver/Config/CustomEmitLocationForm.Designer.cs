namespace Natsnudasoft.EgamiFlowScreensaver.Config
{
    partial class CustomEmitLocationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomEmitLocationForm));
            System.Windows.Forms.GroupBox emitLocationGroupBox;
            System.Windows.Forms.Label positionYLabel;
            System.Windows.Forms.Label positionXLabel;
            System.Windows.Forms.Panel panel1;
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.positionXNumericUpDown = new Natsnudasoft.EgamiFlowScreensaver.NumericUpDownWheel();
            this.positionYNumericUpDown = new Natsnudasoft.EgamiFlowScreensaver.NumericUpDownWheel();
            this.configurationToolTip = new System.Windows.Forms.ToolTip(this.components);
            panel2 = new System.Windows.Forms.Panel();
            emitLocationGroupBox = new System.Windows.Forms.GroupBox();
            positionYLabel = new System.Windows.Forms.Label();
            positionXLabel = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            panel2.SuspendLayout();
            emitLocationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.positionXNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionYNumericUpDown)).BeginInit();
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
            // emitLocationGroupBox
            // 
            resources.ApplyResources(emitLocationGroupBox, "emitLocationGroupBox");
            emitLocationGroupBox.Controls.Add(positionYLabel);
            emitLocationGroupBox.Controls.Add(positionXLabel);
            emitLocationGroupBox.Controls.Add(this.positionXNumericUpDown);
            emitLocationGroupBox.Controls.Add(this.positionYNumericUpDown);
            emitLocationGroupBox.Name = "emitLocationGroupBox";
            emitLocationGroupBox.TabStop = false;
            // 
            // positionYLabel
            // 
            resources.ApplyResources(positionYLabel, "positionYLabel");
            positionYLabel.Name = "positionYLabel";
            this.configurationToolTip.SetToolTip(positionYLabel, resources.GetString("positionYLabel.ToolTip"));
            // 
            // positionXLabel
            // 
            resources.ApplyResources(positionXLabel, "positionXLabel");
            positionXLabel.Name = "positionXLabel";
            this.configurationToolTip.SetToolTip(positionXLabel, resources.GetString("positionXLabel.ToolTip"));
            // 
            // positionXNumericUpDown
            // 
            resources.ApplyResources(this.positionXNumericUpDown, "positionXNumericUpDown");
            this.positionXNumericUpDown.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.positionXNumericUpDown.Minimum = new decimal(new int[] {
            32767,
            0,
            0,
            -2147483648});
            this.positionXNumericUpDown.Name = "positionXNumericUpDown";
            // 
            // positionYNumericUpDown
            // 
            resources.ApplyResources(this.positionYNumericUpDown, "positionYNumericUpDown");
            this.positionYNumericUpDown.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.positionYNumericUpDown.Minimum = new decimal(new int[] {
            32767,
            0,
            0,
            -2147483648});
            this.positionYNumericUpDown.Name = "positionYNumericUpDown";
            // 
            // panel1
            // 
            panel1.Controls.Add(emitLocationGroupBox);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // CustomEmitLocationForm
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
            this.Name = "CustomEmitLocationForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            panel2.ResumeLayout(false);
            emitLocationGroupBox.ResumeLayout(false);
            emitLocationGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.positionXNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionYNumericUpDown)).EndInit();
            panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip configurationToolTip;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private NumericUpDownWheel positionYNumericUpDown;
        private NumericUpDownWheel positionXNumericUpDown;
    }
}