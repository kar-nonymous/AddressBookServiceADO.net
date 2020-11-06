// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddressBookRepo.cs" company="Capgemini">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kumar Kartikeya"/>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace AddressBookADO.net
{
    class AddressBookRepo
    {
        /// <summary>
        /// UC 1:
        /// The connection string which creates the connection between our code and the databse
        /// </summary>
        public static string connectionString = "Data Source=KARTIKEYA;Initial Catalog=addressBookService;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection connection = new SqlConnection(connectionString);
        /// <summary>
        /// UC 2:
        /// Gets all the Entries from the database.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void GetAllEntries()
        {
            AddressBookModel model = new AddressBookModel();
            try
            {
                using (this.connection)
                {
                    string query = @"select * from address_book";
                    SqlCommand command = new SqlCommand(query, this.connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model.FirstName = reader.GetString(0);
                            model.LastName = reader.GetString(1);
                            model.Address = reader.GetString(2);
                            model.City = reader.GetString(3);
                            model.State = reader.GetString(4);
                            model.Zip = reader.GetInt32(5);
                            model.PhoneNo = reader.GetInt64(6);
                            model.Email = reader.GetString(7);
                            model.AddressBookName = reader.GetString(8);
                            model.ContactType = reader.GetString(9);
                            Console.WriteLine("{0} {1}", model.FirstName, model.LastName);
                        }
                    }
                    else
                        Console.WriteLine("No data found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
