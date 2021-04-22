namespace Engine.Maze {
    public class Grid {
        // Width of the dungeon, 0 based.
        public readonly int Width;
        // Height of the dungeon, 0 based.
        public readonly int Height;
        public readonly Cell[,] Cells;

        public Grid(int width, int height) {
            Width = width;
            Height = height;
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
            for (int x = 0; x < Width; x++) {
                for (int y = 0; y < Height; y++) {

                    // North
                    if (y > 0) {
                        Cells[x,y].North = Cells[x,y-1];
                    }

                    // South
                    if (y < Height-1) {
                        Cells[x,y].South = Cells[x,y+1];
                    }

                    // East
                    if (x < Width-1) {
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