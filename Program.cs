// See https://aka.ms/new-console-template for more information
using System;


namespace AddressBooks
{
    class AddrBook
    {

        static void Main(string[] args)
        {


            Console.WriteLine("Welcome To Address Book System!");
            AddrBook.GetCustomer();
            AddressBooks.AddrBook.Modify();
            AddrBook.ListingPeople();

        }
    }
}
