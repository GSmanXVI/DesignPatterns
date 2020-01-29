using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBuilder
{
    class Player
    {
        ////BAD CODE! Too many params in constructor.
        //public Player(string name, Weapon rightHand, Weapon leftHand, Armor head, Armor chest, Armor legs)
        //{
        //    Name = name;
        //    RightHand = rightHand;
        //    LeftHand = leftHand;
        //    Head = head;
        //    Chest = chest;
        //    Legs = legs;
        //}

        public string Name { get; set; }

        public Weapon RightHand { get; set; }
        public Weapon LeftHand { get; set; }
        public Armor Head { get; set; }
        public Armor Chest { get; set; }
        public Armor Legs { get; set; }

        public void Info()
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine($"Player name: {Name}");
            Console.WriteLine($"\nPlayer equipment:");
            Console.WriteLine($"Right hand: {RightHand?.ToString() ?? "None"}");
            Console.WriteLine($"Left hand: {LeftHand?.ToString() ?? "None"}");
            Console.WriteLine($"Head: {Head?.ToString() ?? "None"}");
            Console.WriteLine($"Chest: {Chest?.ToString() ?? "None"}");
            Console.WriteLine($"Legs: {Legs?.ToString() ?? "None"}");
            Console.WriteLine($"\nPlayer stats:");
            Console.WriteLine($"Damage: {(RightHand?.Damage ?? 0) + (LeftHand?.Damage ?? 0)}");
            Console.WriteLine($"Defense: {(RightHand?.Defense ?? 0) + (LeftHand?.Defense ?? 0) + (Head?.Defense ?? 0) + (Chest?.Defense ?? 0) + (Legs?.Defense ?? 0)}");
            Console.WriteLine("-----------------------\n");
        }
    }


    //Fluent builder patern
    class PlayerBuilder
    {
        private Player player = new Player();
        public PlayerBuilder(string playerName)
        {
            player.Name = playerName;
        }

        public PlayerBuilder EquipRightHand(Weapon weapon)
        {
            player.RightHand = weapon;
            return this;
        }

        public PlayerBuilder EquipLeftHand(Weapon weapon)
        {
            player.LeftHand = weapon;
            return this;
        }

        public PlayerBuilder EquipHead(Armor armor)
        {
            player.Head = armor;
            return this;
        }

        public PlayerBuilder EquipChest(Armor armor)
        {
            player.Chest = armor;
            return this;
        }

        public PlayerBuilder EquipLegs(Armor armor)
        {
            player.Legs = armor;
            return this;
        }

        public Player Build()
        {
            return player;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Player player = new PlayerBuilder("Gleb")
                .EquipLegs(new LeatherArmor())
                .EquipHead(new ClothArmor())
                .EquipRightHand(new Sword())
                .EquipLeftHand(new Shield())
                .Build();

            player.Info();


            //// BAD CODE
            //var player = new Player("Gleb", new Sword(), null, null, new PlateArmor(), new LeatherArmor());
            //player.Info();
        }
    }
}
