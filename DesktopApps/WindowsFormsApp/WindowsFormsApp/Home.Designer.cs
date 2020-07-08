namespace WindowsFormsApp
{
    partial class Home
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
            this.userInfoHead1 = new ControlLib.UserInfoHead();
            this.SuspendLayout();
            // 
            // userInfoHead1
            // 
            this.userInfoHead1.Address = "啊";
            this.userInfoHead1.CellPhoneNumber = "1";
            this.userInfoHead1.Location = new System.Drawing.Point(62, 59);
            this.userInfoHead1.Name = "userInfoHead1";
            this.userInfoHead1.Sex = "sex";
            this.userInfoHead1.Size = new System.Drawing.Size(848, 160);
            this.userInfoHead1.TabIndex = 0;
            this.userInfoHead1.UserName = "name";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 614);
            this.Controls.Add(this.userInfoHead1);
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlLib.UserInfoHead userInfoHead1;
    }
}

