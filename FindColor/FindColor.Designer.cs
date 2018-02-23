namespace FindColor
{
    partial class FindColor
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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindColor));
            this.btnFindingColor = new System.Windows.Forms.Button();
            this.txtHexColor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGetColor = new System.Windows.Forms.Button();
            this.tmrGetColor = new System.Windows.Forms.Timer(this.components);
            this.imgHexColor = new System.Windows.Forms.PictureBox();
            this.lblHelp = new System.Windows.Forms.Label();
            this.tmrFindingColor = new System.Windows.Forms.Timer(this.components);
            this.lblSound = new System.Windows.Forms.Label();
            this.btnPlaySound = new System.Windows.Forms.Button();
            this.btnSelectSound = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnColorDialog = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgHexColor)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFindingColor
            // 
            this.btnFindingColor.Location = new System.Drawing.Point(356, 113);
            this.btnFindingColor.Name = "btnFindingColor";
            this.btnFindingColor.Size = new System.Drawing.Size(80, 35);
            this.btnFindingColor.TabIndex = 0;
            this.btnFindingColor.Text = "Run/Stop (F8)";
            this.btnFindingColor.UseVisualStyleBackColor = true;
            // 
            // txtHexColor
            // 
            this.txtHexColor.Location = new System.Drawing.Point(77, 12);
            this.txtHexColor.Name = "txtHexColor";
            this.txtHexColor.Size = new System.Drawing.Size(105, 20);
            this.txtHexColor.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hex Color";
            // 
            // btnGetColor
            // 
            this.btnGetColor.Location = new System.Drawing.Point(98, 113);
            this.btnGetColor.Name = "btnGetColor";
            this.btnGetColor.Size = new System.Drawing.Size(80, 35);
            this.btnGetColor.TabIndex = 0;
            this.btnGetColor.Text = "Get Color (F5)";
            this.btnGetColor.UseVisualStyleBackColor = true;
            // 
            // imgHexColor
            // 
            this.imgHexColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgHexColor.Location = new System.Drawing.Point(12, 47);
            this.imgHexColor.Name = "imgHexColor";
            this.imgHexColor.Size = new System.Drawing.Size(170, 50);
            this.imgHexColor.TabIndex = 3;
            this.imgHexColor.TabStop = false;
            // 
            // lblHelp
            // 
            this.lblHelp.AutoSize = true;
            this.lblHelp.Location = new System.Drawing.Point(267, 15);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(39, 13);
            this.lblHelp.TabIndex = 4;
            this.lblHelp.Text = "lblHelp";
            // 
            // lblSound
            // 
            this.lblSound.AllowDrop = true;
            this.lblSound.Location = new System.Drawing.Point(204, 47);
            this.lblSound.Name = "lblSound";
            this.lblSound.Size = new System.Drawing.Size(170, 50);
            this.lblSound.TabIndex = 5;
            this.lblSound.Text = "lblSound";
            // 
            // btnPlaySound
            // 
            this.btnPlaySound.Location = new System.Drawing.Point(270, 113);
            this.btnPlaySound.Name = "btnPlaySound";
            this.btnPlaySound.Size = new System.Drawing.Size(80, 35);
            this.btnPlaySound.TabIndex = 6;
            this.btnPlaySound.Text = "Play Sound (F7)";
            this.btnPlaySound.UseVisualStyleBackColor = true;
            // 
            // btnSelectSound
            // 
            this.btnSelectSound.Location = new System.Drawing.Point(184, 113);
            this.btnSelectSound.Name = "btnSelectSound";
            this.btnSelectSound.Size = new System.Drawing.Size(80, 35);
            this.btnSelectSound.TabIndex = 7;
            this.btnSelectSound.Text = "Select Sound (F6)";
            this.btnSelectSound.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(9, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Copyrights by BơmBơm™ ";
            // 
            // btnColorDialog
            // 
            this.btnColorDialog.Location = new System.Drawing.Point(12, 113);
            this.btnColorDialog.Name = "btnColorDialog";
            this.btnColorDialog.Size = new System.Drawing.Size(80, 35);
            this.btnColorDialog.TabIndex = 9;
            this.btnColorDialog.Text = "Color (F4)";
            this.btnColorDialog.UseVisualStyleBackColor = true;
            // 
            // FindColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 187);
            this.Controls.Add(this.btnColorDialog);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSelectSound);
            this.Controls.Add(this.btnPlaySound);
            this.Controls.Add(this.lblSound);
            this.Controls.Add(this.lblHelp);
            this.Controls.Add(this.imgHexColor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHexColor);
            this.Controls.Add(this.btnGetColor);
            this.Controls.Add(this.btnFindingColor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FindColor";
            this.Text = "FindColor";
            ((System.ComponentModel.ISupportInitialize)(this.imgHexColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFindingColor;
        private System.Windows.Forms.TextBox txtHexColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGetColor;
        private System.Windows.Forms.Timer tmrGetColor;
        private System.Windows.Forms.PictureBox imgHexColor;
        private System.Windows.Forms.Timer tmrFindingColor;
        private System.Windows.Forms.Label lblHelp;
        private System.Windows.Forms.Label lblSound;
        private System.Windows.Forms.Button btnPlaySound;
        private System.Windows.Forms.Button btnSelectSound;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnColorDialog;
    }
}

