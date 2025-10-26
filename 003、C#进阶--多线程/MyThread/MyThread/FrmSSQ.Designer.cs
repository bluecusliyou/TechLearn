namespace MyThread
{
    partial class FrmSSQ
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
            this.gboSSQ = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblBlue = new System.Windows.Forms.Label();
            this.lblRed6 = new System.Windows.Forms.Label();
            this.lblRed5 = new System.Windows.Forms.Label();
            this.lblRed4 = new System.Windows.Forms.Label();
            this.lblRed3 = new System.Windows.Forms.Label();
            this.lblRed2 = new System.Windows.Forms.Label();
            this.lblRed1 = new System.Windows.Forms.Label();
            this.gboSSQ.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboSSQ
            // 
            this.gboSSQ.Controls.Add(this.btnStop);
            this.gboSSQ.Controls.Add(this.btnStart);
            this.gboSSQ.Controls.Add(this.lblBlue);
            this.gboSSQ.Controls.Add(this.lblRed6);
            this.gboSSQ.Controls.Add(this.lblRed5);
            this.gboSSQ.Controls.Add(this.lblRed4);
            this.gboSSQ.Controls.Add(this.lblRed3);
            this.gboSSQ.Controls.Add(this.lblRed2);
            this.gboSSQ.Controls.Add(this.lblRed1);
            this.gboSSQ.Location = new System.Drawing.Point(12, 13);
            this.gboSSQ.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gboSSQ.Name = "gboSSQ";
            this.gboSSQ.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gboSSQ.Size = new System.Drawing.Size(792, 316);
            this.gboSSQ.TabIndex = 0;
            this.gboSSQ.TabStop = false;
            this.gboSSQ.Text = "双色球结果区";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(472, 213);
            this.btnStop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(84, 47);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(164, 213);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(84, 47);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblBlue
            // 
            this.lblBlue.AutoSize = true;
            this.lblBlue.ForeColor = System.Drawing.Color.Blue;
            this.lblBlue.Location = new System.Drawing.Point(627, 96);
            this.lblBlue.Name = "lblBlue";
            this.lblBlue.Size = new System.Drawing.Size(27, 20);
            this.lblBlue.TabIndex = 0;
            this.lblBlue.Text = "00";
            // 
            // lblRed6
            // 
            this.lblRed6.AutoSize = true;
            this.lblRed6.ForeColor = System.Drawing.Color.Red;
            this.lblRed6.Location = new System.Drawing.Point(469, 96);
            this.lblRed6.Name = "lblRed6";
            this.lblRed6.Size = new System.Drawing.Size(27, 20);
            this.lblRed6.TabIndex = 0;
            this.lblRed6.Text = "00";
            // 
            // lblRed5
            // 
            this.lblRed5.AutoSize = true;
            this.lblRed5.ForeColor = System.Drawing.Color.Red;
            this.lblRed5.Location = new System.Drawing.Point(374, 96);
            this.lblRed5.Name = "lblRed5";
            this.lblRed5.Size = new System.Drawing.Size(27, 20);
            this.lblRed5.TabIndex = 0;
            this.lblRed5.Text = "00";
            // 
            // lblRed4
            // 
            this.lblRed4.AutoSize = true;
            this.lblRed4.ForeColor = System.Drawing.Color.Red;
            this.lblRed4.Location = new System.Drawing.Point(290, 96);
            this.lblRed4.Name = "lblRed4";
            this.lblRed4.Size = new System.Drawing.Size(27, 20);
            this.lblRed4.TabIndex = 0;
            this.lblRed4.Text = "00";
            // 
            // lblRed3
            // 
            this.lblRed3.AutoSize = true;
            this.lblRed3.ForeColor = System.Drawing.Color.Red;
            this.lblRed3.Location = new System.Drawing.Point(204, 96);
            this.lblRed3.Name = "lblRed3";
            this.lblRed3.Size = new System.Drawing.Size(27, 20);
            this.lblRed3.TabIndex = 0;
            this.lblRed3.Text = "00";
            // 
            // lblRed2
            // 
            this.lblRed2.AutoSize = true;
            this.lblRed2.ForeColor = System.Drawing.Color.Red;
            this.lblRed2.Location = new System.Drawing.Point(126, 96);
            this.lblRed2.Name = "lblRed2";
            this.lblRed2.Size = new System.Drawing.Size(27, 20);
            this.lblRed2.TabIndex = 0;
            this.lblRed2.Text = "00";
            // 
            // lblRed1
            // 
            this.lblRed1.AutoSize = true;
            this.lblRed1.ForeColor = System.Drawing.Color.Red;
            this.lblRed1.Location = new System.Drawing.Point(53, 96);
            this.lblRed1.Name = "lblRed1";
            this.lblRed1.Size = new System.Drawing.Size(27, 20);
            this.lblRed1.TabIndex = 0;
            this.lblRed1.Text = "00";
            // 
            // FrmSSQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 351);
            this.Controls.Add(this.gboSSQ);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmSSQ";
            this.Text = "双色球";
            this.gboSSQ.ResumeLayout(false);
            this.gboSSQ.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboSSQ;
        private System.Windows.Forms.Label lblRed1;
        private System.Windows.Forms.Label lblRed6;
        private System.Windows.Forms.Label lblRed5;
        private System.Windows.Forms.Label lblRed4;
        private System.Windows.Forms.Label lblRed3;
        private System.Windows.Forms.Label lblRed2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblBlue;
    }
}