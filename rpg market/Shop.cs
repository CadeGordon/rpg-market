using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace rpg_market
{
    class Shop
    {
        private int _gold;
        private Item[] _inventory;

        public Shop()
        {
            _gold = 100;
            _inventory = new Item[7];
        }

        public string[] GetItemNames()
        {
            string[] itemNames = new string[_inventory.Length];

            for (int i = 0; i < _inventory.Length; i++)
            {
                itemNames[i] = _inventory[i].Name;
            }

            return itemNames;
        }

        public Shop(Item[] items)
        {
            _gold = 100;

            _inventory = items;
        }

        public bool Sell(Player player, int itemIndex)
        {
            Item itemToBuy = _inventory[itemIndex];

            if (player.Buy(itemToBuy))
            {
                _gold += itemToBuy.Cost;
                return true;
            }
            return false;



        }
    }

}
