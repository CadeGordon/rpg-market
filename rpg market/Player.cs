using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace rpg_market
{
    class Player
    {
        private Item[] _items;
        private int _gold;
        private Item[] _inventory;
        private int _inventoryIndex;
        
        

        public Player()
        {
            _gold = 100;

            _inventory = new Item[7];
            
        }

        public void Buy()
        {

        }

        public string[] GetItemNames()
        {
            string[] itemNames = new string[_items.Length];

            for (int i = 0; i < _items.Length; i++)
            {
                itemNames[i] = _items[i].Name;
            }

            return itemNames;
        }

        public bool Buy(Item item)
        {
            if (_gold >= item.Cost)
            {
                _gold -= item.Cost;

                _inventory[_inventoryIndex] = item;
                return true;
            }
            return false;
        }
        
        public int GetGold()
        {
            return _gold;
        }

        





    }
}
