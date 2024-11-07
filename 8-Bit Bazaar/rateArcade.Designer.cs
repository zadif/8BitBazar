namespace _8_Bit_Bazaar
{
    partial class rateArcade
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
            this.label2 = new System.Windows.Forms.Label();
            this.cuiSlider1 = new CuoreUI.Controls.cuiSlider();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift SemiLight Condensed", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(132, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(241, 64);
            this.label2.TabIndex = 3;
            this.label2.Text = "Rate Arcade";
            // 
            // cuiSlider1
            // 
            this.cuiSlider1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cuiSlider1.DesignStyle = CuoreUI.Controls.cuiSlider.Styles.Partial;
            this.cuiSlider1.Location = new System.Drawing.Point(117, 132);
            this.cuiSlider1.MaxValue = 100F;
            this.cuiSlider1.MinValue = 0F;
            this.cuiSlider1.Name = "cuiSlider1";
            this.cuiSlider1.OutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.cuiSlider1.OutlineThickness = 1.6F;
            this.cuiSlider1.Size = new System.Drawing.Size(278, 24);
            this.cuiSlider1.TabIndex = 4;
            this.cuiSlider1.ThumbColor = System.Drawing.Color.Coral;
            this.cuiSlider1.Value = 100F;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(15)))), ((int)(((byte)(31)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Purple;
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Purple;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Location = new System.Drawing.Point(208, 198);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 48);
            this.button2.TabIndex = 48;
            this.button2.Text = "Submit";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // rateArcade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(15)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(522, 286);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cuiSlider1);
            this.Controls.Add(this.label2);
            this.Name = "rateArcade";
            this.Text = "Rate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private CuoreUI.Controls.cuiSlider cuiSlider1;
        private System.Windows.Forms.Button button2;
    }
}