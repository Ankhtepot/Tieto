﻿namespace Cipherator
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
            this.groupCipher = new System.Windows.Forms.GroupBox();
            this.NudKey = new System.Windows.Forms.NumericUpDown();
            this.LbKey = new System.Windows.Forms.Label();
            this.BuReset = new System.Windows.Forms.Button();
            this.BuDecipher = new System.Windows.Forms.Button();
            this.BuExit = new System.Windows.Forms.Button();
            this.BuCipher = new System.Windows.Forms.Button();
            this.BuToInput = new System.Windows.Forms.Button();
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
            // groupCipher
            // 
            this.groupCipher.Location = new System.Drawing.Point(12, 98);
            this.groupCipher.Name = "groupCipher";
            this.groupCipher.Size = new System.Drawing.Size(278, 86);
            this.groupCipher.TabIndex = 6;
            this.groupCipher.TabStop = false;
            this.groupCipher.Text = "Crypting method";
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
            this.LbKey.Size = new System.Drawing.Size(151, 13);
            this.LbKey.TabIndex = 10;
            this.LbKey.Text = "Select crypting method above:";
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
            this.Controls.Add(this.groupCipher);
            this.Controls.Add(this.TbResult);
            this.Controls.Add(this.LbResult);
            this.Controls.Add(this.BuCipher);
            this.Controls.Add(this.lbInput);
            this.Controls.Add(this.TbInput);
            this.Name = "FrMain";
            this.Text = "Cipher";
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
        private System.Windows.Forms.GroupBox groupCipher;
        private System.Windows.Forms.Button BuExit;
        private System.Windows.Forms.Button BuDecipher;
        private System.Windows.Forms.NumericUpDown NudKey;
        private System.Windows.Forms.Label LbKey;
        private System.Windows.Forms.Button BuReset;
        private System.Windows.Forms.Button BuToInput;
    }
}

