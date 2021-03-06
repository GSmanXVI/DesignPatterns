﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
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

    class CharacterCreator
    {
        public Player Create(PlayerBuilder playerBuilder)
        {
            playerBuilder.EquipRightHand();
            playerBuilder.EquipLeftHand();
            playerBuilder.EquipHead();
            playerBuilder.EquipChest();
            playerBuilder.EquipLegs();
            return playerBuilder.Build();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //// GOOD CODE
            WarriorBuilder warriorBuilder = new WarriorBuilder();
            ArcherBuilder archerBuilder = new ArcherBuilder();
            BerserkerBuilder berserkerBuilder = new BerserkerBuilder();
            HomelessBuilder homelessBuilder = new HomelessBuilder();

            CharacterCreator characterCreator = new CharacterCreator();

            Player player1 = characterCreator.Create(warriorBuilder);
            player1.Name = "Warrior";
            player1.Info();

            Player player2 = characterCreator.Create(archerBuilder);
            player2.Name = "Archer";
            player2.Info();

            Player player3 = characterCreator.Create(berserkerBuilder);
            player3.Name = "Berserker";
            player3.Info();

            Player player4 = characterCreator.Create(homelessBuilder);
            player4.Name = "Homeless";
            player4.Info();



            //// BAD CODE
            //var player = new Player("Gleb", new Sword(), null, null, new PlateArmor(), new LeatherArmor());
            //player.Info();
        }
    }
}
