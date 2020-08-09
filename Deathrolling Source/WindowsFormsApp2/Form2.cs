using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{

    public partial class Form2 : Form
    {
        int isstart = 0;
        static Random Dice = new Random();//dice object
        public int maxroll = 2000;//max dice roll
        public List<int> lastrolls = new List<int> { };//roll history
        public int[] PID = { 1, 2 };//player id
        public int[] thatroll = { 0, 0 };//what the player rolled last
        public string[] Pname = { "Player 1", "Player 2" };//player names
        public int PDSwitch = 1;//player switch
        public bool isshown = true;
        
        






        public void Form2_Load(object sender, EventArgs e)
        {
            button1.Hide();//hides the reset button
            label1.Hide();
            label4.Hide();

        }

        private void button1_Click(object sender, EventArgs e)// on button 1 click
        {
            
            isstart = 0;// isstart eqals 0
            maxroll = 2000;//maxroll reset
            textBox1.Show();//show namebox
            textBox2.Show();//show player 2 namebox
            label2.Show();//show label
            button2.Text = "Submit";//make button 2 say submit
            textBox4.Text = null;//null what is in the roll box
            lastrolls.Clear();//clear previous rolls
            label3.Text = null;//gets rid of text
            label1.Hide();
            label4.Hide();
            richTextBox1.Text = null;

        }

        public Form2()
        {
            InitializeComponent(); 
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
           

            if (isstart == 0) //on startup
            {
                label1.Hide();
                label4.Hide();
                button1.Hide();// hide reset button
                if (textBox1.Text != "")//set player 1 name
                {
                    label1.Text = textBox1.Text;
                    Pname[0] = textBox1.Text;
                }
                
                if (textBox2.Text != "")//set player 2 name
                {
                    label4.Text = textBox2.Text;
                    Pname[1] = textBox2.Text;

                }

                if (PDSwitch == PID[0]) // make lable 3 say roll
                {
                    label3.Text = "Roll:";

                }

                richTextBox1.Text += "Previous rolls";

                
                textBox1.Hide();//hide 1st textbox
                textBox2.Hide();//hide second textbox
                label2.Hide();//hide label 2
                button1.Hide();
                richTextBox1.Text = null;
                button2.Text = "Roll";
                isstart++;
               
                
            }
            else if (isstart == 1) 
            {
                label1.Show();
                label4.Show();
                //players take turns rolling the dice
                int dice = Dice.Next(0, maxroll);
                maxroll = dice;
                textBox4.Text = dice.ToString();
                
                if (PDSwitch == PID[0]) 
                {
                    thatroll[0] = dice;
                    label3.Text = Pname[0] + " " + "Roll:";
                    richTextBox1.Text += Environment.NewLine + Pname[0] + " rolled: " + thatroll[0];
                    richTextBox1.Text += Environment.NewLine;
                    PDSwitch++;
                    

                }
                else if (PDSwitch == PID[1])
                {
                    thatroll[1] = dice;
                    label3.Text = Pname[1] + " " + "Roll:";
                    richTextBox1.Text += Environment.NewLine + Pname[1] + " rolled: " + thatroll[1];
                    richTextBox1.Text += Environment.NewLine;
                    PDSwitch--;
                    
                }
                if (lastrolls.Count > 1)
                {
                    
                }
                lastrolls.Add(dice);
                if (maxroll == 0)
                {
                    button1.Show();
                    isstart++;
                }
                
            }
            if (isstart == 2) 
            {
                //tell players who has won
                if (thatroll[0] == 0)
                {
                    label3.Text = Pname[1] + " has won the game";
                }
                else if (thatroll[1] == 0)
                {
                    label3.Text = Pname[0] + " has won the game";

                }


            }
            

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void MainMenuBtn_Click(object sender, EventArgs e)
        {

            Deathrolling f1 = new Deathrolling();
            f1.Show();

            this.Close();
        }
    }
}
