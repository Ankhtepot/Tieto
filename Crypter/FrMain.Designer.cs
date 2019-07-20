namespace Cipherator
{
    partial class FrMain
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
            this.TbInput = new System.Windows.Forms.TextBox();
            this.lbInput = new System.Windows.Forms.Label();
            this.LbResult = new System.Windows.Forms.Label();
            this.TbResult = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RbCaesar = new System.Windows.Forms.RadioButton();
            this.RbMorse = new System.Windows.Forms.RadioButton();
            this.NudKey = new System.Windows.Forms.NumericUpDown();
            this.LbKey = new System.Windows.Forms.Label();
            this.BuReset = new System.Windows.Forms.Button();
            this.BuDecipher = new System.Windows.Forms.Button();
            this.BuExit = new System.Windows.Forms.Button();
            this.BuCipher = new System.Windows.Forms.Button();
            this.BuToInput = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudKey)).BeginInit();
            this.SuspendLayout();
            // 
            // TbInput
            // 
            this.TbInput.Location = new System.Drawing.Point(12, 27);
            this.TbInput.Name = "TbInput";
            this.TbInput.Size = new System.Drawing.Size(278, 20);
            this.TbInput.TabIndex = 0;
            // 
            // lbInput
            // 
            this.lbInput.AutoSize = true;
            this.lbInput.Location = new System.Drawing.Point(12, 10);
            this.lbInput.Name = "lbInput";
            this.lbInput.Size = new System.Drawing.Size(34, 13);
            this.lbInput.TabIndex = 1;
            this.lbInput.Text = "Input:";
            // 
            // LbResult
            // 
            this.LbResult.AutoSize = true;
            this.LbResult.Location = new System.Drawing.Point(12, 213);
            this.LbResult.Name = "LbResult";
            this.LbResult.Size = new System.Drawing.Size(40, 13);
            this.LbResult.TabIndex = 3;
            this.LbResult.Text = "Result:";
            // 
            // TbResult
            // 
            this.TbResult.Location = new System.Drawing.Point(10, 229);
            this.TbResult.Name = "TbResult";
            this.TbResult.Size = new System.Drawing.Size(233, 20);
            this.TbResult.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RbCaesar);
            this.groupBox1.Controls.Add(this.RbMorse);
            this.groupBox1.Location = new System.Drawing.Point(12, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 86);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Crypting method";
            // 
            // RbCaesar
            // 
            this.RbCaesar.AutoSize = true;
            this.RbCaesar.Location = new System.Drawing.Point(7, 44);
            this.RbCaesar.Name = "RbCaesar";
            this.RbCaesar.Size = new System.Drawing.Size(58, 17);
            this.RbCaesar.TabIndex = 1;
            this.RbCaesar.TabStop = true;
            this.RbCaesar.Tag = "2";
            this.RbCaesar.Text = "Caesar";
            this.RbCaesar.UseVisualStyleBackColor = true;
            // 
            // RbMorse
            // 
            this.RbMorse.AutoSize = true;
            this.RbMorse.Location = new System.Drawing.Point(7, 20);
            this.RbMorse.Name = "RbMorse";
            this.RbMorse.Size = new System.Drawing.Size(54, 17);
            this.RbMorse.TabIndex = 0;
            this.RbMorse.TabStop = true;
            this.RbMorse.Tag = "1";
            this.RbMorse.Text = "Morse";
            this.RbMorse.UseVisualStyleBackColor = true;
            // 
            // NudKey
            // 
            this.NudKey.Location = new System.Drawing.Point(188, 190);
            this.NudKey.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudKey.Name = "NudKey";
            this.NudKey.Size = new System.Drawing.Size(43, 20);
            this.NudKey.TabIndex = 9;
            this.NudKey.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudKey.Visible = false;
            // 
            // LbKey
            // 
            this.LbKey.AutoSize = true;
            this.LbKey.Location = new System.Drawing.Point(12, 192);
            this.LbKey.Name = "LbKey";
            this.LbKey.Size = new System.Drawing.Size(61, 13);
            this.LbKey.TabIndex = 10;
            this.LbKey.Text = "Cipher Key:";
            // 
            // BuReset
            // 
            this.BuReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BuReset.Location = new System.Drawing.Point(238, 190);
            this.BuReset.Name = "BuReset";
            this.BuReset.Size = new System.Drawing.Size(50, 33);
            this.BuReset.TabIndex = 11;
            this.BuReset.Text = "Reset";
            this.BuReset.UseVisualStyleBackColor = true;
            // 
            // BuDecipher
            // 
            this.BuDecipher.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BuDecipher.Image = global::Crypter.Properties.Resources.decrypt24x23;
            this.BuDecipher.Location = new System.Drawing.Point(155, 54);
            this.BuDecipher.Name = "BuDecipher";
            this.BuDecipher.Size = new System.Drawing.Size(139, 39);
            this.BuDecipher.TabIndex = 8;
            this.BuDecipher.Text = "Decipher";
            this.BuDecipher.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BuDecipher.UseVisualStyleBackColor = true;
            // 
            // BuExit
            // 
            this.BuExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BuExit.Image = global::Crypter.Properties.Resources.exit24x24;
            this.BuExit.Location = new System.Drawing.Point(10, 255);
            this.BuExit.Name = "BuExit";
            this.BuExit.Size = new System.Drawing.Size(278, 36);
            this.BuExit.TabIndex = 7;
            this.BuExit.Text = "Exit";
            this.BuExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BuExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BuExit.UseVisualStyleBackColor = true;
            // 
            // BuCipher
            // 
            this.BuCipher.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BuCipher.Image = global::Crypter.Properties.Resources.crypt17x24;
            this.BuCipher.Location = new System.Drawing.Point(12, 53);
            this.BuCipher.Name = "BuCipher";
            this.BuCipher.Size = new System.Drawing.Size(136, 39);
            this.BuCipher.TabIndex = 2;
            this.BuCipher.Text = "Cipher";
            this.BuCipher.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BuCipher.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BuCipher.UseVisualStyleBackColor = true;
            // 
            // BuToInput
            // 
            this.BuToInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BuToInput.Location = new System.Drawing.Point(238, 229);
            this.BuToInput.Name = "BuToInput";
            this.BuToInput.Size = new System.Drawing.Size(50, 20);
            this.BuToInput.TabIndex = 12;
            this.BuToInput.Text = "->Input";
            this.BuToInput.UseVisualStyleBackColor = true;
            // 
            // FrMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 302);
            this.Controls.Add(this.BuToInput);
            this.Controls.Add(this.BuReset);
            this.Controls.Add(this.LbKey);
            this.Controls.Add(this.NudKey);
            this.Controls.Add(this.BuDecipher);
            this.Controls.Add(this.BuExit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TbResult);
            this.Controls.Add(this.LbResult);
            this.Controls.Add(this.BuCipher);
            this.Controls.Add(this.lbInput);
            this.Controls.Add(this.TbInput);
            this.Name = "FrMain";
            this.Text = "Cipher";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudKey)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbInput;
        private System.Windows.Forms.Label lbInput;
        private System.Windows.Forms.Button BuCipher;
        private System.Windows.Forms.Label LbResult;
        private System.Windows.Forms.TextBox TbResult;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RbCaesar;
        private System.Windows.Forms.RadioButton RbMorse;
        private System.Windows.Forms.Button BuExit;
        private System.Windows.Forms.Button BuDecipher;
        private System.Windows.Forms.NumericUpDown NudKey;
        private System.Windows.Forms.Label LbKey;
        private System.Windows.Forms.Button BuReset;
        private System.Windows.Forms.Button BuToInput;
    }
}

