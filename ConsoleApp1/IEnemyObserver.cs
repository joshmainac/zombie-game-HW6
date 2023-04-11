using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IEnemyObserver
    {
        void IZombieAdded(IZombie zombie);
    }

    public class GameEventManager : IEnemyObserver
    {
        private List<IZombie> _enemies = new List<IZombie>();
        private GameObjectManager gameObjectManager;
        public GameEventManager(GameObjectManager gameObjectManager)
        {
            this.gameObjectManager = gameObjectManager;
        }

        public IZombie GetZombie(int index)
        {
            if (index >= 0 && index < _enemies.Count)
            {
                return _enemies[index];
            }
            else
            {
                return null;
            }
        }


        public void IZombieAdded(IZombie IZombie)
        {
            _enemies.Add(IZombie);
        }

        public void DoDamage(int d, IZombie zombie)
        {
            if (zombie is RegularZombie)
            {
                //zombie.Attack();
                zombie.TakeDamage(d);
                Console.WriteLine($"Regular zombie takes {d} damage.");
                // TODO: implement damage calculation for regular zombie
            }
            else if (zombie is ConeAccessory)
            {
                // zombie.Attack();
                zombie.TakeDamage(d);
                Console.WriteLine($"Cone zombie takes {d} damage.");
                // TODO: implement damage calculation for cone zombie
            }
            else if (zombie is BucketAccessory)
            {
                //zombie.Attack();
                zombie.TakeDamage(d);
                Console.WriteLine($"Bucket zombie takes {d} damage.");
                // TODO: implement damage calculation for bucket zombie
            }
            else if (zombie is ScreenDoorAccessory)
            {
                //zombie.Attack();
                zombie.TakeDamage(d);
                Console.WriteLine($"Screen door zombie takes {d} damage.");
                // TODO: implement damage calculation for screen door zombie
            }
        }

        public void DoDamageFromAbove(int d, IZombie zombie)
        {
            if (zombie is RegularZombie)
            {
                //zombie.Attack();
                zombie.TakeDamage(d);
                Console.WriteLine($"Regular zombie takes {d} damage.");
                // TODO: implement damage calculation for regular zombie
            }
            else if (zombie is ConeAccessory)
            {
                //zombie.Attack();
                zombie.TakeDamage(d);
                Console.WriteLine($"Cone zombie takes {d} damage.");
                // TODO: implement damage calculation for cone zombie
            }
            else if (zombie is BucketAccessory)
            {
                //zombie.Attack();
                zombie.TakeDamage(d);
                Console.WriteLine($"Bucket zombie takes {d} damage.");
                // TODO: implement damage calculation for bucket zombie
            }
            else if (zombie is ScreenDoorAccessory)
            {
                //zombie.Attack();
                ScreenDoorAccessory screenDoorZombie = zombie as ScreenDoorAccessory;
                screenDoorZombie.TakeDamageFromAbove(d);
                Console.WriteLine($"Screen door zombie takes {d} damage.");
                // TODO: implement damage calculation for screen door zombie
            }
        }

        public void ApplyMagnetForce(IZombie zombie)
        {
            if (zombie is RegularZombie)
            {
                Console.WriteLine("Regular zombie is attracted by magnet.");
                // TODO: implement magnet force on regular zombie
            }
            else if (zombie is ConeAccessory)
            {
                Console.WriteLine("Cone zombie is attracted by magnet.");
                // TODO: implement magnet force on cone zombie
            }
            else if (zombie is BucketAccessory)
            {
                Console.WriteLine("Bucket zombie is attracted by magnet.");
                // TODO: implement magnet force on bucket zombie
                BucketAccessory bucketZombie = zombie as BucketAccessory;
                bucketZombie.ApplyMagnetForce();
            }
            else if (zombie is ScreenDoorAccessory)
            {
                Console.WriteLine("Screen door zombie is attracted by magnet.");
                // TODO: implement magnet force on screen door zombie
                ScreenDoorAccessory screenDoorZombie = zombie as ScreenDoorAccessory;
                screenDoorZombie.ApplyMagnetForce();
            }
        }

        public void SimulateCollisionDetection(int plant)
        {
            // For simplicity, assume each zombie occupies a single unit of space and each plant has a range of 1 unit.
            List<IZombie> enemies = gameObjectManager.GetEnemies();

            switch (plant)
            {
                case 1: // Peashooter attack
                    DoDamage(25, enemies[0]);
                    //DoDamage(40, enemies[0]);
                    break;
                case 2: // Watermelon attack
                    DoDamageFromAbove(40, enemies[0]);
                    break;
                case 3: // Magnet-shroom attack
                    if (enemies[0] is BucketAccessory)
                    {
                        ApplyMagnetForce(enemies[0]);
                    }

                    if (enemies[0] is ScreenDoorAccessory)
                    {
                        ApplyMagnetForce(enemies[0]);
                    }
                    break;
                default:
                    Console.WriteLine("Invalid attack type.");
                    break;
            }



        }

        //public void Update()
        //{
        //    foreach (IZombie zombie in _enemies)
        //    {
        //        if (zombie.IsDead())
        //        {
        //            // Respawn the zombie
        //            GameObject newZombieObject = Instantiate(zombiePrefab, zombie.transform.position, zombie.transform.rotation);
        //            Enemy newZombie = newZombieObject.GetComponent<Enemy>();
        //            newZombie.Subscribe(this);
        //            zombies.Remove(zombie);
        //            break;
        //        }
        //    }
        //}
    }

    public class GameObjectManager
    {
        private List<IZombie> _enemies = new List<IZombie>();
        private List<IEnemyObserver> _observers = new List<IEnemyObserver>();

        public List<IZombie> GetEnemies()
        {
            return _enemies;
        }

        public void Attach(IEnemyObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IEnemyObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyAdd(IZombie IZombie)
        {
            foreach (var observer in _observers)
            {
                observer.IZombieAdded(IZombie);
            }
        }

        public void CreateZombie(string type)
        {
            IZombie zombie = null;

            if (type == "Regular")
            {
                zombie = new RegularZombie();
            }
            else if (type == "Cone")
            {
                zombie = new ConeAccessory(new RegularZombie());
            }
            else if (type == "Bucket")
            {
                zombie = new BucketAccessory(new RegularZombie());
            }
            else if (type == "ScreenDoor")
            {
                zombie = new ScreenDoorAccessory(new RegularZombie());
            }

            if (zombie != null)
            {
                _enemies.Add(zombie);
                NotifyAdd(zombie);
            }
        }

        public void CheckForDeadEnemies()
        {
            List<IZombie> deadEnemies = new List<IZombie>();
            foreach (IZombie enemy in _enemies)
            {
                if (enemy.IsDead())
                {
                    deadEnemies.Add(enemy);
                }
            }

            foreach (IZombie deadEnemy in deadEnemies)
            {
                _enemies.Remove(deadEnemy);
                //if(deadEnemy is not RegularZombie)
                //{
                //    IZombie newZombie = deadEnemy.GetZombie();
                //    _enemies.Insert(0, newZombie);

                //}
            }

            Console.WriteLine("Updated enemy list:");
            //foreach (IZombie enemy in _enemies)
            //{
            //    Console.WriteLine(enemy.GetType().Name);
            //}
            
            Console.WriteLine(GetZombieHealthString());
        }

        public string GetZombieHealthString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IZombie zombie in _enemies)
            {
                if (zombie is RegularZombie)
                {
                    sb.Append("[R/");

                }
                else if (zombie is ConeAccessory)
                {

                    string temp = zombie.Display();
                    sb.Append(temp);

                }
                else if (zombie is BucketAccessory)
                {
                    string temp = zombie.Display();
                    sb.Append(temp);
                    //sb.Append("[B/");

                }
                else if (zombie is ScreenDoorAccessory)
                {
                    string temp = zombie.Display();
                    sb.Append(temp);
                    //sb.Append("[S/");

                }
                sb.Append(zombie.GetHealth() + "]");

            }
            return sb.ToString();
        }



    }

}
