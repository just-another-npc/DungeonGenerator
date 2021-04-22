using System;

namespace Engine
{
    public class GeneratorEngine 
    {
        private readonly int _seed;
        private readonly Random _random;


        public GeneratorEngine(int seed) {
            _seed = seed;
            _random = new Random(seed);
        }
    }
}
