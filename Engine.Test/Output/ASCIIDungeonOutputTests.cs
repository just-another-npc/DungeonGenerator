using Engine.Maze;
using Engine.Output;
using NUnit.Framework;

namespace Engine.Test.Output {
    public class ASCIIDungeonOutputTests {
        [Test]
        public void GetSegmentTests() {
            var op = new ASCIIDungeonOutput();
            
            Assert.AreEqual(ASCIIDungeonOutput.N, op.GetSegment(CreateCell(true, false, false, false)));
            Assert.AreEqual(ASCIIDungeonOutput.S, op.GetSegment(CreateCell(false, true, false, false)));
            Assert.AreEqual(ASCIIDungeonOutput.E, op.GetSegment(CreateCell(false, false, true, false)));
            Assert.AreEqual(ASCIIDungeonOutput.W, op.GetSegment(CreateCell(false, false, false, true)));
            
            Assert.AreEqual(ASCIIDungeonOutput.NS, op.GetSegment(CreateCell(true, true, false, false)));
            Assert.AreEqual(ASCIIDungeonOutput.EW, op.GetSegment(CreateCell(false, false, true, true)));
            
            Assert.AreEqual(ASCIIDungeonOutput.NE, op.GetSegment(CreateCell(true, false, true, false)));
            Assert.AreEqual(ASCIIDungeonOutput.NW, op.GetSegment(CreateCell(true, false, false, true)));
            
            Assert.AreEqual(ASCIIDungeonOutput.SE, op.GetSegment(CreateCell(false, true, true, false)));
            Assert.AreEqual(ASCIIDungeonOutput.SW, op.GetSegment(CreateCell(false, true, false, true)));

            Assert.AreEqual(ASCIIDungeonOutput.NSE, op.GetSegment(CreateCell(true, true, true, false)));
            Assert.AreEqual(ASCIIDungeonOutput.SEW, op.GetSegment(CreateCell(false, true, true, true)));
            Assert.AreEqual(ASCIIDungeonOutput.NEW, op.GetSegment(CreateCell(true, false, true, true)));
            Assert.AreEqual(ASCIIDungeonOutput.NSW, op.GetSegment(CreateCell(true, true, false, true)));
            
            Assert.AreEqual(ASCIIDungeonOutput.NSEW, op.GetSegment(CreateCell(true, true, true, true)));
        }
        
        private Cell CreateCell(bool north, bool south, bool east, bool west) {
            return new Cell(-1, -1) {
                North = north ? new Cell(-1, -1) : null,
                NorthExit = north ? 1 : -1,
                South = south ? new Cell(-1, -1) : null,
                SouthExit = south ? 1 : -1,
                East = east ? new Cell(-1, -1) : null,
                EastExit = east ? 1 : -1,
                West = west ? new Cell(-1, -1) : null,
                WestExit = west ? 1 : -1
            };
        }
    }
}