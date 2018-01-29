namespace BubblePopper
{
    partial class BubblePop
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
            this.components = new System.ComponentModel.Container();
            this.UI_BTN_Play = new System.Windows.Forms.Button();
            this.UI_Timer = new System.Windows.Forms.Timer(this.components);
            this.UI_GB_Difficulty = new System.Windows.Forms.GroupBox();
            this.UI_RB_Hard = new System.Windows.Forms.RadioButton();
            this.UI_RB_Medium = new System.Windows.Forms.RadioButton();
            this.UI_RB_Easy = new System.Windows.Forms.RadioButton();
            this.UI_TB_Score = new System.Windows.Forms.TextBox();
            this.UI_GB_Difficulty.SuspendLayout();
            this.SuspendLayout();
            // 
            // UI_BTN_Play
            // 
            this.UI_BTN_Play.Location = new System.Drawing.Point(66, 115);
            this.UI_BTN_Play.Name = "UI_BTN_Play";
            this.UI_BTN_Play.Size = new System.Drawing.Size(75, 22);
            this.UI_BTN_Play.TabIndex = 0;
            this.UI_BTN_Play.Text = "Start Game";
            this.UI_BTN_Play.UseVisualStyleBackColor = true;
            this.UI_BTN_Play.Click += new System.EventHandler(this.UI_BTN_Play_Click);
            // 
            // UI_Timer
            // 
            this.UI_Timer.Tick += new System.EventHandler(this.UI_Timer_Tick);
            // 
            // UI_GB_Difficulty
            // 
            this.UI_GB_Difficulty.Controls.Add(this.UI_RB_Hard);
            this.UI_GB_Difficulty.Controls.Add(this.UI_RB_Medium);
            this.UI_GB_Difficulty.Controls.Add(this.UI_RB_Easy);
            this.UI_GB_Difficulty.Location = new System.Drawing.Point(50, 12);
            this.UI_GB_Difficulty.Name = "UI_GB_Difficulty";
            this.UI_GB_Difficulty.Size = new System.Drawing.Size(117, 92);
            this.UI_GB_Difficulty.TabIndex = 1;
            this.UI_GB_Difficulty.TabStop = false;
            this.UI_GB_Difficulty.Text = "Difficulty";
            // 
            // UI_RB_Hard
            // 
            this.UI_RB_Hard.AutoSize = true;
            this.UI_RB_Hard.Checked = true;
            this.UI_RB_Hard.Location = new System.Drawing.Point(6, 65);
            this.UI_RB_Hard.Name = "UI_RB_Hard";
            this.UI_RB_Hard.Size = new System.Drawing.Size(48, 17);
            this.UI_RB_Hard.TabIndex = 2;
            this.UI_RB_Hard.TabStop = true;
            this.UI_RB_Hard.Text = "Hard";
            this.UI_RB_Hard.UseVisualStyleBackColor = true;
            // 
            // UI_RB_Medium
            // 
            this.UI_RB_Medium.AutoSize = true;
            this.UI_RB_Medium.Location = new System.Drawing.Point(6, 42);
            this.UI_RB_Medium.Name = "UI_RB_Medium";
            this.UI_RB_Medium.Size = new System.Drawing.Size(62, 17);
            this.UI_RB_Medium.TabIndex = 1;
            this.UI_RB_Medium.Text = "Medium";
            this.UI_RB_Medium.UseVisualStyleBackColor = true;
            // 
            // UI_RB_Easy
            // 
            this.UI_RB_Easy.AutoSize = true;
            this.UI_RB_Easy.Location = new System.Drawing.Point(6, 19);
            this.UI_RB_Easy.Name = "UI_RB_Easy";
            this.UI_RB_Easy.Size = new System.Drawing.Size(48, 17);
            this.UI_RB_Easy.TabIndex = 0;
            this.UI_RB_Easy.Text = "Easy";
            this.UI_RB_Easy.UseVisualStyleBackColor = true;
            // 
            // UI_TB_Score
            // 
            this.UI_TB_Score.Location = new System.Drawing.Point(32, 143);
            this.UI_TB_Score.Name = "UI_TB_Score";
            this.UI_TB_Score.ReadOnly = true;
            this.UI_TB_Score.Size = new System.Drawing.Size(158, 20);
            this.UI_TB_Score.TabIndex = 2;
            // 
            // BubblePop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 182);
            this.Controls.Add(this.UI_TB_Score);
            this.Controls.Add(this.UI_GB_Difficulty);
            this.Controls.Add(this.UI_BTN_Play);
            this.MaximumSize = new System.Drawing.Size(242, 221);
            this.MinimumSize = new System.Drawing.Size(242, 221);
            this.Name = "BubblePop";
            this.Text = "Bubble Pop";
            this.UI_GB_Difficulty.ResumeLayout(false);
            this.UI_GB_Difficulty.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UI_BTN_Play;
        private System.Windows.Forms.Timer UI_Timer;
        private System.Windows.Forms.GroupBox UI_GB_Difficulty;
        private System.Windows.Forms.RadioButton UI_RB_Hard;
        private System.Windows.Forms.RadioButton UI_RB_Medium;
        private System.Windows.Forms.RadioButton UI_RB_Easy;
        private System.Windows.Forms.TextBox UI_TB_Score;
    }
}

