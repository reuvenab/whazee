namespace wazer
{
    partial class Form1
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
            this.Check = new System.Windows.Forms.Button();
            this.Routes = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // Check
            // 
            this.Check.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Check.Location = new System.Drawing.Point(869, 626);
            this.Check.Name = "Check";
            this.Check.Size = new System.Drawing.Size(202, 59);
            this.Check.TabIndex = 0;
            this.Check.Text = "Check";
            this.Check.UseVisualStyleBackColor = true;
            this.Check.Click += new System.EventHandler(this.Check_Click);
            // 
            // Routes
            // 
            this.Routes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Routes.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Routes.Location = new System.Drawing.Point(12, 12);
            this.Routes.Name = "Routes";
            this.Routes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Routes.Size = new System.Drawing.Size(1059, 597);
            this.Routes.TabIndex = 1;
            this.Routes.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 697);
            this.Controls.Add(this.Routes);
            this.Controls.Add(this.Check);
            this.Name = "Form1";
            this.Text = "Wazer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Check;
        private System.Windows.Forms.ListView Routes;
    }
}

