namespace Pelotas
{
    partial class Pelotas
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
            this.PCT_CANVAS = new System.Windows.Forms.PictureBox();
            this.TIMER = new System.Windows.Forms.Timer(this.components);
            this.firstplayer = new System.Windows.Forms.Button();
            this.secondplayer = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PCT_CANVAS)).BeginInit();
            this.SuspendLayout();
            // 
            // PCT_CANVAS
            // 
            this.PCT_CANVAS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PCT_CANVAS.Location = new System.Drawing.Point(0, 0);
            this.PCT_CANVAS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PCT_CANVAS.Name = "PCT_CANVAS";
            this.PCT_CANVAS.Size = new System.Drawing.Size(1520, 957);
            this.PCT_CANVAS.TabIndex = 0;
            this.PCT_CANVAS.TabStop = false;
            // 
            // TIMER
            // 
            this.TIMER.Enabled = true;
            this.TIMER.Interval = 10;
            this.TIMER.Tick += new System.EventHandler(this.TIMER_Tick);
            // 
            // firstplayer
            // 
            this.firstplayer.Location = new System.Drawing.Point(1278, 90);
            this.firstplayer.Name = "firstplayer";
            this.firstplayer.Size = new System.Drawing.Size(91, 64);
            this.firstplayer.TabIndex = 1;
            this.firstplayer.Text = "FirstPlayerTurn";
            this.firstplayer.UseVisualStyleBackColor = true;
            this.firstplayer.Click += new System.EventHandler(this.firstplayer_Click);
            // 
            // secondplayer
            // 
            this.secondplayer.Location = new System.Drawing.Point(1278, 191);
            this.secondplayer.Name = "secondplayer";
            this.secondplayer.Size = new System.Drawing.Size(91, 64);
            this.secondplayer.TabIndex = 2;
            this.secondplayer.Text = "SecondPlayerTurn";
            this.secondplayer.UseVisualStyleBackColor = true;
            this.secondplayer.Click += new System.EventHandler(this.secondplayer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1054, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
           
            // 
            // Pelotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1520, 957);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.secondplayer);
            this.Controls.Add(this.firstplayer);
            this.Controls.Add(this.PCT_CANVAS);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Pelotas";
            this.Text = "Pelotas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Pelotas_Load);
            this.SizeChanged += new System.EventHandler(this.Pelotas_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.PCT_CANVAS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PCT_CANVAS;
        private System.Windows.Forms.Timer TIMER;
        private System.Windows.Forms.Button firstplayer;
        private System.Windows.Forms.Button secondplayer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
    }
}