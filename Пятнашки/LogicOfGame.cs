using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Пятнашки
{
    class Game
    {
        readonly int size;
        readonly int[,] map;
        int spaceX, spaceY;
        static Random rand = new Random();


        public Game(int size)
        {
            if (size < 2) size = 2;
            if (size > 5) size = 5;
            this.size = size;
            map = new int[size, size];



        }

        public void Start()
        {
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    map[x,y] = CoordsToPosition(x,y) + 1;
            spaceX = size - 1;
            spaceY = size - 1;
            map[spaceX,spaceY] = 0;
        }

        public int GetNumber (int position)
        {
            
            PositionToCoords(position, out int x, out int y);
            if (x < 0 || x >= size) return 0;
            if (y < 0 || y >= size) return 0;
            return map[x, y];
        }

        private void PositionToCoords(int position, out int x, out int y)
        {
            if (position < 0) position = 0;
            if (position > size * size) position = size * size -1;
            x = position % size;
            y = position / size;
        }

        private int CoordsToPosition(int x, int y)
        {
            if (x < 0) x = 0;
            if (x > size - 1) x = size - 1;
            if (y < 0) y = 0;
            if (y > size - 1) y = size - 1;
            return y * size + x;

        }

        public void shift(int position)
        {
            
            PositionToCoords(position, out int x, out int y);
            if (Math.Abs(spaceX - x) + Math.Abs(spaceY - y) != 1)
                return;
            map[spaceX, spaceY] = map[x, y];
            map[x, y] = 0;
            spaceX = x;
            spaceY = y;

        }

        public void shift_random()
        {
            //shift(rand.Next(0, size * size));
            int a = rand.Next(0, 4);
            int x = spaceX;
            int y = spaceY;
            switch (a)
            {
                case 0: x--; break;
                case 1: x++; break;
                case 2: y--; break;
                case 3: y++; break;
            }
            shift(CoordsToPosition(x, y));

        }
        public bool CheckGame()
            {
                if (!(spaceX == size - 1 && spaceY == size - 1))
                    return false;
                for (int x = 0; x < size; x++)
                    for (int y = 0; y < size; y++)
                        if (!(x == size - 1 && y == size - 1))
                        if (map[x, y] != CoordsToPosition(x, y) + 1)
                            return false;
                return true;

            }
        
    
    }
}
