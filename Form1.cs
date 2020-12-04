using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    /*NOTEPAD 
      Am sters butoanele acuma trebuie sa fac jocul zoom pe player !
   */
    public partial class Form1 : Form
    {
        int n, m, n1, m1, start, finish, d, g, num, cat = 0, pozX, pozY, dx, dy, stx, sty, sfx, sfy, cheiex, cheiey, x, tstart=0, timp;

        private void timer1_Tick(object sender, EventArgs e)
        {
            timp ++;
            label2.Text = Convert.ToString(timp);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            x = Convert.ToInt32(numericUpDown1.Text);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        int apasButton = 1;
        Button[,] t;
        int[,] verif;
        public Form1()
        {
            InitializeComponent();
            KeyDown += new KeyEventHandler(Form1_KeyDown);
        }

        public int chance()
        {
            Random rnd = new Random();
            int chance;
            chance = rnd.Next(0, 99);
            if (chance < 50)
                return 0;
            else
                return 1;
        } //SANSA PT PERETE SAU DRUM
        public void genRand()
        {
            Random rnd = new Random();
            d = rnd.Next(1, 5);
            if (d == 1 || d == 3)
                start = rnd.Next(2, n);
            else
                start = rnd.Next(2, m);
            g = rnd.Next(1, 5);
            while (g == d)
                g = rnd.Next(1, 5);
            if (g == 1 || g == 3)
                finish = rnd.Next(2, n);
            else
                finish = rnd.Next(2, m);
            cheiex = rnd.Next(2, n);
            cheiey = rnd.Next(2, n);
            while (verif[cheiex, cheiey] != 1)
            {
                cheiex = rnd.Next(2, n);
                cheiey = rnd.Next(2, n);
            }
        } //GENERARE POZITIE INCEPUT SI SFARSIT

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {


        } //NIMIC

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {



        } //NIMIC

        public void button1_Click(object sender, EventArgs e)
        {
            if (x < 30 || x > 50)
            {
                MessageBox.Show("Un numar intre din intervalul [30-50]!");
                x = Convert.ToInt32(numericUpDown1.Text);
            }
            else {
                tstart = 0;
                n = x;
                int i, j;
                m = n;
                void pozPlayer(int k)
                {
                    if (k == 1)
                    {
                        pozX = 2;
                        pozY = start;
                    }
                    if (k == 2)
                    {
                        pozX = start;
                        pozY = 2;
                    }
                    if (k == 3)
                    {
                        pozX = n - 1;
                        pozY = start;
                    }
                    if (k == 4)
                    {
                        pozX = start;
                        pozY = n - 1;
                    }
                    t[pozX, pozY].Show();
                    t[pozX, pozY].BackColor = Color.Red;
                    t[pozX, pozY].FlatStyle = FlatStyle.Popup;
                }
                void genSF(int k, int test)
                {
                    if (k == 1)
                    {
                        int ok = -1;
                        i = k;
                        if (test != 1)
                        {
                            stx = i;
                            sty = start;
                            t[i, start].Hide();
                        }
                        else
                        {
                            sfx = i;
                            sfy = start;
                        }
                        while (ok < 2)
                        {
                            try
                            {
                                if (verif[i + 1, start] == 1)
                                    ok++;
                                if (verif[i + 1, start] == 2)
                                {
                                    verif[i + 1, start] = 1;
                                    t[i + 1, start].Hide();
                                }
                            }
                            catch { }
                            i++;
                        }
                    }
                    else if (k == 2)
                    {
                        int ok = -1;
                        i = 1;
                        if (test != 1)
                        {
                            stx = start;
                            sty = i;
                            t[start, i].Hide();
                        }
                        else
                        {
                            sfx = start;
                            sfy = i;
                        }


                        while (ok < 2)
                        {
                            try
                            {
                                if (verif[start, i + 1] == 1)
                                    ok++;
                                if (verif[start, i + 1] == 2)
                                {
                                    verif[start, i + 1] = 1;
                                    t[start, i + 1].Hide();
                                }
                            }
                            catch { }
                            i++;
                        }
                    }
                    else if (k == 3)
                    {
                        int ok = -1;
                        i = n;
                        if (test != 1)
                        {
                            stx = i;
                            sty = start;
                            t[i, start].Hide();
                        }
                        else
                        {
                            sfx = i;
                            sfy = start;
                        }
                        while (ok < 2)
                        {
                            try
                            {
                                if (verif[i - 1, start] == 1)
                                    ok++;
                                if (verif[i - 1, start] == 2)
                                {
                                    verif[i - 1, start] = 1;
                                    t[i - 1, start].Hide();
                                }
                            }
                            catch { }
                            i--;
                        }
                    }
                    else if (k == 4)
                    {
                        int ok = -1;
                        i = n;
                        if (test != 1)
                        {
                            stx = start;
                            sty = i;
                            t[start, i].Hide();
                        }
                        else
                        {
                            sfx = start;
                            sfy = i;
                        }

                        while (ok < 2)
                        {
                            try
                            {
                                if (verif[start, i - 1] == 1)
                                    ok++;
                                if (verif[start, i - 1] == 2)
                                {
                                    verif[start, i - 1] = 1;
                                    t[start, i - 1].Hide();
                                }
                            }
                            catch { }
                            i--;
                        }
                    }
                } //GENERARE START SI FINISH
                void genAby(int k, int l)
                {

                    if (verif[k, l] == 0)
                    {
                        cat++;
                        try
                        { t[k, l].Hide(); }
                        catch { }
                        verif[k, l] = 1;
                        int ok = 0;
                        try
                        {
                            if (verif[k + 1, l] == 1)
                                ok++;
                        }
                        catch
                        { }
                        try
                        {
                            if (verif[k - 1, l] == 1)
                                ok++;
                        }
                        catch
                        { }
                        try
                        {
                            if (verif[k, l - 1] == 1)
                                ok++;
                        }
                        catch
                        { }
                        try
                        {
                            if (verif[k, l + 1] == 1)
                                ok++;
                        }
                        catch
                        { }
                        if (chance() == 0)
                        {
                            try
                            {
                                t[k, l].Show();
                                verif[k, l] = 2;
                            }
                            catch { }

                        }

                        else if (ok > 1)
                        {
                            try
                            {
                                t[k, l].Show();
                                verif[k, l] = 2;
                            }
                            catch { }

                        }
                        else if (verif[k, l] == 2)
                        {
                            if (ok >= 3)
                            {
                                t[k, l].Hide();
                                verif[k, l] = 1;
                            }
                        }
                        else
                        {
                            genAby(k + 1, l);
                            genAby(k - 1, l);
                            genAby(k, l + 1);
                            genAby(k, l - 1);
                        }
                    }

                } //GENERARE MATRICE
                void verifica(int k, int l)
                {
                    if (verif[k, l] == 2)
                    {
                        int ok = 0;
                        if (verif[k + 1, l] == 1)
                            ok++;
                        if (verif[k - 1, l] == 1)
                            ok++;
                        if (verif[k, l - 1] == 1)
                            ok++;
                        if (verif[k, l + 1] == 1)
                            ok++;
                        if (ok >= 2)
                            try
                            {

                                t[k, l].Hide();
                                verif[k, l] = 1;

                            }
                            catch { }
                    }
                } //CONDITIE PT GENERARE LABIRINT
                try
                {
                    for (i = 1; i <= n1; i++)
                    {
                        for (j = 1; j <= m1; j++)
                        {
                            t[i, j].Dispose();
                        }
                    }
                }
                catch
                {
                } //STERGEM BUTOANELE

                int dx = (this.Width - 10 * n) / 2;
                int dy = (this.Height - 10 * m) / 2;
                t = new Button[n + 5, m + 5];
                verif = new int[n + 5, m + 5];
                for (i = 1; i <= n; i++)
                {
                    for (j = 1; j <= m; j++)
                    {
                        verif[i, j] = 0;
                        t[i, j] = new Button();
                        t[i, j].Location = new System.Drawing.Point(dx + (10 * i), dy + (10 * j));
                        t[i, j].Size = new System.Drawing.Size(10, 10);
                        t[i, j].BackColor = Color.White;
                        t[i, j].FlatStyle = FlatStyle.Popup;
                        this.Controls.Add(t[i, j]);
                    }
                } //DESENAM BUTOANELE
                  /*for (i = 1; i <= n; i++)
                  {
                      for(j=1; j<=m;j++)
                      {

                              t[i, j].Hide();

                      }
                  }*/
                n1 = n;
                m1 = m;
                for (i = 1; i <= n1; i++)
                {
                    verif[i, 1] = 3;

                    verif[i, n] = 3;

                } //PERETE EXTERIOR I
                for (i = 1; i <= m1; i++)
                {
                    verif[1, i] = 3;
                    verif[n, i] = 3;
                } //PERETE EXTERIOR II

                cat = n * 2 + (m * 2) - 4; //{
                Random rnd = new Random(); //{GERARE DRUM RANDOM
                while (cat < n * m)
                {
                    num = rnd.Next(1, (m * n));
                    if (num % m == 0)
                    {

                        genAby(num / m, m);
                    }
                    else
                    {

                        genAby(num / m + 1, num % m);
                    }
                }     //{
                for (i = 2; i < n; i++)
                    for (j = 2; j < n; j++)
                    {

                        int ok = 0;
                        if (verif[i, j] == 2)
                        {
                            if (verif[i + 1, j] == 1)
                                ok++;
                            if (verif[i - 1, j] == 1)
                                ok++;
                            if (verif[i, j - 1] == 1)
                                ok++;
                            if (verif[i, j + 1] == 1)
                                ok++;
                            if (ok == 0)
                            {
                                genAby(i, j);
                            }


                        }


                    } //VERIFICAM SPATII GOALE
                for (i = 2; i < n; i++)
                    for (j = 2; j < n; j++)
                    {
                        int ok = 0;
                        if (verif[i, j] == 1)
                        {
                            if (verif[i + 1, j] == 2)
                                ok++;
                            if (verif[i - 1, j] == 2)
                                ok++;
                            if (verif[i, j - 1] == 2)
                                ok++;
                            if (verif[i, j + 1] == 2)
                                ok++;
                            if (ok >= 3)
                            {
                                verifica(i + 1, j);
                                verifica(i - 1, j);
                                verifica(i, j + 1);
                                verifica(i, j - 1);
                            }

                        }

                    } //TESTUL 2 PT VERIFICARE SPATII GOALE

                /*for (i = 1; i <= n; i++)
                    for (j = 1; j <= m; j++)
                        MessageBox.Show(Convert.ToString(verif[i, j]));*/
                genRand();
                genSF(d, 0);//intrare
                genSF(g, 1);//iesire
                pozPlayer(d); //pozitie player
                for (i = 1; i <= n; i++)
                {
                    for (j = 1; j <= m; j++)
                    {

                        t[i, j].Hide();

                    }
                }
                for (i = pozX - 3; i <= pozX + 3; i++)
                    for (j = pozY - 3; j <= pozY + 3; j++)
                    {
                        try
                        {
                            if (i == cheiex && j == cheiey)
                            {
                                t[i, j].Show();
                                t[i, j].BackColor = Color.Yellow;
                                t[i, j].FlatStyle = FlatStyle.Popup;
                            }
                            if (i == pozX && j == pozY)
                            {
                                t[i, j].Show();
                                t[i, j].BackColor = Color.Red;
                                t[i, j].FlatStyle = FlatStyle.Popup;
                            }

                            /*if (verif[i, j] != 1)
                            {
                          
                                t[i, j].Show();
                            }*/
                        }
                        catch { }

                    }
                timer1.Start();
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
            {
            try
            {
                
                    
                int i;
                int j;
                /*for (i = pozX - 3; i <= pozX + 3; i++)
                    for (j = pozY - 3; j <= pozY + 3; j++)
                    {
                        try
                        {
                            t[i, j].BackColor = Color.White;
                            t[i, j].Hide();
                        }
                        catch { };
                    }*/
                if (e.KeyCode == Keys.D && verif[pozX + 1, pozY] == 1)
                {
                    for (i = pozX - 3; i <= pozX - 3; i++)
                        for (j = pozY - 3; j <= pozY + 3; j++)
                        {
                            try { t[i, j].Hide(); }
                            catch { }
                        }
                    try
                    {
                        t[pozX, pozY].Hide();
                        t[pozX, pozY].BackColor = Color.White;
                        t[pozX, pozY].FlatStyle = FlatStyle.Popup;
                    }
                    catch { }
                    pozX++;
                    try
                    {
                        t[pozX, pozY].Show();
                        t[pozX, pozY].BackColor = Color.Red;
                        t[pozX, pozY].FlatStyle = FlatStyle.Popup;
                    }
                    catch { }
                    for (i = pozX + 3; i <= pozX + 3; i++)
                        for (j = pozY - 3; j <= pozY + 3; j++)
                        {
                            try
                            {

                                if (i == cheiex && j == cheiey)
                                {
                                    t[i, j].Show();
                                    t[i, j].BackColor = Color.Yellow;
                                    t[i, j].FlatStyle = FlatStyle.Popup;
                                }
                                if (i == pozX && j == pozY)
                                {
                                    t[i, j].Show();
                                    t[i, j].BackColor = Color.Red;
                                    t[i, j].FlatStyle = FlatStyle.Popup;
                                }
                                if ((i == sfx && j == sfy) && verif[sfx, sfy] == 1)
                                {
                                    t[i, j].Show();
                                    t[i, j].BackColor = Color.BlueViolet;
                                    t[i, j].FlatStyle = FlatStyle.Popup;
                                }
                                if (pozX == cheiex && pozY == cheiey)
                                {
                                    verif[sfx, sfy] = 1;
                                    cheiex = -1;
                                    cheiey = -1;
                                }
                                if (pozX == sfx && pozY == sfy)
                                {
                                    timer1.Stop();
                                    MessageBox.Show("Bravo! Ai terminat in " + timp + " secunde!");

                                    this.Close();
                                }
                                if (verif[i, j] != 1)
                                    t[i, j].Show();
                            }
                            catch { }
                        }

                }
                else if (e.KeyCode == Keys.A && verif[pozX - 1, pozY] == 1)
                {
                    for (i = pozX + 3; i <= pozX + 3; i++)
                        for (j = pozY - 3; j <= pozY + 3; j++)
                        {
                            try { t[i, j].Hide(); }
                            catch { }
                        }
                    try
                    {
                        t[pozX, pozY].Hide();
                        t[pozX, pozY].BackColor = Color.White;
                        t[pozX, pozY].FlatStyle = FlatStyle.Popup;
                    }
                    catch { }
                    pozX--;
                    try
                    {
                        t[pozX, pozY].Show();
                        t[pozX, pozY].BackColor = Color.Red;
                        t[pozX, pozY].FlatStyle = FlatStyle.Popup;
                    }
                    catch { }
                    for (i = pozX - 3; i <= pozX - 3; i++)
                        for (j = pozY - 3; j <= pozY + 3; j++)
                        {
                            try
                            {

                                if (i == cheiex && j == cheiey)
                                {
                                    t[i, j].Show();
                                    t[i, j].BackColor = Color.Yellow;
                                    t[i, j].FlatStyle = FlatStyle.Popup;
                                }
                                if (i == pozX && j == pozY)
                                {
                                    t[i, j].Show();
                                    t[i, j].BackColor = Color.Red;
                                    t[i, j].FlatStyle = FlatStyle.Popup;
                                }
                                if ((i == sfx && j == sfy) && verif[sfx, sfy] == 1)
                                {
                                    t[i, j].Show();
                                    t[i, j].BackColor = Color.BlueViolet;
                                    t[i, j].FlatStyle = FlatStyle.Popup;
                                }
                                if (pozX == cheiex && pozY == cheiey)
                                {
                                    verif[sfx, sfy] = 1;
                                    cheiex = -1;
                                    cheiey = -1;
                                }
                                if (pozX == sfx && pozY == sfy)
                                {
                                    timer1.Stop();
                                    MessageBox.Show("Bravo! Ai terminat in " + timp + " secunde!");

                                    this.Close();
                                }
                                if (verif[i, j] != 1)
                                    t[i, j].Show();
                            }
                            catch { }
                        }

                }
                else if (e.KeyCode == Keys.W && verif[pozX, pozY - 1] == 1)
                {
                    for (i = pozX - 3; i <= pozX + 3; i++)
                        for (j = pozY + 3; j <= pozY + 3; j++)
                        {
                            try { t[i, j].Hide(); }
                            catch { }
                        }
                    try
                    {
                        t[pozX, pozY].Hide();
                        t[pozX, pozY].BackColor = Color.White;
                        t[pozX, pozY].FlatStyle = FlatStyle.Popup;
                    }
                    catch { }
                    pozY--;
                    try
                    {
                        t[pozX, pozY].Show();
                        t[pozX, pozY].BackColor = Color.Red;
                        t[pozX, pozY].FlatStyle = FlatStyle.Popup;
                    }
                    catch { }
                    for (i = pozX - 3; i <= pozX + 3; i++)
                        for (j = pozY - 3; j <= pozY - 3; j++)
                        {
                            try
                            {

                                if (i == cheiex && j == cheiey)
                                {
                                    t[i, j].Show();
                                    t[i, j].BackColor = Color.Yellow;
                                    t[i, j].FlatStyle = FlatStyle.Popup;
                                }
                                if (i == pozX && j == pozY)
                                {
                                    t[i, j].Show();
                                    t[i, j].BackColor = Color.Red;
                                    t[i, j].FlatStyle = FlatStyle.Popup;
                                }
                                if ((i == sfx && j == sfy) && verif[sfx, sfy] == 1)
                                {
                                    t[i, j].Show();
                                    t[i, j].BackColor = Color.BlueViolet;
                                    t[i, j].FlatStyle = FlatStyle.Popup;
                                }
                                if (pozX == cheiex && pozY == cheiey)
                                {
                                    verif[sfx, sfy] = 1;
                                    cheiex = -1;
                                    cheiey = -1;
                                }
                                if (pozX == sfx && pozY == sfy)
                                {
                                    timer1.Stop();
                                    MessageBox.Show("Bravo! Ai terminat in " + timp + " secunde!");

                                    this.Close();
                                }
                                if (verif[i, j] != 1)
                                    t[i, j].Show();
                            }
                            catch { }
                        }
                }
                else if (e.KeyCode == Keys.S && verif[pozX, pozY + 1] == 1)
                {
                    for (i = pozX - 3; i <= pozX + 3; i++)
                        for (j = pozY - 3; j <= pozY - 3; j++)
                        {
                            try { t[i, j].Hide(); }
                            catch { }
                        }
                    try
                    {
                        t[pozX, pozY].Hide();
                        t[pozX, pozY].BackColor = Color.White;
                        t[pozX, pozY].FlatStyle = FlatStyle.Popup;
                    }
                    catch { }
                    pozY++;
                    try
                    {
                        t[pozX, pozY].Show();
                        t[pozX, pozY].BackColor = Color.Red;
                        t[pozX, pozY].FlatStyle = FlatStyle.Popup;
                    }
                    catch { }
                    for (i = pozX - 3; i <= pozX + 3; i++)
                        for (j = pozY + 3; j <= pozY + 3; j++)
                        {
                            try
                            {

                                if (i == cheiex && j == cheiey)
                                {
                                    t[i, j].Show();
                                    t[i, j].BackColor = Color.Yellow;
                                    t[i, j].FlatStyle = FlatStyle.Popup;
                                }
                                if (i == pozX && j == pozY)
                                {
                                    t[i, j].Show();
                                    t[i, j].BackColor = Color.Red;
                                    t[i, j].FlatStyle = FlatStyle.Popup;
                                }
                                if ((i == sfx && j == sfy) && verif[sfx, sfy] == 1)
                                {
                                    t[i, j].Show();
                                    t[i, j].BackColor = Color.BlueViolet;
                                    t[i, j].FlatStyle = FlatStyle.Popup;
                                }
                                if (pozX == cheiex && pozY == cheiey)
                                {
                                    verif[sfx, sfy] = 1;
                                    cheiex = -1;
                                    cheiey = -1;
                                }
                                if (pozX == sfx && pozY == sfy)
                                {
                                    timer1.Stop();
                                    MessageBox.Show("Bravo! Ai terminat in " + timp + " secunde!");

                                    this.Close();
                                }
                                if (verif[i, j] != 1)
                                    t[i, j].Show();
                            }
                            catch { }
                        }
                }
            }
            catch { }
                /*for (i = pozX - 3; i <= pozX + 3; i++)
                    for (j = pozY - 3; j <= pozY + 3; j++)
                    {
                        try
                        {

                            if (i == cheiex && j == cheiey)
                            {
                                t[i, j].Show();
                                t[i, j].BackColor = Color.Yellow;
                                t[i, j].FlatStyle = FlatStyle.Popup;
                            }
                            if (i == pozX && j == pozY)
                            {
                                t[i, j].Show();
                                t[i, j].BackColor = Color.Red;
                                t[i, j].FlatStyle = FlatStyle.Popup;
                            }
                            if ((i == sfx && j == sfy) && verif[sfx, sfy] == 1)
                            {
                                t[i, j].Show();
                                t[i, j].BackColor = Color.BlueViolet;
                                t[i, j].FlatStyle = FlatStyle.Popup;
                            }
                            if (pozX==cheiex && pozY==cheiey)
                            {
                                verif[sfx, sfy] = 1;
                                cheiex = -1;
                                cheiey = -1;
                            }
                            if(pozX==sfx && j==sfy)
                            {
                                MessageBox.Show("Bravo!");
                                this.Close();
                            }
                            if (verif[i, j] != 1)
                                t[i, j].Show();
                        }
                        catch { }*/
            }
        }
    


    
    }  //MOVEMENT 
      /*private void Press_KeyDown(object sender, KeyEventArgs e)
      {

          apasButton = 0; 
      }*/

