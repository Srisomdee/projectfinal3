
namespace projectfinal3
{
    partial class pee
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
            this.User = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.pic_gun = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.name_file = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_gun)).BeginInit();
            this.SuspendLayout();
            // 
            // User
            // 
            this.User.Location = new System.Drawing.Point(267, 158);
            this.User.Name = "User";
            this.User.Size = new System.Drawing.Size(313, 26);
            this.User.TabIndex = 0;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(267, 223);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(313, 26);
            this.password.TabIndex = 1;
            // 
            // pic_gun
            // 
            this.pic_gun.Location = new System.Drawing.Point(284, 278);
            this.pic_gun.Name = "pic_gun";
            this.pic_gun.Size = new System.Drawing.Size(272, 179);
            this.pic_gun.TabIndex = 2;
            this.pic_gun.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(378, 530);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 42);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(576, 465);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 42);
            this.button2.TabIndex = 4;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // name_file
            // 
            this.name_file.Location = new System.Drawing.Point(284, 473);
            this.name_file.Name = "name_file";
            this.name_file.Size = new System.Drawing.Size(286, 26);
            this.name_file.TabIndex = 5;
            // 
            // pee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 599);
            this.Controls.Add(this.name_file);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pic_gun);
            this.Controls.Add(this.password);
            this.Controls.Add(this.User);
            this.Name = "pee";
            this.Text = "pee";
            this.Load += new System.EventHandler(this.pee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_gun)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox User;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.PictureBox pic_gun;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox name_file;
    }
}