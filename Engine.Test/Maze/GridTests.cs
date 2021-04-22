using Engine.Maze;
using NUnit.Framework;

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
    }
}