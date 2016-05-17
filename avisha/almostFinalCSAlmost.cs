using System;
using System.Collections.Generic;
using System.Linq;
      
public class Program
{
  public static void Main()
  {
    CLSim craycray = new CLSim();
        
           
  }
  
  public class CLSim
  
  {
    public CLSim()
    {
      
      string x = "";

   CrazyLibrary cl = new CrazyLibrary();
   cl.FindBorrower("Royce");
   cl.AddBook("Hello","C", 3);
   
   cl.AddBook("Zed","B", 2);
   
   cl.AddBook("Procopio","D", 4);
   
   cl.AddBook("Alpha","E", 12);
   
   cl.AddBook("Etits","A", 5);
   cl.Lineup("First");
   
   cl.Lineup("Second");
   
   cl.Lineup("Third");
   
   cl.Lineup("Fourth");
   
   cl.Lineup("Fifth");
            while (x != "exit")
            {
                Console.WriteLine("\n-------------------------\nInput Command\n");
                x = Console.ReadLine();

                IList<string> names = x.Split(new string[] { " " },
                StringSplitOptions.RemoveEmptyEntries);
                if (names.Count > 0)
                {
                    if (names[0].ToLower() == "lineup")
                    {
                      cl.Lineup(names[1]);
                    }
                    else if (names[0] == "help")
                    {
                        Console.WriteLine("command list \n add [name]\n\t adds a user to the queue \n\t creates a new borrower if user is not on borrowers list\n\n");
                        Console.WriteLine("\n libro [book title]\n\t adds a book to the book stack\n\n");
                        Console.WriteLine("\n serve\n\t serves a borrower and assigns a book to him / her \n\n");
                        Console.WriteLine("\n rotate\n\t rotates borrower queue\n\n");
                        Console.WriteLine("\n summary\n\t lists number of borrowers in queue and number of books in the stack / her \n\n");
                    }
                  else if (names[0] == "rotate")
                    {
              
                    cl.Rotate();
                    }
                   else if (names[0] == "return")
                    {
              
                    cl.ReturnBook(names[1]);
                    }
                    else if (names[0] == "serve")
                    {
                        Console.WriteLine("Serving ...");
                      cl.Serve();
                    }
                   else if (names[0] == "add")
                    {
                     if (((names[2]!=null)&&(names[1]!=null))&&(names[3]!=null))
                     {
                      cl.AddBook(names[1],names[2], int.Parse(names[3]));
                     }
                     else
                     {
                       Console.WriteLine("Invalid Parameters");
                     }
                    }
                  else if (names[0] == "summary")
                    {
                      cl.Summary();
                    
                    }
                   else if (names[0] == "sort")
                    {
                     if (names[1].ToLower() == "title")
                     {cl.SortBooks(0);}// Sort B title
                     else if (names[1].ToLower() == "author")
                     {cl.SortBooks(1);}// Sort By Author
                     else if (names[1].ToLower() == "isbn")
                     {cl.SortBooks(2);}// Sort By ISBN
                     else
                     {
                       
                     }
                    
                    }
                    else
                    {
                        Console.WriteLine("invalid command '" + names[0] + "'");
                    }
                }

                else
                {
                    Console.WriteLine("hoy! ayus!");
                }

            }
      
    }  
    
  }  
  
  
  public class Book
{
  string title; 
  string author; 
  int ISBN;

  public Book(string t,string a,int i) 
  {
    title = t;
    author = a;
    ISBN = i;
   }

  public string GetAuthor()
  {
    return author;
  } 

   public string GetTitle() 
  {
    return title;
   }

   public int GetISBN()
  {
    return ISBN;
   }

}

public class Borrower
{
   string name;
   Book b ;
   public Borrower(String n) 
  {
    name = n;
  } 
  public string GetName()
  {
    return name;
  }
  public Book GetBook()
   {
    return b;
   }
   public void SetBook(Book libro)
  {
    b = libro;
   }

 }


  class Node
    {

          object element;
          Node next;
         public Node(object e, Node n)
        {
            element = e;
            next = n;

        }
         public object GetElement()
         {

             return element;
         }
         public Node GetNext()

