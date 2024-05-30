namespace GildedRoseKata.ItemTypes
{
    public class BackstagePass(Item item) : CustomItem(item)
    {
        public override void UpdateQuality()
        {
            if (Item.SellIn <= 0)
            {
                Item.Quality = 0;
            }
            else if (Item.SellIn <= 5)
            {
                IncreaseQuality(3);
            }
            else if (Item.SellIn <= 10)
            {
                IncreaseQuality(2);
            }
            else
            {
                IncreaseQuality(1);
            }
            DecreaseSellIn();
        }
    }
}
