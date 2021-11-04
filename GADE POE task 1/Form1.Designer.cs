
namespace GADE_POE_task_1
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.MapLabel = new System.Windows.Forms.Label();
            this.buttonUP1 = new System.Windows.Forms.Button();
            this.buttonRIGHT1 = new System.Windows.Forms.Button();
            this.buttonLEFT1 = new System.Windows.Forms.Button();
            this.buttonDown1 = new System.Windows.Forms.Button();
            this.groupBoxAttacking = new System.Windows.Forms.GroupBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.attack_richTextBox = new System.Windows.Forms.RichTextBox();
            this.button_Attack = new System.Windows.Forms.Button();
            this.groupBox_Player_Stats = new System.Windows.Forms.GroupBox();
            this.richTextBox_Player_Stats = new System.Windows.Forms.RichTextBox();
            this.select_enemy = new System.Windows.Forms.ComboBox();
            this.groupBoxAttacking.SuspendLayout();
            this.groupBox_Player_Stats.SuspendLayout();
            this.SuspendLayout();
            // 
            // MapLabel
            // 
            this.MapLabel.AccessibleName = "MapLabel";
            this.MapLabel.AutoSize = true;
            this.MapLabel.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MapLabel.Location = new System.Drawing.Point(27, 39);
            this.MapLabel.Name = "MapLabel";
            this.MapLabel.Size = new System.Drawing.Size(38, 18);
            this.MapLabel.TabIndex = 0;
            this.MapLabel.Text = "Map";
            this.MapLabel.Click += new System.EventHandler(this.MapLabel_Click);
            // 
            // buttonUP1
            // 
            this.buttonUP1.Location = new System.Drawing.Point(649, 398);
            this.buttonUP1.Name = "buttonUP1";
            this.buttonUP1.Size = new System.Drawing.Size(40, 23);
            this.buttonUP1.TabIndex = 2;
            this.buttonUP1.Text = "^";
            this.buttonUP1.UseVisualStyleBackColor = true;
            this.buttonUP1.Click += new System.EventHandler(this.buttonUP1_Click);
            // 
            // buttonRIGHT1
            // 
            this.buttonRIGHT1.Location = new System.Drawing.Point(702, 425);
            this.buttonRIGHT1.Name = "buttonRIGHT1";
            this.buttonRIGHT1.Size = new System.Drawing.Size(40, 23);
            this.buttonRIGHT1.TabIndex = 3;
            this.buttonRIGHT1.Text = ">";
            this.buttonRIGHT1.UseVisualStyleBackColor = true;
            this.buttonRIGHT1.Click += new System.EventHandler(this.buttonRIGHT1_Click);
            // 
            // buttonLEFT1
            // 
            this.buttonLEFT1.Location = new System.Drawing.Point(594, 425);
            this.buttonLEFT1.Name = "buttonLEFT1";
            this.buttonLEFT1.Size = new System.Drawing.Size(40, 23);
            this.buttonLEFT1.TabIndex = 4;
            this.buttonLEFT1.Text = "<";
            this.buttonLEFT1.UseVisualStyleBackColor = true;
            this.buttonLEFT1.Click += new System.EventHandler(this.buttonLEFT1_Click);
            // 
            // buttonDown1
            // 
            this.buttonDown1.Location = new System.Drawing.Point(649, 457);
            this.buttonDown1.Name = "buttonDown1";
            this.buttonDown1.Size = new System.Drawing.Size(40, 23);
            this.buttonDown1.TabIndex = 5;
            this.buttonDown1.Text = "v";
            this.buttonDown1.UseVisualStyleBackColor = true;
            this.buttonDown1.Click += new System.EventHandler(this.buttonDown1_Click);
            // 
            // groupBoxAttacking
            // 
            this.groupBoxAttacking.Controls.Add(this.richTextBox2);
            this.groupBoxAttacking.Controls.Add(this.attack_richTextBox);
            this.groupBoxAttacking.Controls.Add(this.button_Attack);
            this.groupBoxAttacking.Location = new System.Drawing.Point(552, 108);
            this.groupBoxAttacking.Name = "groupBoxAttacking";
            this.groupBoxAttacking.Size = new System.Drawing.Size(216, 270);
            this.groupBoxAttacking.TabIndex = 6;
            this.groupBoxAttacking.TabStop = false;
            this.groupBoxAttacking.Text = "Attacking";
            this.groupBoxAttacking.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(6, 205);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(204, 59);
            this.richTextBox2.TabIndex = 2;
            this.richTextBox2.Text = "";
            // 
            // attack_richTextBox
            // 
            this.attack_richTextBox.Location = new System.Drawing.Point(6, 22);
            this.attack_richTextBox.Name = "attack_richTextBox";
            this.attack_richTextBox.Size = new System.Drawing.Size(204, 143);
            this.attack_richTextBox.TabIndex = 1;
            this.attack_richTextBox.Text = "";
            // 
            // button_Attack
            // 
            this.button_Attack.Location = new System.Drawing.Point(6, 171);
            this.button_Attack.Name = "button_Attack";
            this.button_Attack.Size = new System.Drawing.Size(204, 28);
            this.button_Attack.TabIndex = 0;
            this.button_Attack.Text = "Attack";
            this.button_Attack.UseVisualStyleBackColor = true;
            this.button_Attack.Click += new System.EventHandler(this.button_Attack_Click);
            // 
            // groupBox_Player_Stats
            // 
            this.groupBox_Player_Stats.Controls.Add(this.richTextBox_Player_Stats);
            this.groupBox_Player_Stats.Location = new System.Drawing.Point(552, 12);
            this.groupBox_Player_Stats.Name = "groupBox_Player_Stats";
            this.groupBox_Player_Stats.Size = new System.Drawing.Size(216, 98);
            this.groupBox_Player_Stats.TabIndex = 8;
            this.groupBox_Player_Stats.TabStop = false;
            this.groupBox_Player_Stats.Text = "Player Stats";
            // 
            // richTextBox_Player_Stats
            // 
            this.richTextBox_Player_Stats.Location = new System.Drawing.Point(6, 22);
            this.richTextBox_Player_Stats.Name = "richTextBox_Player_Stats";
            this.richTextBox_Player_Stats.Size = new System.Drawing.Size(204, 68);
            this.richTextBox_Player_Stats.TabIndex = 0;
            this.richTextBox_Player_Stats.Text = "";
            // 
            // select_enemy
            // 
            this.select_enemy.FormattingEnabled = true;
            this.select_enemy.Items.AddRange(new object[] {
            "Above you",
            "Under you",
            "On your Right",
            "On your Left"});
            this.select_enemy.Location = new System.Drawing.Point(12, 399);
            this.select_enemy.Name = "select_enemy";
            this.select_enemy.Size = new System.Drawing.Size(121, 23);
            this.select_enemy.TabIndex = 9;
            this.select_enemy.SelectedIndexChanged += new System.EventHandler(this.select_enemy_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 509);
            this.Controls.Add(this.select_enemy);
            this.Controls.Add(this.groupBox_Player_Stats);
            this.Controls.Add(this.groupBoxAttacking);
            this.Controls.Add(this.buttonDown1);
            this.Controls.Add(this.buttonLEFT1);
            this.Controls.Add(this.buttonRIGHT1);
            this.Controls.Add(this.buttonUP1);
            this.Controls.Add(this.MapLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxAttacking.ResumeLayout(false);
            this.groupBox_Player_Stats.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label MapLabel;
        private System.Windows.Forms.Button buttonUP1;
        private System.Windows.Forms.Button buttonRIGHT1;
        private System.Windows.Forms.Button buttonLEFT1;
        private System.Windows.Forms.Button buttonDown1;
        private System.Windows.Forms.GroupBox groupBoxAttacking;
        private System.Windows.Forms.Button button_Attack;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox attack_richTextBox;
        private System.Windows.Forms.GroupBox groupBox_Player_Stats;
        private System.Windows.Forms.RichTextBox richTextBox_Player_Stats;
        private System.Windows.Forms.ComboBox select_enemy;
    }
}