         {
             return next;
         
         }
         public void SetElement(object newElem)
         {
             element = newElem;
         }
         public void SetNext(Node newNext)
         {
             next = newNext;
         }
    
    
    }


  class NodeStack
{
  private Node top;
  private int count;
  public NodeStack()
  {
    top = null;
    count = 0;
  }
  public int Count()
  {
    return count;
  }
    public void Push(object obj)
    {
        Node v = new Node(obj, top);
        top = v;
        count++;
    }
        public object peek() {
            if (count != 0)
            {
                return top.GetElement();
            }
            else
            { return null; }
  }
  public object pop() {
    object temp = null;
    if( count != 0 ) {
      temp = top.GetElement();
      top = top.GetNext();
      count--;
    }
    return temp;
  }


}

 
  public class NodeQueue
  {
      private Node front;
      private Node rear;
      private int size;

      public NodeQueue()
      {
          front = null;
          rear = null;
          size = 0;
      }

      public void Enqueue(object o)
      {
          Node temp = new Node(o, null);
          //remove & return front element
          if (size > 0)
          {
              rear.SetNext(temp);
              rear = temp;
          }

          else
          {
             
              rear = temp;
              front = temp;
          }

          size++;
      }

      public object Dequeue()
      {
          //remove and return front element

          object temporary;
          if (size >= 0)
          {
              if (size == 1)
              {
                  temporary = front.GetElement();
                  front = null;
                  rear = null;
                  size--;
              }
              else
              {
                  temporary = front.GetElement();
                  front = front.GetNext();
                  size--;
              }

              return temporary;
          }
          else
          {
              // if Node is already empty
              return null;

          }
      }

      public int count()
      {
          //return number of elements in queue
          return size;
      }

      public object peek()
      {
          //return front element
          if (size != 0)
          {
              return front.GetElement();
          }
          return null;
      }

      public void clear()
      {
          //empties the queue
          front = null;
          rear = null;
          size = 0;
      }
  }
  
  public class CrazyLibrary
{
  private List<Book> a;
  private NodeStack BookStack ;
  private NodeQueue BorrowerQueue; 
  private List<Borrower> BorrowerList;
  public CrazyLibrary()
  {
    BorrowerList = new List<Borrower>();
    BookStack = new NodeStack();
    BorrowerQueue = new NodeQueue();
  
  }
  public Borrower FindBorrower(string b) 
  {
    // find borrower
    
    for (int i = 0; i < BorrowerList.Count(); i++)
    {
      if (String.Compare(BorrowerList[i].GetName().ToLower(), b.ToLower())==0)
        {
          return BorrowerList[i];
        }
    }
    return (new Borrower(null));
  }
  public void Lineup(string b)
  {
    
    Console.WriteLine("Hello "+b);
    if (FindBorrower(b).GetName() == null)
    {
      
    Console.WriteLine(b+" You do not exist");
      Borrower br = new Borrower(b);
      BorrowerList.Add(br); // Maybeee I dunno how to put it in 
    }
    else 
    {
      Borrower br = FindBorrower(b);
    }


    BorrowerQueue.Enqueue(FindBorrower(b));
    Console.WriteLine("Ok, "+FindBorrower(b).GetName()+" is in the line");

  }
  public void Serve()
  {
    if (BorrowerQueue.count() > 0)
    {
      if (BookStack.Count()> 0 )
      {
        Borrower guy = (Borrower)BorrowerQueue.Dequeue();
        Book libro  = (Book)BookStack.pop();
        guy.SetBook(libro);
        Console.WriteLine(guy.GetName()+" Borrowed "+libro.GetTitle() );
      }
      else
      {
        Console.WriteLine("Empty Stack, sorry");
      }

    }
    else
    {
      Console.WriteLine("Line is empty, No one is in line");
    }
  }
    public void Summary()
    {
      Console.WriteLine(BookStack.Count().ToString()+" Books in Stack and \n"+BorrowerQueue.count()+" People in Line");
    }
  public void AddBook(string n,string a,int i) 
  {
    Book libro = new Book(n,a,i);
    BookStack.Push(libro);
    Console.WriteLine("eto, nadagdadag na ang librong "+libro.GetTitle()+" sa stack ng mga libro!");
  }
  public void ReturnBook(string n)
  {
    Borrower br = FindBorrower(n);
    if (br != null)
    {
      BookStack.Push(br.GetBook());

      Console.WriteLine(br.GetName()+" returned "+ br.GetBook().GetTitle());
      br.SetBook(null);
    }
    else 
    {
      Console.WriteLine("di kita kilala!");
    }

  }
  public void Rotate()
  {
    NodeStack temp = new NodeStack();
    for(int i=0;i<BorrowerQueue.count(); i++)   
    {
      temp.Push(BorrowerQueue.Dequeue());
      
    }
      for(int i=0;i<temp.Count(); i++)   
    {
      BorrowerQueue.Enqueue(temp.pop());

    }
    Console.WriteLine("Flipped na bui");
  }
    
