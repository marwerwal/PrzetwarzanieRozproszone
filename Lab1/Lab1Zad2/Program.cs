using System;
using System.Collections.Generic;
using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
using System.Threading;

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
	public int[] preferences;

        public User(int ID, int[] preferences)
        {
            this.ID = ID;
	    this.preferences = preferences;
        }
 

        public void readBook(Book book)
        {
            Console.WriteLine($"Uzytkownik {this.ID} chce przeczytac ksiazke {book.ID} z posrod ksiazek: " +
                "[{0}]", string.Join(", ", this.preferences));
            
            {
                SemaphoreSlim _kniga = new SemaphoreSlim(4, 4);

                //Thread.Sleep(500);

                _kniga.Wait();

                Console.WriteLine($"Uzytkownik {this.ID} rozpoczal czytanie ksiazki {book.ID} " +
                    $" o liczbie stron {book.pages}. Niezajętych semaforów jest: [{0}],", _kniga.CurrentCount);

                Thread.Sleep(book.pages);
                Console.WriteLine($"Uzytkownik {this.ID} przeczytal ksiazke {book.ID}");
                _kniga.Release();
            }
        }

        public void readAllBooks(List<Book> booksList)
        {
            foreach (int preference in preferences)
            {
                this.readBook(booksList[preference]);
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
                    usersList[i].preferences.Add(rnd.Next(1, 300));
                }
            }

            foreach (User user in usersList)
            {
                var x = new Thread(() => user.readAllBooks(booksList));
                x.Start();
            }

            Console.ReadKey();

        }
    }

    
}
