namespace FindColor
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtHexColor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGetColor = new System.Windows.Forms.Button();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.imgHexColor = new System.Windows.Forms.PictureBox();
            this.lblHelpSelectColor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgHexColor)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(105, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtHexColor
            // 
            this.txtHexColor.Location = new System.Drawing.Point(105, 12);
            this.txtHexColor.Name = "txtHexColor";
            this.txtHexColor.Size = new System.Drawing.Size(167, 20);
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
            this.btnGetColor.Location = new System.Drawing.Point(12, 226);
            this.btnGetColor.Name = "btnGetColor";
            this.btnGetColor.Size = new System.Drawing.Size(81, 23);
            this.btnGetColor.TabIndex = 0;
            this.btnGetColor.Text = "Get Color (F5)";
            this.btnGetColor.UseVisualStyleBackColor = true;
            this.btnGetColor.Click += new System.EventHandler(this.btnGetColor_Click);
            // 
            // Timer
            // 
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // imgHexColor
            // 
            this.imgHexColor.Location = new System.Drawing.Point(12, 38);
            this.imgHexColor.Name = "imgHexColor";
            this.imgHexColor.Size = new System.Drawing.Size(260, 50);
            this.imgHexColor.TabIndex = 3;
            this.imgHexColor.TabStop = false;
            // 
            // lblHelpSelectColor
            // 
            this.lblHelpSelectColor.AutoSize = true;
            this.lblHelpSelectColor.Location = new System.Drawing.Point(12, 100);
            this.lblHelpSelectColor.Name = "lblHelpSelectColor";
            this.lblHelpSelectColor.Size = new System.Drawing.Size(0, 13);
            this.lblHelpSelectColor.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lblHelpSelectColor);
            this.Controls.Add(this.imgHexColor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHexColor);
            this.Controls.Add(this.btnGetColor);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.imgHexColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtHexColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGetColor;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.PictureBox imgHexColor;
        private System.Windows.Forms.Label lblHelpSelectColor;
    }
}

