// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Capgemini">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kumar Kartikeya"/>
// --------------------------------------------------------------------------------------------------------------------
using System;

namespace AddressBookADO.net
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to address book problem ADO.net");
            /// Creating an object of AddressBookRepo class
            AddressBookRepo addressBookRepo = new AddressBookRepo();
            /// Calling the GetAllEntries method from AddressBookRepo class
            addressBookRepo.GetAllEntries();
            AddressBookModel model = new AddressBookModel
            {
                FirstName = "Shashank",
                LastName = "Singh",
                Address = "Techman City",
                City = "Mathura",
                State = "Uttar Pradesh",
                Zip = 281006,
                PhoneNo = 8265800789,
                Email = "shashank.singh@gmail.com",
                AddressBookName = "Kartikeya",
                ContactType = "Friends"
            };
            Console.WriteLine(addressBookRepo.AddContact(model) ? "Record inserted successfully " : "Failed");
            /// Calling the update contact method
            addressBookRepo.UpdateContact();
            /// Calling the DeleteContact method
            addressBookRepo.DeleteContact();
            /// Calling the GetPersonByCityOrState method
            addressBookRepo.GetPersonByCityOrState();
            ///Calling the GetSizeByCity method
            addressBookRepo.GetSizeByCity();
            ///Calling the GetSizeByState method
            addressBookRepo.GetSizeByState();
        }
    }
}
