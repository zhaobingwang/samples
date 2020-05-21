namespace CodeSnippets.Winform
{
    partial class HZHCalendar
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
            this.ucDatePickerExt1 = new HZH_Controls.Controls.UCDatePickerExt();
            this.ucDatePickerExt2 = new HZH_Controls.Controls.UCDatePickerExt();
            this.ucDatePickerExt3 = new HZH_Controls.Controls.UCDatePickerExt();
            this.SuspendLayout();
            // 
            // ucDatePickerExt1
            // 
            this.ucDatePickerExt1.BackColor = System.Drawing.Color.White;
            this.ucDatePickerExt1.ConerRadius = 5;
            this.ucDatePickerExt1.CurrentTime = new System.DateTime(2020, 5, 14, 16, 5, 57, 0);
            this.ucDatePickerExt1.FillColor = System.Drawing.Color.Transparent;
            this.ucDatePickerExt1.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucDatePickerExt1.IsRadius = true;
            this.ucDatePickerExt1.IsShowRect = true;
            this.ucDatePickerExt1.Location = new System.Drawing.Point(13, 14);
            this.ucDatePickerExt1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucDatePickerExt1.Name = "ucDatePickerExt1";
            this.ucDatePickerExt1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.ucDatePickerExt1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ucDatePickerExt1.RectWidth = 1;
            this.ucDatePickerExt1.Size = new System.Drawing.Size(336, 39);
            this.ucDatePickerExt1.TabIndex = 0;
            this.ucDatePickerExt1.TimeFontSize = 20;
            this.ucDatePickerExt1.TimeType = HZH_Controls.Controls.DateTimePickerType.DateTime;
            // 
            // ucDatePickerExt2
            // 
            this.ucDatePickerExt2.BackColor = System.Drawing.Color.White;
            this.ucDatePickerExt2.ConerRadius = 5;
            this.ucDatePickerExt2.CurrentTime = new System.DateTime(2020, 5, 14, 16, 6, 59, 0);
            this.ucDatePickerExt2.FillColor = System.Drawing.Color.Transparent;
            this.ucDatePickerExt2.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucDatePickerExt2.IsRadius = true;
            this.ucDatePickerExt2.IsShowRect = true;
            this.ucDatePickerExt2.Location = new System.Drawing.Point(13, 79);
            this.ucDatePickerExt2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucDatePickerExt2.Name = "ucDatePickerExt2";
            this.ucDatePickerExt2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.ucDatePickerExt2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ucDatePickerExt2.RectWidth = 1;
            this.ucDatePickerExt2.Size = new System.Drawing.Size(211, 39);
            this.ucDatePickerExt2.TabIndex = 1;
            this.ucDatePickerExt2.TimeFontSize = 20;
            this.ucDatePickerExt2.TimeType = HZH_Controls.Controls.DateTimePickerType.Date;
            // 
            // ucDatePickerExt3
            // 
            this.ucDatePickerExt3.BackColor = System.Drawing.Color.White;
            this.ucDatePickerExt3.ConerRadius = 5;
            this.ucDatePickerExt3.CurrentTime = new System.DateTime(2020, 5, 14, 16, 7, 23, 0);
            this.ucDatePickerExt3.FillColor = System.Drawing.Color.Transparent;
            this.ucDatePickerExt3.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucDatePickerExt3.IsRadius = true;
            this.ucDatePickerExt3.IsShowRect = true;
            this.ucDatePickerExt3.Location = new System.Drawing.Point(13, 144);
            this.ucDatePickerExt3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucDatePickerExt3.Name = "ucDatePickerExt3";
            this.ucDatePickerExt3.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.ucDatePickerExt3.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ucDatePickerExt3.RectWidth = 1;
            this.ucDatePickerExt3.Size = new System.Drawing.Size(141, 39);
            this.ucDatePickerExt3.TabIndex = 2;
            this.ucDatePickerExt3.TimeFontSize = 20;
            this.ucDatePickerExt3.TimeType = HZH_Controls.Controls.DateTimePickerType.Time;
            // 
            // HZHCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ucDatePickerExt3);
            this.Controls.Add(this.ucDatePickerExt2);
            this.Controls.Add(this.ucDatePickerExt1);
            this.Name = "HZHCalendar";
            this.Text = "HZHCalendar";
            this.ResumeLayout(false);

        }

        #endregion

        private HZH_Controls.Controls.UCDatePickerExt ucDatePickerExt1;
        private HZH_Controls.Controls.UCDatePickerExt ucDatePickerExt2;
        private HZH_Controls.Controls.UCDatePickerExt ucDatePickerExt3;
    }
}