namespace GildedRoseKata.ItemTypes
{
    public class ConjuredItem(Item item) : CustomItem(item)
    {
        public override void UpdateQuality()
        {
            DecreaseQuality(2);
            DecreaseSellIn();
        }
    }
}
