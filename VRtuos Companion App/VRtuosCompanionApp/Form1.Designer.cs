namespace VRtuosCompanionApp
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.OutputCombo = new System.Windows.Forms.ComboBox();
            this.Button = new System.Windows.Forms.Button();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.ConnectionStatusLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.IPTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.InputCombo = new System.Windows.Forms.ComboBox();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Georgia", 55F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(42, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(831, 85);
            this.label1.TabIndex = 0;
            this.label1.Text = "VRtuos Companion App";
            // 
            // OutputCombo
            // 
            this.OutputCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OutputCombo.Font = new System.Drawing.Font("Arial", 14F);
            this.OutputCombo.FormattingEnabled = true;
            this.OutputCombo.Location = new System.Drawing.Point(57, 267);
            this.OutputCombo.Name = "OutputCombo";
            this.OutputCombo.Size = new System.Drawing.Size(349, 30);
            this.OutputCombo.TabIndex = 9;
            this.OutputCombo.SelectedIndexChanged += new System.EventHandler(this.OutputCombo_SelectedIndexChanged);
            // 
            // Button
            // 
            this.Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Button.FlatAppearance.BorderSize = 0;
            this.Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button.Font = new System.Drawing.Font("Arial", 14F);
            this.Button.Location = new System.Drawing.Point(671, 245);
            this.Button.Name = "Button";
            this.Button.Size = new System.Drawing.Size(172, 30);
            this.Button.TabIndex = 5;
            this.Button.Text = "Connect";
            this.Button.UseVisualStyleBackColor = false;
            this.Button.Click += new System.EventHandler(this.Button_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.RefreshButton.FlatAppearance.BorderSize = 0;
            this.RefreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshButton.Font = new System.Drawing.Font("Arial", 14F);
            this.RefreshButton.Location = new System.Drawing.Point(234, 303);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(172, 30);
            this.RefreshButton.TabIndex = 10;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = false;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // ConnectionStatusLabel
            // 
            this.ConnectionStatusLabel.AutoSize = true;
            this.ConnectionStatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.ConnectionStatusLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConnectionStatusLabel.Font = new System.Drawing.Font("Arial", 14F);
            this.ConnectionStatusLabel.ForeColor = System.Drawing.Color.White;
            this.ConnectionStatusLabel.Location = new System.Drawing.Point(650, 278);
            this.ConnectionStatusLabel.Name = "ConnectionStatusLabel";
            this.ConnectionStatusLabel.Size = new System.Drawing.Size(133, 22);
            this.ConnectionStatusLabel.TabIndex = 6;
            this.ConnectionStatusLabel.Text = "Not connected";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Arial", 14F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(53, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 22);
            this.label5.TabIndex = 11;
            this.label5.Text = "Input device:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Arial", 14F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(490, 278);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Connection status:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Arial", 14F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(53, 242);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 22);
            this.label6.TabIndex = 12;
            this.label6.Text = "Output device:";
            // 
            // IPTextbox
            // 
            this.IPTextbox.Font = new System.Drawing.Font("Arial", 14F);
            this.IPTextbox.Location = new System.Drawing.Point(494, 210);
            this.IPTextbox.MaxLength = 15;
            this.IPTextbox.Name = "IPTextbox";
            this.IPTextbox.Size = new System.Drawing.Size(349, 29);
            this.IPTextbox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Arial", 14F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(490, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 22);
            this.label2.TabIndex = 13;
            this.label2.Text = "IP address:";
            // 
            // InputCombo
            // 
            this.InputCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.InputCombo.Font = new System.Drawing.Font("Arial", 14F);
            this.InputCombo.FormattingEnabled = true;
            this.InputCombo.Location = new System.Drawing.Point(57, 209);
            this.InputCombo.Name = "InputCombo";
            this.InputCombo.Size = new System.Drawing.Size(349, 30);
            this.InputCombo.TabIndex = 8;
            this.InputCombo.SelectedIndexChanged += new System.EventHandler(this.InputCombo_SelectedIndexChanged);
            // 
            // Timer
            // 
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Arial", 10F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(491, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(292, 32);
            this.label4.TabIndex = 14;
            this.label4.Text = "Make sure VRtuos is running and your Quest\r\nis connected to the same network.";
            // 
            // Form1
            // 
            this.AcceptButton = this.Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(914, 442);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.OutputCombo);
            this.Controls.Add(this.InputCombo);
            this.Controls.Add(this.Button);
            this.Controls.Add(this.ConnectionStatusLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.IPTextbox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VRtuos Companion App";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Leave += new System.EventHandler(this.Form1_Leave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox OutputCombo;
        private System.Windows.Forms.Button Button;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Label ConnectionStatusLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox IPTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox InputCombo;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Label label4;
    }
}

