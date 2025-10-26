
namespace MyThread
{
    partial class FrmThread
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTask = new System.Windows.Forms.Button();
            this.btnParallel = new System.Windows.Forms.Button();
            this.btnTaskAdvanced = new System.Windows.Forms.Button();
            this.btnThread = new System.Windows.Forms.Button();
            this.btnThreadPool = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnAwaitAsync = new System.Windows.Forms.Button();
            this.textAsyncResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnTask
            // 
            this.btnTask.Location = new System.Drawing.Point(283, 25);
            this.btnTask.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTask.Name = "btnTask";
            this.btnTask.Size = new System.Drawing.Size(134, 29);
            this.btnTask.TabIndex = 2;
            this.btnTask.Text = "Task";
            this.btnTask.UseVisualStyleBackColor = true;
            this.btnTask.Click += new System.EventHandler(this.btnTask_Click);
            // 
            // btnParallel
            // 
            this.btnParallel.Location = new System.Drawing.Point(284, 138);
            this.btnParallel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnParallel.Name = "btnParallel";
            this.btnParallel.Size = new System.Drawing.Size(132, 29);
            this.btnParallel.TabIndex = 3;
            this.btnParallel.Text = "Parallel";
            this.btnParallel.UseVisualStyleBackColor = true;
            this.btnParallel.Click += new System.EventHandler(this.btnParallel_Click);
            // 
            // btnTaskAdvanced
            // 
            this.btnTaskAdvanced.Location = new System.Drawing.Point(283, 80);
            this.btnTaskAdvanced.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTaskAdvanced.Name = "btnTaskAdvanced";
            this.btnTaskAdvanced.Size = new System.Drawing.Size(132, 29);
            this.btnTaskAdvanced.TabIndex = 4;
            this.btnTaskAdvanced.Text = "TaskAdvanced";
            this.btnTaskAdvanced.UseVisualStyleBackColor = true;
            this.btnTaskAdvanced.Click += new System.EventHandler(this.TaskAdvanced_Click);
            // 
            // btnThread
            // 
            this.btnThread.Location = new System.Drawing.Point(60, 25);
            this.btnThread.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThread.Name = "btnThread";
            this.btnThread.Size = new System.Drawing.Size(134, 29);
            this.btnThread.TabIndex = 5;
            this.btnThread.Text = "Thread";
            this.btnThread.UseVisualStyleBackColor = true;
            this.btnThread.Click += new System.EventHandler(this.btnThread_Click);
            // 
            // btnThreadPool
            // 
            this.btnThreadPool.Location = new System.Drawing.Point(60, 81);
            this.btnThreadPool.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThreadPool.Name = "btnThreadPool";
            this.btnThreadPool.Size = new System.Drawing.Size(134, 29);
            this.btnThreadPool.TabIndex = 6;
            this.btnThreadPool.Text = "ThreadPool";
            this.btnThreadPool.UseVisualStyleBackColor = true;
            this.btnThreadPool.Click += new System.EventHandler(this.btnThreadPool_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(60, 138);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(127, 27);
            this.textBox1.TabIndex = 7;
            // 
            // btnAwaitAsync
            // 
            this.btnAwaitAsync.Location = new System.Drawing.Point(492, 26);
            this.btnAwaitAsync.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAwaitAsync.Name = "btnAwaitAsync";
            this.btnAwaitAsync.Size = new System.Drawing.Size(156, 27);
            this.btnAwaitAsync.TabIndex = 8;
            this.btnAwaitAsync.Text = "AwaitAsync";
            this.btnAwaitAsync.UseVisualStyleBackColor = true;
            this.btnAwaitAsync.Click += new System.EventHandler(this.btnAwaitAsync_Click);
            // 
            // textAsyncResult
            // 
            this.textAsyncResult.Location = new System.Drawing.Point(492, 80);
            this.textAsyncResult.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textAsyncResult.Name = "textAsyncResult";
            this.textAsyncResult.Size = new System.Drawing.Size(154, 27);
            this.textAsyncResult.TabIndex = 10;
            // 
            // FrmThread
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 222);
            this.Controls.Add(this.textAsyncResult);
            this.Controls.Add(this.btnAwaitAsync);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnThreadPool);
            this.Controls.Add(this.btnThread);
            this.Controls.Add(this.btnTaskAdvanced);
            this.Controls.Add(this.btnParallel);
            this.Controls.Add(this.btnTask);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmThread";
            this.Text = "多线程";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_async;
        private System.Windows.Forms.Button asnyc;
        private System.Windows.Forms.Button btnTask;
        private System.Windows.Forms.Button btnParallel;
        private System.Windows.Forms.Button btnTaskAdvanced;
        private System.Windows.Forms.Button btnThread;
        private System.Windows.Forms.Button btnThreadPool;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnAwaitAsync;
        private System.Windows.Forms.TextBox textAsyncResult;
    }
}

