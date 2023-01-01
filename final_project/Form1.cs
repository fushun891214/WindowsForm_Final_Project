using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final_project
{
    public partial class Form1 : Form
    {
        List<Button> buttonList = new List<Button>();
        List<int> numberList = new List<int>();
        int x = 0;
        int y = 0;
        int score = 0;
        //String result = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            score = 0;
            //label4.Text = score.ToString();
            x = 1;
            y = 0;
            
            InitButton();
            //InitList();
            SuffleListAndColor();
            button1.Enabled = false;
            timer1.Start();

            //Console.WriteLine(buttonList[1].Tag.ToString());

            for (int i = 0; i < buttonList.Count; i++)
            {
                //Console.WriteLine(numberList[i]);
                //Console.WriteLine(buttonList[i].Tag.ToString());
            }

            //Random random = new Random();
            //Console.WriteLine(buttonList.Count);
            //Console.WriteLine(random.Next(0, buttonList.Count+1));
        }

        void InitButton()
        {
            for (int i = 0; i < buttonList.Count; i++)
            {
                this.Controls.Remove(buttonList[i]);
                
            }
            buttonList.Clear();
            int counter = 1;
            for (int i = 0; i < 6 ; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Button button = new Button();
                    //button.Name = "button" + Convert.ToString(counter);
                    //button.Tag = (counter);
                    counter++;
                    button.Text = "";
                    button.TabIndex = 0;

                    int buttonWidth = 50;
                    int buttonHeight = 50;

                    int buttonSpace = 5;

                    int buttonX = buttonSpace + i * (buttonWidth + buttonSpace);
                    int buttonY = buttonSpace + (j+1) * (buttonHeight + buttonSpace);

                    button.Size = new Size(buttonWidth, buttonHeight);

                    button.Location = new Point(buttonX, buttonY);

                    //UseVisualStyleBackColor = false才能設定顏色
                    button.UseVisualStyleBackColor = false;

                    button.Click += new System.EventHandler(this.Button_Click_Playgame);

                    this.Controls.Add(button);

                    this.buttonList.Add(button);

                }
            }
            //suffleList();
        }

        void InitList()
        {
            numberList.Clear();
            for (int i = 1; i <= buttonList.Count; i++)
            {
                numberList.Add(i);
            }
        }

        void SuffleListAndColor()
        {
            InitList();
            Random random = new Random();

            int x = random.Next(1, 255);
            int y = random.Next(1, 255);
            int z = random.Next(1, 255);
            int random_x = 0;
            int random_y = 0;
            int random_z = 0;
            //initList();


            for (int i = 0; i < buttonList.Count; i++)
            {
                int randomNumber = random.Next(1, buttonList.Count);
                int temp = numberList[i];
                numberList[i] = numberList[randomNumber];
                numberList[randomNumber] = temp;
            }

            for (int i = 0; i < buttonList.Count; i++)
            {
                //buttonList[i].Text = "";
                buttonList[i].Tag = numberList[i];
                buttonList[i].Name = "button" + Convert.ToString(buttonList[i].Tag);
                //buttonList[i].Text = Convert.ToString(buttonList[i].Tag);

                buttonList[i].BackColor = System.Drawing.Color.FromArgb(x, y, z);

                if (buttonList[i].Tag.Equals(18))
                {
                    if (x < 128) random_x = (x + 20);
                    if (y < 128) random_y = (y + 20);
                    if (z < 128) random_z = (z + 20);
                    if (x > 129) random_x = (x - 20);
                    if (y > 129) random_y = (y - 20);
                    if (z > 129) random_z = (z - 20);
                    //buttonList[buttonList.Count - 1].BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
                    buttonList[i].BackColor = System.Drawing.Color.FromArgb(random_x, random_y, random_z);
                }
            }
            //Console.WriteLine(random.Next(0, buttonList.Count));
        }

        void Button_Click_Playgame(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int tag = Convert.ToInt32(button.Tag);
            
            if (tag.Equals(18))
            {
                score += 10;
                SuffleListAndColor();
               // button.BackColor = Color.AliceBlue;
            }
            else
            {
                score -= 2;
                //button.BackColor = Color.Black;
            }
            label4.Text = score.ToString();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = x.ToString() + "分" + y.ToString() + "秒";
            
            if (x == 0 && y == 0)
            {
                timer1.Stop();
                MessageBox.Show("遊戲結束囉！");
                button1.Enabled = true;
                
            }
            else if (y == 0 && x != 0)
            {
                x -= 1;
                y = 59;
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = false;
                y -= 1;
            }
        }

        //private void label1_Click(object sender, EventArgs e)
        //{

        //}

        //private void Form1_Load(object sender, EventArgs e)
        //{

        //}
    }
}
