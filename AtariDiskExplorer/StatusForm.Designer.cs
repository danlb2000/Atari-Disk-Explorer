
    partial class StatusForm
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
            this.UIErrors = new System.Windows.Forms.TextBox();
            this.UIClose = new System.Windows.Forms.Button();
            this.UIMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UIErrors
            // 
            this.UIErrors.Location = new System.Drawing.Point(12, 29);
            this.UIErrors.Multiline = true;
            this.UIErrors.Name = "UIErrors";
            this.UIErrors.Size = new System.Drawing.Size(349, 221);
            this.UIErrors.TabIndex = 1;
            // 
            // UIClose
            // 
            this.UIClose.Location = new System.Drawing.Point(286, 257);
            this.UIClose.Name = "UIClose";
            this.UIClose.Size = new System.Drawing.Size(75, 23);
            this.UIClose.TabIndex = 2;
            this.UIClose.Text = "Close";
            this.UIClose.UseVisualStyleBackColor = true;
            this.UIClose.Click += new System.EventHandler(this.UIClose_Click);
            // 
            // UIMessage
            // 
            this.UIMessage.AutoSize = true;
            this.UIMessage.Location = new System.Drawing.Point(13, 10);
            this.UIMessage.Name = "UIMessage";
            this.UIMessage.Size = new System.Drawing.Size(35, 13);
            this.UIMessage.TabIndex = 0;
            this.UIMessage.Text = "label1";
            // 
            // StatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 292);
            this.Controls.Add(this.UIClose);
            this.Controls.Add(this.UIErrors);
            this.Controls.Add(this.UIMessage);
            this.Name = "StatusForm";
            this.Text = "StatusForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UIErrors;
        private System.Windows.Forms.Button UIClose;
        private System.Windows.Forms.Label UIMessage;
    }
