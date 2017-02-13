namespace whazee
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
            this.Routes1 = new System.Windows.Forms.ListView();
            this.Routes = new System.Windows.Forms.TabControl();
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
            // Routes1
            // 
            this.Routes1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Routes1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Routes1.Location = new System.Drawing.Point(12, 495);
            this.Routes1.Name = "Routes1";
            this.Routes1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Routes1.Size = new System.Drawing.Size(1059, 114);
            this.Routes1.TabIndex = 1;
            this.Routes1.UseCompatibleStateImageBehavior = false;
            // 
            // Routes
            // 
            this.Routes.Location = new System.Drawing.Point(12, 12);
            this.Routes.Name = "Routes";
            this.Routes.SelectedIndex = 0;
            this.Routes.Size = new System.Drawing.Size(1059, 477);
            this.Routes.TabIndex = 2;
            this.Routes.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Routes_DrawItem);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 697);
            this.Controls.Add(this.Routes);
            this.Controls.Add(this.Routes1);
            this.Controls.Add(this.Check);
            this.Name = "Form1";
            this.Text = "Whazee";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Check;
        private System.Windows.Forms.ListView Routes1;
        private System.Windows.Forms.TabControl Routes;
    }
}

