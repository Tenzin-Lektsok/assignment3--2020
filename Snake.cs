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
    //Return snake name and position as a string.
    public override string ToString()
    {
        return Name + "(" + X + "," + Y + ")";
    }
}
