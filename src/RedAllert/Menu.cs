using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BobAdv
{ 
    public partial class Menu : Form
    {
        private Dictionary<string, int> _scores = new Dictionary<string, int>();
        public SoundPlayer MainSound = new SoundPlayer("../../../resources/main.wav");
        public Menu()
        {
            InitializeComponent();
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            new Game(this);
            MainSound.Stop();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void AddToScoreList(int score)
        {
            listBox1.Items.Clear();
            if (_scores.ContainsKey(textBox1.Text == string.Empty ? "Unknow" : textBox1.Text))
                _scores[textBox1.Text == string.Empty ? "Unknow" : textBox1.Text] = _scores[textBox1.Text == string.Empty ? "Unknow" : textBox1.Text] < score ? score : _scores[textBox1.Text == string.Empty ? "Unknow" : textBox1.Text];
            else
                _scores.Add(textBox1.Text == string.Empty ? "Unknow" : textBox1.Text, score);
            foreach (var s in _scores.OrderByDescending(x => x.Value))
                listBox1.Items.Add($"{s.Key}:{s.Value}\n");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                MainSound.PlayLooping();
            }
            else
            {
                MainSound.Stop();
            }
        }
    }
}
