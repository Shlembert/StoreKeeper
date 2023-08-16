using NUnit.Framework;

[TestFixture]
public class Tests
{
    [Test]
    public void TestBoxVolume()
    {
        Box box = new Box(1, 2, 3, 4, 5, DateTime.Now);
        double expectedVolume = 1 * 2 * 3;

        Assert.AreEqual(expectedVolume, box.GetVolumeBox());
    }

    [Test]
    public void TestPalletTotalValue()
    {
        Pallet pallet = new Pallet(string.Empty);
        Box box1 = new Box(1, 2, 3, 4, 5, DateTime.Now);
        Box box2 = new Box(2, 3, 4, 5, 6, DateTime.Now);
        pallet.Boxes.Add(box1);
        pallet.Boxes.Add(box2);

        double expectedTotalValue = (800 * 1200 * 144) + (2 * 3 * 4) + (3 * 4 * 5);

        Assert.AreEqual(expectedTotalValue, pallet.GetTotalValue());
    }

    [Test]
    public void TestSorting()
    {
        List<Pallet> pallets = new List<Pallet> { new Pallet(string.Empty), new Pallet(string.Empty), new Pallet(string.Empty) };

        Sorting.Sort(pallets);

        for (int i = 0; i < pallets.Count - 1; i++)
        {
            Assert.True(pallets[i].GetMinShelfLife() <= pallets[i + 1].GetMinShelfLife());
        }
    }
}
