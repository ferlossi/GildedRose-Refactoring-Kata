namespace GildedRoseKata.ItemTypes
{
    public class Sulfuras(Item item) : CustomItem(item)
    {
        public override void UpdateQuality()
        {
            // Sulfuras does not change in quality or sell-in
        }
    }
}
