namespace VVS_Desktop_mit_Py
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            show_result = new Button();
            other = new RadioButton();
            fav2 = new RadioButton();
            fav1 = new RadioButton();
            output = new TextBox();
            Linie = new TextBox();
            label1 = new Label();
            other_field = new TextBox();
            groupBox1 = new GroupBox();
            button1 = new Button();
            general_serialize = new System.Windows.Forms.Timer(components);
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // show_result
            // 
            show_result.BackColor = Color.DarkOrange;
            show_result.Cursor = Cursors.Hand;
            show_result.FlatStyle = FlatStyle.Flat;
            show_result.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            show_result.ForeColor = Color.Black;
            show_result.Location = new Point(375, 392);
            show_result.Name = "show_result";
            show_result.Size = new Size(496, 69);
            show_result.TabIndex = 0;
            show_result.Text = "Ergebnis Anzeigen";
            show_result.UseVisualStyleBackColor = false;
            show_result.Click += button1_Click;
            // 
            // other
            // 
            other.AutoSize = true;
            other.Font = new Font("Segoe UI", 18F);
            other.ForeColor = SystemColors.ControlLightLight;
            other.Location = new Point(22, 100);
            other.Name = "other";
            other.Size = new Size(234, 36);
            other.TabIndex = 3;
            other.TabStop = true;
            other.Text = "Anderer Startpunkt";
            other.UseVisualStyleBackColor = true;
            other.CheckedChanged += other_CheckedChanged;
            // 
            // fav2
            // 
            fav2.AutoSize = true;
            fav2.Font = new Font("Segoe UI", 18F);
            fav2.ForeColor = SystemColors.ControlLightLight;
            fav2.Location = new Point(22, 58);
            fav2.Name = "fav2";
            fav2.Size = new Size(140, 36);
            fav2.TabIndex = 4;
            fav2.TabStop = true;
            fav2.Text = "favourite2";
            fav2.UseVisualStyleBackColor = true;
            // 
            // fav1
            // 
            fav1.AutoSize = true;
            fav1.Font = new Font("Segoe UI", 18F);
            fav1.ForeColor = SystemColors.ControlLightLight;
            fav1.Location = new Point(22, 16);
            fav1.Name = "fav1";
            fav1.Size = new Size(140, 36);
            fav1.TabIndex = 5;
            fav1.TabStop = true;
            fav1.Text = "favourite1";
            fav1.UseVisualStyleBackColor = true;
            // 
            // output
            // 
            output.BackColor = Color.LightGray;
            output.BorderStyle = BorderStyle.None;
            output.Enabled = false;
            output.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            output.ForeColor = SystemColors.WindowText;
            output.Location = new Point(12, 12);
            output.Multiline = true;
            output.Name = "output";
            output.ReadOnly = true;
            output.ScrollBars = ScrollBars.Vertical;
            output.Size = new Size(1096, 261);
            output.TabIndex = 6;
            output.WordWrap = false;
            // 
            // Linie
            // 
            Linie.BackColor = Color.Silver;
            Linie.BorderStyle = BorderStyle.FixedSingle;
            Linie.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Linie.ForeColor = SystemColors.WindowText;
            Linie.Location = new Point(442, 296);
            Linie.Name = "Linie";
            Linie.Size = new Size(163, 35);
            Linie.TabIndex = 7;
            //Linie.TextChanged += this.Linie_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(375, 299);
            label1.Name = "label1";
            label1.Size = new Size(61, 30);
            label1.TabIndex = 8;
            label1.Text = "Linie:";
            label1.Click += label1_Click;
            // 
            // other_field
            // 
            other_field.BackColor = Color.Silver;
            other_field.BorderStyle = BorderStyle.FixedSingle;
            other_field.Enabled = false;
            other_field.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            other_field.ForeColor = SystemColors.WindowText;
            other_field.Location = new Point(36, 142);
            other_field.Name = "other_field";
            other_field.ReadOnly = true;
            other_field.Size = new Size(213, 27);
            other_field.TabIndex = 9;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(other_field);
            groupBox1.Controls.Add(fav1);
            groupBox1.Controls.Add(fav2);
            groupBox1.Controls.Add(other);
            groupBox1.ForeColor = SystemColors.ControlLightLight;
            groupBox1.Location = new Point(12, 279);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(315, 182);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Startpunkt";
            // 
            // button1
            // 
            button1.BackColor = Color.Silver;
            button1.FlatAppearance.BorderColor = Color.White;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Location = new Point(899, 392);
            button1.Name = "button1";
            button1.Size = new Size(209, 69);
            button1.TabIndex = 11;
            button1.Text = "Favouriten setzen";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // general_serialize
            // 
            general_serialize.Enabled = true;
            general_serialize.Tick += general_serialize_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(1120, 473);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(Linie);
            Controls.Add(output);
            Controls.Add(show_result);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            Text = "VVS Desktop";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button show_result;
        private RadioButton other;
        private RadioButton fav2;
        private RadioButton fav1;
        private TextBox output;
        private TextBox Linie;
        private Label label1;
        private TextBox other_field;
        private GroupBox groupBox1;
        private Button button1;
        private System.Windows.Forms.Timer general_serialize;
    }
}
