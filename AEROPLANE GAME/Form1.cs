using System;
using System.Drawing;
using System.Windows.Forms;
using MediaPlayer; // Import the Windows Media Player library to play music and sound effects in the game
using WMPLib; // Use the COM interop Windows Media Player namespace explicitly

namespace AEROPLANE_GAME
{

    public partial class form1 : Form
    {
        // Use the COM interop Windows Media Player type to avoid runtime binder errors
        WMPLib.WindowsMediaPlayer gameMedia;
        WMPLib.WindowsMediaPlayer shootingMedia;
        WMPLib.WindowsMediaPlayer explosionMedia;

        PictureBox[] stars; // Array to hold the star PictureBoxes

        PictureBox[] munitions;
        int munitionspeed;

        PictureBox[] enemies;
        int enemiespeed;

        PictureBox[] enemiesMunition;
        int enemiesMunitionspeed;

        int backgroudspeed; // Variable to control the speed of the background movement
        int ArtilierXEspeed;// Variable to control the speed of the player movement

        // Variables to control the initial position and spacing of the enemy PictureBoxes
        int enemyStartX;
        int enemySpacing;

        Random rnd; // Random object to generate random numbers for star positions and speeds
        
        int score; // Variable to keep track of the player's score
        int level; // Variable to keep track of the current level of the game
        int difficulty; // Variable to control the difficulty of the game, which can affect the speed of enemies and munitions
        bool pause; // Variable to control whether the game is paused or not
        bool gameOver; // Variable to control whether the game is over or not

        public form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            //create WMP objects (explicitly use WMPLib.WindowsMediaPlayer)
            gameMedia = new WMPLib.WindowsMediaPlayer();
            shootingMedia = new WMPLib.WindowsMediaPlayer();
            explosionMedia = new WMPLib.WindowsMediaPlayer();

            //LOAD MUSIC
            gameMedia.URL = @"D:\C#\AEROPLANE GAME\AEROPLANE GAME\bin\Debug\sound\GameSong.mp3";
            shootingMedia.URL = @"D:\C#\AEROPLANE GAME\AEROPLANE GAME\bin\Debug\sound\shoot.mp3";
            explosionMedia.URL = @"D:\C#\AEROPLANE GAME\AEROPLANE GAME\bin\Debug\sound\boom.mp3";

            //setup music
            gameMedia.settings.setMode("loop", true); // Set the game music to loop continuously
            gameMedia.settings.volume = 5; // Set the volume of the game music to 50%
            shootingMedia.settings.volume = 1; // Set the volume of the shooting sound effect to 10%
            explosionMedia.settings.volume = 6; // Set the volume of the explosion sound effect to 60%
        }

        private void form1_Load(object sender, EventArgs e)
        {
            pause = false;
            gameOver = false;
            score = 0;
            level = 1;
            levellbl.Text = "01";
            difficulty = 9;

            enemiesMunitionspeed = 4;
            ArtilierXEspeed = 4;
            enemiespeed = 4;
            munitionspeed = 20;
            backgroudspeed = 4; // Set the initial speed of the background movement

            munitions = new PictureBox[5]; // Initialize the array to hold 5 munitions
            stars = new PictureBox[15];   // Initialize the array to hold 15 stars

            rnd = new Random(); // Initialize the Random object

            // load images
            Image munition = Image.FromFile(@"D:\C#\AEROPLANE GAME\AEROPLANE GAME\bin\Debug\characters\munition.png");
            Image enemy1 = Image.FromFile(@"D:\C#\AEROPLANE GAME\AEROPLANE GAME\bin\Debug\characters\E1.png");
            Image enemy2 = Image.FromFile(@"D:\C#\AEROPLANE GAME\AEROPLANE GAME\bin\Debug\characters\E2.png");
            Image enemy3 = Image.FromFile(@"D:\C#\AEROPLANE GAME\AEROPLANE GAME\bin\Debug\characters\E3.png");
            Image boss1 = Image.FromFile(@"D:\C#\AEROPLANE GAME\AEROPLANE GAME\bin\Debug\characters\Boss1.png");
            Image boss2 = Image.FromFile(@"D:\C#\AEROPLANE GAME\AEROPLANE GAME\bin\Debug\characters\Boss2.png");

            //ENEMIES
            enemies = new PictureBox[10]; // Initialize the array to hold 10 enemies

            int enemyWidth = 30;
            enemySpacing = 42;
            int totalRowWidth = (enemies.Length * enemyWidth) + ((enemies.Length - 1) * (enemySpacing - enemyWidth));
            enemyStartX = (582 - totalRowWidth) / 2 - 75;

            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = new PictureBox();
                enemies[i].Size = new Size(enemyWidth, enemyWidth);
                enemies[i].SizeMode = PictureBoxSizeMode.Zoom;
                enemies[i].BorderStyle = BorderStyle.None;
                enemies[i].BackColor = Color.Transparent;
                enemies[i].Visible = false;
                this.Controls.Add(enemies[i]);
                enemies[i].Location = new Point(enemyStartX + (i * enemySpacing), -50);
            }


