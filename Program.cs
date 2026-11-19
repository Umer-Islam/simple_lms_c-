using System;

namespace LibraryManagementSystem
{
    public class LibraryItem
    {
        public int ItemID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public LibraryItem(int itemId, string title, string author)
        {
            ItemID = itemId;
            Title = title;
            Author = author;
        }

        public virtual void Display()
        {
            Console.WriteLine($"Item ID: {ItemID}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
        }
    }

    public class Book : LibraryItem
    {
        public int NumberOfPages { get; set; }

        public Book(int itemId, string title, string author, int numberOfPages) 
            : base(itemId, title, author)
        {
            NumberOfPages = numberOfPages;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Number of Pages: {NumberOfPages}");
            Console.WriteLine("--------------------------------");
        }
    }

    public class Magazine : LibraryItem
    {
        public int IssueNumber { get; set; }

        public Magazine(int itemId, string title, string author, int issueNumber) 
            : base(itemId, title, author)
        {
            IssueNumber = issueNumber;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Issue Number: {IssueNumber}");

            Console.WriteLine("--------------------------------");
        }
    }

    public class Library
    {
        private LibraryItem[] items;

        public Library(int size)
        {
            items = new LibraryItem[size];
        }

        public LibraryItem this[int index]
        {
            get
            {
                if (index >= 0 && index < items.Length)
                    return items[index];
                throw new IndexOutOfRangeException("Index out of range.");
            }
            set
            {
                if (index >= 0 && index < items.Length)
                    items[index] = value;
                else
                    throw new IndexOutOfRangeException("Index out of range.");
            }
        }

        public int Length => items.Length;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book(101, "Programming Fundamentals", "Ali Khan", 450);
            Magazine magazine = new Magazine(102, "Technology Today", "Ahmed Raza", 25);

            Console.WriteLine("===> Polymorphism Demonstration <===");
            LibraryItem itemRef;

            itemRef = book;
            itemRef.Display(); 
            Console.WriteLine();

            itemRef = magazine;
            itemRef.Display(); 
            Console.WriteLine();

            Console.WriteLine("===> Library Indexer Demonstration <===");
            Library library = new Library(2);

            library[0] = book;
            library[1] = magazine;

            for (int i = 0; i < library.Length; i++)
            {
                library[i].Display();
                Console.WriteLine();
            }
        }
    }
}