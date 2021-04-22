using Engine.Maze;
using NUnit.Framework;
using System.Linq;

namespace Engine.Test.Maze {
    public class GridTests {
        [Test]
        public void GridCtorTests() {
            var g = new Grid(5, 5);
            Assert.AreEqual(25, g.Cells.Length);
        } 
        
        [Test]
        public void GridLinkTests() {
            var g= new Grid(5,5);

            Assert.AreEqual(g.Cells[1,0], g.Cells[0,0].East);
            Assert.AreEqual(g.Cells[0,1], g.Cells[0,0].South);
            Assert.AreEqual(g.Cells[0,0], g.Cells[0,1].North);
            Assert.AreEqual(g.Cells[0,0], g.Cells[1,0].West);
        }
        
        [Test]
        public void CellExitsTests() {
            var c = new Cell(-1,-1);
            Assert.AreEqual(0, c.Exits.Count());
            
            c.North = new Cell(-1, -1);
            c.NorthExit = 1;
            
            Assert.AreEqual(1, c.Exits.Count());
            
            c.South = new Cell(-1, -1);
            c.SouthExit = 1;
            Assert.AreEqual(2, c.Exits.Count());

            
            c.East = new Cell(-1, -1);
            c.EastExit = 1;
            Assert.AreEqual(3, c.Exits.Count());
            
            c.West = new Cell(-1, -1);
            c.WestExit = 1;
            Assert.AreEqual(4, c.Exits.Count());
        }
    }
}