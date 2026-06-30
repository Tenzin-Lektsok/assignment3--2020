using System;
using System.Diagnostics; // Required for stopwatch
//Your name here


namespace Assignment3Template
{
    class Program
    {
        static void Main(string[] args)
        { /*

            CircularArray < SO> priorityArray = new CircularArray<SO>();
            CircularLinkedList<SO> priorityLL = new CircularLinkedList<SO>();

            SO sampleSO = new SO(0);
            sampleSO.ToString();

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();


            // in here is where you do the thing that's being timed

            /*
             write a simple tool to compare the performance of the two structures you implemented in “2” and “3”.  
            Your system is going to work like this -  you’re going to generate a random number between 1 and 11 (inclusive), call this variable n_events, 
            and then a second random number 0, or 1.  
            If the second number is 0, you dequeue n_events objects from the structure, if it’s 1, you enqueue that many (these simple objects are randomly generated).

            At the end of your simulation you should be able to report the largest size your priority queue ever reached, 
            the number of objects in your queue at the end, 
            and the total number of objects added or removed.
            
            An event is just that a Simple Object is generated, assigned a random priority (1-5 inclusive), 
            and enqueued, or that n objects are dequeued from the priority queue (and then discarded).  

            Note that you will need to deal with the possibility of attempting to dequeue from an empty list, in that case just return nothing or a null object and ignore it.  

            There are two ways to do this – either generate a fixed number of random events (and see which one is fastest) 
            or run for a fixed amount of time (say 10 seconds) and count how many you could accomplish.  Do both.   
            */

            /*
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            long tsticks = stopWatch.ElapsedTicks;
            Console.WriteLine();

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

            /*
             * Hashtable code
             * 
             */
            /* string[] demostrings = { "Srivastava", "Hurley", "Mitchell", "McConnell", "Feng", "Noorian", "Young",
                "Smith", "Northrop", "Andreau", "Reid", "Alam", "Addas", "Atkinson", "Hickson", "Aniag", "Patrick",
                "Subramanian", "Pollanen", "Bruder", "Beland", "Akaiso", "Hircock", "Erzurumluoglu", "Neels"};
            Console.WriteLine("Hashmap Testign");
            int size = 20;
            HashTable<string> myhashtable = new HashTable<string>(size);
            // You'll want to actually add things into myhashtable


            Console.WriteLine("My name is: ___________________");// (please put your name in this statement)
            */

            AnimalSimulationTest();
        }

