public class Bird : Animal
{
    // declare Speed as a property of type double to track how far the bird moved in each round
    // double is used because speed can have decimal values like 14.28
    public double Speed { get; set; }

    // constructor calls base Animal constructor to set Name, ID, X, Y, Z
    // we add id and z as per assignment 3
    public Bird(string name, string id, int x, int y, int z) : base(name, id, x, y, z)
    {

    }

     // return bird name, ID and position as a string
     // updated from A2 to include ID and Z coordinate
     public override string ToString()
     {
    return Name + "(ID:" + ID + " X:" + X + " Y:" + Y + " Z:" + Z + ")";
    }
    // Reference Assignment3 specification of Animals sections
    // "birds can move at most +/-10 in X, Y and +/-2 in Z"
    // "max speed of sqrt(10^2 + 10^2 + 4^2) = 14.28"
    // "when a bird exceeds speed of 5 all cats within 15 units can hear it"
    // "when a bird exceeds speed of 10 all snakes within 10 units can hear it"
    // https://www.geeksforgeeks.org/c-sharp/c-sharp-random-next-method/
    // Next(minValue, maxValue) method returns >= minValue and  < maxValue
    // maxValue is the exclusive upper boundary of the random number generated.
    // minValue is the inclusive lower bound of the random number returned
    // so random.Next(-10, 11) gives -10 to 10 because 11 is exclusive
    // and random.Next(-2, 3) gives -2 to 2 because 3 is exclusive
    // this matches assignment rule of +/-10 in X and Y and +/-2 in Z

    // https://stackoverflow.com/questions/23937825/calculating-the-distance-between-2-points-in-2d-and-3d
     // Speed property needed to track how fast bird moved each round using formula FindDistance
     //we compare old position and new position of same bird instead of two animals
     public void Move(Random random)
     {
        // save old position before moving so we can calculate speed
        int oldX = X;
        int oldY = Y;
        int oldZ = Z;
        
         // Update the X, Y and Z positions by adding a random movement.
        // X and Y change by -10 to 10, and Z changes by -2 to 2, as specified in the assignment. 
        X =  X + random.Next(-10, 11);
        Y =  Y + random.Next(-10, 11);
        Z = Z + random.Next(-2, 3);

         // assignment says max speed = squareroot(10^2 + 10^2 + 4^2) = 14.28
         // we calculate speed same way and dx, dy, dz are the difference between new position and old position
         int dx = X - oldX;
         int dy = Y - oldY;
         int dz = Z - oldZ;
         Speed = Math.Sqrt(dx * dx + dy * dy + dz * dz);

     }

     // Reference Assignment3 specification of Animals sections
      // "when a bird exceeds speed of 5 all cats within 15 units can hear it"
      // "when a bird exceeds speed of 10 all snakes within 10 units can hear it"
      // "the birds tell cats/snakes in range what their speed is"
      // "In HearMovement method, the birds need to store their movement and each cat/snake needs
      //  to test distance and velocity for each bird, so what should happen is the birds tell
      //  cats/snakes in range what their speed is"
      // traversal pattern same as our PrintAllForward
      // https://stackoverflow.com/questions/23937825/calculating-the-distance-between-2-points-in-2d-and-3d
      // https://www.educative.io/answers/how-to-compute-euclidean-distance-in-c-sharp
      // The distance check by FindDistance method which built from StackOverflow and Educative.
      public void HearMovement(DoublyLinkedList<Cat> allCats, DoublyLinkedList<Snake>allSnakes)
      {
         // if speed is greater than 5 and also greater than 10 (like 12)
        // we need to handle both cases individually
        // if-else would skip the else block once the first if is true
        // so we use two separate if statements instead 
        
        //if bird speed exceeds 5, all cats within 15 units range can hear bird and 
        if(Speed > 5)
        {
            Node<Cat> c = allCats.head;
            while(c != null)
            {
                // if distance from this bird to cat (found using FindDistance) is less than or equal to 15
                if(FindDistance(c.element) <= 15)
                {
                    //then add this bird to that cats HeardBirds list as cat can hear it.
                    c.element.HeardBirds.AddLast(this);

                }
                //Move forward to next cat in allCats list
                c = c.next;

            }


        }
        //if bird speed exceeds 10, all snakes within 10 units range can hear bird
         if(Speed > 10)
            {
                Node<Snake> s = allSnakes.head;

                while( s != null)
                {
                    // if distance from this bird to snake (found using FindDistance) is less than or equal to 10
                    if(FindDistance(s.element) <= 10)
                    {
                        //then add this bird to that snakes HeardBirds list since the snake can hear it.
                        s.element.HeardBirds.AddLast(this);

                    }
                      //Move forward to next snake in allSnakes list
                    s =s.next;

                }
                
            }


}
