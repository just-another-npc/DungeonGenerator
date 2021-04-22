using System;
using Engine;
using Engine.Output;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new GeneratorEngine(1234);
            engine.Generate();
            engine.OutputDungeon(new ASCIIDungeonOutput());
        }
    }
}
