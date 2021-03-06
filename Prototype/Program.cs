﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    enum CharacterClass { Warrior = 1, Thief, Mage }

    class Character : ICloneable
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intellect { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public void Info()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine("\nStats: ");
            Console.WriteLine($"Health points: {HP}");
            Console.WriteLine($"Mana points: {MP}");
            Console.WriteLine($"Strength: {Strength}");
            Console.WriteLine($"Dexterity: {Dexterity}");
            Console.WriteLine($"Intellect: {Intellect}");
        }
    }

    class CharacterManager
    {
        private Dictionary<CharacterClass, Character> presets;

        public CharacterManager()
        {
            presets = new Dictionary<CharacterClass, Character>();
            presets.Add(CharacterClass.Warrior, new Character()
            {
                HP = 200,
                MP = 0,
                Strength = 10,
                Dexterity = 5,
                Intellect = 2
            });

            presets.Add(CharacterClass.Thief, new Character()
            {
                HP = 120,
                MP = 50,
                Strength = 4,
                Dexterity = 10,
                Intellect = 5
            });

            presets.Add(CharacterClass.Mage, new Character()
            {
                HP = 80,
                MP = 120,
                Strength = 2,
                Dexterity = 3,
                Intellect = 10
            });
        }

        public Character this[CharacterClass cls]
        {
            get { return presets[cls].Clone() as Character; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CharacterManager characterManager = new CharacterManager();
            Character character;
            
            while (true)
            {
                Console.Write("Choose your class (1 - Warrior, 2 - Theif, 3 - Mage): ");
                Enum.TryParse(Console.ReadKey().KeyChar.ToString(), out CharacterClass classChoise);
                try
                {
                    character = characterManager[classChoise];
                    Console.Clear();
                    break;
                }
                catch (KeyNotFoundException)
                {
                    Console.Clear();
                }
            }

            while (true)
            {
                Console.Write("Write your name: ");
                character.Name = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(character.Name))
                {
                    Console.Clear();
                    Console.WriteLine("Name can't be empty!");
                }
                else break;
            }


            int additionalPoints = 3;
            while (additionalPoints != 0)
            {
                Console.Clear();
                character.Info();
                Console.WriteLine($"\nYou have {additionalPoints} additional points!");
                Console.Write("Choose stat to improve (1 - STR, 2 - DEX, 3 - INT): ");
                Int32.TryParse(Console.ReadKey().KeyChar.ToString(), out int skillChoise);
                switch (skillChoise)
                {
                    case 1:
                        character.Strength++;
                        additionalPoints--;
                        break;
                    case 2:
                        character.Dexterity++;
                        additionalPoints--;
                        break;
                    case 3:
                        character.Intellect++;
                        additionalPoints--;
                        break;
                }
            }

            Console.Clear();
            Console.WriteLine("Your character has been created!\n");
            character.Info();
        }
    }
}
