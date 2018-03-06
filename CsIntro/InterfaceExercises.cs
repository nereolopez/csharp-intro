using System;

namespace CsIntro
{
    class InterfaceExercises
    {
        public void WaitForUserInput()
        {
            Console.WriteLine("Please press any key to continue...");
            Console.ReadKey();
        }

        // The interfaces and classes needed for the exercise are below!
        public void PetProgram()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the pet program. Please select an option:");
            Console.WriteLine("1. I want a dog!");
            Console.WriteLine("2. I love cockatoos!");
            Console.WriteLine("3. Exit");

            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    DogSelected(GetPetName());
                    break;

                case 2:
                    CockatooSelected(GetPetName());
                    break;

                default:
                    Console.WriteLine("Thanks for using the app. Bye!");
                    break;
            }

            string GetPetName()
            {
                Console.Clear();
                Console.WriteLine("How do you want to call your new pet?");
                return Console.ReadLine();
            }

            void DogSelected(string name)
            {
                IDoggo pet = new Dog(name);
                bool exit = false;

                while (!exit)
                {
                    Console.Clear();
                    Console.WriteLine("What do you want to do with {0}?", name);
                    Console.WriteLine("1. Feed");
                    Console.WriteLine("2. Play Fetch");
                    Console.WriteLine("3. Play Hide and Seek");
                    Console.WriteLine("4. Rub Belly");
                    Console.WriteLine("5. Put Cone of Shame");
                    Console.WriteLine("6. Display {0} status", name);
                    Console.WriteLine("7. Exit");

                    int opt = Convert.ToInt32(Console.ReadLine());
                    switch (opt)
                    {
                        case 1:
                            pet.Feed(Food.Meat);
                            Console.WriteLine("{0} was fed", name);
                            WaitForUserInput();
                            break;
                        case 2:
                            pet.Fetch();
                            Console.WriteLine("You played fetch with {0}", name);
                            WaitForUserInput();
                            break;
                        case 3:
                            pet.HideAndSeek();
                            Console.WriteLine("You played Hide and Seek with {0}", name);
                            WaitForUserInput();
                            break;
                        case 4:
                            pet.RubBelly();
                            Console.WriteLine("You rubbed {0}'s belly", name);
                            WaitForUserInput();
                            break;
                        case 5:
                            pet.PutConeOfShame();
                            Console.WriteLine("How could you put the Cone of Shame to {0}?", name);
                            WaitForUserInput();
                            break;
                        case 6:
                            pet.DisplayAnimalStatus();
                            WaitForUserInput();
                            break;
                        default:
                            Console.WriteLine("Hope you enjoyed with your pet!!");
                            exit = true;
                            break;
                    }
                }
            }

            void CockatooSelected(string name)
            {
                IBird pet = new Cockatoo(name);
                bool exit = false;

                while (!exit)
                {
                    Console.Clear();
                    Console.WriteLine("What do you want to do with {0}?", name);
                    Console.WriteLine("1. Feed");
                    Console.WriteLine("2. Dance to Music");
                    Console.WriteLine("3. Sing");
                    Console.WriteLine("4. Put in Cage");
                    Console.WriteLine("5. Display {0} status", name);
                    Console.WriteLine("6. Exit");

                    int opt = Convert.ToInt32(Console.ReadLine());
                    switch (opt)
                    {
                        case 1:
                            pet.Feed(Food.Seeds);
                            Console.WriteLine("{0} was fed", name);
                            WaitForUserInput();
                            break;
                        case 2:
                            pet.DanceToMusic();
                            Console.WriteLine("{0} danced to music", name);
                            WaitForUserInput();
                            break;
                        case 3:
                            pet.Sing();
                            Console.WriteLine("{0} sang", name);
                            WaitForUserInput();
                            break;
                        case 4:
                            pet.PutInCage();
                            Console.WriteLine("How could you put {0} in the cage?", name);
                            WaitForUserInput();
                            break;
                        case 5:
                            pet.DisplayAnimalStatus();
                            WaitForUserInput();
                            break;
                        default:
                            Console.WriteLine("Hope you enjoyed with your pet!!");
                            exit = true;
                            break;
                    }
                }
            }
        }

        enum Food
        {
            Meat,

            Fish,

            Seeds
        }

        interface IAnimal
        {
            string Species { get; }

            string Name { get; }

            string WayOfBeingBorned { get; }

            int Mood { get; }

            int NumberOfLegs { get; }

            void Feed(Food food);

            void DisplayAnimalStatus();
        }

        interface IDoggo : IAnimal
        {
            void HideAndSeek();

            void Fetch();

            void RubBelly();

            void PutConeOfShame();
        }

        interface IBird : IAnimal
        {
            void DanceToMusic();

            void Sing();

            void PutInCage();
        }

        abstract class Animal : IAnimal
        {
            protected string species;

            protected string name;

            protected string wayOfBeingBorned;

            protected int mood;

            protected int numberOfLegs;

            public string Species => this.species;

            public string Name => this.name;

            public string WayOfBeingBorned => this.wayOfBeingBorned;

            public int Mood => this.mood;

            public int NumberOfLegs => this.numberOfLegs;

            public Animal(string name)
            {
                this.name = name;
                this.mood = 3;
            }

            public abstract void Feed(Food food);

            protected void IncreaseMood()
            {
                if (this.mood < 10)
                {
                    this.mood++;
                }
            }

            protected void DecreaseMood()
            {
                if (this.mood > 0)
                {
                    this.mood--;
                }
            }

            public void DisplayAnimalStatus()
            {
                Console.WriteLine("==========================");
                Console.WriteLine("This is a status summary for {0}", this.name);
                Console.WriteLine("{0} is {1} and was borned {2}", this.name, this.species, this.wayOfBeingBorned);
                Console.WriteLine("{0} has {1} legs", this.name, this.numberOfLegs);
                Console.WriteLine("{0}'s mood is {1}", this.name, this.mood);
            }
        }

        class Dog : Animal, IDoggo
        {
            public Dog(string name)
                : base(name)
            {
                base.species = "Mammal";
                base.wayOfBeingBorned = "from parent";
                base.numberOfLegs = 4;
            }

            public override void Feed(Food food)
            {
                if (food != Food.Seeds)
                {
                    base.IncreaseMood();
                }
                else
                {
                    base.DecreaseMood();
                }
            }

            public void Fetch()
            {
                base.IncreaseMood();
                base.IncreaseMood();
            }

            public void HideAndSeek()
            {
                base.IncreaseMood();
            }

            public void PutConeOfShame()
            {
                base.DecreaseMood();
                base.DecreaseMood();
                base.DecreaseMood();
            }

            public void RubBelly()
            {
                base.IncreaseMood();
                base.IncreaseMood();
                base.IncreaseMood();
                base.IncreaseMood();
            }
        }

        class Cockatoo : Animal, IBird
        {
            public Cockatoo(string name)
                : base(name)
            {
                base.species = "Oviparous";
                base.wayOfBeingBorned = "from egg";
                base.numberOfLegs = 2;
            }

            public void DanceToMusic()
            {
                base.IncreaseMood();
                base.IncreaseMood();
                base.IncreaseMood();
            }

            public override void Feed(Food food)
            {
                if (food == Food.Seeds)
                {
                    base.IncreaseMood();
                }
                else
                {
                    base.DecreaseMood();
                }
            }

            public void PutInCage()
            {
                base.DecreaseMood();
                base.DecreaseMood();
                base.DecreaseMood();
            }

            public void Sing()
            {
                base.IncreaseMood();
                base.IncreaseMood();
            }
        }
    }
}
