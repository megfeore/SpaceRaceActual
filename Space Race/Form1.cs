using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;
//Meg Feore
//January 19/22
//Are you able to win in the Space Race?

namespace Space_Race
{
    public partial class Form1 : Form
    {
        //set up players
        Rectangle player1LeftSide = new Rectangle(140, 350, 5, 50);
        Rectangle player1RightSide = new Rectangle(160, 350, 5, 50);
        Rectangle player1TopVer1 = new Rectangle(145, 340, 5, 10);
        Rectangle player1TopVer2 = new Rectangle(155, 340, 5, 10);
        Rectangle player1TopVer3 = new Rectangle(150, 330, 5, 10);

        Rectangle player2LeftSide = new Rectangle(440, 350, 5, 50);
        Rectangle player2RightSide = new Rectangle(460, 350, 5, 50);
        Rectangle player2TopVer1 = new Rectangle(445, 340, 5, 10);
        Rectangle player2TopVer2 = new Rectangle(455, 340, 5, 10);
        Rectangle player2TopVer3 = new Rectangle(450, 330, 5, 10);
        int playerSpeed = 5;

        //set up moving RIGHT asterioids
        List<Rectangle> balls = new List<Rectangle>();
        List<int> ballSpeeds = new List<int>();
        List<string> ballColour = new List<string>();
        int ballSize = 5;

        //set up moving LEFT asteroids
        List<Rectangle> leftBalls = new List<Rectangle>();
        List<int> leftBallSpeeds = new List<int>();
        List<string> leftBallColour = new List<string>();

        //declare random value
        Random randGen = new Random();
        int randValue = 0;

        //set up finish line
        Rectangle finishLine = new Rectangle(0, 0, 600, 10);

        //set up brushes
        SolidBrush whiteBrush = new SolidBrush(Color.White);

        //initializing keys that will be used to control the player
        bool wDown = false;
        bool sDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;

        //initialize player scores
        int player1Score = 0;
        int player2Score = 0;
        string winningPlayer;

        //game state
        string gameState = "waiting";

        //declare sounds
        SoundPlayer panSound = new SoundPlayer(Properties.Resources.pan);
        SoundPlayer glassSound = new SoundPlayer(Properties.Resources.glass);



        public Form1()
        {
            InitializeComponent();
        }

        public void GameInitialize()
        {
            titleLabel.Text = "";
            subtitleLabel.Text = "";

            gameLoop.Enabled = true;
            gameState = "running";
            player1Score = 0;
            player2Score = 0;
            balls.Clear();
            ballColour.Clear();
            ballSpeeds.Clear();

            player1LeftSide.X = 140;
            player1LeftSide.Y = 350;
            player2LeftSide.X = 440;
            player2LeftSide.Y = 350;
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Space:
                    if (gameState == "waiting" || gameState == "over")
                    {
                        GameInitialize();
                    }
                    break;
                case Keys.Escape:
                    if (gameState == "waiting" || gameState == "over")
                    {
                        Application.Exit();
                    }
                    break;
            }
        }

