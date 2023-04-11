using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1
{
    public interface IZombie
    {
        void Attack();
        void TakeDamage(int damage);

        bool IsDead();
        string Display();

        int GetHealth();
        public IZombie GetZombie();

    }

    public class RegularZombie : IZombie
    {
        private int _health = 50;

        public int GetHealth()
        {
            return _health;
        }

        public IZombie GetZombie()
        {
            return null;
        }
        public void Attack()
        {
            Console.WriteLine("Regular Zombie attacking...");
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;
            //Console.WriteLine($"Regular Zombie taking {damage} damage. Health: {_health}");
        }

        public bool IsDead()
        {
            return _health <= 0;
        }

        public string Display()
        {
            return "[R/";
        }
    }

    public class ConeAccessory : IZombie
    {
        private readonly IZombie _zombie;
        private int _health = 25;

        public int GetHealth()
        {
            if (_health > 0)
            {
                return _health;

            }
            else
            {
                return _zombie.GetHealth();


            }
        }
        public IZombie GetZombie()
        {
            return _zombie;
        }

        public ConeAccessory(IZombie zombie)
        {
            _zombie = zombie;
        }

        public void Attack()
        {
            _zombie.Attack();
            Console.WriteLine("Adding cone accessory to zombie...");
        }

        public void TakeDamage(int damage)
        {
            if (_health > 0)
            {
                _health -= damage;
                //Console.WriteLine($"Cone Zombie with {_zombie.Display()} and {_health} Health");
                if (_health <= 0)
                {
                    //Console.WriteLine($"Cone destroyed!");
                    _zombie.TakeDamage(-(_health));
                }
            }
            else
            {
                _zombie.TakeDamage(damage);


            }
        }
        public bool IsDead()
        {
            return _zombie.IsDead();
        }

        public string Display()
        {
            if (_health <= 0)
            {
                return _zombie.Display();
            }
            else
            {
                //return $"Cone Zombie with {_zombie.Display()} and {_health} Health";
                return "[C/";
            }
        }
    }

    public class BucketAccessory : IZombie
    {
        private readonly IZombie _zombie;
        private int _health = 100;

        public int GetHealth()
        {
            if (_health > 0)
            {
                return _health;

            }
            else
            {
                return _zombie.GetHealth();


            }
        }


        public IZombie GetZombie()
        {
            return _zombie;
        }

        public BucketAccessory(IZombie zombie)
        {
            _zombie = zombie;
        }

        public void Attack()
        {
            _zombie.Attack();
            Console.WriteLine("Adding bucket accessory to zombie...");
        }

        public void TakeDamage(int damage)
        {
            if (_health > 0)
            {
                _health -= damage;
                //Console.WriteLine($"Bucket Zombie with {_zombie.Display()} and {_health} Health");
                if (_health <= 0)
                {
                    //Console.WriteLine($"Bucket destroyed!");
                    _zombie.TakeDamage(-(_health));
                }
            }
            else
            {
                _zombie.TakeDamage(damage);


            }
        }
        public void ApplyMagnetForce()
        {
            _health = 0;
        }
        public bool IsDead()
        {
            return _zombie.IsDead();
        }

        public string Display()
        {
            if (_health <= 0)
            {
                return _zombie.Display();
            }
            else
            {
                //return $"Cone Zombie with {_zombie.Display()} and {_health} Health";
                return "[B/";
            }
        }



    }

    public class ScreenDoorAccessory : IZombie
    {
        private readonly IZombie _zombie;
        private int _health = 25;

        public int GetHealth()
        {
            if (_health > 0)
            {
                return _health;

            }
            else
            {
                return _zombie.GetHealth();


            }
        }


        public IZombie GetZombie()
        {
            return _zombie;
        }

        public ScreenDoorAccessory(IZombie zombie)
        {
            _zombie = zombie;
        }

        public void Attack()
        {
            _zombie.Attack();
            Console.WriteLine("Adding screendoor accessory to zombie...");
        }

        public void TakeDamage(int damage)
        {
            if (_health > 0)
            {
                _health -= damage;
                //Console.WriteLine($"ScreenDoor Zombie with {_zombie.Display()} and {_health} Health");
                if (_health <= 0)
                {
                    //Console.WriteLine($"ScreenDoor destroyed!");
                    _zombie.TakeDamage(-(_health));
                }
            }
            else
            {
                _zombie.TakeDamage(damage);


            }
        }


        public void TakeDamageFromAbove(int damage)
        {
            _zombie.TakeDamage(damage);
            //Console.WriteLine("ScreenDoor Zombie took damage from above.");
        }

        public void ApplyMagnetForce()
        {
            _health =0;
        }
        public bool IsDead()
        {
            return _zombie.IsDead();
        }

        public string Display()
        {
            if (_health <= 0)
            {
                return _zombie.Display();
            }
            else
            {
                //return $"Cone Zombie with {_zombie.Display()} and {_health} Health";
                return "[S/";
            }
        }

    }






}
