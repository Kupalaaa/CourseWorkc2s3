using System.Media;
using static System.Formats.Asn1.AsnWriter;

namespace BobAdv
{
    public partial class Game : Form
    {
        private List<GameObject> _gameObjects  = new List<GameObject>();
        public Menu Menu;
        public SoundPlayer StepSound = new SoundPlayer("../../../resources/step.wav");
        private Bob _bob;

        public Game(Menu menu)
        {
            InitializeComponent();
            Show();
            Menu = menu;
        }
        private void Start(object sender, EventArgs e)
        {
            var world = new World(3,3,0,0,this);
            _bob = new Bob(4, 6, 32, 32, this,world, 10, 3, 0, "Bob");
            label2.Text = $"Attack / {_bob.Attack}";
            label3.Text = $"Health / {_bob.Health}";
            label4.Text = $"Score / {_bob.Score}";
        }

        public void CreateNewObject(GameObject gameObject) => _gameObjects.Add(gameObject);

        /// <summary>
        /// Step Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
                
                if (_bob.Health > 0)
                {
                StepSound.Play();
                for (var i = 0; i < _gameObjects.Count; i++)
                    _gameObjects[i]?.Update();
                    _bob.Score += 1;
                    pictureBox1.Invalidate();
                    label2.Text = $"Attack / {_bob.Attack}";
                    label3.Text = $"Health / {_bob.Health}";
                    label4.Text = $"Score / {_bob.Score}";
                }
               else
                {
                    Menu.AddToScoreList(_bob.Score);
                    Menu.Show();
                    Close();
                }

        }
        

        /// <summary>
        /// Draw picturebox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Draw(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            for (var i = 0; i < _gameObjects.Count; i++)
                _gameObjects[i]?.Draw(graphics);
        }

       
    }
}