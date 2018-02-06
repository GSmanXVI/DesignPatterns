using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    abstract class PlayerBuilder
    {
        public Player Player { get; protected set; }

        public PlayerBuilder()
        {
            Player = new Player();
        }

        public abstract void EquipRightHand();
        public abstract void EquipLeftHand();
        public abstract void EquipHead();
        public abstract void EquipChest();
        public abstract void EquipLegs();
    }

    class WarriorBuilder : PlayerBuilder
    {
        public override void EquipRightHand()
        {
            Player.RightHand = new Sword();
        }

        public override void EquipLeftHand()
        {
            Player.LeftHand = new Shield();
        }

        public override void EquipHead()
        {
            Player.Head = new PlateArmor();
        }

        public override void EquipChest()
        {
            Player.Chest = new PlateArmor();
        }

        public override void EquipLegs()
        {
            Player.Legs = new PlateArmor();
        }
    }

    class ArcherBuilder : PlayerBuilder
    {
        public override void EquipRightHand()
        {
            Player.RightHand = new Bow();
        }

        public override void EquipLeftHand()
        {
            Player.LeftHand = null;
        }

        public override void EquipHead()
        {
            Player.Head = new LeatherArmor();
        }

        public override void EquipChest()
        {
            Player.Chest = new LeatherArmor();
        }

        public override void EquipLegs()
        {
            Player.Legs = new LeatherArmor();
        }
    }

    class BerserkerBuilder : PlayerBuilder
    {
        public override void EquipRightHand()
        {
            Player.RightHand = new Sword();
        }

        public override void EquipLeftHand()
        {
            Player.LeftHand = new Sword();
        }

        public override void EquipHead()
        {
            Player.Head = new LeatherArmor();
        }

        public override void EquipChest()
        {
            Player.Chest = new LeatherArmor();
        }

        public override void EquipLegs()
        {
            Player.Legs = new LeatherArmor();
        }
    }

    class HomelessBuilder : PlayerBuilder
    {
        public override void EquipRightHand()
        {
            Player.RightHand = null;
        }

        public override void EquipLeftHand()
        {
            Player.LeftHand = null;
        }

        public override void EquipHead()
        {
            Player.Head = null;
        }

        public override void EquipChest()
        {
            Player.Chest = new ClothArmor();
        }

        public override void EquipLegs()
        {
            Player.Legs = new ClothArmor();
        }
    }
}
