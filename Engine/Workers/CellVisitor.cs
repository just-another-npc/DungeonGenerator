using System;
using Engine.Maze;
using System.Linq;
using System.Collections.Generic;

namespace Engine.Workers {
    public class CellVisitor {
        private readonly Random _rng;
        private readonly bool[,] _visited;
        public readonly Grid Dungeon;
        private readonly int _turnChance;
        private readonly List<Cell> _visitedCells = new List<Cell>();

        public CellVisitor(Grid dungeon, Random rng, int turnChance) {
            _rng = rng;
            _visited = new bool[dungeon.Width, dungeon.Height];
            _turnChance = turnChance;
            Dungeon = dungeon;
        }
        
        public void DrawMaze() {
            var curCell = Dungeon.Cells[_rng.Next(0, Dungeon.Width), _rng.Next(0, Dungeon.Height)] ;
            var canMove = true;
            var nextDir = _rng.Next(0, 4);
            var dirsUsed = new List<int>();
            var lastValid = true;
        
            while (canMove)
            {
                Cell nextCell = null;
                _visited[curCell.X, curCell.Y] = true;

                if (!_visitedCells.Contains(curCell))
                {
                    _visitedCells.Add(curCell);
                }

                if (_rng.Next(0, 100) <= _turnChance || !lastValid) {
                    nextDir = _rng.Next(0, 4);
                }
                
                switch (nextDir)
                {
                    case 0:
                        if (curCell.North != null && !_visited[curCell.North.X, curCell.North.Y])
                        {
                            nextCell = curCell.North;
                            curCell.NorthExit = 1;
                            nextCell.SouthExit = 1;
                        }
                        break;
                    case 1:
                        if (curCell.South != null && !_visited[curCell.South.X, curCell.South.Y])
                        {
                            nextCell = curCell.South;
                            curCell.SouthExit = 1;
                            nextCell.NorthExit = 1;
                        }
                        break;
                    case 2:
                        if (curCell.East != null && !_visited[curCell.East.X, curCell.East.Y])
                        {
                            nextCell = curCell.East;
                            curCell.EastExit = 1;
                            nextCell.WestExit = 1;
                        }
                        break;
                    case 3:
                        if (curCell.West != null && !_visited[curCell.West.X, curCell.West.Y])
                        {
                            nextCell = curCell.West;
                            curCell.WestExit = 1;
                            nextCell.EastExit = 1;
                        }
                        break;
                }

                if (nextCell != null) {
                    curCell = nextCell;
                    lastValid = true;
                }
                else {
                    lastValid = false;

                    if (!dirsUsed.Contains(nextDir)) {
                        dirsUsed.Add(nextDir);
                    }
                }

                if (!lastValid && dirsUsed.Count == 4) {
                    if (_visitedCells.Count == Dungeon.Width * Dungeon.Height) {
                        canMove = false;
                    }
                    else {
                        curCell = _visitedCells.ElementAt(_rng.Next(0, _visitedCells.Count));
                    }
                }
            }
        }
    }
}