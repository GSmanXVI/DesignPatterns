using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Player
    {
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
        public void Create(PlayerBuilder playerBuilder)
        {
            playerBuilder.EquipRightHand();
            playerBuilder.EquipLeftHand();
            playerBuilder.EquipHead();
            playerBuilder.EquipChest();
            playerBuilder.EquipLegs();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            WarriorBuilder warriorBuilder = new WarriorBuilder();
            ArcherBuilder archerBuilder = new ArcherBuilder();
            BerserkerBuilder berserkerBuilder = new BerserkerBuilder();
            HomelessBuilder homelessBuilder = new HomelessBuilder();

            CharacterCreator characterCreator = new CharacterCreator();

            characterCreator.Create(warriorBuilder);
            Player player1 = warriorBuilder.Player;
            player1.Name = "Warrior";
            player1.Info();

            characterCreator.Create(archerBuilder);
            Player player2 = archerBuilder.Player;
            player2.Name = "Archer";
            player2.Info();

            characterCreator.Create(berserkerBuilder);
            Player player3 = berserkerBuilder.Player;
            player3.Name = "Berserker";
            player3.Info();

            characterCreator.Create(homelessBuilder);
            Player player4 = homelessBuilder.Player;
            player4.Name = "Homeless";
            player4.Info();
        }
    }
}
