namespace Example.Runtime
{
    partial class Form2
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
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BlankUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.Brank = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.IsoImagePathtextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.holdUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.MoveImageIntervalNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SetImagePasthtextBox = new System.Windows.Forms.TextBox();
            this.GetImagePathtextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GetImageIntervalNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Set_button = new System.Windows.Forms.Button();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlankUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.holdUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoveImageIntervalNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GetImageIntervalNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox9
            // 
            this.groupBox9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.groupBox9.Controls.Add(this.label7);
            this.groupBox9.Controls.Add(this.BlankUpDown1);
            this.groupBox9.Controls.Add(this.Brank);
            this.groupBox9.Controls.Add(this.label6);
            this.groupBox9.Controls.Add(this.IsoImagePathtextBox);
            this.groupBox9.Controls.Add(this.label5);
            this.groupBox9.Controls.Add(this.label2);
            this.groupBox9.Controls.Add(this.holdUpDown1);
            this.groupBox9.Controls.Add(this.MoveImageIntervalNumericUpDown);
            this.groupBox9.Controls.Add(this.label4);
            this.groupBox9.Controls.Add(this.label3);
            this.groupBox9.Controls.Add(this.SetImagePasthtextBox);
            this.groupBox9.Controls.Add(this.GetImagePathtextBox);
            this.groupBox9.Controls.Add(this.label1);
            this.groupBox9.Controls.Add(this.GetImageIntervalNumericUpDown);
            this.groupBox9.Controls.Add(this.label17);
            this.groupBox9.Controls.Add(this.label24);
            this.groupBox9.Controls.Add(this.label18);
            this.groupBox9.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox9.ForeColor = System.Drawing.Color.White;
            this.groupBox9.Location = new System.Drawing.Point(4, 5);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox9.Size = new System.Drawing.Size(743, 333);
            this.groupBox9.TabIndex = 11;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "画像取得　：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(316, 297);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(226, 24);
            this.label7.TabIndex = 24;
            this.label7.Text = "%（入力範囲：0～100）";
            // 
            // BlankUpDown1
            // 
            this.BlankUpDown1.Location = new System.Drawing.Point(218, 290);
            this.BlankUpDown1.Name = "BlankUpDown1";
            this.BlankUpDown1.Size = new System.Drawing.Size(82, 31);
            this.BlankUpDown1.TabIndex = 23;
            // 
            // Brank
            // 
            this.Brank.AutoSize = true;
            this.Brank.Location = new System.Drawing.Point(7, 292);
            this.Brank.Name = "Brank";
            this.Brank.Size = new System.Drawing.Size(190, 24);
            this.Brank.TabIndex = 22;
            this.Brank.Text = "画像保存しきい値:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 123);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(245, 24);
            this.label6.TabIndex = 21;
            this.label6.Text = "破損エラー画像保存先：";
            // 
            // IsoImagePathtextBox
            // 
            this.IsoImagePathtextBox.Location = new System.Drawing.Point(259, 120);
            this.IsoImagePathtextBox.Margin = new System.Windows.Forms.Padding(2);
            this.IsoImagePathtextBox.Name = "IsoImagePathtextBox";
            this.IsoImagePathtextBox.Size = new System.Drawing.Size(450, 31);
            this.IsoImagePathtextBox.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(316, 255);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(276, 24);
            this.label5.TabIndex = 19;
            this.label5.Text = "msec (入力範囲：0～2000)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(316, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(288, 24);
            this.label2.TabIndex = 19;
            this.label2.Text = "msec (入力範囲：10～1000)";
            // 
            // holdUpDown1
            // 
            this.holdUpDown1.Location = new System.Drawing.Point(218, 248);
            this.holdUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.holdUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.holdUpDown1.Name = "holdUpDown1";
            this.holdUpDown1.Size = new System.Drawing.Size(82, 31);
            this.holdUpDown1.TabIndex = 18;
            this.holdUpDown1.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // MoveImageIntervalNumericUpDown
            // 
            this.MoveImageIntervalNumericUpDown.Location = new System.Drawing.Point(218, 206);
            this.MoveImageIntervalNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.MoveImageIntervalNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MoveImageIntervalNumericUpDown.Name = "MoveImageIntervalNumericUpDown";
            this.MoveImageIntervalNumericUpDown.Size = new System.Drawing.Size(82, 31);
            this.MoveImageIntervalNumericUpDown.TabIndex = 18;
            this.MoveImageIntervalNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 24);
            this.label4.TabIndex = 17;
            this.label4.Text = "画像表示時間：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 24);
            this.label3.TabIndex = 17;
            this.label3.Text = "ファイル移動周期：";
            // 
            // SetImagePasthtextBox
            // 
            this.SetImagePasthtextBox.Location = new System.Drawing.Point(259, 83);
            this.SetImagePasthtextBox.Name = "SetImagePasthtextBox";
            this.SetImagePasthtextBox.Size = new System.Drawing.Size(450, 31);
            this.SetImagePasthtextBox.TabIndex = 16;
            // 
            // GetImagePathtextBox
            // 
            this.GetImagePathtextBox.Location = new System.Drawing.Point(259, 47);
            this.GetImagePathtextBox.Name = "GetImagePathtextBox";
            this.GetImagePathtextBox.Size = new System.Drawing.Size(450, 31);
            this.GetImagePathtextBox.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(316, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 24);
            this.label1.TabIndex = 14;
            this.label1.Text = "msec (入力範囲：10～1000)";
            // 
            // GetImageIntervalNumericUpDown
            // 
            this.GetImageIntervalNumericUpDown.Location = new System.Drawing.Point(218, 164);
            this.GetImageIntervalNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.GetImageIntervalNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.GetImageIntervalNumericUpDown.Name = "GetImageIntervalNumericUpDown";
            this.GetImageIntervalNumericUpDown.Size = new System.Drawing.Size(82, 31);
            this.GetImageIntervalNumericUpDown.TabIndex = 13;
            this.GetImageIntervalNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(16, 166);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(185, 24);
            this.label17.TabIndex = 12;
            this.label17.Text = "ファイル取得周期：";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label24.Location = new System.Drawing.Point(23, 85);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(163, 24);
            this.label24.TabIndex = 7;
            this.label24.Text = "保存先フォルダ：";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label18.Location = new System.Drawing.Point(23, 50);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(230, 24);
            this.label18.TabIndex = 3;
            this.label18.Text = "ファイル取得先フォルダ：";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(627, 347);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 35);
            this.button1.TabIndex = 10;
            this.button1.Text = "キャンセル";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Set_button
            // 
            this.Set_button.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Set_button.Location = new System.Drawing.Point(528, 347);
            this.Set_button.Name = "Set_button";
            this.Set_button.Size = new System.Drawing.Size(80, 35);
            this.Set_button.TabIndex = 12;
            this.Set_button.Text = "設定";
            this.Set_button.UseVisualStyleBackColor = true;
            this.Set_button.Click += new System.EventHandler(this.Set_button_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(771, 383);
            this.Controls.Add(this.Set_button);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.button1);
            this.Name = "Form2";
            this.Text = "検査画像取得設定";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlankUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.holdUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoveImageIntervalNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GetImageIntervalNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.NumericUpDown MoveImageIntervalNumericUpDown;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox SetImagePasthtextBox;
        public System.Windows.Forms.TextBox GetImagePathtextBox;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown GetImageIntervalNumericUpDown;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Set_button;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.NumericUpDown holdUpDown1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox IsoImagePathtextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown BlankUpDown1;
        private System.Windows.Forms.Label Brank;
    }
}