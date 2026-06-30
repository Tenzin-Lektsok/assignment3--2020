
Using System; 

namespace Assignment3Template
{
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

     // https://stackoverflow.com/questions/23937825/calculating-the-distance-between-2-points-in-2d-and-3d
    // https://www.educative.io/answers/how-to-compute-euclidean-distance-in-c-sharp
    // we only pass one parameter (other) because this animal is already available as 'this'
    // it gives us two points — this animal (first point) and other animal (second point)
    // Find the 3D Euclidean distance between this animal and another animal.
    // The formula is based on Pythagorean theorem
    // distance = sqrt( (x2-x1)^2 + (y2-y1)^2 + (z2-z1)^2 )
    public double FindDistance(Animal other)
    {
        int dx = other.X - this.X;
        int dy = other.Y - this.Y;
        int dz = other.Z - this.Z;
        return Math.Sqrt(dx * dx + dy * dy + dz * dz);
        
    }

    // ToString — return name, id and position
    public override string ToString()
    {
        return Name + "(ID:" + ID + " X:" + X + " Y:" + Y + " Z:" + Z + ")";
    }

}
