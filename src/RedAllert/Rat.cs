using System.Media;

namespace BobAdv
{

    public class Rat : ALifeUnit
    {
        public Image Sprite = Image.FromFile("../../../resources/dirt.png");


        public Rat(int x, int y, int width, int height, Game form, int health, int attack,int score, string name) : base(x, y, width,
            height, form, health, attack,score, name)
        {
            var random = new Random();
            
            Health = random.Next(6, 8);
            Attack = random.Next(2, 4);
        }

        public override void Draw(Graphics graphics)
        {

        }
        
        public override void BattleDraw(Graphics graphics)
        {
            graphics.DrawImage(Sprite, X * Width, Y * Height);
        }

        public override void Update()
        {
            
        }
    }
}