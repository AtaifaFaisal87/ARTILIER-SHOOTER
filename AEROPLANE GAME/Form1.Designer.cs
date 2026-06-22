namespace AEROPLANE_GAME
{
    partial class form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form1));
            this.MovebgTimer = new System.Windows.Forms.Timer(this.components);
            this.ArtilierXE = new System.Windows.Forms.PictureBox();
            this.LeftMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.RightMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.UpMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.DownMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.MoveMunitionsTimer = new System.Windows.Forms.Timer(this.components);
            this.MoveEnemiesTimer = new System.Windows.Forms.Timer(this.components);
            this.MoveEnemiesMunitionTimer = new System.Windows.Forms.Timer(this.components);
            this.label = new System.Windows.Forms.Label();
            this.EXITBUTTON = new System.Windows.Forms.Button();
            this.STARTBUTTON = new System.Windows.Forms.Button();
            this.levellbl = new System.Windows.Forms.Label();
            this.scorelbl = new System.Windows.Forms.Label();
            this.SCOREtext = new System.Windows.Forms.Label();
            this.LEVELtext = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ArtilierXE)).BeginInit();
            this.SuspendLayout();
            // 
            // MovebgTimer
            // 
            this.MovebgTimer.Enabled = true;
            this.MovebgTimer.Interval = 16;
            this.MovebgTimer.Tick += new System.EventHandler(this.MoveBgTimer_Tick);
            // 
            // ArtilierXE
            // 
            this.ArtilierXE.BackColor = System.Drawing.Color.Transparent;
            this.ArtilierXE.Image = global::AEROPLANE_GAME.Properties.Resources.player;
            this.ArtilierXE.Location = new System.Drawing.Point(268, 382);
            this.ArtilierXE.Name = "ArtilierXE";
            this.ArtilierXE.Size = new System.Drawing.Size(50, 50);
            this.ArtilierXE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ArtilierXE.TabIndex = 1;
            this.ArtilierXE.TabStop = false;
            this.ArtilierXE.Click += new System.EventHandler(this.ArtilierXE_Click);
            // 
            // LeftMoveTimer
            // 
            this.LeftMoveTimer.Interval = 10;
            this.LeftMoveTimer.Tick += new System.EventHandler(this.LeftMoveTimer_Tick);
            // 
            // RightMoveTimer
            // 
            this.RightMoveTimer.Interval = 10;
            this.RightMoveTimer.Tick += new System.EventHandler(this.RightMoveTimer_Tick);
            // 
            // UpMoveTimer
            // 
            this.UpMoveTimer.Interval = 10;
            this.UpMoveTimer.Tick += new System.EventHandler(this.UpMoveTimer_Tick);
            // 
            // DownMoveTimer
            // 
            this.DownMoveTimer.Interval = 10;
            this.DownMoveTimer.Tick += new System.EventHandler(this.DownMoveTimer_Tick);
            // 
            // MoveMunitionsTimer
            // 
            this.MoveMunitionsTimer.Enabled = true;
            this.MoveMunitionsTimer.Interval = 20;
            this.MoveMunitionsTimer.Tick += new System.EventHandler(this.MoveMunitionsTimer_Tick);
            // 
            // MoveEnemiesTimer
            // 
            this.MoveEnemiesTimer.Enabled = true;
            this.MoveEnemiesTimer.Tick += new System.EventHandler(this.MoveEnemiesTimer_Tick);
            // 
            // MoveEnemiesMunitionTimer
            // 
            this.MoveEnemiesMunitionTimer.Enabled = true;
            this.MoveEnemiesMunitionTimer.Interval = 20;
            this.MoveEnemiesMunitionTimer.Tick += new System.EventHandler(this.MoveEnemiesMunitionTimer_Tick);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label.Location = new System.Drawing.Point(161, 121);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(232, 68);
            this.label.TabIndex = 4;
            this.label.Text = "LABEL";
            this.label.Visible = false;
            this.label.Click += new System.EventHandler(this.label_Click);
            // 
            // EXITBUTTON
            // 
            this.EXITBUTTON.BackColor = System.Drawing.Color.MidnightBlue;
            this.EXITBUTTON.Font = new System.Drawing.Font("MS Reference Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EXITBUTTON.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.EXITBUTTON.Location = new System.Drawing.Point(209, 290);
            this.EXITBUTTON.Name = "EXITBUTTON";
            this.EXITBUTTON.Size = new System.Drawing.Size(164, 48);
            this.EXITBUTTON.TabIndex = 5;
            this.EXITBUTTON.Text = "EXIT";
            this.EXITBUTTON.UseVisualStyleBackColor = false;
            this.EXITBUTTON.Visible = false;
            this.EXITBUTTON.Click += new System.EventHandler(this.EXITBUTTON_Click);
            // 
            // STARTBUTTON
            // 
            this.STARTBUTTON.BackColor = System.Drawing.Color.MidnightBlue;
            this.STARTBUTTON.Font = new System.Drawing.Font("MS Reference Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.STARTBUTTON.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.STARTBUTTON.Location = new System.Drawing.Point(209, 225);
            this.STARTBUTTON.Name = "STARTBUTTON";
            this.STARTBUTTON.Size = new System.Drawing.Size(164, 48);
            this.STARTBUTTON.TabIndex = 6;
            this.STARTBUTTON.Text = "START";
            this.STARTBUTTON.UseVisualStyleBackColor = false;
            this.STARTBUTTON.Visible = false;
            this.STARTBUTTON.Click += new System.EventHandler(this.STARTBUTTON_Click);
            // 
            // levellbl
            // 
            this.levellbl.AutoSize = true;
            this.levellbl.Font = new System.Drawing.Font("Pristina", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levellbl.ForeColor = System.Drawing.Color.Gold;
            this.levellbl.Location = new System.Drawing.Point(504, 40);
            this.levellbl.Name = "levellbl";
            this.levellbl.Size = new System.Drawing.Size(26, 31);
            this.levellbl.TabIndex = 7;
            this.levellbl.Text = "L";
            this.levellbl.Click += new System.EventHandler(this.label1_Click);
            // 
            // scorelbl
            // 
            this.scorelbl.AutoSize = true;
            this.scorelbl.Font = new System.Drawing.Font("Pristina", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scorelbl.ForeColor = System.Drawing.Color.Gold;
            this.scorelbl.Location = new System.Drawing.Point(24, 40);
            this.scorelbl.Name = "scorelbl";
            this.scorelbl.Size = new System.Drawing.Size(28, 31);
            this.scorelbl.TabIndex = 8;
            this.scorelbl.Text = "S";
            this.scorelbl.Click += new System.EventHandler(this.scorelbl_Click);
            // 
            // SCOREtext
            // 
            this.SCOREtext.AutoSize = true;
            this.SCOREtext.Font = new System.Drawing.Font("Pristina", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SCOREtext.ForeColor = System.Drawing.Color.Gold;
            this.SCOREtext.Location = new System.Drawing.Point(-2, 9);
            this.SCOREtext.Name = "SCOREtext";
            this.SCOREtext.Size = new System.Drawing.Size(88, 31);
            this.SCOREtext.TabIndex = 9;
            this.SCOREtext.Text = "SCORE";
            // 
            // LEVELtext
            // 
            this.LEVELtext.AutoSize = true;
            this.LEVELtext.Font = new System.Drawing.Font("Pristina", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LEVELtext.ForeColor = System.Drawing.Color.Gold;
            this.LEVELtext.Location = new System.Drawing.Point(475, 9);
            this.LEVELtext.Name = "LEVELtext";
            this.LEVELtext.Size = new System.Drawing.Size(89, 31);
            this.LEVELtext.TabIndex = 10;
            this.LEVELtext.Text = "LEVEL ";
            this.LEVELtext.Click += new System.EventHandler(this.LEVELtext_Click);
            // 
            // form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(582, 453);
            this.Controls.Add(this.LEVELtext);
            this.Controls.Add(this.SCOREtext);
            this.Controls.Add(this.scorelbl);
            this.Controls.Add(this.levellbl);
            this.Controls.Add(this.STARTBUTTON);
            this.Controls.Add(this.EXITBUTTON);
            this.Controls.Add(this.label);
            this.Controls.Add(this.ArtilierXE);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(600, 500);
            this.Name = "form1";
            this.Text = "ARTILIER SHOOTER";
            this.Load += new System.EventHandler(this.form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.ArtilierXE)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer MovebgTimer;
        private System.Windows.Forms.PictureBox ArtilierXE;
        private System.Windows.Forms.Timer LeftMoveTimer;
        private System.Windows.Forms.Timer RightMoveTimer;
        private System.Windows.Forms.Timer UpMoveTimer;
        private System.Windows.Forms.Timer DownMoveTimer;
        private System.Windows.Forms.Timer MoveMunitionsTimer;
        private System.Windows.Forms.Timer MoveEnemiesTimer;
        private System.Windows.Forms.Timer MoveEnemiesMunitionTimer;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button EXITBUTTON;
        private System.Windows.Forms.Button STARTBUTTON;
        private System.Windows.Forms.Label levellbl;
        private System.Windows.Forms.Label scorelbl;
        private System.Windows.Forms.Label SCOREtext;
        private System.Windows.Forms.Label LEVELtext;
    }
}

