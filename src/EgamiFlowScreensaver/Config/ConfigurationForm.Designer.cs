namespace Natsnudasoft.EgamiFlowScreensaver.Config
{
    partial class ConfigurationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.Windows.Forms.Panel panel1;
            System.Windows.Forms.GroupBox imagesGroupBox;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationForm));
            System.Windows.Forms.Label imageEmitLocationLabel;
            System.Windows.Forms.Label maxImageEmitCountLabel;
            System.Windows.Forms.Label imageEmitRateLabel;
            System.Windows.Forms.Label imagePositionLabel;
            System.Windows.Forms.Panel panel2;
            this.chooseCustomEmitLocationButton = new System.Windows.Forms.Button();
            this.imageEmitLocationComboBox = new System.Windows.Forms.ComboBox();
            this.maxImageEmitCountNumericUpDown = new Natsnudasoft.EgamiFlowScreensaver.NumericUpDownWheel();
            this.imageEmitRateNumericUpDown = new Natsnudasoft.EgamiFlowScreensaver.NumericUpDownWheel();
            this.imagePreviewPictureBox = new System.Windows.Forms.PictureBox();
            this.removeImageButton = new System.Windows.Forms.Button();
            this.addImageButton = new System.Windows.Forms.Button();
            this.imagesListBox = new System.Windows.Forms.ListBox();
            this.backgroundRadioGroupBox = new Natsnudasoft.EgamiFlowScreensaver.RadioGroupBox();
            this.backgroundImageScaleModeComboBox = new System.Windows.Forms.ComboBox();
            this.chooseImageButton = new System.Windows.Forms.Button();
            this.solidColorRadioButton = new System.Windows.Forms.RadioButton();
            this.chooseColorButton = new System.Windows.Forms.Button();
            this.desktopRadioButton = new System.Windows.Forms.RadioButton();
            this.imageRadioButton = new System.Windows.Forms.RadioButton();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.configurationToolTip = new System.Windows.Forms.ToolTip(this.components);
            panel1 = new System.Windows.Forms.Panel();
            imagesGroupBox = new System.Windows.Forms.GroupBox();
            imageEmitLocationLabel = new System.Windows.Forms.Label();
            maxImageEmitCountLabel = new System.Windows.Forms.Label();
            imageEmitRateLabel = new System.Windows.Forms.Label();
            imagePositionLabel = new System.Windows.Forms.Label();
            panel2 = new System.Windows.Forms.Panel();
            panel1.SuspendLayout();
            imagesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxImageEmitCountNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageEmitRateNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagePreviewPictureBox)).BeginInit();
            this.backgroundRadioGroupBox.SuspendLayout();
            panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(imagesGroupBox);
            panel1.Controls.Add(this.backgroundRadioGroupBox);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // imagesGroupBox
            // 
            resources.ApplyResources(imagesGroupBox, "imagesGroupBox");
            imagesGroupBox.Controls.Add(this.chooseCustomEmitLocationButton);
            imagesGroupBox.Controls.Add(imageEmitLocationLabel);
            imagesGroupBox.Controls.Add(this.imageEmitLocationComboBox);
            imagesGroupBox.Controls.Add(maxImageEmitCountLabel);
            imagesGroupBox.Controls.Add(this.maxImageEmitCountNumericUpDown);
            imagesGroupBox.Controls.Add(imageEmitRateLabel);
            imagesGroupBox.Controls.Add(this.imageEmitRateNumericUpDown);
            imagesGroupBox.Controls.Add(this.imagePreviewPictureBox);
            imagesGroupBox.Controls.Add(this.removeImageButton);
            imagesGroupBox.Controls.Add(this.addImageButton);
            imagesGroupBox.Controls.Add(this.imagesListBox);
            imagesGroupBox.Name = "imagesGroupBox";
            imagesGroupBox.TabStop = false;
            // 
            // chooseCustomEmitLocationButton
            // 
            resources.ApplyResources(this.chooseCustomEmitLocationButton, "chooseCustomEmitLocationButton");
            this.chooseCustomEmitLocationButton.Name = "chooseCustomEmitLocationButton";
            this.configurationToolTip.SetToolTip(this.chooseCustomEmitLocationButton, resources.GetString("chooseCustomEmitLocationButton.ToolTip"));
            this.chooseCustomEmitLocationButton.UseVisualStyleBackColor = true;
            // 
            // imageEmitLocationLabel
            // 
            resources.ApplyResources(imageEmitLocationLabel, "imageEmitLocationLabel");
            imageEmitLocationLabel.Name = "imageEmitLocationLabel";
            this.configurationToolTip.SetToolTip(imageEmitLocationLabel, resources.GetString("imageEmitLocationLabel.ToolTip"));
            // 
            // imageEmitLocationComboBox
            // 
            resources.ApplyResources(this.imageEmitLocationComboBox, "imageEmitLocationComboBox");
            this.imageEmitLocationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.imageEmitLocationComboBox.FormattingEnabled = true;
            this.imageEmitLocationComboBox.Name = "imageEmitLocationComboBox";
            // 
            // maxImageEmitCountLabel
            // 
            resources.ApplyResources(maxImageEmitCountLabel, "maxImageEmitCountLabel");
            maxImageEmitCountLabel.Name = "maxImageEmitCountLabel";
            this.configurationToolTip.SetToolTip(maxImageEmitCountLabel, resources.GetString("maxImageEmitCountLabel.ToolTip"));
            // 
            // maxImageEmitCountNumericUpDown
            // 
            resources.ApplyResources(this.maxImageEmitCountNumericUpDown, "maxImageEmitCountNumericUpDown");
            this.maxImageEmitCountNumericUpDown.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.maxImageEmitCountNumericUpDown.Name = "maxImageEmitCountNumericUpDown";
            // 
            // imageEmitRateLabel
            // 
            resources.ApplyResources(imageEmitRateLabel, "imageEmitRateLabel");
            imageEmitRateLabel.Name = "imageEmitRateLabel";
            this.configurationToolTip.SetToolTip(imageEmitRateLabel, resources.GetString("imageEmitRateLabel.ToolTip"));
            // 
            // imageEmitRateNumericUpDown
            // 
            this.imageEmitRateNumericUpDown.DecimalPlaces = 2;
            this.imageEmitRateNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            resources.ApplyResources(this.imageEmitRateNumericUpDown, "imageEmitRateNumericUpDown");
            this.imageEmitRateNumericUpDown.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.imageEmitRateNumericUpDown.Name = "imageEmitRateNumericUpDown";
            // 
            // imagePreviewPictureBox
            // 
            resources.ApplyResources(this.imagePreviewPictureBox, "imagePreviewPictureBox");
            this.imagePreviewPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imagePreviewPictureBox.Name = "imagePreviewPictureBox";
            this.imagePreviewPictureBox.TabStop = false;
            // 
            // removeImageButton
            // 
            resources.ApplyResources(this.removeImageButton, "removeImageButton");
            this.removeImageButton.Name = "removeImageButton";
            this.configurationToolTip.SetToolTip(this.removeImageButton, resources.GetString("removeImageButton.ToolTip"));
            this.removeImageButton.UseVisualStyleBackColor = true;
            // 
            // addImageButton
            // 
            resources.ApplyResources(this.addImageButton, "addImageButton");
            this.addImageButton.Name = "addImageButton";
            this.configurationToolTip.SetToolTip(this.addImageButton, resources.GetString("addImageButton.ToolTip"));
            this.addImageButton.UseVisualStyleBackColor = true;
            // 
            // imagesListBox
            // 
            resources.ApplyResources(this.imagesListBox, "imagesListBox");
            this.imagesListBox.FormattingEnabled = true;
            this.imagesListBox.Name = "imagesListBox";
            // 
            // backgroundRadioGroupBox
            // 
            resources.ApplyResources(this.backgroundRadioGroupBox, "backgroundRadioGroupBox");
            this.backgroundRadioGroupBox.Controls.Add(imagePositionLabel);
            this.backgroundRadioGroupBox.Controls.Add(this.backgroundImageScaleModeComboBox);
            this.backgroundRadioGroupBox.Controls.Add(this.chooseImageButton);
            this.backgroundRadioGroupBox.Controls.Add(this.solidColorRadioButton);
            this.backgroundRadioGroupBox.Controls.Add(this.chooseColorButton);
            this.backgroundRadioGroupBox.Controls.Add(this.desktopRadioButton);
            this.backgroundRadioGroupBox.Controls.Add(this.imageRadioButton);
            this.backgroundRadioGroupBox.Name = "backgroundRadioGroupBox";
            this.backgroundRadioGroupBox.SelectedRadioIndex = 0;
            this.backgroundRadioGroupBox.SelectedRadioValue = Natsnudasoft.EgamiFlowScreensaver.BackgroundMode.SolidColor;
            this.backgroundRadioGroupBox.TabStop = false;
            // 
            // imagePositionLabel
            // 
            resources.ApplyResources(imagePositionLabel, "imagePositionLabel");
            imagePositionLabel.Name = "imagePositionLabel";
            this.configurationToolTip.SetToolTip(imagePositionLabel, resources.GetString("imagePositionLabel.ToolTip"));
            // 
            // backgroundImageScaleModeComboBox
            // 
            resources.ApplyResources(this.backgroundImageScaleModeComboBox, "backgroundImageScaleModeComboBox");
            this.backgroundImageScaleModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.backgroundImageScaleModeComboBox.FormattingEnabled = true;
            this.backgroundImageScaleModeComboBox.Name = "backgroundImageScaleModeComboBox";
            // 
            // chooseImageButton
            // 
            resources.ApplyResources(this.chooseImageButton, "chooseImageButton");
            this.chooseImageButton.Name = "chooseImageButton";
            this.configurationToolTip.SetToolTip(this.chooseImageButton, resources.GetString("chooseImageButton.ToolTip"));
            this.chooseImageButton.UseVisualStyleBackColor = true;
            // 
            // solidColorRadioButton
            // 
            resources.ApplyResources(this.solidColorRadioButton, "solidColorRadioButton");
            this.solidColorRadioButton.Name = "solidColorRadioButton";
            this.solidColorRadioButton.Tag = Natsnudasoft.EgamiFlowScreensaver.BackgroundMode.SolidColor;
            this.configurationToolTip.SetToolTip(this.solidColorRadioButton, resources.GetString("solidColorRadioButton.ToolTip"));
            this.solidColorRadioButton.UseVisualStyleBackColor = true;
            // 
            // chooseColorButton
            // 
            resources.ApplyResources(this.chooseColorButton, "chooseColorButton");
            this.chooseColorButton.Name = "chooseColorButton";
            this.configurationToolTip.SetToolTip(this.chooseColorButton, resources.GetString("chooseColorButton.ToolTip"));
            this.chooseColorButton.UseVisualStyleBackColor = true;
            // 
            // desktopRadioButton
            // 
            resources.ApplyResources(this.desktopRadioButton, "desktopRadioButton");
            this.desktopRadioButton.Checked = true;
            this.desktopRadioButton.Name = "desktopRadioButton";
            this.desktopRadioButton.TabStop = true;
            this.desktopRadioButton.Tag = Natsnudasoft.EgamiFlowScreensaver.BackgroundMode.Desktop;
            this.configurationToolTip.SetToolTip(this.desktopRadioButton, resources.GetString("desktopRadioButton.ToolTip"));
            this.desktopRadioButton.UseVisualStyleBackColor = true;
            // 
            // imageRadioButton
            // 
            resources.ApplyResources(this.imageRadioButton, "imageRadioButton");
            this.imageRadioButton.Name = "imageRadioButton";
            this.imageRadioButton.Tag = Natsnudasoft.EgamiFlowScreensaver.BackgroundMode.Image;
            this.configurationToolTip.SetToolTip(this.imageRadioButton, resources.GetString("imageRadioButton.ToolTip"));
            this.imageRadioButton.UseVisualStyleBackColor = true;
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
            // ConfigurationForm
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
            this.Name = "ConfigurationForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            panel1.ResumeLayout(false);
            imagesGroupBox.ResumeLayout(false);
            imagesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxImageEmitCountNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageEmitRateNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagePreviewPictureBox)).EndInit();
            this.backgroundRadioGroupBox.ResumeLayout(false);
            this.backgroundRadioGroupBox.PerformLayout();
            panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.RadioButton solidColorRadioButton;
        private System.Windows.Forms.RadioButton desktopRadioButton;
        private System.Windows.Forms.Button chooseColorButton;
        private System.Windows.Forms.Button chooseImageButton;
        private System.Windows.Forms.RadioButton imageRadioButton;
        private System.Windows.Forms.ListBox imagesListBox;
        private System.Windows.Forms.Button removeImageButton;
        private System.Windows.Forms.Button addImageButton;
        private System.Windows.Forms.PictureBox imagePreviewPictureBox;
        private RadioGroupBox backgroundRadioGroupBox;
        private NumericUpDownWheel imageEmitRateNumericUpDown;
        private System.Windows.Forms.ToolTip configurationToolTip;
        private NumericUpDownWheel maxImageEmitCountNumericUpDown;
        private System.Windows.Forms.ComboBox backgroundImageScaleModeComboBox;
        private System.Windows.Forms.ComboBox imageEmitLocationComboBox;
        private System.Windows.Forms.Button chooseCustomEmitLocationButton;
    }
}