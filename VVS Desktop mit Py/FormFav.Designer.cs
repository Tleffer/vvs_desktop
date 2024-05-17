namespace VVS_Desktop_mit_Py
{
    partial class FormFav
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
            label1 = new Label();
            label2 = new Label();
            fav1_box = new TextBox();
            fav2_box = new TextBox();
            ok = new Button();
            cancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(22, 32);
            label1.Name = "label1";
            label1.Size = new Size(113, 30);
            label1.TabIndex = 0;
            label1.Text = "Favourit 1:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(22, 110);
            label2.Name = "label2";
            label2.Size = new Size(116, 30);
            label2.TabIndex = 1;
            label2.Text = "Favourit 2:";
            // 
            // fav1_box
            // 
            fav1_box.BackColor = SystemColors.ControlDark;
            fav1_box.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fav1_box.Location = new Point(176, 33);
            fav1_box.Name = "fav1_box";
            fav1_box.Size = new Size(324, 33);
            fav1_box.TabIndex = 2;
            // 
            // fav2_box
            // 
            fav2_box.BackColor = SystemColors.ControlDark;
            fav2_box.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fav2_box.Location = new Point(176, 110);
            fav2_box.Name = "fav2_box";
            fav2_box.Size = new Size(324, 33);
            fav2_box.TabIndex = 3;
            // 
            // ok
            // 
            ok.BackColor = SystemColors.ControlDark;
            ok.FlatAppearance.BorderColor = Color.Green;
            ok.FlatAppearance.BorderSize = 2;
            ok.FlatAppearance.MouseDownBackColor = Color.Green;
            ok.FlatAppearance.MouseOverBackColor = Color.Green;
            ok.FlatStyle = FlatStyle.Flat;
            ok.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ok.Location = new Point(379, 163);
            ok.Name = "ok";
            ok.Size = new Size(121, 46);
            ok.TabIndex = 4;
            ok.Text = "OK";
            ok.UseVisualStyleBackColor = false;
            ok.Click += ok_Click;
            // 
            // cancel
            // 
            cancel.BackColor = SystemColors.ControlDark;
            cancel.FlatAppearance.BorderColor = Color.FromArgb(192, 0, 0);
            cancel.FlatAppearance.BorderSize = 2;
            cancel.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 0, 0);
            cancel.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            cancel.FlatStyle = FlatStyle.Flat;
            cancel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cancel.Location = new Point(188, 163);
            cancel.Name = "cancel";
            cancel.Size = new Size(161, 46);
            cancel.TabIndex = 5;
            cancel.Text = "Abbrechen";
            cancel.UseVisualStyleBackColor = false;
            cancel.Click += cancel_Click;
            // 
            // FormFav
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(546, 221);
            Controls.Add(cancel);
            Controls.Add(ok);
            Controls.Add(fav2_box);
            Controls.Add(fav1_box);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormFav";
            ShowIcon = false;
            Text = "FormFav";
            TopMost = true;
            Load += FormFav_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox fav1_box;
        private TextBox fav2_box;
        private Button ok;
        private Button cancel;
    }
}