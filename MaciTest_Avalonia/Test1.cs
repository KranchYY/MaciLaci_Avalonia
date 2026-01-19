using MaciLaci_Avalonia.Models;
using MaciLaci_Avalonia.Persistance;

namespace MaciTest_Avalonia
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void InitTest()
        {
            Forest f = new Forest(11);
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (j == 0 || j == 10 || i == 0 || i == 10)
                    {
                        Assert.AreEqual(ForestField.Border, f.Table[i, j]);
                    }
                    else
                    {
                        Assert.AreEqual(ForestField.Empty, f.Table[i, j]);
                    }
                }
            }
            GameModel model = new GameModel("11x11.txt", new GameTimerInheritance());
            Assert.AreEqual(ForestField.MaciLaci, model.Forest.Table[1, 1]);
            model.MoveMaci(Dir.RIGHT);
            Assert.AreEqual(ForestField.Empty, model.Forest.Table[1, 1]);
            Assert.AreEqual(ForestField.MaciLaci, model.Forest.Table[1, 2]);
        }
        [TestMethod]
        public void MoveTest()
        {
            GameModel model = new GameModel("11x11.txt", new GameTimerInheritance());
            model.MoveMaci(Dir.RIGHT);
            Assert.AreEqual(ForestField.Empty, model.Forest.Table[1, 1]);
            Assert.AreEqual(ForestField.MaciLaci, model.Forest.Table[1, 2]);
            model.MoveMaci(Dir.LEFT);
            Assert.AreEqual(ForestField.MaciLaci, model.Forest.Table[1, 1]);
            Assert.AreEqual(ForestField.Empty, model.Forest.Table[1, 2]);
            model.MoveMaci(Dir.UP);
            Assert.AreEqual(ForestField.MaciLaci, model.Forest.Table[1, 1]);
            Assert.AreEqual(ForestField.Border, model.Forest.Table[0, 1]);
            model.MoveMaci(Dir.DOWN);
            Assert.AreEqual(ForestField.Empty, model.Forest.Table[1, 1]);
            Assert.AreEqual(ForestField.MaciLaci, model.Forest.Table[2, 1]);
        }
        [TestMethod]
        public void MoveTest2()
        {
            GameModel model = new GameModel("11x11.txt", new GameTimerInheritance());
            model.MoveMaci(Dir.RIGHT);
            Assert.AreEqual(ForestField.Empty, model.Forest.Table[1, 1]);
            Assert.AreEqual(ForestField.MaciLaci, model.Forest.Table[1, 2]);
            model.MoveMaci(Dir.RIGHT);
            Assert.AreEqual(ForestField.Empty, model.Forest.Table[1, 2]);
            Assert.AreEqual(ForestField.MaciLaci, model.Forest.Table[1, 3]);
            model.MoveMaci(Dir.RIGHT);
            Assert.AreEqual(ForestField.MaciLaci, model.Forest.Table[1, 3]);
            Assert.AreEqual(ForestField.Tree, model.Forest.Table[1, 4]);
            model.MoveMaci(Dir.RIGHT);
            Assert.AreEqual(ForestField.MaciLaci, model.Forest.Table[1, 3]);
            Assert.AreEqual(ForestField.Tree, model.Forest.Table[1, 4]);
            model.MoveMaci(Dir.RIGHT);
            Assert.AreEqual(ForestField.MaciLaci, model.Forest.Table[1, 3]);
            Assert.AreEqual(ForestField.Tree, model.Forest.Table[1, 4]);
            model.MoveMaci(Dir.RIGHT);
            Assert.AreEqual(ForestField.MaciLaci, model.Forest.Table[1, 3]);
            Assert.AreEqual(ForestField.Tree, model.Forest.Table[1, 4]);
            model.MoveMaci(Dir.RIGHT);
            Assert.AreEqual(ForestField.MaciLaci, model.Forest.Table[1, 3]);
            Assert.AreEqual(ForestField.Tree, model.Forest.Table[1, 4]);
            model.MoveMaci(Dir.RIGHT);
            Assert.AreEqual(ForestField.MaciLaci, model.Forest.Table[1, 3]);
            Assert.AreEqual(ForestField.Tree, model.Forest.Table[1, 4]);
            model.MoveMaci(Dir.UP);
            Assert.AreEqual(ForestField.MaciLaci, model.Forest.Table[1, 3]);
            Assert.AreEqual(ForestField.Tree, model.Forest.Table[1, 4]);
            Assert.AreEqual(ForestField.Border, model.Forest.Table[0, 3]);
        }
        [TestMethod]
        public void HunterMoveTest()
        {
            GameModel model = new GameModel("11x11.txt", new GameTimerInheritance());
            Assert.AreEqual(ForestField.Hunter, model.Forest.Table[2, 5]);
            Assert.AreEqual(ForestField.Hunter, model.Forest.Table[2, 8]);
            Assert.AreEqual(ForestField.Hunter, model.Forest.Table[7, 7]);
            model.MoveHunters();
            Assert.AreEqual(ForestField.Empty, model.Forest.Table[2, 5]);
            Assert.AreEqual(ForestField.Empty, model.Forest.Table[2, 8]);
            Assert.AreEqual(ForestField.Empty, model.Forest.Table[7, 7]);
        }
        [TestMethod]
        public void CollectKosarTest()
        {
            GameModel model = new GameModel("11x11.txt", new GameTimerInheritance());
            Assert.AreEqual(model.Macilaci.Kosarak, 0);
            model.MoveMaci(Dir.RIGHT);
            model.MoveMaci(Dir.DOWN);
            Assert.AreEqual(model.Macilaci.Kosarak, 1);

        }
    }
}
