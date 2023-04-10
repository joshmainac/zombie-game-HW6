using System;
using System.Collections.Generic;
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

        public void IZombieAdded(IZombie IZombie)
        {
            _enemies.Add(IZombie);
        }

        public void doDamage(int d, IZombie e)
        {
            //e.takeDamage(d);
        }

        public void applyMagnetForce(IZombie e)
        {
            // implementation here
        }

        public void simulateCollisionDetection(int plant)
        {
            // implementation here
        }
    }

    public class GameObjectManager
    {
        private List<IZombie> _enemies = new List<IZombie>();
        private List<IEnemyObserver> _observers = new List<IEnemyObserver>();

        public void Attach(IEnemyObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IEnemyObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(IZombie IZombie)
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
                Notify(zombie);
            }
        }



    }

}