        private void gameLoop_Tick(object sender, EventArgs e)
        {
            //move player 1 up 
            if (wDown == true && player1TopVer3.Y >= 0)
            {
                player1LeftSide.Y -= playerSpeed;
                player1RightSide.Y -= playerSpeed;
                player1TopVer1.Y -= playerSpeed;
                player1TopVer2.Y -= playerSpeed;
                player1TopVer3.Y -= playerSpeed;
            }

            //move player1 down
            if (sDown == true && player1LeftSide.Y < this.Height - player1LeftSide.Height)
            {
                player1LeftSide.Y += playerSpeed;
                player1RightSide.Y += playerSpeed;
                player1TopVer1.Y += playerSpeed;
                player1TopVer2.Y += playerSpeed;
                player1TopVer3.Y += playerSpeed;
            }

            //move player 2 up 
            if (upArrowDown == true && player2TopVer3.Y >= 0)
            {
                player2LeftSide.Y -= playerSpeed;
                player2RightSide.Y -= playerSpeed;
                player2TopVer1.Y -= playerSpeed;
                player2TopVer2.Y -= playerSpeed;
                player2TopVer3.Y -= playerSpeed;
            }

            //move player2 down
            if (downArrowDown == true && player2LeftSide.Y < this.Height - player1LeftSide.Height)
            {
                player2LeftSide.Y += playerSpeed;
                player2RightSide.Y += playerSpeed;
                player2TopVer1.Y += playerSpeed;
                player2TopVer2.Y += playerSpeed;
                player2TopVer3.Y += playerSpeed;
            }

            // move asteroids RIGHT across the screen
            for (int i = 0; i < balls.Count(); i++)
            {
                //find the new postion of x based on speed
                int xRight = balls[i].X + ballSpeeds[i];

                //replace the rectangle in the list with updated one using new y
                balls[i] = new Rectangle(xRight, balls[i].Y, ballSize, ballSize);
            }

            // move asteroids LEFT across the screen
            for (int i = 0; i < leftBalls.Count(); i++)
            {
                //find the new postion of x based on speed
                int xLeft = leftBalls[i].X - leftBallSpeeds[i];

                //replace the rectangle in the list with updated one using new y
                leftBalls[i] = new Rectangle(xLeft, leftBalls[i].Y, ballSize, ballSize);
            }

            //check to see if a new ball should be created
            randValue = randGen.Next(0, 101);

            //check to see if new ball should be added moving RIGHT
            if (randValue < 15)
            {
                int yRight = randGen.Next(10, this.Height - ballSize * 2);
                balls.Add(new Rectangle(10, yRight, ballSize, ballSize));
                ballSpeeds.Add(randGen.Next(2, 10));
                ballColour.Add("white");
            }

            //check to see if new ball should be added moving LEFT
            if (randValue < 15)
            {
                int yLeft = randGen.Next(10, this.Height - ballSize * 2);
                leftBalls.Add(new Rectangle(600, yLeft, ballSize, ballSize));
                leftBallSpeeds.Add(randGen.Next(2, 10));
                leftBallColour.Add("white");
            }

            //check if ball is across play area moving RIGHT and remove it if it is
            for (int i = 0; i < balls.Count(); i++)
            {
                if (balls[i].X > this.Width - ballSize)
                {
                    balls.RemoveAt(i);
                    ballSpeeds.RemoveAt(i);
                    ballColour.RemoveAt(i);
                }
            }

            //check if ball is across play area moving LEFT and remove it if it is
            for (int i = 0; i < leftBalls.Count(); i++)
            {
                if (leftBalls[i].X < 0)
                {
                    leftBalls.RemoveAt(i);
                    leftBallSpeeds.RemoveAt(i);
                    leftBallColour.RemoveAt(i);
                }
            }

            //check for intersections with player1
            for (int i = 0; i < balls.Count(); i++)
            {
                if (player1LeftSide.IntersectsWith(balls[i]) || 
                    player1RightSide.IntersectsWith(balls[i]) ||
                    player1TopVer1.IntersectsWith(balls[i]) ||
                    player1TopVer2.IntersectsWith(balls[i]) ||
                    player1TopVer3.IntersectsWith(balls[i]))
                {
                    panSound.Play();
                    player1LeftSide.Y = 350;
                    player1RightSide.Y = 350;
                    player1TopVer1.Y = 340;
                    player1TopVer2.Y = 340;
                    player1TopVer3.Y = 330;


                    balls.RemoveAt(i);
                    ballSpeeds.RemoveAt(i);
                    ballColour.RemoveAt(i);
                }
            }

            for (int i = 0; i < leftBalls.Count(); i++)
            {
                if (player1LeftSide.IntersectsWith(leftBalls[i]) ||
                    player1RightSide.IntersectsWith(leftBalls[i]) ||
                    player1TopVer1.IntersectsWith(leftBalls[i]) ||
                    player1TopVer2.IntersectsWith(leftBalls[i]) ||
                    player1TopVer3.IntersectsWith(leftBalls[i]))
                {
                    panSound.Play();
                    player1LeftSide.Y = 350;
                    player1RightSide.Y = 350;
                    player1TopVer1.Y = 340;
                    player1TopVer2.Y = 340;
                    player1TopVer3.Y = 330;


                    leftBalls.RemoveAt(i);
                    leftBallSpeeds.RemoveAt(i);
                    leftBallColour.RemoveAt(i);
                }
            }

            if (player1TopVer3.IntersectsWith(finishLine))
            {
                glassSound.Play();

                player1LeftSide.Y = 350;
                player1RightSide.Y = 350;
                player1TopVer1.Y = 340;
                player1TopVer2.Y = 340;
                player1TopVer3.Y = 330;

                player1Score++;
                score1Label.Text = $"{player1Score}";
            }

            //check for intersections with player2
            for (int i = 0; i < balls.Count(); i++)
            {
                if (player2LeftSide.IntersectsWith(balls[i]) ||
                    player2RightSide.IntersectsWith(balls[i]) ||
                    player2TopVer1.IntersectsWith(balls[i]) ||
                    player2TopVer2.IntersectsWith(balls[i]) ||
                    player2TopVer3.IntersectsWith(balls[i]))
                {
                    panSound.Play();
                    player2LeftSide.Y = 350;
                    player2RightSide.Y = 350;
                    player2TopVer1.Y = 340;
                    player2TopVer2.Y = 340;
                    player2TopVer3.Y = 330;


                    balls.RemoveAt(i);
                    ballSpeeds.RemoveAt(i);
                    ballColour.RemoveAt(i);
                }
            }

            for (int i = 0; i < leftBalls.Count(); i++)
            {
                if (player2LeftSide.IntersectsWith(leftBalls[i]) ||
                    player2RightSide.IntersectsWith(leftBalls[i]) ||
                    player2TopVer1.IntersectsWith(leftBalls[i]) ||
                    player2TopVer2.IntersectsWith(leftBalls[i]) ||
                    player2TopVer3.IntersectsWith(leftBalls[i]))
                {
                    panSound.Play();
                    player2LeftSide.Y = 350;
                    player2RightSide.Y = 350;
                    player2TopVer1.Y = 340;
                    player2TopVer2.Y = 340;
                    player2TopVer3.Y = 330;


                    leftBalls.RemoveAt(i);
                    leftBallSpeeds.RemoveAt(i);
                    leftBallColour.RemoveAt(i);
                }
            }

            if (player2TopVer3.IntersectsWith(finishLine))
            {
                glassSound.Play();

                player2LeftSide.Y = 350;
                player2RightSide.Y = 350;
                player2TopVer1.Y = 340;
                player2TopVer2.Y = 340;
                player2TopVer3.Y = 330;

                player2Score++;
                score2Label.Text = $"{player2Score}";

            }

            //if player1 gets to 3 then game is over
            if (player1Score == 3)
            {
                gameLoop.Enabled = false;
                gameState = "over";
                winningPlayer = "Player 1";
            }

            //if player2 gets to 3 then game is over
            if (player2Score == 3)
            {
                gameLoop.Enabled = false;
                gameState = "over";
                winningPlayer = "Player 2";
            }

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (gameState == "waiting")
            {
                titleLabel.Text = "Welcome to Space Race!";
                subtitleLabel.Text = "Press the space bar to begin OR escape to exit OR the i key for instructions";
                score1Label.Visible = false;
                score2Label.Visible = false;
            }
            else if (gameState == "running")
            {
                // draw text at top 
                score1Label.Visible = true;
                score2Label.Visible = true;

                //draw player 1
                e.Graphics.FillRectangle(whiteBrush, player1LeftSide);
                e.Graphics.FillRectangle(whiteBrush, player1RightSide);
                e.Graphics.FillRectangle(whiteBrush, player1TopVer1);
                e.Graphics.FillRectangle(whiteBrush, player1TopVer2);
                e.Graphics.FillRectangle(whiteBrush, player1TopVer3);

                //draw player 2
                e.Graphics.FillRectangle(whiteBrush, player2LeftSide);
                e.Graphics.FillRectangle(whiteBrush, player2RightSide);
                e.Graphics.FillRectangle(whiteBrush, player2TopVer1);
                e.Graphics.FillRectangle(whiteBrush, player2TopVer2);
                e.Graphics.FillRectangle(whiteBrush, player2TopVer3);

                //draw finish line
                e.Graphics.FillRectangle(whiteBrush, finishLine);

                //draw balls moving RIGHT
                for (int i = 0; i < balls.Count(); i++)
                {
                    if (ballColour[i] == "white")
                    {
                        e.Graphics.FillEllipse(whiteBrush, balls[i]);
                    }
                }

                //draw balls moving LEFT
                for (int i = 0; i < leftBalls.Count(); i++)
                {
                    if (leftBallColour[i] == "white")
                    {
                        e.Graphics.FillEllipse(whiteBrush, leftBalls[i]);
                    }
                }
            }
            else if (gameState == "over")
            {
                titleLabel.Text = $"Congratulations {winningPlayer} you won!";
                subtitleLabel.Text = "Press the space bar to begin OR escape to exit";
                score1Label.Visible = false;
                score2Label.Visible = false;
                score1Label.Text = "0";
                score2Label.Text = "0";
            }
        }
    }
}

