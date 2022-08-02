namespace Track_ShuttleRun
{
    partial class DialogMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogMessage));
            this.Toast = new System.Windows.Forms.PictureBox();
            this.timer_Close = new System.Windows.Forms.Timer(this.components);
            this.btnCloseMessage = new System.Windows.Forms.Button();
            this.textMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Toast)).BeginInit();
            this.SuspendLayout();
            // 
            // Toast
            // 
            this.Toast.BackColor = System.Drawing.Color.Transparent;
            this.Toast.Image = ((System.Drawing.Image)(resources.GetObject("Toast.Image")));
            this.Toast.Location = new System.Drawing.Point(2, 2);
            this.Toast.Name = "Toast";
            this.Toast.Size = new System.Drawing.Size(488, 92);
            this.Toast.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Toast.TabIndex = 0;
            this.Toast.TabStop = false;
            // 
            // timer_Close
            // 
            this.timer_Close.Interval = 10000;
            this.timer_Close.Tick += new System.EventHandler(this.timer_Close_Tick);
            // 
            // btnCloseMessage
            // 
            this.btnCloseMessage.BackColor = System.Drawing.Color.White;
            this.btnCloseMessage.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCloseMessage.FlatAppearance.BorderSize = 0;
            this.btnCloseMessage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCloseMessage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnCloseMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseMessage.ForeColor = System.Drawing.Color.White;
            this.btnCloseMessage.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseMessage.Image")));
            this.btnCloseMessage.Location = new System.Drawing.Point(429, 17);
            this.btnCloseMessage.Name = "btnCloseMessage";
            this.btnCloseMessage.Size = new System.Drawing.Size(27, 21);
            this.btnCloseMessage.TabIndex = 5;
            this.btnCloseMessage.UseVisualStyleBackColor = false;
            this.btnCloseMessage.Click += new System.EventHandler(this.btnCloseMessage_Click);
            // 
            // textMessage
            // 
            this.textMessage.AutoSize = true;
            this.textMessage.BackColor = System.Drawing.Color.White;
            this.textMessage.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textMessage.Location = new System.Drawing.Point(57, 40);
            this.textMessage.Name = "textMessage";
            this.textMessage.Size = new System.Drawing.Size(93, 29);
            this.textMessage.TabIndex = 4;
            this.textMessage.Text = "Message";
            // 
            // DialogMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(490, 94);
            this.Controls.Add(this.btnCloseMessage);
            this.Controls.Add(this.textMessage);
            this.Controls.Add(this.Toast);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(1401, 934);
            this.Name = "DialogMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "DialogMessage";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.DialogMessage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Toast)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Toast;
        private System.Windows.Forms.Timer timer_Close;
        private System.Windows.Forms.Button btnCloseMessage;
        private System.Windows.Forms.Label textMessage;
    }
}