        static void AnimalSimulationTest()
        {
            Console.WriteLine("==== Animal Simulation Test ===\n");

            // assignment says we can hard code name and ID for cats and snakes
            // we only need 2 cats and 2 snakes now instead of more like before
            Cat cat1 = new Cat("Whisker", "C1", 0, 0, 0);
            Cat cat2 = new Cat("Tom", "C2", 20, 20, 0);

            Snake snake1 = new Snake("Cobra", "S1", 0, 0, 0);
            Snake snake2 = new Snake("Python", "S2", 5, 5, 0);

            // random is used to give each bird a random starting position
            // assignment says birds can spawn anywhere on the map
            Random random = new Random();

            // these names come from the BirdNames.txt file given in the assignment
            string[] birdNames = {
                "Aja","Ala","Archimedes","Aubrey","Ava","Barry","Bella","Benny",
                "Bertram","Birdie","Bobo","Bougie","Bubba","Calypso","Chantey",
                "Cher","Chip","Chive","Chloe","Clive","Couscous","Dewey","Donut",
                "Elvis","Flossie"};

            // we create 25 birds because assignment says increase bird count to about 25
            // each bird gets a name from the list above and a random x, y, z position
            // birds spawn between -20 and 20 in X and Y so they land close enough
            // to cats and snakes to actually test smell and hearmovement
            DoublyLinkedList<Bird> birds = new DoublyLinkedList<Bird>();

            for (int i = 0; i < birdNames.Length; i++)
            {
                int x = random.Next(-20, 21);
                int y = random.Next(-20, 21);
                int z = random.Next(-5, 6);

                string thisBirdName = birdNames[i];
                string thisBirdID = "B" + (i + 1);

                Bird newBird = new Bird(thisBirdName, thisBirdID, x, y, z);

                birds.AddLast(newBird);
            }

            Console.WriteLine("Created " + birds.GetCount() + " birds.");

            DoublyLinkedList<Cat> allCats = new DoublyLinkedList<Cat>();
            DoublyLinkedList<Snake> allSnakes = new DoublyLinkedList<Snake>();
            DoublyLinkedList<Animal> allAnimals = new DoublyLinkedList<Animal>();

            allCats.AddLast(cat1);
            allCats.AddLast(cat2);

            allSnakes.AddLast(snake1);
            allSnakes.AddLast(snake2);

            allAnimals.AddLast(cat1);
            allAnimals.AddLast(cat2);
            allAnimals.AddLast(snake1);
            allAnimals.AddLast(snake2);

            Node<Bird> b = birds.head;
            while (b != null)
            {
                allAnimals.AddLast(b.element);
                b = b.next;
            }

            Console.WriteLine("Total animals in simulation: " + allAnimals.GetCount());

            Console.WriteLine("\n==== FindDistance Test ====");

            Console.WriteLine("Distance from " + cat1.Name + " to " + snake1.Name +
                              " = " + cat1.FindDistance(snake1));

            Console.WriteLine("Distance from " + cat1.Name + " to " + cat2.Name +
                              " = " + cat1.FindDistance(cat2));

            Console.WriteLine("Distance from " + snake2.Name + " to " + cat2.Name +
                              " = " + snake2.FindDistance(cat2));

            Console.WriteLine("\n==== Smell Test ====");

            cat1.UpdateSmell(allAnimals);
            cat2.UpdateSmell(allAnimals);

            snake1.UpdateSmell(allAnimals);
            snake2.UpdateSmell(allAnimals);

            Console.WriteLine("\nAnimals smelled by " + cat1.Name);
            cat1.SmellList.PrintAllForward();

            Console.WriteLine("\nAnimals smelled by " + cat2.Name);
            cat2.SmellList.PrintAllForward();

            Console.WriteLine("\nAnimals smelled by " + snake1.Name);
            snake1.SmellList.PrintAllForward();

            Console.WriteLine("\nAnimals smelled by " + snake2.Name);
            snake2.SmellList.PrintAllForward();

            Console.WriteLine("\n==== HearMovement Test ====");

            // clear old heard lists before testing
            cat1.HeardBirds = new DoublyLinkedList<Bird>();
            cat2.HeardBirds = new DoublyLinkedList<Bird>();
            snake1.HeardBirds = new DoublyLinkedList<Bird>();
            snake2.HeardBirds = new DoublyLinkedList<Bird>();

            Node<Bird> birdNode = birds.head;
            while (birdNode != null)
            {
                // move bird and calculate its speed
                birdNode.element.Move(random);

                Console.WriteLine(birdNode.element.Name + " moved with speed " +
                                  birdNode.element.Speed.ToString("F2"));

                // bird tells cats/snakes in range if it moved fast enough
                birdNode.element.HearMovement(allCats, allSnakes);

                birdNode = birdNode.next;
            }

            Console.WriteLine("\nBirds heard by " + cat1.Name);
            cat1.HeardBirds.PrintAllForward();

            Console.WriteLine("\nBirds heard by " + cat2.Name);
            cat2.HeardBirds.PrintAllForward();

            Console.WriteLine("\nBirds heard by " + snake1.Name);
            snake1.HeardBirds.PrintAllForward();

            Console.WriteLine("\nBirds heard by " + snake2.Name);
            snake2.HeardBirds.PrintAllForward();

            Console.WriteLine("\n==== Smell Update Test ====");

            Console.WriteLine("\nBefore moving Tom:");
            cat1.UpdateSmell(allAnimals);
            cat1.SmellList.PrintAllForward();

            // move Tom close to Whisker so the smell list should change
            cat2.X = 2;
            cat2.Y = 2;
            cat2.Z = 0;

            Console.WriteLine("\nAfter moving Tom close to Whisker:");
            cat1.UpdateSmell(allAnimals);
            cat1.SmellList.PrintAllForward();

            Console.WriteLine("\nAfter deleting one bird:");
            birds.DeleteFirst();
            Console.WriteLine("Birds remaining: " + birds.GetCount());

            // rebuild allAnimals because the birds list changed
            allAnimals = new DoublyLinkedList<Animal>();
            allAnimals.AddLast(cat1);
            allAnimals.AddLast(cat2);
            allAnimals.AddLast(snake1);
            allAnimals.AddLast(snake2);

            // add only the birds that are still in the birds list
            b = birds.head;
            while (b != null)
            {
                allAnimals.AddLast(b.element);
                b = b.next;
            }

            // update smell again to show the list changes after deletion
            cat1.UpdateSmell(allAnimals);
            cat1.SmellList.PrintAllForward();
        }
    }
}