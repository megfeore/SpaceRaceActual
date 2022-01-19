
namespace Space_Race
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
            this.components = new System.ComponentModel.Container();
            this.gameLoop = new System.Windows.Forms.Timer(this.components);
            this.score1Label = new System.Windows.Forms.Label();
            this.score2Label = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameLoop
            // 
            this.gameLoop.Tick += new System.EventHandler(this.gameLoop_Tick);
            // 
            // score1Label
            // 
            this.score1Label.BackColor = System.Drawing.Color.Transparent;
            this.score1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score1Label.ForeColor = System.Drawing.SystemColors.Control;
            this.score1Label.Location = new System.Drawing.Point(12, 368);
            this.score1Label.Name = "score1Label";
            this.score1Label.Size = new System.Drawing.Size(128, 23);
            this.score1Label.TabIndex = 0;
            this.score1Label.Text = "Player 1 Score:";
            this.score1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // score2Label
            // 
            this.score2Label.BackColor = System.Drawing.Color.Transparent;
            this.score2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score2Label.ForeColor = System.Drawing.SystemColors.Control;
            this.score2Label.Location = new System.Drawing.Point(472, 368);
            this.score2Label.Name = "score2Label";
            this.score2Label.Size = new System.Drawing.Size(116, 23);
            this.score2Label.TabIndex = 1;
            this.score2Label.Text = "Player 2 Score:";
            this.score2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.titleLabel.Location = new System.Drawing.Point(12, 131);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(576, 47);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "title";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.subtitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtitleLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.subtitleLabel.Location = new System.Drawing.Point(117, 201);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(352, 23);
            this.subtitleLabel.TabIndex = 3;
            this.subtitleLabel.Text = "subtitle";
            this.subtitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.subtitleLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.score2Label);
            this.Controls.Add(this.score1Label);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameLoop;
        private System.Windows.Forms.Label score1Label;
        private System.Windows.Forms.Label score2Label;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subtitleLabel;
    }
}

