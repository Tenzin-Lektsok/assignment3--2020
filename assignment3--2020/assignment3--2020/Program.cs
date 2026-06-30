
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
             Cat cat2 = new Cat("Tom", "C2", 0, 0, 0);

             Snake snake1 = new Snake("Cobra", "S1", 0, 0, 0);
             Snake snake2 = new Snake("Python", "S2", 0, 0, 0);
            
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
                int z = random.Next(-10, 11);
                // pick the ith  name for this bird from the names array
                string thisBirdName = birdNames[i];

                // give this bird an ID like B1,B2..
                string thisBirdID = "B" + (i + 1);

                 // create a new Bird object using its name, id, and the random x, y, z
                 Bird newBird = new Bird(thisBirdName, thisBirdID, x, y, z);

                //add that new bird to the end of the birds list
                birds.AddLast(newBird);

            }

            Console.WriteLine("Created " + birds.GetCount() + " birds.");

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
             Cat cat2 = new Cat("Tom", "C2", 0, 0, 0);

             Snake snake1 = new Snake("Cobra", "S1", 0, 0, 0);
             Snake snake2 = new Snake("Python", "S2", 0, 0, 0);
            
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
                int z = random.Next(-10, 11);
                birds.AddLast(new Bird(birdNames[i], "B" + (i + 1), x, y, z));
            }

            Console.WriteLine("Created " + birds.GetCount() + " birds.");


            // allCats and allSnakes are used by Bird's HearMovement method
            // to check distance against every cat and every snake
            DoublyLinkedList<Cat> allCats = new DoublyLinkedList<Cat>();
            allCats.AddLast(cat1);
            allCats.AddLast(cat2);

            DoublyLinkedList<Snake> allSnakes = new DoublyLinkedList<Snake>();
            allSnakes.AddLast(snake1);
            allSnakes.AddLast(snake2);

            // allAnimals is used by Cat and Snake's UpdateSmell method
            // to check distance against every animal in the simulation
            // Birds are included in this list as well, but only as targets to be smelled, 
            // Bird cannot call UpdaateSmell as it has no UpdateSmell method.
            DoublyLinkedList<Animal> allAnimals = new DoublyLinkedList<Animal>();
            allAnimals.AddLast(cat1);
            allAnimals.AddLast(cat2);
            allAnimals.AddLast(snake1);
            allAnimals.AddLast(snake2);

           // traverse the birds list to add each bird into allAnimals too
           Node<Bird> b = birds.head;
           while (b != null)
           {
               allAnimals.AddLast(b.element);
                b = b.next;
            }

            Console.WriteLine("Total animals in simulation: " + allAnimals.GetCount());        

        }
              Console.WriteLine("\n=== Smell Testing ===");     
            // before we call UpdateSmell, cat1's SmellList is empty as nothing added yet
            Console.WriteLine("Test 1: cat1 SmellList count = " + cat1.SmellList.GetCount()); 

            // call UpdateSmell so cat1 checks distance with each animal in allAnimals list one at a time
            //if that animal is within 10 units, cat1 adds it to its own SmellList
           cat1.UpdateSmell(allAnimals);
          // print how many animals got added proves the list can grow
            Console.WriteLine("After UpdateSmell, cat1 SmellList count = " + cat1.SmellList.GetCount());
            cat1.SmellList.PrintAllForward();

            // snake1 works the same way as cat1, this proves UpdateSmell works for snakes too
            snake1.UpdateSmell(allAnimals);

            // cat1 eats a bird so that bird is removed from the birds list
            cat1.EatBird(birds);

            // bird is eaten and removed from birds list but it still sitting in allAnimals
            // since allAnimals never gets updated when birds is changed
            // we clear allAnimals and rebuild it the same way as before
            // using cats, snakes, and the updated birds list 
            // create brand new empty allAnimals list.
            allAnimals = new DoublyLinkedList<Animal>();
            allAnimals.AddLast(cat1);
            allAnimals.AddLast(cat2);
            allAnimals.AddLast(snake1);
            allAnimals.AddLast(snake2);

           // loop through birds list again and add only the birds that are still alive
           b = birds.head;
           while (b != null)
           {
               allAnimals.AddLast(b.element);
              b = b.next;
            }

            // call UpdateSmell again with the rebuild allAnimals
            //  bird1 was eaten so we rebuilt allAnimals without it
            // cat1's SmellList updates correctly and no longer includes bird1
             cat1.UpdateSmell(allAnimals);
             Console.WriteLine("cat1 SmellList count after eating a bird = " + cat1.SmellList.GetCount());

             
            Console.WriteLine("\n=== Smell Testing ===");     
            // before we call UpdateSmell, cat1's SmellList is empty as nothing added yet
            Console.WriteLine("Test 1: cat1 SmellList count = " + cat1.SmellList.GetCount()); 

            // call UpdateSmell so cat1 checks distance with each animal in allAnimals list one at a time
            //if that animal is within 10 units, cat1 adds it to its own SmellList
           cat1.UpdateSmell(allAnimals);
          // print how many animals got added proves the list can grow
            Console.WriteLine("After UpdateSmell, cat1 SmellList count = " + cat1.SmellList.GetCount());
            cat1.SmellList.PrintAllForward();

            // snake1 works the same way as cat1, this proves UpdateSmell works for snakes too
            snake1.UpdateSmell(allAnimals);

            // cat1 eats a bird so that bird is removed from the birds list
            cat1.EatBird(birds);

            // bird is eaten and removed from birds list but it still sitting in allAnimals
            // since allAnimals never gets updated when birds is changed
            // we clear allAnimals and rebuild it the same way as before
            // using cats, snakes, and the updated birds list 
            // create brand new empty allAnimals list.
            allAnimals = new DoublyLinkedList<Animal>();
            allAnimals.AddLast(cat1);
            allAnimals.AddLast(cat2);
            allAnimals.AddLast(snake1);
            allAnimals.AddLast(snake2);

           // loop through birds list again and add only the birds that are still alive
           b = birds.head;
           while (b != null)
           {
               allAnimals.AddLast(b.element);
              b = b.next;
            }

            // call UpdateSmell again with the rebuild allAnimals
            //  bird1 was eaten so we rebuilt allAnimals without it
            // cat1's SmellList updates correctly and no longer includes bird1
             cat1.UpdateSmell(allAnimals);
             Console.WriteLine("cat1 SmellList count after eating a bird = " + cat1.SmellList.GetCount());


             Console.WriteLine("\n=== HearMovement Testing ===");

            // pick the first bird sitting at birds.head list to test with
            Bird testBird = birds.head.element;
            Console.WriteLine("\nTesting with bird: " + testBird);

           // move this bird so it gets a new random position and a Speed value gets calculated
           testBird.Move(random);
           Console.WriteLine("After moving, " + testBird.Name + " Speed = " + testBird.Speed);

          // print distance from this bird to each cat and snake before checking HearMovement
          // so we can manually verify later if HearMovement correctly adds testBird to the right cats and snakes
           Console.WriteLine("Distance to cat1 = " + testBird.FindDistance(cat1));
           Console.WriteLine("Distance to cat2 = " + testBird.FindDistance(cat2));
           Console.WriteLine("Distance to snake1 = " + testBird.FindDistance(snake1));
           Console.WriteLine("Distance to snake2 = " + testBird.FindDistance(snake2));

          // testBird calls HearMovement to tell nearby cats and snakes about its speed
           // if speed is more than 5, all cats within 15 units get added to their HeardBirds
          // if speed is more than 10, all snakes within 10 units also get added
          testBird.HearMovement(allCats, allSnakes);

           // print how many birds cat1 has heard, count of birds added to cat1's HeardBirds
           Console.WriteLine("\ncat1 HeardBirds count = " + cat1.HeardBirds.GetCount());
           // print how many birds snake1 has heard, count of birds added to snake's HeardBirds
           Console.WriteLine("snake1 HeardBirds count = " + snake1.HeardBirds.GetCount());

        } 

        } 



    }
}


        }
        
    }
}
