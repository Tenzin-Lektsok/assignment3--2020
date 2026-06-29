using System;

public class Snake : Animal
{
     // SmellList stores all animals within 10 unit radius of this snake
     // it updates every time the snake moves
     public DoublyLinkedList<Animal> SmellList { get; set; }

     // constructor calls base Animal constructor to set Name, ID, X, Y, Z
    //we add id and z as per assignment3 
    public Snake(string name, string id, int x, int y, int z) : base(name, id, x, y, z)
    {
        // SmellList is Snake specific so we initialize it here
         SmellList = new DoublyLinkedList<Animal>();
    }
    

    // Move one step toward the target animal
    // updated from A2 to use Animal instead of Bird so snake can move toward any animal
    //added Z movement because animals now move in 3D grid
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

   //Snake eats the first bird in the list.
    // updated from A2 to use DoublyLinkedList instead of MyArrayList
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
            //skip this snake as snake should not smell itself
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
    //Return snake name,ID and position as a string.
    // updated from A2 to include ID and Z coordinate
    public override string ToString()
    {
        return Name + "(ID:" + ID + " X:" + X + " Y:" + Y + " Z:" + Z + ")";
    }
}
