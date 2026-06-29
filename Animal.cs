
Using System; 
public class Animal
{
   // store animal name and ID
    public string Name { get; set; }
    public string ID { get; set; }

    //store animal position on 3D grid.
    //z cooridinate is added as per instruction A3 to move birds move up and down.
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }


     // constructor sets all properties when animal object is created.
    public Animal(string name, string id, int x, int y, int z)
    {
        Name = name;
        ID = id;
        X = x;
        Y = y;
        Z = z;
    }



}
