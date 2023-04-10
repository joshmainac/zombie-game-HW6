// See https://aka.ms/new-console-template for more information


namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("Hello, World!");
            // create a regular zombie
            IZombie zombie = new RegularZombie();

            // add accessories to the zombie
            zombie = new ConeAccessory(zombie);
            zombie = new BucketAccessory(zombie);
            zombie = new ScreenDoorAccessory(zombie);

            // attack with the zombie
            zombie.Attack();
            zombie.Attack();


        }
    }
}