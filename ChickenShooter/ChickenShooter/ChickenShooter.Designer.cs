namespace ChickenShooter
{
    partial class ChickenShooter
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
            this.IblScore = new System.Windows.Forms.Label();
            this.BulletTm = new System.Windows.Forms.Timer(this.components);
            this.chickensTm = new System.Windows.Forms.Timer(this.components);
            this.eggsTm = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // IblScore
            // 
            this.IblScore.AutoSize = true;
            this.IblScore.Location = new System.Drawing.Point(22, 9);
            this.IblScore.Name = "IblScore";
            this.IblScore.Size = new System.Drawing.Size(150, 31);
            this.IblScore.TabIndex = 0;
            this.IblScore.Text = "Score: 0";
            // 
            // BulletTm
            // 
            this.BulletTm.Enabled = true;
            this.BulletTm.Interval = 20;
            this.BulletTm.Tick += new System.EventHandler(this.BulletsTm_Tick);
            // 
            // chickensTm
            // 
            this.chickensTm.Enabled = true;
            this.chickensTm.Interval = 20;
            this.chickensTm.Tick += new System.EventHandler(this.chickensTm_Tick);
            // 
            // eggsTm
            // 
            this.eggsTm.Enabled = true;
            this.eggsTm.Tick += new System.EventHandler(this.eggsTm_Tick);
            // 
            // ChickenShooter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = global::ChickenShooter.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.IblScore);
            this.Font = new System.Drawing.Font("Courier New", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "ChickenShooter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ChickenShooter_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChickenShooter_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ChickenShooter_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label IblScore;
        private System.Windows.Forms.Timer BulletTm;
        private System.Windows.Forms.Timer chickensTm;
        private System.Windows.Forms.Timer eggsTm;
    }
}

