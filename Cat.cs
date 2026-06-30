using System;
// Cat inherits from Animal, gets Name, ID, X, Y, Z and FindDistance for free
// we remove Name, X, Y from Cat because they now come from Animal base class
public class Cat : Animal
{
    // SmellList stores all animals within 10 unit radius of this cat
    // it updates every time the cat moves
    public DoublyLinkedList<Animal> SmellList { get; set; } 

    // HeardBirds stores birds that told this cat their speed
    // because they were moving fast and within range
     public DoublyLinkedList<Bird> HeardBirds { get; set; }

    // constructor calls base Animal constructor to set Name, ID, X, Y, Z
    //we add id and z as per assignment3 
    public Cat(string name, string id, int x, int y, int z) : base(name, id, x, y, z)
    {
        //initialize empty smell list
        SmellList = new DoublyLinkedList<Animal>();  

        //initialize empty HearBird list to store bird itself
        HeardBirds = new DoublyLinkedList<Bird>(); 

    }

    // Move one step toward the target animal
    // updated from A2 to use Animal instead of Bird so cat can move toward any animal
    public void MoveToward(Animal target)
    {
        int dx = target.X - this.X;
        int dy = target.Y - this.Y;
        int dz = target.Z - this.Z;

        if (dx > 0) X++;
        else if (dx < 0) X--;

        if (dy > 0) Y++;
        else if (dy < 0) Y--;

         if (dz > 0) Z++;
        else if (dz < 0) Z--;

        Console.WriteLine(Name + " moved to (" + X + ", " + Y + "," + Z + ")");
    }

    // Cat eats the first bird in the list.
    //updated from A2 to use DoublyLinkedList instead of MyArrayList
    public void EatBird(DoublyLinkedList<Bird> birds)
    {
        if (birds.GetCount() > 0)
        {
            birds.DeleteFirst();
            Console.WriteLine(Name + " ate a bird.");
        }
    }

    //Reference is assignment 3 specifaction
    //"cats and snakes can smell all animals within a 10 unit radius"
    //"they need to store list of animals they can smell and update it as they move"
    //"cats and snakes build their own lists since they have perfect information"
    public void UpdateSmell(DoublyLinkedList<Animal> allAnimals)
    {
        //clear old smell list first because animals move each round
        //animals that were in range before might now be out of range
        // and new animals might now be in range so we start fresh each update
        SmellList = new DoublyLinkedList<Animal>();

        //traversal pattern from our PrintAllForward method where p starts at head.
        Node<Animal> p = allAnimals.head;
        while(p != null)
        {
            //skip this cat as cat should not smell itself
            if(p.element != this)
            {
                //use FindDistance of Animal class to check if animal is within 10 unit radius
                if(FindDistance(p.element)<= 10){
                    SmellList.AddLast(p.element);
                }

            }
            //move p pointer forward to next animal in list
            p = p.next;

        }

    }

    // Return cat name, id and position as a string.
    public override string ToString()
    {
        return Name + "(ID:" + ID + " X:" + X + " Y:" + Y + " Z:" + Z + ")";
    }
}
