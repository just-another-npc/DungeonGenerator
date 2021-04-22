namespace Engine.Maze {
    public class Grid {
        private readonly int _w;
        private readonly int _h;
        public readonly Cell[,] Cells;

        public Grid(int width, int height) {
            _w = width;
            _h = height;
            Cells = new Cell[width, height];

            for (int w = width - 1; w >= 0; w--) {
                for (int h = height - 1; h >= 0; h--) {
                    Cells[w,h] = new Cell(w, h);
                }
            }

            Link();
        }
        
        // Links the cells in the grid. (0,0) is top left, (width,height) bottom right
        private void Link() {
            for (int x = 0; x < _w; x++) {
                for (int y = 0; y < _h; y++) {

                    // North
                    if (y > 0) {
                        Cells[x,y].North = Cells[x,y-1];
                    }

                    // South
                    if (y < _h-1) {
                        Cells[x,y].South = Cells[x,y+1];
                    }

                    // East
                    if (x < _w-1) {
                        Cells[x,y].East = Cells[x+1,y];
                    }

                    // West
                    if (x > 0) {
                        Cells[x,y].West = Cells[x-1,y];
                    }
                }
            }
        }
    }
}