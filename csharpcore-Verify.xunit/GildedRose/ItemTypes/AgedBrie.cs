namespace GildedRoseKata.ItemTypes
{
    public class AgedBrie(Item item) : CustomItem(item)
    {
        public override void UpdateQuality()
        {
            IncreaseQuality(1);
            DecreaseSellIn();

            if (IsExpired())
            {
                IncreaseQuality(1);
            }
        }
    }
}
