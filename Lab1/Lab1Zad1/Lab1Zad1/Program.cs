using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab1Zad1
{
    public class Book
    {
        public int ID;
        public int pages;

        public Book(int ID, int pages)
        {
            this.ID = ID;
            this.pages = pages;
        }

    }
    public class User
    {
        public int ID;

        public User(int ID)
        {
            this.ID = ID;
        }

        public List<int> wantedBooks = new List<int>();

        

        public void readBook(Book book)
        {
            Console.WriteLine($"Uzytkownik {this.ID} chce przeczytac ksiazke {book.ID}");
            lock (book)
            {
                Console.WriteLine($"Uzytkownik {this.ID} rozpoczal czytanie ksiazki {book.ID}");
                Thread.Sleep(book.pages);
                Console.WriteLine($"Uzytkownik {this.ID} przeczytal ksiazke {book.ID}");
            }
        }

        public void readAllBooks(List<Book> booksList)
        {
            foreach (int book in wantedBooks)
            {
                this.readBook(booksList[book]);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            List<Book> booksList = new List<Book>();

            for (int i = 0; i < 300; i++)
            {
                booksList.Add(new Book(i, rnd.Next(1, 801)));
            }

            List<User> usersList = new List<User>();
            for (int i = 0; i < 20; i++)
            {
                usersList.Add(new User(i));
                for(int j=0; j < 40; j++)
                {
                    usersList[i].wantedBooks.Add(rnd.Next(1, 300));
                }
            }

            var reading0 = new Thread(() => usersList[0].readAllBooks(booksList));
            var reading1 = new Thread(() => usersList[1].readAllBooks(booksList));
            var reading2 = new Thread(() => usersList[2].readAllBooks(booksList));
            var reading3 = new Thread(() => usersList[3].readAllBooks(booksList));
            var reading4 = new Thread(() => usersList[4].readAllBooks(booksList));
            var reading5 = new Thread(() => usersList[5].readAllBooks(booksList));
            var reading6 = new Thread(() => usersList[6].readAllBooks(booksList));
            var reading7 = new Thread(() => usersList[7].readAllBooks(booksList));
            var reading8 = new Thread(() => usersList[8].readAllBooks(booksList));
            var reading9 = new Thread(() => usersList[9].readAllBooks(booksList));
            var reading10 = new Thread(() => usersList[10].readAllBooks(booksList));
            var reading11 = new Thread(() => usersList[11].readAllBooks(booksList));
            var reading12 = new Thread(() => usersList[12].readAllBooks(booksList));
            var reading13 = new Thread(() => usersList[13].readAllBooks(booksList));
            var reading14 = new Thread(() => usersList[14].readAllBooks(booksList));
            var reading15 = new Thread(() => usersList[15].readAllBooks(booksList));
            var reading16 = new Thread(() => usersList[16].readAllBooks(booksList));
            var reading17 = new Thread(() => usersList[17].readAllBooks(booksList));
            var reading18 = new Thread(() => usersList[18].readAllBooks(booksList));
            var reading19 = new Thread(() => usersList[19].readAllBooks(booksList));

            reading0.Start();
            reading1.Start();
            reading2.Start();
            reading3.Start();
            reading4.Start();
            reading5.Start();
            reading6.Start();
            reading7.Start();
            reading8.Start();
            reading9.Start();
            reading10.Start();
            reading11.Start();
            reading12.Start();
            reading13.Start(); 
            reading14.Start();
            reading15.Start();
            reading16.Start();
            reading17.Start();
            reading18.Start();
            reading19.Start();

            Console.ReadKey();

        }
    }

    
}