 public void fix( int n, int i)
{
    int root = i; 
    int mrLeft = 2*i + 1;  
    int mrRight = 2*i + 2;  
 
    if ((mrLeft < n) && (String.Compare(a[mrLeft].GetTitle() , a[root].GetTitle())>0))
        {root = mrLeft;}// is left higher?
    if ((mrRight < n) && (String.Compare(a[mrRight].GetTitle() , a[root].GetTitle())>0))
        {root = mrRight;}//is right higher
   
    if (root != i)// is i the highest
    {
      Book temp = a[i];
      a[i] = a[root];
      a[root] = (Book)temp; //swappit
        fix( n, root);
    }
}
     public void fix1( int n, int i) // Arrange According to Author // Basically Heapify
{
    int root = i; 
    int mrLeft = 2*i + 1;  
    int mrRight = 2*i + 2;  
 
    if ((mrLeft < n) && (String.Compare(a[mrLeft].GetAuthor() , a[root].GetAuthor())>0))
        {root = mrLeft;}// is left higher?
    if ((mrRight < n) && (String.Compare(a[mrRight].GetAuthor() , a[root].GetAuthor())>0))
        {root = mrRight;}//is right higher
   
    if (root != i)// is i the highest
    {
      Book temp = a[i];
      a[i] = a[root];
      a[root] = (Book)temp; //swappit
        fix1( n, root);
    }
}
     public void fix2( int n, int i)
{
    int root = i; 
    int mrLeft = 2*i + 1;  
    int mrRight = 2*i + 2;  
 
    if ((mrLeft < n) && (a[mrLeft].GetISBN() > a[root].GetISBN()))
        {root = mrLeft;}// is left higher?
    if ((mrRight < n) && (a[mrRight].GetISBN() > a[root].GetISBN()))
        {root = mrRight;}//is right higher
   
    if (root != i)// is i the highest
    {
      Book temp = a[i];
      a[i] = a[root];
      a[root] = (Book)temp; //swappit
        fix2( n, root);
    }
}
  public void SortBooks(int x)
  {
    
    
    
    if (x == 0)
    { // for title 
        a = new List<Book>();
        a.Clear();
        while(BookStack.Count() > 0)
        {
          a.Add((Book)BookStack.pop()); // adding everything in the stack to the list
        }


        List<Book> temp = new List<Book> (a); // temporarily ttransfer everything to another array
        a.Clear();
        for(int i=0 ; i<temp.Count; i++)
        {
          int parentIndex = 0;
          int indexxx = a.Count; // index of end of array

          a.Add(temp[i]);// add new element at the end of array
          while (indexxx>0)//Compare the key of the newly added element with it’s parent’s key to check if heap property is observed
        {
          parentIndex = (int)((indexxx-1)/2);
          if (String.Compare(a[indexxx].GetTitle(), a[parentIndex].GetTitle())>0) // if the indexxx is greater than it's parent
          {
            Book hand = a[indexxx];
            a[indexxx] = a[parentIndex];
            a[parentIndex] = hand;
            indexxx = parentIndex;
            //swap them
          }
          else 
          {
            break;
          }
        }
        }
        string s = "";
        for(int i=0;i<a.Count;i++)
        {
         s+=a[i].GetTitle()+" - ";
        }
        Console.WriteLine(s);

        // Heap was built where a[0] is highest 


        //swap then demote
        for (int i = a.Count-1; i>0 ;i-- )
        {
          Book hand = a[0];
          a[0] = a[i];
          a[i] = hand;

          Console.WriteLine("top of the heap was"+ a[i].GetTitle());

          int n= i; // n is length of remaining heap

          fix(n,0);
        }
        s = "";
        for(int i=0;i<a.Count;i++)
        {
          s+=a[i].GetTitle()+" - ";
        }

        Console.WriteLine(s);
        for(int i = a.Count - 1; i>= 0; i--)
        {
          BookStack.Push(a[i]);
        }

    }
    else if(x==1)
    {// for author
      
      // for title 
        a = new List<Book>();
        a.Clear();
        while(BookStack.Count() > 0)
        {
          a.Add((Book)BookStack.pop()); // adding everything in the stack to the list
        }


        List<Book> temp = new List<Book> (a); // temporarily ttransfer everything to another array
        a.Clear();
        for(int i=0 ; i<temp.Count; i++)
        {
          int parentIndex = 0;
          int indexxx = a.Count; // index of end of array

          a.Add(temp[i]);// add new element at the end of array
          while (indexxx>0)//Compare the key of the newly added element with it’s parent’s key to check if heap property is observed
        {
          parentIndex = (int)((indexxx-1)/2);
          if (String.Compare(a[indexxx].GetAuthor(), a[parentIndex].GetAuthor())>0) // if the indexxx is greater than it's parent
          {
            Book hand = a[indexxx];
            a[indexxx] = a[parentIndex];
            a[parentIndex] = hand;
            indexxx = parentIndex;
            //swap them
          }
          else 
          {
            break;
          }
        }
        }
        string s = "";
        for(int i=0;i<a.Count;i++)
        {
         s+=a[i].GetAuthor()+" - ";
        }
        Console.WriteLine(s);

        // Heap was built where a[0] is highest 


        //swap then demote
        for (int i = a.Count-1; i>0 ;i-- )
        {
          Book hand = a[0];
          a[0] = a[i];
          a[i] = hand;

          Console.WriteLine("top of the heap was"+ a[i].GetAuthor());
          int n= i; // n is length of remaining heap

          fix1(n,0);
        }
        s = "";
        for(int i=0;i<a.Count;i++)
        {
          s+=a[i].GetAuthor()+" - ";
        }

        for(int i = a.Count - 1; i>= 0; i--)
        {
          BookStack.Push(a[i]);
        }

      
      
      
      
    }
    else if(x==2)
    {
      
       // for isbn 
        a = new List<Book>();
        a.Clear();
        while(BookStack.Count() > 0)
        {
          a.Add((Book)BookStack.pop()); // adding everything in the stack to the list
        }


        List<Book> temp = new List<Book> (a); // temporarily ttransfer everything to another array
        a.Clear();
        for(int i=0 ; i<temp.Count; i++)
        {
          int parentIndex = 0;
          int indexxx = a.Count; // index of end of array

          a.Add(temp[i]);// add new element at the end of array
          while (indexxx>0)//Compare the key of the newly added element with it’s parent’s key to check if heap property is observed
        {
          parentIndex = (int)((indexxx-1)/2);
          if (a[indexxx].GetISBN()>a[parentIndex].GetISBN()) // if the indexxx is greater than it's parent
          {
            Book hand = a[indexxx];
            a[indexxx] = a[parentIndex];
            a[parentIndex] = hand;
            indexxx = parentIndex;
            //swap them
          }
          else 
          {
            break;
          }
        }
        }
        string s = "";
        for(int i=0;i<a.Count;i++)
        {
         s+=a[i].GetISBN().ToString()+" - ";
        }
        Console.WriteLine(s);

        // Heap was built where a[0] is highest 


        //swap then demote
        for (int i = a.Count-1; i>0 ;i-- )
        {
          Book hand = a[0];
          a[0] = a[i];
          a[i] = hand;

          int n= i; // n is length of remaining heap

          fix2(n,0);
        }
        s = "";
        for(int i=0;i<a.Count;i++)
        {
          s+=a[i].GetISBN()+" - ";
        }

        Console.WriteLine(s);
        for(int i = a.Count - 1; i>= 0; i--)
        {
          BookStack.Push(a[i]);
        }

      
      
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
  
  }
}

}
