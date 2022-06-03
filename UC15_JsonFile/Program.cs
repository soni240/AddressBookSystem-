﻿// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using UC15_JsonFile;

namespace AddressBooks
{
    class Program
    {

        public static Dictionary<string, List<AddrBook>> numberNames = new Dictionary<string, List<AddrBook>>();
        public static Dictionary<string, List<AddrBook>> City = new Dictionary<string, List<AddrBook>>();
        public static Dictionary<string, List<AddrBook>> State = new Dictionary<string, List<AddrBook>>();

        static void Main(string[] args)
        {
            //Input an AddressBook name
            Console.WriteLine("Enter number of AddressBook to create");
            int num = Convert.ToInt32(Console.ReadLine());

            //Runs till number of addressbook needs to be added
            while (0 < num)
            {
                //Get input
                Console.WriteLine("Enter name of addressBook");
                string addrBookName = Console.ReadLine();

                //Create object for Class
                AddrBook addressBookSystem = new AddrBook();
                Console.WriteLine("Enter number of Contacts to Add");
                int contacts = Convert.ToInt32(Console.ReadLine());

                //Input contacts values from user
                while (contacts > 0)
                {
                    Console.WriteLine("\nEnter Firstname ");
                    string firstname = Console.ReadLine();
                    Console.WriteLine("Enter Lastname ");
                    string lastname = Console.ReadLine();

                    Console.WriteLine("Enter Address");
                    string address = Console.ReadLine();

                    Console.WriteLine("Enter City");
                    string city = Console.ReadLine();

                    Console.WriteLine("Enter State");
                    string state = Console.ReadLine();

                    Console.WriteLine("Enter pincode");
                    string pincode = Console.ReadLine();

                    Console.WriteLine("Enter PhoneNumber ");
                    string phone = Console.ReadLine();

                    Console.WriteLine("Enter Email");
                    string email = Console.ReadLine();

                    //Call Method
                    addressBookSystem.CreateContact(firstname, lastname, address, city, state, pincode, phone, email);
                    contacts--;
                }
                //Check if any modification needed
                Console.WriteLine("Do you want to Modify?(Y/N)");
                char ch = Convert.ToChar(Console.ReadLine());
                if (ch == 'Y')
                {

                    addressBookSystem.Modify();
                }

                numberNames.Add(addrBookName, addressBookSystem.ContactArray);
                foreach (KeyValuePair<string, List<AddrBook>> kvp in numberNames)
                {
                    //Console.WriteLine("Key: {0}, Value: {1}", kvp.Key, kvp.Value[0].firstName);              
                    Console.WriteLine("Key: {0}, Value: {1}", kvp.Key, kvp.Value + "\n");
                }
                num--;

            }

            Search();
        }
        //Display Details
        public void Display(List<AddrBook> ContactArray, int N)
        {
            Console.WriteLine("---------Address Book Contains---------");
            int i;
            for (i = 0; i < N; i++)
            {
                Console.WriteLine("First name: {0}\n Last name: {1}\n Address: {2}\n City: {3}\n Zip: {4}\n State: {5}\n Phone Number: {6}\n Email: {7} \n", ContactArray[i].firstName, ContactArray[i].lastName, ContactArray[i].Address, ContactArray[i].city, ContactArray[i].zip, ContactArray[i].state, ContactArray[i].phoneNumber, ContactArray[i].email);

            }
        }

        //Sort using SortedList collection classes
        public static void SortContactPerson()
        {

            Console.WriteLine("Enter 1-to Sort contact based on First Name");
            Console.WriteLine("Enter 2-to Sort Contact Based on State");
            Console.WriteLine("Enter 3-to Sort Contact based on City");
            Console.WriteLine("Enter 4-to Sort Contact based on zip");
            int option = Convert.ToInt32(Console.ReadLine());
            foreach (KeyValuePair<string, List<AddrBook>> kvp in numberNames)
            {
                Console.WriteLine("********Displaying sorted Contact Person Details in address book: {0}********", kvp.Key);
                //Store value of Dictionary in a list
                List<AddrBook> listAddressBook = kvp.Value;
                //Create object for Class that implements IComparer<AddressBookSystem>  
                ContactPersonComparer contactPersonComparer = new ContactPersonComparer();
                switch (option)
                {
                    case 1:
                        //Set field based on the switch case Option
                        contactPersonComparer.compareByFields = ContactPersonComparer.sortBy.firstName;
                        //Call Sort Method
                        listAddressBook.Sort(contactPersonComparer);
                        break;
                    case 2:
                        contactPersonComparer.compareByFields = ContactPersonComparer.sortBy.state;
                        listAddressBook.Sort(contactPersonComparer);
                        break;
                    case 3:
                        contactPersonComparer.compareByFields = ContactPersonComparer.sortBy.city;
                        listAddressBook.Sort(contactPersonComparer);
                        break;
                    case 4:
                        contactPersonComparer.compareByFields = ContactPersonComparer.sortBy.zip;
                        listAddressBook.Sort(contactPersonComparer);
                        break;
                }

                foreach (var emp in listAddressBook)
                {
                    Console.WriteLine(emp.ToString());
                }

            }

        }

