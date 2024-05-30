using GildedRoseKata;
using System;

namespace GildedRoseKata
{
    public abstract class CustomItem
    {
        public Item Item { get; }

        public CustomItem(Item item)
        {
            Item = item;
        }

        public abstract void UpdateQuality();
        public void DecreaseSellIn() => Item.SellIn--;
        public void IncreaseQuality(int amount) => Item.Quality = Math.Min(Item.Quality + amount, 50);
        public void DecreaseQuality(int amount) => Item.Quality = Math.Max(Item.Quality - amount, 0);
        public bool IsExpired() => Item.SellIn < 0;
    }

}