            enemies[0].Image = boss1;
            enemies[1].Image = enemy3;
            enemies[2].Image = enemy1;
            enemies[3].Image = enemy1;
            enemies[4].Image = enemy3;
            enemies[5].Image = enemy2;
            enemies[6].Image = enemy3;
            enemies[7].Image = enemy2;
            enemies[8].Image = enemy1;
            enemies[9].Image = boss2;

            for (int i = 0; i < munitions.Length; i++)
            {
                munitions[i] = new PictureBox();
                munitions[i].Size = new Size(8, 8);
                munitions[i].Image = munition;
                munitions[i].SizeMode = PictureBoxSizeMode.Zoom;
                munitions[i].BorderStyle = BorderStyle.None;
                this.Controls.Add(munitions[i]);
            }

            enemiesMunition = new PictureBox[10];

            for(int i=0; i < enemiesMunition.Length; i++)
            {
               enemiesMunition[i] = new PictureBox();
               enemiesMunition[i].Size = new Size(2, 25);
               enemiesMunition[i].Visible = false;
               enemiesMunition[i].BackColor= Color.Yellow;
               int x=rnd.Next(0, enemies.Length);
               enemiesMunition[i].Location = new Point(enemies[x].Location.X + 15, enemies[x].Location.Y + 30);
               this.Controls.Add(enemiesMunition[i]);
            }


            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new PictureBox();
                stars[i].BorderStyle = BorderStyle.None; // Set the border style of the star PictureBox to none
                stars[i].Location = new Point(rnd.Next(20, 500), rnd.Next(-16, 600)); // Set the initial location of the star PictureBox
                if (i % 2 == 1)
                {
                    stars[i].Size = new Size(2, 2); // Set the size of the star PictureBox to 2x2 pixels for odd indexed stars
                    stars[i].BackColor = Color.White;
                }
                else
                {
                    stars[i].Size = new Size(3, 3); // Set the size of the star PictureBox to 3x3 pixels for even indexed stars
                    stars[i].BackColor = Color.DarkGray;
                }

