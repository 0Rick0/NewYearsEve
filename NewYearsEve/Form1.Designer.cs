namespace NewYearsEve
{
    partial class frmMain
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
            this.btBegin = new System.Windows.Forms.Button();
            this.cbAntiAlias = new System.Windows.Forms.CheckBox();
            this.cbLogo = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cbSmoothTime = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // btBegin
            // 
            this.btBegin.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBegin.Location = new System.Drawing.Point(12, 12);
            this.btBegin.Name = "btBegin";
            this.btBegin.Size = new System.Drawing.Size(260, 185);
            this.btBegin.TabIndex = 0;
            this.btBegin.Text = "Begin";
            this.btBegin.UseVisualStyleBackColor = true;
            this.btBegin.Click += new System.EventHandler(this.btBegin_Click);
            // 
            // cbAntiAlias
            // 
            this.cbAntiAlias.AutoSize = true;
            this.cbAntiAlias.Checked = true;
            this.cbAntiAlias.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAntiAlias.Location = new System.Drawing.Point(13, 232);
            this.cbAntiAlias.Name = "cbAntiAlias";
            this.cbAntiAlias.Size = new System.Drawing.Size(66, 17);
            this.cbAntiAlias.TabIndex = 1;
            this.cbAntiAlias.Text = "AntiAlias";
            this.cbAntiAlias.UseVisualStyleBackColor = true;
            // 
            // cbLogo
            // 
            this.cbLogo.AutoSize = true;
            this.cbLogo.Location = new System.Drawing.Point(85, 232);
            this.cbLogo.Name = "cbLogo";
            this.cbLogo.Size = new System.Drawing.Size(80, 17);
            this.cbLogo.TabIndex = 2;
            this.cbLogo.Text = "Show Logo";
            this.cbLogo.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(237, 231);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(35, 20);
            this.numericUpDown1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(190, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Display";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 203);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "midnight";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbSmoothTime
            // 
            this.cbSmoothTime.AutoSize = true;
            this.cbSmoothTime.Checked = true;
            this.cbSmoothTime.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.cbSmoothTime.Location = new System.Drawing.Point(184, 207);
            this.cbSmoothTime.Name = "cbSmoothTime";
            this.cbSmoothTime.Size = new System.Drawing.Size(88, 17);
            this.cbSmoothTime.TabIndex = 6;
            this.cbSmoothTime.Text = "Smooth Time";
            this.cbSmoothTime.ThreeState = true;
            this.cbSmoothTime.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.cbSmoothTime);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.cbLogo);
            this.Controls.Add(this.cbAntiAlias);
            this.Controls.Add(this.btBegin);
            this.Name = "frmMain";
            this.Text = "New Years Eve";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btBegin;
        private System.Windows.Forms.CheckBox cbAntiAlias;
        private System.Windows.Forms.CheckBox cbLogo;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox cbSmoothTime;
    }
}

