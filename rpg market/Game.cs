using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace rpg_market
{
    
        public struct Item
        {
            public string Name;
            public int Cost;
        }

    class Game
    {
        private Shop _shop;
        private Player _player;
        private bool _gameOver;
        private Scene _currentScene;
        private Item[] _shopInventory;
        private Item[] _inventory;
        private Item[] _shopItems;
        private int _inventoryIndex;
        
        public enum Scene
        {
            STARTMENU,
            SHOPMENU,
            NONE
        }

        public enum ShopItems
        {
            BFG,
            RAYGUN,
            PORTALGUN,
            RUSTKNIFE,
            UNCLEPHIL,
            FLIMSEYSWORD,
            MEGAPOTION
        }
        

       
        




        public void Run()
        {
            Start();

            while (!_gameOver)
            {
                update();
            }

            End();
        }

        private void Start()
        {
            _gameOver = false;
            _player = new Player();
            InitializeItems();
        }

        //plays when the player exits the application
        public void End()
        {
            Console.WriteLine("DO NOT TELL ANYONE YOU WERE HERE!!! Safe travels =)");
            Console.ReadKey(true);
        }

        //Updates the current scene
        private void update()
        {
            DisplayCurrentScene();
        }

        private void InitializeItems()
        {
            //Shop items
            Item bfg = new Item { Name = "BFG", Cost = 40000000 };
            Item rayGun = new Item { Name = "Ray Gun", Cost = 1000000 };
            Item unclePhil = new Item { Name = "Uncle Phil", Cost = 200000 };
            Item megaPotion = new Item { Name = "Mega Potion", Cost = 20000 };
            Item flimseySword = new Item { Name = "Flimsey Sword", Cost = 25 };
            Item rustyKnife = new Item { Name = "Rusty Knife", Cost = 15 };
            Item portalGun = new Item { Name = "Portal Gun", Cost = 5000000 };

            _shopItems = new Item[] { bfg, rayGun, unclePhil, megaPotion, flimseySword, rustyKnife, portalGun };



        }

        private void Save()
        {

        }

       
        

            
        

        //Load function will go here


        private void DisplayCurrentScene()
        {
            switch (_currentScene)
            {
                case Scene.STARTMENU:
                    DisplayOpeningMenu();
                    break;
                case Scene.SHOPMENU:
                    DisplayShopMenu();
                    break;
            }
        }


        private void DisplayOpeningMenu()
        {
            int choice = GetInput("Welcome to the Black Market! Would you like to enter?", "Yes", "No");

            if (choice == 0)
            {
                _currentScene = Scene.SHOPMENU;
            }
            else if (choice == 1)
            {
                _gameOver = true;
            }
        }

        private void DisplayShopMenu()
        {
           int choice = GetInput("Welcome to the black market what would you like to buy?")

            
            

            
            
                
                    
            



            
        }

        private void GetShopMenuOptions()
        {
            
            
            //Create a new array with one more slot than the old array
            string[] tempArray = new string[_shopItems.Length + 2];

            //Copy the values from the old array into the new array
            for (int i = 0; i < _shopItems.Length; i++)
            {
                tempArray[i] = _shopItems[i].Name;

            }

            //Set the last index to be the new item
            tempArray[_shopItems.Length] = "save";
            tempArray[_shopItems.Length + 1] = "quit";

            
            
        }


       


        int GetInput(string description, params string[] options)
        {
            string input = "";
            int inputRecieved = -1;

            while (inputRecieved == -1)
            {
                //Print options
                Console.WriteLine(description);
                for (int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine((i + 1) + ". " + options[i]);
                }
                Console.WriteLine("> ");

                //get input from player
                input = Console.ReadLine();

                //If the player typed an int...
                if (int.TryParse(input, out inputRecieved))
                {
                    //...decrement the input and check if it's within the bounds of the array
                    inputRecieved--;
                    if (inputRecieved < 0 || inputRecieved >= options.Length)
                    {
                        //set input recieved to be the default value
                        inputRecieved = -1;
                        //display error message
                        Console.WriteLine("Invalid Input");
                        Console.ReadKey(true);
                    }
                }
                //if the player didnt type and int
                else
                {
                    //Set input recieved to be the default value
                    inputRecieved = -1;
                    Console.WriteLine("inavlid input");
                    Console.ReadKey(true);
                }

                Console.Clear();
            }

            return inputRecieved;
        }


    }
}
