namespace Natsnudasoft.EgamiFlowScreensaver.Config
{
    partial class ApplyBehaviorsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplyBehaviorsForm));
            System.Windows.Forms.GroupBox behaviorsGroupBox;
            System.Windows.Forms.Panel panel1;
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.behaviorDescriptionLabel = new System.Windows.Forms.Label();
            this.configureSelectedBehaviorButton = new System.Windows.Forms.Button();
            this.availableBehaviorsCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.configurationToolTip = new System.Windows.Forms.ToolTip(this.components);
            panel2 = new System.Windows.Forms.Panel();
            behaviorsGroupBox = new System.Windows.Forms.GroupBox();
            panel1 = new System.Windows.Forms.Panel();
            panel2.SuspendLayout();
            behaviorsGroupBox.SuspendLayout();
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
            // behaviorsGroupBox
            // 
            resources.ApplyResources(behaviorsGroupBox, "behaviorsGroupBox");
            behaviorsGroupBox.Controls.Add(this.behaviorDescriptionLabel);
            behaviorsGroupBox.Controls.Add(this.configureSelectedBehaviorButton);
            behaviorsGroupBox.Controls.Add(this.availableBehaviorsCheckedListBox);
            behaviorsGroupBox.Name = "behaviorsGroupBox";
            behaviorsGroupBox.TabStop = false;
            // 
            // behaviorDescriptionLabel
            // 
            resources.ApplyResources(this.behaviorDescriptionLabel, "behaviorDescriptionLabel");
            this.behaviorDescriptionLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.behaviorDescriptionLabel.Name = "behaviorDescriptionLabel";
            this.configurationToolTip.SetToolTip(this.behaviorDescriptionLabel, resources.GetString("behaviorDescriptionLabel.ToolTip"));
            // 
            // configureSelectedBehaviorButton
            // 
            resources.ApplyResources(this.configureSelectedBehaviorButton, "configureSelectedBehaviorButton");
            this.configureSelectedBehaviorButton.Name = "configureSelectedBehaviorButton";
            this.configurationToolTip.SetToolTip(this.configureSelectedBehaviorButton, resources.GetString("configureSelectedBehaviorButton.ToolTip"));
            this.configureSelectedBehaviorButton.UseVisualStyleBackColor = true;
            // 
            // availableBehaviorsCheckedListBox
            // 
            resources.ApplyResources(this.availableBehaviorsCheckedListBox, "availableBehaviorsCheckedListBox");
            this.availableBehaviorsCheckedListBox.FormattingEnabled = true;
            this.availableBehaviorsCheckedListBox.Name = "availableBehaviorsCheckedListBox";
            this.configurationToolTip.SetToolTip(this.availableBehaviorsCheckedListBox, resources.GetString("availableBehaviorsCheckedListBox.ToolTip"));
            // 
            // panel1
            // 
            panel1.Controls.Add(behaviorsGroupBox);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // ApplyBehaviorsForm
            // 
            this.AcceptButton = this.okButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.Controls.Add(panel1);
            this.Controls.Add(panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ApplyBehaviorsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            panel2.ResumeLayout(false);
            behaviorsGroupBox.ResumeLayout(false);
            panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip configurationToolTip;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckedListBox availableBehaviorsCheckedListBox;
        private System.Windows.Forms.Button configureSelectedBehaviorButton;
        private System.Windows.Forms.Label behaviorDescriptionLabel;
    }
}