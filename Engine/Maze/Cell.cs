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

        public int NorthExit = -1;
        public int SouthExit = -1;
        public int EastExit = -1;
        public int WestExit = -1;
        
    }
}