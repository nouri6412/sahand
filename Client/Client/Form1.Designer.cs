namespace Client
{
    partial class Sahand
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.LBpast = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LBremind = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LBstate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LBGabli = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // LBpast
            // 
            this.LBpast.AutoSize = true;
            this.LBpast.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBpast.ForeColor = System.Drawing.Color.Red;
            this.LBpast.Location = new System.Drawing.Point(71, 141);
            this.LBpast.Name = "LBpast";
            this.LBpast.Size = new System.Drawing.Size(45, 25);
            this.LBpast.TabIndex = 2;
            this.LBpast.Text = "000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "وقت گذرانده";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "گیم نت سهند";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "خوش گلیبسیز";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(37, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 24);
            this.label5.TabIndex = 7;
            this.label5.Text = "وقت باقیمانده";
            // 
            // LBremind
            // 
            this.LBremind.AutoSize = true;
            this.LBremind.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBremind.ForeColor = System.Drawing.Color.Red;
            this.LBremind.Location = new System.Drawing.Point(69, 217);
            this.LBremind.Name = "LBremind";
            this.LBremind.Size = new System.Drawing.Size(45, 25);
            this.LBremind.TabIndex = 6;
            this.LBremind.Text = "000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(62, 451);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 24);
            this.label7.TabIndex = 9;
            this.label7.Text = "وضعیت";
            // 
            // LBstate
            // 
            this.LBstate.AutoSize = true;
            this.LBstate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBstate.ForeColor = System.Drawing.Color.Red;
            this.LBstate.Location = new System.Drawing.Point(71, 485);
            this.LBstate.Name = "LBstate";
            this.LBstate.Size = new System.Drawing.Size(45, 25);
            this.LBstate.TabIndex = 8;
            this.LBstate.Text = "000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 322);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = "وقت قبلی";
            // 
            // LBGabli
            // 
            this.LBGabli.AutoSize = true;
            this.LBGabli.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBGabli.ForeColor = System.Drawing.Color.Red;
            this.LBGabli.Location = new System.Drawing.Point(71, 362);
            this.LBGabli.Name = "LBGabli";
            this.LBGabli.Size = new System.Drawing.Size(45, 25);
            this.LBGabli.TabIndex = 10;
            this.LBGabli.Text = "000";
            // 
            // Sahand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(200, 534);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LBGabli);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.LBstate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LBremind);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LBpast);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(900, 100);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Sahand";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Sahand";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Sahand_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Sahand_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Sahand_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label LBpast;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LBremind;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LBstate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LBGabli;
    }
}

