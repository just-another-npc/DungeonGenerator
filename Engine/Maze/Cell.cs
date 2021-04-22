using System.Collections.Generic;

namespace Engine.Maze {
    public class Cell {
        
        public Cell(int x, int y) {
            X = x;
            Y = y;
        }

        public readonly int X;
        public readonly int Y;
        
        public Cell North;
        public Cell South;
        public Cell East;
        public Cell West;

        public Cell[] Exits
        {
            get
            {
                var result = new List<Cell>();

                if (NorthExit > 0)
                    result.Add(North);
                    
                if (SouthExit > 0)
                    result.Add(South);

                if (EastExit > 0)
                    result.Add(East);

                if (WestExit > 0)
                    result.Add(West);
                    
                return result.ToArray();
            }
        }


        public int NorthExit = -1;
        public int SouthExit = -1;
        public int EastExit = -1;
        public int WestExit = -1;
        
    }
}