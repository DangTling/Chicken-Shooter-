using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChickenShooter
{
    public partial class ChickenShooter : Form
    {
        //Ten Lua
        Piece _rocket;

        //Dan Ten Lua
        List<Piece> _bullets = new List<Piece>();

        // Ga
        Bitmap _mainChickenImage = Properties.Resources.bossRed;
        List<Bitmap> _chickenFrames = new List<Bitmap>();
        Piece[,] _chicken =  new Piece[3,8];
        int[] topChicken = new int[3];

        //Toc Do Cua Ga
        int chickenSpeed = 1, leftMostChicken = 0, count = 0, dt = 1;

        //Mang Song Cua Ng Choi
        List<Piece> _liveHeart = new List<Piece>();
        int live = 3, score = 0;

        //Trung 
        Bitmap _mainBrokenEggs = Properties.Resources.eggBreak;
        List<Bitmap> _brokenEggsFrames = new List<Bitmap>();
        List<Piece> _eggs = new List<Piece>();

        Random rand = new Random();


        public ChickenShooter()
        {
            InitializeComponent();
            intial();
        }

        private void intial()
        {
            _rocket = new Piece(100,100);
            _rocket.Left = Width / 2 - _rocket.Width / 2;
            _rocket.Top = Height - _rocket.Height;
            _rocket.Image = Properties.Resources.ship;
            Controls.Add(_rocket);

            divideImageIntoFrames(_mainChickenImage, _chickenFrames, 10);

            CreateChicken();

            CreateHeart();

            divideImageIntoFrames(_mainBrokenEggs, _brokenEggsFrames, 8);
        }

        private void CreateHeart()
        {
            Bitmap heart = Properties.Resources.heart;
            for (int i=0;i<3;i++)
            {
                _liveHeart.Add(new Piece(50,50));
                _liveHeart[i].Image = heart;
                _liveHeart[i].Left = Width - (3-i)*45;
                Controls.Add(_liveHeart[i]);
            }
        }

        private void CreateChicken()
        {
            Bitmap img = _chickenFrames[0];
            for (int i=0;i<3;i++)
            {
                topChicken[i] = i * 100 + img.Height;
                for(int j=0;j<8;j++)
                {
                    Piece chicken = new Piece(img.Width, img.Height);
                    chicken.Image = img;
                    chicken.Left = j * 100;
                    chicken.Top = i * 100 + img.Height;
                    _chicken[i, j] = chicken;
                    Controls.Add(chicken);
                }
            }
        }

        private void divideImageIntoFrames(Bitmap Orignal, List<Bitmap> res, int n)
        {
            int w = Orignal.Width / n;
            int h = Orignal.Height;
            for (int i=0;i<n;i++)
            {
                int s = i* w;
                Bitmap piece = new Bitmap(w, h);
                for (int j=0;j<h; j++)
                {
                    for (int k=0;k<w;k++)
                    {
                        piece.SetPixel(k, j, Orignal.GetPixel(k+s, j));
                    }
                }
                res.Add(piece);
            }
        }

        private void ChickenShooter_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    _rocket.Left -= 10;
                    break;
                case Keys.Right:
                    _rocket.Left += 10;
                    break;
                case Keys.Up:
                    _rocket.Top -= 10;
                    break;
                case Keys.Down:
                    _rocket.Top += 10;
                    break;
            }
        }

        private void eggsTm_Tick(object sender, EventArgs e)
        {
            if (rand.Next(200) == 5) launchRandomEggs();

            // Tha Trung xuong
            for(int i=0;i<_eggs.Count;i++)
            {
                _eggs[i].Top += _eggs[i].eggDownSpeed;
                //Trung roi vo ten lua
                if (_rocket.Bounds.IntersectsWith(_eggs[i].Bounds))
                {
                    Controls.Remove(_eggs[i]);
                    _eggs.RemoveAt(i);
                    decreaseLive();
                    break;
                }
                if (_eggs[i].Top >= Height - (_eggs[i].Height + 20))
                {
                    _eggs[i].eggDownSpeed = 0;
                    if (_eggs[i].eggLandCount/2 < _brokenEggsFrames.Count)
                    {
                        _eggs[i].Image = _brokenEggsFrames[_eggs[i].eggLandCount / 2];
                        _eggs[i].eggLandCount += 1;
                    } else
                    {
                        Controls.Remove(_eggs[i]);
                        _eggs.RemoveAt(i);
                    }
                }
            }
        }

        private void decreaseLive()
        {
            live -= 1;
            _liveHeart[live].Image = Properties.Resources.d_heart;
            if (live < 1) endGame(Properties.Resources.lose);
        }

        private void endGame(Bitmap img)
        {
            eggsTm.Stop();
            BulletTm.Stop();
            chickensTm.Stop();
            Controls.Clear();
            Piece pic = new Piece(100, 100);
            pic.Click += cls;
            pic.Image = img;
            pic.Left = Width / 2 + pic.Width / 2;
            pic.Top = Height / 2 + pic.Height / 2;
            Controls.Add(pic);
        }

        private void cls(object sender, EventArgs e)
        {
            Close();
        }

        private void launchRandomEggs()
        {
            List<Piece> availablesChickens = new List<Piece>();
            for(int i=0;i<3;i++)
            {
                for (int j=0;j<8;j++)
                {
                    if (_chicken[i,j] != null)
                    {
                        availablesChickens.Add(_chicken[i,j]);
                    }
                }
            }

            //Chon ga tha trung
            Piece chicken = availablesChickens[rand.Next() % availablesChickens.Count];
            Piece egg = new Piece(10, 10);
            egg.Image = Properties.Resources.egg;
            egg.Left = chicken.Left + chicken.Width / 2 - egg.Width/2;
            egg.Top = chicken.Top + chicken.Height;
            _eggs.Add(egg);
            Controls.Add(egg);
        }

        private void ChickenShooter_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space) launchBullet();
        }

        private void ChickenShooter_Load(object sender, EventArgs e)
        {

        }

        private void launchBullet()
        {
            Piece bullet = new Piece(10,10);
            bullet.Left = _rocket.Left + _rocket.Width / 2 - bullet.Width / 2;
            bullet.Top = _rocket.Top - bullet.Height;
            bullet.Image = Properties.Resources.b2;
            _bullets.Add(bullet);
            Controls.Add(bullet);
        }

        private void chickensTm_Tick(object sender, EventArgs e)
        {
            if (leftMostChicken+800>Width || leftMostChicken<0)
            {
                chickenSpeed = -chickenSpeed;
            }
            leftMostChicken += chickenSpeed;
            for (int i=0;i<3;i++)
            {
                for (int j=0;j<8;j++)
                {
                    if (_chicken[i, j] == null) continue;
                    _chicken[i, j].Image = _chickenFrames[count];
                    _chicken[i,j].Left += chickenSpeed;
                }
                count += dt;
                dt = count == 9? -1 : (count == 0? 1 :dt);
            }
        }

        private void BulletsTm_Tick(object sender, EventArgs e)
        {
            for (int i=0;i<_bullets.Count;i++)
            {
                _bullets[i].Top -= 3;
            }
            collision();
            if (score == 240) endGame(Properties.Resources.win);
        }

        private void collision()
        {
            for (int i=0;i<topChicken.Length;i++)
            {
                int lo = 0, hi = _bullets.Count - 1, md, ans = -1;
                while (lo <= hi)
                {
                    md = lo+(hi-lo)/2;
                    if (_bullets[md].Top >= topChicken[i])
                    {
                        hi = md - 1;
                        ans = md;
                    } else
                    {
                        lo = md + 1;
                    }
                }
                if (ans != -1 && _bullets[ans].Top >= topChicken[i] && _bullets[ans].Top<=topChicken[i]+ _chickenFrames[0].Height)
                {
                    int j = (_bullets[ans].Left + 9 - leftMostChicken) / 100;
                    if (j >= 0 && j < 8 && _chicken[i, j] != null && _bullets[ans].Bounds.IntersectsWith(_chicken[i, j].Bounds)) {
                        Controls.Remove(_bullets[ans]);
                        _bullets.RemoveAt(ans);
                        Controls.Remove(_chicken[i, j]);
                        _chicken[i, j] = null;
                        score += 10;
                        IblScore.Text = "Score: " + score.ToString();
                    
                    }
                }
            }
        }
    }
}
