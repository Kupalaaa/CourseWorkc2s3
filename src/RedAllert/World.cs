using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BobAdv
{
    public class World : GameObject
    {
        private List<Tile> _tiles = new List<Tile>();
        private List<Tuple<GameObject, int>> _gameObjectInWorld = new();
        private Random _random = new Random();

        public World(int x, int y, int width, int height, Game form) : base(x, y, width, height, form)
        {
            InitMap();
        }

        public void SetToTile(GameObject gameObject) {
            var index = _random.Next(_tiles.Count);
            _gameObjectInWorld.Add(new Tuple<GameObject, int>(gameObject, index));

            _gameObjectInWorld.Last().Item1.X = _tiles[index].X;
            _gameObjectInWorld.Last().Item1.Y = _tiles[index].Y;
        }


        public void MoveToNextTile(GameObject gameObject)
        {
            var findedObject = _gameObjectInWorld.FindIndex(x => x.Item1 == gameObject);

            if (_gameObjectInWorld[findedObject].Item2 == _tiles.Count - 1)
            {
                _gameObjectInWorld[findedObject].Item1.X = _tiles[0].X;
                _gameObjectInWorld[findedObject].Item1.Y = _tiles[0].Y;
                _gameObjectInWorld[findedObject] = new Tuple<GameObject, int>(_gameObjectInWorld[findedObject].Item1, 0);
                return;
            }

            _gameObjectInWorld[findedObject].Item1.X = _tiles[_gameObjectInWorld[findedObject].Item2 + 1].X;
            _gameObjectInWorld[findedObject].Item1.Y = _tiles[_gameObjectInWorld[findedObject].Item2 + 1].Y;
            _gameObjectInWorld[findedObject] = new Tuple<GameObject, int>(_gameObjectInWorld[findedObject].Item1, _gameObjectInWorld[findedObject].Item2 + 1);
        }

        public override void Draw(Graphics graphics) { }

        public override void Update() { }

        private void InitMap()
        {
            Random x1r = new Random();
             var x1Count = x1r.Next(10,25);
             Random y1r = new Random(); 
             var y1Count = y1r.Next(3,14);
             Random x2r = new Random();
             var x2Count = x2r.Next(10,25);
             Random y2r = new Random();
             var y2Count = y2r.Next(3, 14);
           
            for (int x = X; x <= x1Count + X; x++)
                _tiles.Add(new Tile(x, Y, 32, 32, Form, 0));

            for (int y = Y ; y <= y1Count + Y; y++)
                _tiles.Add(new Tile(X + x1Count, y, 32, 32, Form, 0));

            for (int x = X+x1Count; x <=x1Count + x2Count + X; x++)
                _tiles.Add(new Tile(x, Y+y1Count, 32, 32, Form, 0));

            for (int y = Y + y1Count; y <= y1Count + y2Count + Y; y++)
                _tiles.Add(new Tile(X + x1Count+x2Count, y, 32, 32, Form, 0));

            for (int x = X + x1Count +x2Count; x >=x2Count + X; x--)
                _tiles.Add(new Tile(x, Y + y1Count+ y2Count , 32, 32, Form, 0));

            for (int y = Y + y1Count+y2Count; y >= y2Count + Y; y--)
                _tiles.Add(new Tile(X+x2Count, y, 32, 32, Form, 0));

            for (int x = X + x2Count; x >= X; x--)
                _tiles.Add(new Tile(x, Y + y2Count, 32, 32, Form, 0));

            for (int y = Y + y2Count; y >= Y; y--)
                _tiles.Add(new Tile(X, y, 32, 32, Form, 0)); 

        }
    }
}
