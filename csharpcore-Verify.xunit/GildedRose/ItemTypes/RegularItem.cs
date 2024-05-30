namespace GildedRoseKata.ItemTypes
{
    public class RegularItem(Item item) : CustomItem(item)
    {
        public override void UpdateQuality()
        {
            DecreaseQuality(1);
            DecreaseSellIn();

            if (IsExpired())
            {
                DecreaseQuality(1);
            }
        }
    }
}
