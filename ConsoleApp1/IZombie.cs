using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IZombie
    {
        void Attack();
    }

    public class RegularZombie : IZombie
    {
        public void Attack()
        {
            Console.WriteLine("Regular Zombie attacking...");
        }
    }

    public class ConeAccessory : IZombie
    {
        private readonly IZombie _zombie;

        public ConeAccessory(IZombie zombie)
        {
            _zombie = zombie;
        }

        public void Attack()
        {
            _zombie.Attack();
            Console.WriteLine("Adding cone accessory to zombie...");
        }
    }

    public class BucketAccessory : IZombie
    {
        private readonly IZombie _zombie;

        public BucketAccessory(IZombie zombie)
        {
            _zombie = zombie;
        }

        public void Attack()
        {
            _zombie.Attack();
            Console.WriteLine("Adding bucket accessory to zombie...");
        }
    }

    public class ScreenDoorAccessory : IZombie
    {
        private readonly IZombie _zombie;

        public ScreenDoorAccessory(IZombie zombie)
        {
            _zombie = zombie;
        }

        public void Attack()
        {
            _zombie.Attack();
            Console.WriteLine("Adding screendoor accessory to zombie...");
        }
    }




}