                this.Controls.Add(stars[i]); // Add the star PictureBox to the form's controls

            }

            gameMedia.controls.play(); // Start playing the game music when the form loads
        }

        private void MoveBgTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].Top += backgroudspeed; // Move the star PictureBox down by the background speed

                if (stars[i].Top > this.Height) // If the star PictureBox has moved off the bottom of the form
                {
                    stars[i].Top = -stars[i].Height; // Move the star PictureBox back to the top of the form
                }
            }

            for (int i = stars.Length / 2; i < stars.Length; i++)
            {
                stars[i].Top += backgroudspeed - 2; // Move the star PictureBox down by a slower speed for the second half of the stars

                if (stars[i].Top >= this.Height) // If the star PictureBox has moved off the bottom of the form
                {
                    stars[i].Top = -stars[i].Height;// Move the star PictureBox back to the top of the form
                }
            }
        }

        private void ArtilierXE_Click(object sender, EventArgs e)
        {

        }

        private void LeftMoveTimer_Tick(object sender, EventArgs e)
        {
            if (ArtilierXE.Left > 10)
            {
                ArtilierXE.Left -= ArtilierXEspeed; // Move the player PictureBox to the left by the player's speed
            }
        }

        private void RightMoveTimer_Tick(object sender, EventArgs e)
        {
            if (ArtilierXE.Right < 580)
            {
                ArtilierXE.Left += ArtilierXEspeed; // Move the player PictureBox to the right by the player's speed
            }
        }

        private void DownMoveTimer_Tick(object sender, EventArgs e)
        {
            if (ArtilierXE.Top < 400)
            {
                ArtilierXE.Top += ArtilierXEspeed; // Move the player PictureBox down by the player's speed
            }
        }


        private void UpMoveTimer_Tick(object sender, EventArgs e)
        {
            if (ArtilierXE.Top > 16)
            {
                ArtilierXE.Top -= ArtilierXEspeed; // Move the player PictureBox up by the player's speed
            }
        }

        private void form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!pause) {
                if (e.KeyCode == Keys.Right && !RightMoveTimer.Enabled)
                {
                    RightMoveTimer.Start();
                }
                if (e.KeyCode == Keys.Left && !LeftMoveTimer.Enabled)
                {
                    LeftMoveTimer.Start();
                }
                if (e.KeyCode == Keys.Up && !UpMoveTimer.Enabled)
                {
                    UpMoveTimer.Start();
                }
                if (e.KeyCode == Keys.Down && !DownMoveTimer.Enabled)
                {
                    DownMoveTimer.Start();
                }
            }
          
        }

        private void form1_KeyUp(object sender, KeyEventArgs e)
        {
            RightMoveTimer.Stop();
            LeftMoveTimer.Stop();
            DownMoveTimer.Stop();
            UpMoveTimer.Stop();

            if (e.KeyCode == Keys.Space)
            {
                if (!gameOver)
                {
                    if (pause)
                    {
                        StartTimer(); // Call the StartTimer method to resume all timers in the game when the pause key is released
                        label.Visible = false;
                        gameMedia.controls.play(); // Resume playing the game music when the pause key is released
                        pause = false; // Set the pause variable to false to indicate that the game is no longer paused

                    }
                    else
                    {
                        label.Location = new Point(this.Width / 2 - 120, 150);
                        label.Text = "PAUSED";
                        label.Visible = true;
                        gameMedia.controls.pause(); // Pause the game music when the pause key is released
                        StopTimer();
                        pause = true; // Set the pause variable to true to indicate that the game is paused
                    }
                }
            }
        }

        private void MoveMunitionsTimer_Tick(object sender, EventArgs e)
        {
            shootingMedia.controls.play(); // Play the shooting sound effect when the munitions are moving
            for (int i = 0; i < munitions.Length; i++)
                if (munitions[i].Top > 0)
                {
                    munitions[i].Visible = true;
                    munitions[i].Top -= munitionspeed; // Move the munition PictureBox up by the munition speed

                    Collision(); // Call the Collision method to check for collisions between munitions and enemies
                }

                else
                {
                    munitions[i].Visible = false;
                    munitions[i].Location = new Point(ArtilierXE.Location.X + 20, ArtilierXE.Location.Y - i * 30); // Move the munition PictureBox back to the initial location above the player PictureBox when it has moved off the top of the form
                }
        }

        private void MoveEnemiesTimer_Tick(object sender, EventArgs e)
        {
            MoveEnemies(enemies, enemiespeed); // Call the MoveEnemies method to move the enemy PictureBoxes down by the enemy speed
        }

        private void MoveEnemies(PictureBox[] array, int speed)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i].Visible = true;
                array[i].Top += speed;

                if (array[i].Top > this.Height)
                {
                    array[i].Location = new Point(enemyStartX + (i * enemySpacing), -200);
                }
            }
        }

        private void Collision()
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (munitions[0].Bounds.IntersectsWith(enemies[i].Bounds) || munitions[1].Bounds.IntersectsWith(enemies[i].Bounds)
                    || munitions[2].Bounds.IntersectsWith(enemies[i].Bounds))
                {
                    explosionMedia.controls.play(); // Play the explosion sound effect when a munition collides with an enemy

                    score += 1; // Increment the player's score by 1 when a munition collides with an enemy
                    scorelbl.Text =(score<10)? "0" + score.ToString() : score.ToString(); // Update the score label to display the current score, adding a leading zero if the score is less than 10
                    
                    if(score % 30 == 0)
                    {
                        level += 1; // Increment the level by 1 when the score is a multiple of 30
                        levellbl.Text = (level < 10) ? "0" + level.ToString() : level.ToString(); // Update the level label to display the current level, adding a leading zero if the level is less than 10

                        if(enemiespeed <= 10 && enemiesMunitionspeed <=10 && difficulty >=0)
                        {
                            difficulty--; // Decrease the difficulty by 1 when the level increases, up to a maximum of 10
                            enemiespeed++;// Increase the enemy speed by 1 when the level increases, up to a maximum of 10
                            enemiesMunitionspeed++;// Increase the enemy munition speed by 1 when the level increases, up to a maximum of 10
                        }

                        if(level == 10)
                        {
                            Gameover("YOU WIN"); // Call the Gameover method to end the game and display a win message when the player reaches level 10
                        }
                    }
                    enemies[i].Location = new Point(enemyStartX + (i * enemySpacing), -200); // Move the enemy PictureBox back to the initial location above the form when it has been hit by a munition
                }

                if (ArtilierXE.Bounds.IntersectsWith(enemies[i].Bounds))
                {
                    explosionMedia.settings.volume = 30; // Set the volume of the explosion sound effect to 100%
                    explosionMedia.controls.play(); // Play the explosion sound effect when the player collides with an enemy
                    ArtilierXE.Visible = false;
                    Gameover("GAME OVER"); // Call the Gameover method to end the game and display a game over message
                }
            }
        }

        private void Gameover(string message)
        {
            if (gameOver) return;

            gameOver = true;
            gameMedia.controls.stop();
            StopTimer();

            label.Text = message;
            label.Font = new Font("Press Start 2P", 28, FontStyle.Bold);
            label.ForeColor = Color.Red;
            label.Location = new Point((this.ClientSize.Width - label.Width) / 2, 100);
            label.Visible = true;

            STARTBUTTON.Location = new Point((this.ClientSize.Width - STARTBUTTON.Width) / 2, 180);
            STARTBUTTON.Visible = true;

            EXITBUTTON.Location = new Point((this.ClientSize.Width - EXITBUTTON.Width) / 2, 220);
            EXITBUTTON.Visible = true;
        }

        private void StopTimer()
        {
            MovebgTimer.Stop();
            MoveMunitionsTimer.Stop();
            MoveEnemiesTimer.Stop();
            MoveEnemiesMunitionTimer.Stop();
        }

        private void StartTimer()
        {
            MovebgTimer.Start();
            MoveMunitionsTimer.Start();
            MoveEnemiesTimer.Start();
            MoveEnemiesMunitionTimer.Start();
        }


        private void MoveEnemiesMunitionTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemiesMunition[i].Top < this.Height)
                {
                    enemiesMunition[i].Visible = true;
                    enemiesMunition[i].Top += enemiesMunitionspeed;
                    collisionEnemiMunition(); // Call the collisionEnemiMunition method to check for collisions between enemy munitions and the player
                }
                else
                {
                    enemiesMunition[i].Visible = false;
                    int x = rnd.Next(0, enemies.Length);
                    enemiesMunition[i].Location = new Point(enemies[x].Location.X + 15, enemies[x].Location.Y + 30);
                }
            }

        }

        private void collisionEnemiMunition()
        {
            for (int i = 0; i < enemiesMunition.Length; i++)
            {
                if (enemiesMunition[i].Bounds.IntersectsWith(ArtilierXE.Bounds))
                {
                    enemiesMunition[i].Visible = false;
                    explosionMedia.settings.volume = 30; // Set the volume of the explosion sound effect to 100%
                    explosionMedia.controls.play(); // Play the explosion sound effect when the player collides with an enemy munition
                    ArtilierXE.Visible = false;
                    Gameover("GAME OVER"); // Call the Gameover method to end the game and display a game over message
                }
            }
        }

   

        private void label_Click(object sender, EventArgs e)
        {

        }

        private Button GetSTARTBUTTON()
        {
            return STARTBUTTON;
        }

        private void STARTBUTTON_Click(object sender, EventArgs e)
        {
            STARTBUTTON.Visible = false;
            EXITBUTTON.Visible = false;
            label.Visible = false;

            foreach (var s in stars) this.Controls.Remove(s);
            foreach (var m in munitions) this.Controls.Remove(m);
            foreach (var en in enemies) this.Controls.Remove(en);
            foreach (var em in enemiesMunition) this.Controls.Remove(em);

            ArtilierXE.Visible = true;
            ArtilierXE.Location = new Point(268, 280);
            this.Controls.Remove(ArtilierXE);
            this.Controls.Add(ArtilierXE);
            ArtilierXE.BringToFront();

            gameMedia.controls.stop();
            shootingMedia.controls.stop();
            explosionMedia.controls.stop();

            form1_Load(sender, e);

            StartTimer();
            this.Focus();
        }


        private void EXITBUTTON_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void scorelbl_Click(object sender, EventArgs e)
        {

        }

        private void LEVELtext_Click(object sender, EventArgs e)
        {

        }
    }
}