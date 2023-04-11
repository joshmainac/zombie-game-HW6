// See https://aka.ms/new-console-template for more information


using System.ComponentModel;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("Hello, World!");

            // Create the game object manager and add a game event manager as an observer
            var gameObjectManager = new GameObjectManager();
            var gameEventManager = new GameEventManager(gameObjectManager);
            gameObjectManager.Attach(gameEventManager);

            string input = "0";
            while (input != "4")
            {
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Change damage ");
                Console.WriteLine("2. add zombie");
                gameObjectManager.CheckForDeadEnemies();
                Console.WriteLine("3. add all zombies one each");
                Console.WriteLine("4. Start Round / Demo game play");
                Console.WriteLine("waiting for Input.....");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Input bullet damage");
                        //damage = int.Parse(Console.ReadLine());
                        break;

                    case "2":
                        Console.WriteLine("1.Regular");
                        Console.WriteLine("2.Cone");
                        Console.WriteLine("3.Bucket");
                        Console.WriteLine("4.ScreenDoor");
                        string choice = Console.ReadLine();
                        switch (choice)
                        {
                            case "1":
                                gameObjectManager.CreateZombie("Regular");
                                break;

                            case "2":
                                //zombies.Add(new ConeZombie());
                                gameObjectManager.CreateZombie("Cone");
                                break;

                            case "3":
                                //zombies.Add(new BucketZombie());
                                gameObjectManager.CreateZombie("Bucket");
                                break;

                            case "4":
                                //zombies.Add(new ScreenDoorZombie());
                                gameObjectManager.CreateZombie("ScreenDoor");
                                break;

                            default:
                                Console.WriteLine("Invalid input. Please try again.");
                                break;


                        }
                        break;



                    case "3":
                        Console.WriteLine("You have chosen to 3.");
                        //Create some zombies
                        gameObjectManager.CreateZombie("Regular");
                        gameObjectManager.CreateZombie("Cone");
                        gameObjectManager.CreateZombie("Bucket");
                        gameObjectManager.CreateZombie("ScreenDoor");
                        gameObjectManager.CheckForDeadEnemies();
                        break;

                    case "4":
                        Console.WriteLine("You have chosen to 4.");
                        break;

                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;

                }
            }


            string input2 = "0";
            while (input2 != "4")
            {
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. DoDamage 25 : “Peashooter ");
                Console.WriteLine("2. DoDamageFromAbove 40 : Watermelon ");
                Console.WriteLine("3. ApplyMagnetForce : Magnet-shroom ");
                Console.WriteLine("4. End Game");
                Console.WriteLine("waiting for Input.....");
                input2 = Console.ReadLine();
                switch (input2)
                {
                    case "1":
                        Console.WriteLine("You have chosen to 1.");
                        gameEventManager.SimulateCollisionDetection(1);
                        gameObjectManager.CheckForDeadEnemies();
                        break;

                    case "2":
                        Console.WriteLine("You have chosen to 2.");
                        gameEventManager.SimulateCollisionDetection(2);
                        gameObjectManager.CheckForDeadEnemies();
                        break;



                    case "3":
                        Console.WriteLine("You have chosen to 3.");
                        gameEventManager.SimulateCollisionDetection(3);
                        gameObjectManager.CheckForDeadEnemies();
                        break;

                    case "4":
                        Console.WriteLine("You have chosen to 4.");
                        Console.WriteLine("End Game ....");
                        break;

                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;

                }
            }





        }
    }
}