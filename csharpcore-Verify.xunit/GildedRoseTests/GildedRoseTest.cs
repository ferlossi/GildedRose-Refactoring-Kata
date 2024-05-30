using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            IGildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("foo", Items[0].Name);
        }

        [Fact]
        public void TestRegularItem()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 } };
            IGildedRose app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(4, items[0].SellIn);
            Assert.Equal(6, items[0].Quality);
        }

        [Fact]
        public void TestAgedBrie()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 } };
            IGildedRose app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(1, items[0].SellIn);
            Assert.Equal(1, items[0].Quality);
        }

        [Fact]
        public void TestSulfuras()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
            IGildedRose app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(0, items[0].SellIn);
            Assert.Equal(80, items[0].Quality);
        }

        [Fact]
        public void TestBackstagePasses()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 } };
            IGildedRose app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(14, items[0].SellIn);
            Assert.Equal(21, items[0].Quality);

            // Test quality increases by 2 when 10 days or less
            items[0].SellIn = 10;
            app.UpdateQuality();
            Assert.Equal(9, items[0].SellIn);
            Assert.Equal(23, items[0].Quality);

            // Test quality increases by 3 when 5 days or less
            items[0].SellIn = 5;
            app.UpdateQuality();
            Assert.Equal(4, items[0].SellIn);
            Assert.Equal(26, items[0].Quality);

            // Test quality drops to 0 after concert
            items[0].SellIn = 0;
            app.UpdateQuality();
            Assert.Equal(-1, items[0].SellIn);
            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void TestConjuredItem()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 } };
            IGildedRose app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(2, items[0].SellIn);
            Assert.Equal(4, items[0].Quality);

            // Test quality degrades twice as fast after sell date
            items[0].SellIn = 0;
            app.UpdateQuality();
            Assert.Equal(-1, items[0].SellIn);
            Assert.Equal(2, items[0].Quality);

            app.UpdateQuality();
            Assert.Equal(-2, items[0].SellIn);
            Assert.Equal(0, items[0].Quality);
        }
    }
}
