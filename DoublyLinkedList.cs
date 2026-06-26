
// https://github.com/Tenzin-Lektsok/DoublyLinkedPractice.git
using System;
 namespace Assignment3Template
 {
    // Reference: Udemy — Data Structures and Algorithms in Depth using C#
    // https://www.udemy.com/course/data-structures-and-algorithms-in-depth-using-c-sharp/learn/lecture/23205590#content
    //Doubly linked contain collections of element represented by nodes,thus create class Node,
    //Node contain data that is element value along memory addrees of immediate next Node as well as immediate prevouis Node. 
    public class Node<T>
    {
        public T element; // Variable type T.
        public Node<T> next; //Variable type Node
        public Node<T> prev; // Variable type Node;

        //We create a constructor in the Node class 
        //because we want to initialize all three members Element, Next, and Prev at the same time when a new node is created.
        public Node(T e, Node<T> n,Node<T> p)
        {
            element = e;
            next = n;
            prev = p;

        }
    }

    // Reference: Udemy — Data Structures and Algorithms in Depth using C#
    // https://www.udemy.com/course/data-structures-and-algorithms-in-depth-using-c-sharp/learn/lecture/23205590#content
    class DoublyLinkedList<T>
    {
        //Within doubly linked list class we declare head of type node to store reference of first Node of doubly linked list
        private Node<T> head;
        //Declare also type node to store reference of last node of doubly linked list
        private Node<T> tail;
        // We declare a variable size to track and store the count of the number of nodes present in the doubly linked list at any given time."
        private int size;

        // Reference: Udemy — Data Structures and Algorithms in Depth using C#
        // https://www.udemy.com/course/data-structures-and-algorithms-in-depth-using-c-sharp/learn/lecture/23205590#content
        //Constructor  for class to intialize head,tail, and size member of doubly linked list.
        public DoublyLinkedList()
        {
            head = null; //No first node yet
            tail = null; //No last node yet
            size = 0; //Zero as intially doubly linked list is empty.

        }
        
        // Reference: Udemy — Data Structures and Algorithms in Depth using C#
        // https://www.udemy.com/course/data-structures-and-algorithms-in-depth-using-c-sharp/learn/lecture/23205590#content
        // Method to return the number of elements or length of the doubly linked list
        // as the size variable stores the count of elements in the doubly linked list.
        public int GetCount()
        {
            return size;

        }
        //Method isEmpty is implemented using a boolean to check whether the doubly linked list is empty or not.
        public bool isEmpty()
        {
            return size == 0;
        }

        // Reference: Udemy — Data Structures and Algorithms in Depth using C#
        // https://www.udemy.com/course/data-structures-and-algorithms-in-depth-using-c-sharp/learn/lecture/23205582#content
         public void AddFirst(T e)
        {
            Node<T> newest = new Node<T>(e, null, null);
            if (isEmpty())
            {
                //if list is empty then head and tail pointer to new node newest.
                head = newest;
                tail = newest;
            }
            else
            {
                //If list is not empty than add newest node at begining of list.
                newest.next = head; // forward link is created in list
                head.prev = newest; //backward link is created in list
                head = newest; //head pointer update to newest node as now it's first node of list.
            }
            size++; //update size or length of list by 1.
          
        }


        // https://www.udemy.com/course/data-structures-and-algorithms-in-depth-using-c-sharp/learn/lecture/23205590#content
        // Method to insert a node at the end of the doubly linked list with the input parameter e.
        public void AddLast(T e)
        {
            //new node is always created first, then if condition is always checked second, and size is always incremented last. 
            Node<T> newest = new Node<T>(e, null, null);

            if (isEmpty())
            {
                head = newest;
                tail = newest;
            }
            else
            {
                //if doubly linked list is not empty, tail's next reference is connected to newest node, yet newest node's prev reference is not linked back to tail.
                tail.next = newest;
                //newest node's prev reference is connected back to tail node,completing the backward link between newest and tail.
                newest.prev = tail;
                // tail reference is moved to newest node,after that the newest pointer will disappea as it is a temporary variable inside the method.
                tail = newest;
            }
            size++; //count is incremented by 1
        }
        
        // https://www.udemy.com/course/data-structures-and-algorithms-in-depth-using-c-sharp/learn/lecture/23205560#content
        public T DeleteFirst()
        {
            // If the list is empty, we cannot remove any element, so we print a message and return -1.
            if (isEmpty())
            {
                Console.WriteLine("Doubly linked list is empty.");
                // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/default
                return default(T);
            }
            // Save the data of the first node so we can return it at the end after head has moved forward.
            T e = head.element;
            // Move head forward to the second node, making it the new first node.
            // The old head node now has no reference pointing to it, so garbage collector will clean it up.
            head = head.next;
            // Decrease the size by one since we removed a node.
            size--;
            // If the list had only one node, after deleting it the list is now empty.
            // Head is already null from head = head.next, but tail is still pointing to the deleted node.
            // So we manually set tail to null.
            if (isEmpty())
            {
                tail = null;
            }
            else
            {
                // If the list had more than one node, the new head's prev is still pointing to the deleted node.
                // So we set head.prev to null to remove that broken link.
                head.prev = null;
            }
            return e;
        }
        
        //  https://www.udemy.com/course/data-structures-and-algorithms-in-depth-using-c-sharp/learn/lecture/23205550#content
        public T DeleteLast()
        {
            // If the list is empty, we cannot remove any element, so we print a message and return -1.
            if (isEmpty())
            {
                Console.WriteLine("Doubly linked list is empty");
                return default(T);
            }

            // Save the data of the last node so we can return it at the end after tail has moved backward.
            T e = tail.element;

            // Move tail backward to the previous node, making it the new last node.
            // The old tail node now has no reference pointing to it, so garbage collector will clean it up.
            tail = tail.prev;

            // The new tail's next is still pointing to the deleted node, so we set it to null to remove that broken link.
            tail.next = null;

            // Decrease the size by one since we removed a node.
            size--;

            // Return the saved data of the deleted node.
            return e;
        }

        //  https://www.udemy.com/course/data-structures-and-algorithms-in-depth-using-c-sharp/learn/lecture/23205590#content
         public void PrintAllForward()
        {
            Node<T> p = head; //To display list of items in doubly linked list, it must traverse via head as it's entry point to entire list.
                           // While loop is implemented as the number of nodes in the doubly linked list is unpredictable, and the last node's next reference is always null,
                           // thus the condition is not equal to null.
            while (p != null)
            {
                Console.Write(p.element + "-> ");
                p = p.next;
            }
            //Add a new line after displaying all elements of the doubly linked list.
            Console.WriteLine();
        }
 
       //  https://www.geeksforgeeks.org/dsa/traversal-in-doubly-linked-list/
       //From geekforgeek BackwardTraversal() logic which start from tail and follows prev pointer untill null
        public void PrintAllReverse()
        {
            Node<T> p = tail;         // start from tail
            //Continue untill current node is not null(first node of list)
            while (p != null)
            {
                 Console.Write(p.element + "-> "); //print element
                  p = p.prev;           // follow prev reference instead of next reference.
            }
             Console.WriteLine();
        }

         //  https://www.geeksforgeeks.org/dsa/search-an-element-in-a-doubly-linked-list/
        //From geekforgeek search method.
        public int Find(T e)
        {
            //Create pointer starting  at head to enter doubly linked list;
            Node<T> p = head;
           int pos = 0; // start counting from position 0
           //Traverse list until node is not null AND element is not found.
             while(p != null && !p.element.Equals(e))
            {
            pos++; //increment position counter by 1
            p = p.next; //Move to next node

            }
             //if p is null as we reached end of the list without finding element  
             //OR element in list p.element doesn't match or equal to search element e.
            if(p == null ||!p.element.Equals(e))
            {  Console.WriteLine("Element is not found in doubly linked list");
                return -1;//and return -1 to indicate not found
            }
            //element is found , return its position
            return pos + 1; //pos +1 as position counting start at 1, not 0

        }

        // https://www.devmaking.com/learn/data-structures/doubly-linked-list/
        /* pseudo-code
           Node head;
           Node tail;
           int size;
 
           function addBefore(int key, int value){
           /// Base case covered first:
           If(size == 0){
            /// Do something, or return.
         } 
           Node tmp = head;
            while( tmp is not null ){
           if( tmp.value equals key ) {
            Node newNode = new Node(value);
           newNode.next = tmp;
             newNode.previous = tmp.previous;

             tmp.previous = newNode;

             if( newNode.previous is not null ) {
               newNode.previous.next = newNode;
              }
              else {
                // * (1)
                head = tmp;
                size++;
               return;
             }
          }
         }
         */
        public void AddBefore(T key, T e)
        {
            //Basecase- if list is empty, we can't insert before anything
            if(size ==0)
            {
                Console.WriteLine("Doubly linked list is empty");
                return;

            }
            //P is start pointer at head which is entry point of doubly linked list.
            Node<T> p = head;
            //Traverse each node one by one untill we find the key
            while(p != null)
            {
                //Check if current node element matches key value we are searching for. 
                // .Equals() used because T is generic. 
                if(p.element.Equals(key))
                {
                    //Once key is found, and p is now pointing at matched node
                    //we create new node with value e.
                    //Initially prev pointer and next point are null as not yet linked to any nodes
                    Node<T> newest = new Node<T>(e,null,null);

                    newest.next = p; //Connect newest forward to current matched p node.
                    newest.prev = p.prev;  //Connect newest backward to whatever previous node was before matched node.
                    p.prev = newest; // matched node p now point backward to newest node.
                    
                     //If previous node exists link it forward to newest
                    if(newest.prev != null)
                    {
                        newest.prev.next = newest; // previous node of matched node is now points forward to newest node.

                    }
                    else
                    {
                        //When newest.prev is null, newest is now first node of list, we update head to point to newest.
                        head = newest;

                    }
                    //Once key was found and newest is inserted, we increment the size by 1
                    //if the key is not  found, size is never incremented
                    size++; 
                    return; //insertion is completed and exit method

                }
                //until no match, we move p forward to next node
                p= p.next;

            }


        }
        // https://www.devmaking.com/learn/data-structures/doubly-linked-list/
        /*
         pseudo-code
          function addAfter(int key, int value){
          /// we have some base cases to tackle:
           if(size == 0){
     
            Depending on your implementation, 
            you might return, or add a node 
       
          }
          /// Make a node to traverse the list
          Node tmp = head;
           while(tmp != null) {
         /// if we get a match, let's add a node after.
          If(tmp.value equals key){
           Node newNode = new Node(value);
           newNode.next = tmp.next;
           newNode.previous = tmp;

             tmp.next = newNode; // * (1)
              (1) is an equivalent operation to
           newNode.previous.next = newNode in this case.
            

            / // *(2) See analysis below.
             if(newNode.next is not null){
             newNode.next.previous = newNode;
             } else {
            tail = newNode; 
            }
            size++;
             return;
           }
           tmp = tmp.next;
            }
   
          Depending on your implementation, you might return,
            or add a node to the end of the list.
         */

         public void AddAfter(T key, T e)
         {
            // base case — if list is empty we cannot insert after anything
            if (size == 0)
            {
                 Console.WriteLine("Doubly linked list is empty");
                return;
            }

            // we set temporary p pointer to head to traverse each node
            // head is entry point of entire list and must always point to first node
           // so head cannot be used for traversing each node directly
          Node<T> p = head;
             //traverse each node one by one until we find the key
             while(p !=null)
             {
                // check if current node element matches key we are searching for
                //.Equals() used because T is generic
                if(p.element.Equals(key))
                {
                    // At this point, p is pointing at matched node
                    //create new node with value e, newest.next and newest.prev are null.
                    Node<T> newest = new Node<T>(e,null,null);
                    
                    // POINTER 1 newest next pointer points forward to whatever node was after matched node p
                    // newest.next = p.next, could be null if p was tail
                    newest.next = p.next;
                    
                      // POINTER 2 newest prev pointer points backward to matched node p
                    newest.prev = p;
                    
                    // POINTER 3 matched node p next pointer now points forward to newest
                    p.next = newest;
                    
                    // newest.next is null only if matched node p was tail or last node of list
                    // because we set newest.next = p.next in pointer 1 so if p.next is null and newest.next null too.
                    if(newest.next != null)
                    {
                        //Node after matched node p is newest.next as set in pointer 1 and it's prev pointer is points backward to newest
                        //this is pointer 4. 
                        newest.next.prev = newest;

                    }
                    else{
                        //if pointr 4 is not possible as newest.next is null then update tail to newest node.
                        tail = newest;
                    }
                    //Insertion complete and increament size and exit
                    size++;
                    return;

                }
                //if no match is found then move p forward to next node.
                p = p.next;

             }


         }

          // https://dev.to/shivams136/leetcode-1721-swapping-nodes-in-a-linked-list-solution-m0
         // https://www.geeksforgeeks.org/dsa/search-an-element-in-a-doubly-linked-list/
         // Swap is made of two simple parts. First we find the two nodes we want to swap
         //Second we swap their values using temp variable. 
         // This idea is from the Dev community article. we learned that we don't need to swap actual nodes by changing pointers.
         //we just swap the data inside the node which is simpler and efficient.
         // For finding the nodes we used the same search idea from the Find method, we search by value instead of position
         public void Swap(T key1,T key2)
         {
            //Base case to check whether doubly linked is empty or not.
             if(size == 0)
             {
                Console.WriteLine("Doubly linked list is empty");
                return;

             }

             // We need two temporary pointers p1 and p2 to find the two nodes we want to swap.
             // Both pointers start from head and traverse forward through the list.
             // p1 traverses to find the node with key1, and p2 traverses to find the node with key2.

             //Create first pointer p1 for first value.
             Node<T> p1 = head;
             // Loop while p1 is not null and p1 element is NOT equal to key1
             // it stops when we find the node with key1 OR reach the end of the list
             while( p1 != null && !p1.element.Equals(key1)){
                p1 = p1.next;
             }
              //create second pointer p2 for second value.
              Node<T> p2 = head;
            // Loop while p2 is not null and p2 element is NOT equal to key2
            // it stops when we find the node with key2 OR reach the end of the list
             while( p2 != null && !p2.element.Equals(key2)){
                p2 = p2.next;
             }
            
            // If either pointer is null that key was not found so we cannot swap
            if (p1 == null || p2 == null)
             {
                Console.WriteLine("One or both keys not found");
                return;
             }

             //Once both nodes are found, we swap their values using a temp variable.
             //then save p1 value in temp, then put p2 value into p1, then put temp value into p2, 
             //we only swap value and prev and next pointer stay same.
             T temp = p1.element;
             p1.element = p2.element;
             p2.element = temp;

         }

         // https://medium.com/@itsanuragjoshi/insert-an-element-in-a-linked-list-data-structures-algorithm-2a41d01afc24
         public void InsertAtRandomLocation(T element)
         {
            //generate a random position from 0 to size
            //GetRandom() can be negative or a very huge number
            // Math.Abs() removes the negative sign so the number becomes positive
            //% (size + 1) shrink the huge number down to valid positon from 0 to size.
            // we use size + 1 so the tail position is also possible
            int position = Math.Abs(MyrandomNumGen.GetRandom()) % (size +1);
            
            // if position is 0 we insert at the head using AddFirst
            if(position == 0)
            {
                AddFirst(element);

            }
            // if position is equal to size we insert at the tail using AddLast
            else if (position == size)
            {
                AddLast(element);

            }
            // otherwise the position is somewhere in the middle
            else{
                 // create a temporary pointer p and start it at head
                 // we move p forward one node at a time until we reach the node at that position
                Node<T> p = head;
                for(int i = 0; i < position; i++)
                {
                    p = p.next;
                }
                //Insert the element before that p node using AddBefore
                AddBefore(p.element, element);
                
            }


        }

        // https://medium.com/@singhamritpal49/doubly-linked-list-20b7e45bb37
         // Merge appends the other list onto the end of this list (no sorting, no comparing values)
        // we learned from the Medium push() method that the same pointer logic applies here
        // instead of adding one node we connect a whole list using the same head tail pattern
        public void Merge(DoublyLinkedList<T> other)
        {
            //if the other list is empty there is nothing to merge so we return
            if(other.head == null)
            {
                return;
            }
            //List1 is empty, we give it list2 head and tail addresses
            if(head == null)
            {
                //now list2 sharing same memory address of head with list1.
                head = other.head;
                //now list2 sharing same memory address of tail with list1.
                tail = other.tail;

            }
            else{
                 //if both lists have nodes we connect the end of list1 to start of list2
                 //list1 tail next pointer now pointing forward to list2 first node
                 tail.next = other.head;
                 //list2 first node prev pointer now pointing back to list1 last node
                 other.head.prev = tail;
                 //list1 tail now pointing at list2 last node to denote end of merged list
                 tail = other.tail;
              
            }
            //Update count by adding both list sizes together.
            size = size + other.GetCount();


        }




    }
        



        

 }
   
    
    


