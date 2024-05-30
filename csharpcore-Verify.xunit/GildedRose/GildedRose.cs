using GildedRoseKata.ItemTypes;
using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata
{
    public class GildedRose : IGildedRose
    {
        private IList<Item> Items;
        private IList<CustomItem> CustomItems;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
            CustomItems = [];

            foreach (var item in Items)
            {
                switch (item.Name)
                {
                    case "Aged Brie":
                        CustomItems.Add(new AgedBrie(item));
                        break;
                    case "Sulfuras, Hand of Ragnaros":
                        CustomItems.Add(new Sulfuras(item));
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        CustomItems.Add(new BackstagePass(item));
                        break;
                    case var name when name.StartsWith("Conjured"):
                        CustomItems.Add(new ConjuredItem(item));
                        break;
                    default:
                        CustomItems.Add(new RegularItem(item));
                        break;
                }
            }
        }

        public void UpdateQuality()
        {

            CustomItems.ToList().ForEach(item => item.UpdateQuality());
        }
    }
}
