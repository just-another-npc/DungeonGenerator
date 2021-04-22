using System;
using System.Linq;
using System.Text;
using Engine.Maze;

namespace Engine.Output {
    public class ASCIIDungeonOutput : IDungeonOutput
    {
        
        public static readonly char NSEW = '╬';
        public static readonly char NEW = '╩';
        public static readonly char SEW = '╦';
        public static readonly char NSW = '╣';
        public static readonly char NSE = '╠';
        public static readonly char NW = '╝';
        public static readonly char NE = '╚';
        public static readonly char SE = '╔';
        public static readonly char SW = '╗';
        public static readonly char NS = '║';
        public static readonly char EW = '═';
        public static readonly char N = '╨';
        public static readonly char S = '╥';
        public static readonly char E = '╞';
        public static readonly char W = '╡';
        public static readonly char X = 'X';
        public static readonly char OOPS = '?';

        public void OutputDungeon(Grid dungeon)
        {
            var sb = new StringBuilder();
            
            for (int y = 0; y < dungeon.Height; y++) {
                for (int x = 0; x < dungeon.Width; x++) {
                    sb.Append(GetSegment(dungeon.Cells[x,y]));
                }
                sb.AppendLine();
            }
            
            Console.WriteLine(sb);
        }

        public char GetSegment(Cell room)  {
            switch (room.Exits.Where(x => x != null).Count()) {
                case 4: {
                    return NSEW;
                }
                case 3: {
                    if (room.NorthExit > 0 && room.SouthExit > 0 && room.WestExit > 0)
                        return NSW;
                    if (room.NorthExit > 0 && room.EastExit > 0 && room.WestExit > 0)
                        return NEW;
                    if (room.SouthExit > 0 && room.EastExit > 0 && room.WestExit > 0)
                        return SEW;
                    if (room.NorthExit > 0 && room.SouthExit > 0 && room.EastExit > 0)
                        return NSE;
                    return OOPS;
                }
                case 2: {
                    if (room.NorthExit > 0 && room.EastExit > 0)
                        return NE;
                    if (room.NorthExit > 0 && room.WestExit > 0)
                        return NW;
                    if (room.NorthExit > 0 && room.SouthExit > 0)
                        return NS;
                    if (room.EastExit > 0 && room.WestExit > 0)
                        return EW;
                    if (room.SouthExit > 0 && room.EastExit > 0)
                        return SE;
                    if (room.SouthExit > 0 && room.WestExit > 0)
                        return SW;
                
                    return OOPS;    
                }
                case 1: {
                    if (room.NorthExit > 0)
                        return N;
                    if (room.SouthExit > 0)
                        return S;
                    if (room.EastExit > 0)
                        return E;
                    if (room.WestExit > 0)
                        return W;
                    return OOPS;
                }
                case 0: {
                    return X;
                }
            } 
            
            return OOPS;
        }

    }
}