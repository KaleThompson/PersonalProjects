using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmashBro
{
    public partial class SmashBros : Form
    {
        Bitmap background;
        Bitmap player1;

        Bitmap Banana;
        Bitmap Dog;

        Bitmap button; 
        
        

        bool Idle;
        bool MovingRight;
        bool MovingLeft;
        bool MovingUp;
        bool Button;
        bool wasIdle;
        bool walk;
        bool run;
        bool check;

        bool Animated;

        Timer timer;
        Timer timer2; 
        int IdleState = 0;
        int MovingState = 0;
        int DogState = 0;
        int BananaState = 0;

        public SmashBros()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            this.Focus();
            
            background = new Bitmap("C:/Users/Skoga/Pictures/Saved Pictures/Background.bmp");
            player1 = new Bitmap("C:/Users/Skoga/Pictures/Saved Pictures/GokuIdle.bmp");
            Banana = new Bitmap("C:/Users/Skoga/Pictures/Saved Pictures/Bannan.bmp");
            Dog = new Bitmap("C:/Users/Skoga/Pictures/Saved Pictures/Dog.bmp");
            button = new Bitmap("C:/Users/Skoga/Pictures/Saved Pictures/button1.bmp");

            walk = false;
            run = false;

            pictureBox1.Location = new Point(687, 451);
            pictureBox2.Location = new Point(742, 457);
            pictureBox1.Image = Banana;
            pictureBox2.Image = Dog;
            Player1Panel.Image = player1;
            BackgroundPanel.Image = background;
            createTimer();
            RunGame();
        }

        private void createTimer()
        {
            timer = new Timer();
            timer2 = new Timer();
            timer2.Interval = 300;
            timer2.Tick += Timer2_Tick;
            timer.Interval = 128;
            timer.Tick += Timer_Tick;
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            check = false;
            walk = false;
            run = false;
        }

        private void RunGame()
        {
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            
            timer.Stop();
            animate();
            CheckButton();
            Player1Panel.Image = player1;
            pictureBox2.Image = Dog;
            pictureBox1.Image = Banana;
            pictureBox3.Image = button;
            MethodInvoker mi = new MethodInvoker(() => Player1Panel.Refresh());
            mi.Invoke();
            Animated = true;
            RunGame();
        }

        private void CheckButton()
        {
            if(Player1Panel.Location.X > 452 && Player1Panel.Location.X < 462)
            {
                Button = true;
                pictureBox1.Location = new Point(656, 399);

            }
        }


        private void animate()
        {
            // PLAYER 1
            if (Idle)
            {
                if(IdleState < 5)
                {
                    player1 = new Bitmap("C:/Users/Skoga/Pictures/Saved Pictures/GokuIdle.bmp");
                    IdleState++;
                } else if(IdleState >= 5 &&IdleState < 10)
                {
                    player1 = new Bitmap("C:/Users/Skoga/Pictures/Saved Pictures/GokuIdle1.bmp");
                    IdleState++;
                } else
                {
                    IdleState = 0;
                }

            } else if (MovingRight)
            {
                switch (MovingState)
                {
                    case 0:
                        player1 = new Bitmap("C:/Users/Skoga/Pictures/Saved Pictures/GokuStand.bmp");
                        Player1Panel.SetBounds(Player1Panel.Location.X + 2, Player1Panel.Location.Y, Player1Panel.Width, Player1Panel.Height);
                        break;
                    case 1:
                        player1 = new Bitmap("C:/Users/Skoga/Pictures/Saved Pictures/GokuWalk1.bmp");
                        Player1Panel.SetBounds(Player1Panel.Location.X + 2, Player1Panel.Location.Y, Player1Panel.Width, Player1Panel.Height);
                        break;
                    case 2:
                        player1 = new Bitmap("C:/Users/Skoga/Pictures/Saved Pictures/GokuWalk2.bmp");
                        Player1Panel.SetBounds(Player1Panel.Location.X + 2, Player1Panel.Location.Y, Player1Panel.Width, Player1Panel.Height);
                        break;
                    case 3:
                        player1 = new Bitmap("C:/Users/Skoga/Pictures/Saved Pictures/GokuWalk3.bmp");
                        Player1Panel.SetBounds(Player1Panel.Location.X + 2, Player1Panel.Location.Y, Player1Panel.Width, Player1Panel.Height);
                        break;
                    case 4:
                        player1 = new Bitmap("C:/Users/Skoga/Pictures/Saved Pictures/GokuRun1.bmp");
                        Player1Panel.SetBounds(Player1Panel.Location.X + 10, Player1Panel.Location.Y, Player1Panel.Width, Player1Panel.Height);
                        break;
                    case 5:
                        player1 = new Bitmap("C:/Users/Skoga/Pictures/Saved Pictures/GokuRun2.bmp");
                        Player1Panel.SetBounds(Player1Panel.Location.X + 10, Player1Panel.Location.Y, Player1Panel.Width, Player1Panel.Height);
                        break;
                    case 6:
                        player1 = new Bitmap("C:/Users/Skoga/Pictures/Saved Pictures/GokuRun3.bmp");
                        Player1Panel.SetBounds(Player1Panel.Location.X + 10, Player1Panel.Location.Y, Player1Panel.Width, Player1Panel.Height);
                        break;
                    case 7:
                        player1 = new Bitmap("C:/Users/Skoga/Pictures/Saved Pictures/GokuRun4.bmp");
                        Player1Panel.SetBounds(Player1Panel.Location.X + 10, Player1Panel.Location.Y, Player1Panel.Width, Player1Panel.Height);
                        break;
                    case 8:
                        player1 = new Bitmap("C:/Users/Skoga/Pictures/Saved Pictures/GokuRun5.bmp");
                        Player1Panel.SetBounds(Player1Panel.Location.X + 10, Player1Panel.Location.Y, Player1Panel.Width, Player1Panel.Height);
                        break;
                    case 9:
                        player1 = new Bitmap("C:/Users/Skoga/Pictures/Saved Pictures/GokuRun6.bmp");
                        Player1Panel.SetBounds(Player1Panel.Location.X + 10, Player1Panel.Location.Y, Player1Panel.Width, Player1Panel.Height);
                        break;
                    case 10:
                        player1 = new Bitmap("C:/Users/Skoga/Pictures/Saved Pictures/GokuRun7.bmp");
                        Player1Panel.SetBounds(Player1Panel.Location.X + 10, Player1Panel.Location.Y, Player1Panel.Width, Player1Panel.Height);
                        break;
                }
            } else if (MovingLeft)
            {
                switch (MovingState)
                {
                    case 0:
                        player1 = new Bitmap("C:/Users/Skoga/Pictures/Saved Pictures/GokuStandL.bmp");
                        Player1Panel.SetBounds(Player1Panel.Location.X - 2, Player1Panel.Location.Y, Player1Panel.Width, Player1Panel.Height);
                        break;
                    case 1:
                        player1 = new Bitmap("C:/Users/Skoga/Pictures/Saved Pictures/GokuWalk1L.bmp");
                        Player1Panel.SetBounds(Player1Panel.Location.X - 2, Player1Panel.Location.Y, Player1Panel.Width, Player1Panel.Height);
                        break;
                    case 2:
                        player1 = new Bitmap("C:/Users/Skoga/Pictures/Saved Pictures/GokuWalk2L.bmp");
                        Player1Panel.SetBounds(Player1Panel.Location.X - 2, Player1Panel.Location.Y, Player1Panel.Width, Player1Panel.Height);
                        break;
                    case 3:
                        player1 = new Bitmap("C:/Users/Skoga/Pictures/Saved Pictures/GokuWalk3L.bmp");
                        Player1Panel.SetBounds(Player1Panel.Location.X - 2, Player1Panel.Location.Y, Player1Panel.Width, Player1Panel.Height);
                        break;
                    case 4:
                        player1 = new Bitmap("C:/Users/Skoga/Pictures/Saved Pictures/GokuRunL1.bmp");
                        Player1Panel.SetBounds(Player1Panel.Location.X - 10, Player1Panel.Location.Y, Player1Panel.Width, Player1Panel.Height);
                        break;
                    case 5:
                        player1 = new Bitmap("C:/Users/Skoga/Pictures/Saved Pictures/GokuRun2L.bmp");
                        Player1Panel.SetBounds(Player1Panel.Location.X - 10, Player1Panel.Location.Y, Player1Panel.Width, Player1Panel.Height);
                        break;
                    case 6:
                        player1 = new Bitmap("C:/Users/Skoga/Pictures/Saved Pictures/GokuRun3L.bmp");
                        Player1Panel.SetBounds(Player1Panel.Location.X - 10, Player1Panel.Location.Y, Player1Panel.Width, Player1Panel.Height);
                        break;
                    case 7:
                        player1 = new Bitmap("C:/Users/Skoga/Pictures/Saved Pictures/GokuRun4L.bmp");
                        Player1Panel.SetBounds(Player1Panel.Location.X - 10, Player1Panel.Location.Y, Player1Panel.Width, Player1Panel.Height);
                        break;
                    case 8:
                        player1 = new Bitmap("C:/Users/Skoga/Pictures/Saved Pictures/GokuRun5L.bmp");
                        Player1Panel.SetBounds(Player1Panel.Location.X - 10, Player1Panel.Location.Y, Player1Panel.Width, Player1Panel.Height);
                        break;
                    case 9:
                        player1 = new Bitmap("C:/Users/Skoga/Pictures/Saved Pictures/GokuRun6L.bmp");
                        Player1Panel.SetBounds(Player1Panel.Location.X - 10, Player1Panel.Location.Y, Player1Panel.Width, Player1Panel.Height);
                        break;
                    case 10:
                        player1 = new Bitmap("C:/Users/Skoga/Pictures/Saved Pictures/GokuRun7L.bmp");
                        Player1Panel.SetBounds(Player1Panel.Location.X - 10, Player1Panel.Location.Y, Player1Panel.Width, Player1Panel.Height);
                        break;
                }
            }



            // DOG
            if (!Button)
            {
                if (DogState < 3)
                {
                    Dog = new Bitmap("C:/Users/Skoga/Pictures/Saved Pictures/Dog2.bmp");
                    DogState++;
                }
                else if (DogState >= 3 && DogState < 5)
                {
                    Dog = new Bitmap("C:/Users/Skoga/Pictures/Saved Pictures/Dog.bmp");
                    DogState++;
                }
                else
                {
                    DogState = 0;
                }
            } else
            {
                Dog = new Bitmap("C:/Users/Skoga/Pictures/Saved Pictures/Background.bmp");
            }

            // BANANA
            if (!Button)
            {
                if (BananaState < 3)
                {
                    Banana = new Bitmap("C:/Users/Skoga/Pictures/Saved Pictures/Bannan2.bmp");
                    BananaState++;
                }
                else if (BananaState >= 3 && BananaState < 5)
                {
                    Banana = new Bitmap("C:/Users/Skoga/Pictures/Saved Pictures/Bannan.bmp");
                    BananaState++;
                }
                else
                {
                    BananaState = 0;
                }
            } else
            {
                if (BananaState < 3)
                {
                    Banana = new Bitmap("C:/Users/Skoga/Pictures/Saved Pictures/PBJT1.bmp");
                    BananaState++;
                }
                else if (BananaState >= 3 && BananaState < 5)
                {
                    Banana = new Bitmap("C:/Users/Skoga/Pictures/Saved Pictures/PBJT2.bmp");
                    BananaState++;
                }
                else
                {
                    BananaState = 0;
                }
            }

            //Button
            if (Button)
            {
                button = new Bitmap("C:/Users/Skoga/Pictures/Saved Pictures/button2.bmp");
            }





        }


        private void SmashBros_KeyDown(object sender, KeyEventArgs e)
        {

            timer2.Stop();
            if (check)
            {
                if (!walk && !run)
                {
                    walk = true;
                    run = false;
                }
                else if (walk && !run)
                {
                    walk = false;
                    run = true;
                }
                else
                {
                    walk = false;
                    run = false;
                }
            }
            
 
            switch (e.KeyCode)
            {
                
                case Keys.D:
                    if (!walk)
                    {
                        
                        MovingRight = true;
                        MovingLeft = false;
                        MovingUp = false;
                        if (Animated || Idle)
                        {
                            if (MovingState == 0)
                            {
                                MovingState = 1;
                            }
                            else if (MovingState == 1)
                            {
                                MovingState = 2;
                            }
                            else if (MovingState == 2)
                            {
                                MovingState = 3;
                            }
                            else if (MovingState == 3)
                            {
                                MovingState = 0;
                            }
                            Animated = false;
                        }
                        break;
                    } else
                    {
                        MovingRight = true;
                        MovingLeft = false;
                        MovingUp = false;
                        if (Animated || Idle)
                        {
                            if (MovingState == 0 || MovingState == 1 || MovingState == 2 || MovingState == 3)
                            {
                                MovingState = 4;
                            }
                            else if (MovingState == 4)
                            {
                                MovingState = 5;
                            }
                            else if (MovingState == 5)
                            {
                                MovingState = 6;
                            }
                            else if (MovingState == 6)
                            {
                                MovingState = 7;
                            }
                            else if (MovingState == 7)
                            {
                                MovingState = 8;
                            }
                            else if (MovingState == 8)
                            {
                                MovingState = 9;
                            }
                            else if (MovingState == 9)
                            {
                                MovingState = 10;
                            }
                            else if (MovingState == 10)
                            {
                                MovingState = 4;
                            }
                            Animated = false;
                        }
                        break;
                    }

                case Keys.A:
                    
                    MovingRight = false;
                    MovingLeft = true;
                    MovingUp = false;
                    if (!walk)
                    {
                        
                        if (Animated || Idle)
                        {
                            if (MovingState == 0)
                            {
                                MovingState = 1;
                            }
                            else if (MovingState == 1)
                            {
                                MovingState = 2;
                            }
                            else if (MovingState == 2)
                            {
                                MovingState = 3;
                            }
                            else if (MovingState == 3)
                            {
                                MovingState = 0;
                            }
                            Animated = false;
                        }
                        break;
                    }
                    else
                    {

                        if (Animated || Idle)
                        {
                            if (MovingState == 0 || MovingState == 1 || MovingState == 2 || MovingState == 3)
                            {
                                MovingState = 4;
                            }
                            else if (MovingState == 4)
                            {
                                MovingState = 5;
                            }
                            else if (MovingState == 5)
                            {
                                MovingState = 6;
                            }
                            else if (MovingState == 6)
                            {
                                MovingState = 7;
                            }
                            else if (MovingState == 7)
                            {
                                MovingState = 8;
                            }
                            else if (MovingState == 8)
                            {
                                MovingState = 9;
                            }
                            else if (MovingState == 9)
                            {
                                MovingState = 10;
                            }
                            else if (MovingState == 10)
                            {
                                MovingState = 4;
                            }
                            Animated = false;
                        }
                        break;
                    }

                case Keys.W:
                    break;
            }
            Idle = false;
        }

        private void SmashBros_KeyUp(object sender, KeyEventArgs e)
        {
            timer2.Start();
            check = true;
            MovingRight = false;
            MovingLeft = false;
            MovingUp = false;
            Idle = true;
            MovingState = 0;
            IdleState = 0;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
