namespace VVS_Desktop_mit_Py
{
    partial class FormStations
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
            stations_text = new TextBox();
            SuspendLayout();
            // 
            // stations_text
            // 
            stations_text.BackColor = Color.LightGray;
            stations_text.BorderStyle = BorderStyle.None;
            stations_text.Location = new Point(1, -1);
            stations_text.Multiline = true;
            stations_text.Name = "stations_text";
            stations_text.ReadOnly = true;
            stations_text.ScrollBars = ScrollBars.Vertical;
            stations_text.Size = new Size(324, 588);
            stations_text.TabIndex = 0;
            // 
            // FormStations
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.LightGray;
            ClientSize = new Size(324, 586);
            Controls.Add(stations_text);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormStations";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Stationen";
            TopMost = true;
            Load += FormStations_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox stations_text;
    }
}