        //Search a person through city or state or View all city and state List
        public static void Search()
        {
            Console.WriteLine("Enter 1-to Seach a person through a City");
            Console.WriteLine("Enter 2-to Seach a person through a State");
            Console.WriteLine("Enter 3-to view people  in City list or State list");
            Console.WriteLine("Enter 4-to Sort Contact people in Address Book");
            Console.WriteLine("Enter 5-To Write AddressBook in File");
            Console.WriteLine("Enter 6-To Read a File");
            Console.WriteLine("Enter 7-Perform Csv Operations");
            Console.WriteLine("Enter 8-Read and Write Operation in Json File");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    SearchAddress(option);
                    break;
                case 2:
                    SearchAddress(option);
                    break;
                case 3:
                    DisplayCityorState();
                    break;
                case 4:
                    SortContactPerson();
                    break;
                case 5:
                    FileOperations.GetDictionary(numberNames);
                    break;
                case 6:
                    FileOperations.ReadAddressBook();
                    break;
                case 7:
                    CsvOperation.CSVOperation(numberNames, 1);
                    break;
                case 8:
                    CsvOperation.CSVOperation(numberNames, 2);
                    break;

                default:
                    Console.WriteLine("Invalid Option!");
                    break;
            }
        }
        //Display City list or State list from Dictionary
        public static void DisplayCityorState()
        {
            Console.WriteLine("Enter 1-to view City list\n Enter 2-to view State list");
            int citystate = Convert.ToInt32(Console.ReadLine());
            if (citystate == 1)
            {
                foreach (var i in City)
                {
                    Console.WriteLine("Display List for City: {0}\n", i.Key);
                    foreach (var j in i.Value)
                    {
                        Console.WriteLine("Found person \"{0} {1}\" , residing in City {2}", j.firstName, j.lastName, j.city);
                    }
                    //Count number of people in Particular city
                    Console.WriteLine("Count of people in City is: {0}", i.Value.Count);

                }
            }
            else
            {
                foreach (var i in State)
                {
                    Console.WriteLine("Display List for State: {0}\n", i.Key);
                    foreach (var j in i.Value)
                    {
                        Console.WriteLine("Found person \"{0} {1}\" , residing in State {2}", j.firstName, j.lastName, j.state);
                    }
                    //Count number of people in Particular State
                    Console.WriteLine("Count of people in State is: {0}", i.Value.Count);
                }
            }


        }

        //Search a person through different Address Book based on City or State
        public static void SearchAddress(int option)
        {
            string city = "", state = "";
            if (option == 1)
            {
                Console.WriteLine("Enter the City Name");
                city = Console.ReadLine();
            }
            if (option == 2)
            {
                Console.WriteLine("Enter the City Name");
                state = Console.ReadLine();
            }

            //Iterate through all Address Book present in Dictionary
            foreach (KeyValuePair<string, List<AddrBook>> kvp in numberNames)
            {
                if (option == 1)
                {
                    StoreCity(kvp.Key, kvp.Value, city);
                }
                if (option == 2)
                {
                    StoreState(kvp.Key, kvp.Value, state);
                }

            }
        }
        //Display Person names found in given City
        public static void StoreCity(string key, List<AddrBook> ContactArray, string city)
        {
            List<AddrBook> CityList = ContactArray.FindAll(x => x.city.Equals(city)).ToList();
            foreach (var i in CityList)
            {
                Console.WriteLine("Found person \"{0}\" in Address Book \"{1}\" , residing in City {2}", i.firstName, key, i.city);
            }
        }
        //Display Person names found in given State
        public static void StoreState(string key, List<AddrBook> ContactArray, string state)
        {
            List<AddrBook> StateList = ContactArray.FindAll(x => x.state.Equals(state)).ToList();
            foreach (var i in StateList)
            {
                Console.WriteLine("Found person \"{0}\" in Address Book \"{1}\" , residing in State {2}", i.firstName, key, i.state);
            }
        }
    }

}

