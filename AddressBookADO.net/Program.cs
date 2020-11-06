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
            AddressBookModel model = new AddressBookModel();
            model.FirstName = "Shashank";
            model.LastName = "Singh";
            model.Address = "Techman City";
            model.City = "Mathura";
            model.State = "Uttar Pradesh";
            model.Zip = 281006;
            model.PhoneNo = 8265800789;
            model.Email = "shashank.singh@gmail.com";
            model.AddressBookName = "Kartikeya";
            model.ContactType = "Friends";
            Console.WriteLine(addressBookRepo.AddContact(model) ? "Record inserted successfully " : "Failed");
            /// Calling the update contact method
            addressBookRepo.UpdateContact();
            /// Calling the DeleteContact method
            addressBookRepo.DeleteContact();
        }
    }
}
