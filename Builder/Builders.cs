using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    abstract class PlayerBuilder
    {
        protected Player player;

        public PlayerBuilder()
        {
            player = new Player();
        }

        public abstract void EquipRightHand();
        public abstract void EquipLeftHand();
        public abstract void EquipHead();
        public abstract void EquipChest();
        public abstract void EquipLegs();

        public Player Build()
        {
            return player;
        }
    }

    class WarriorBuilder : PlayerBuilder
    {
        public override void EquipRightHand()
        {
            player.RightHand = new Sword();
        }

        public override void EquipLeftHand()
        {
            player.LeftHand = new Shield();
        }

        public override void EquipHead()
        {
            player.Head = new PlateArmor();
        }

        public override void EquipChest()
        {
            player.Chest = new PlateArmor();
        }

        public override void EquipLegs()
        {
            player.Legs = new PlateArmor();
        }
    }

    class ArcherBuilder : PlayerBuilder
    {
        public override void EquipRightHand()
        {
            player.RightHand = new Bow();
        }

        public override void EquipLeftHand()
        {
            player.LeftHand = null;
        }

        public override void EquipHead()
        {
            player.Head = new LeatherArmor();
        }

        public override void EquipChest()
        {
            player.Chest = new LeatherArmor();
        }

        public override void EquipLegs()
        {
            player.Legs = new LeatherArmor();
        }
    }

    class BerserkerBuilder : PlayerBuilder
    {
        public override void EquipRightHand()
        {
            player.RightHand = new Sword();
        }

        public override void EquipLeftHand()
        {
            player.LeftHand = new Sword();
        }

        public override void EquipHead()
        {
            player.Head = new LeatherArmor();
        }

        public override void EquipChest()
        {
            player.Chest = new LeatherArmor();
        }

        public override void EquipLegs()
        {
            player.Legs = new LeatherArmor();
        }
    }

    class HomelessBuilder : PlayerBuilder
    {
        public override void EquipRightHand()
        {
            player.RightHand = null;
        }

        public override void EquipLeftHand()
        {
            player.LeftHand = null;
        }

        public override void EquipHead()
        {
            player.Head = null;
        }

        public override void EquipChest()
        {
            player.Chest = new ClothArmor();
        }

        public override void EquipLegs()
        {
            player.Legs = new ClothArmor();
        }
    }
}
