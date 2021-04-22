using System;
using Engine.Maze;
using Engine.Output;
using Engine.Workers;

namespace Engine
{
    public class GeneratorEngine 
    {
        private readonly int _seed;
        private readonly Random _random;
        private Grid _dungeon;

        public int Width = 10;
        public int Height = 5;

        public GeneratorEngine(int seed) {
            _seed = seed;
            _random = new Random(seed);
        }
        
        public void Generate() {
            _dungeon = new Grid(Width, Height);
            new CellVisitor(_dungeon, _random, 50).DrawMaze();
        }

        public void OutputDungeon(IDungeonOutput output) {
           output.OutputDungeon(_dungeon);
        }
    }
}
