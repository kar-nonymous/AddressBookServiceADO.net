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
        /// <summary>
        /// UC 3:
        /// Adds the contact.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public bool AddContact(AddressBookModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("dbo.SpAddContactDetails", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", model.FirstName);
                    command.Parameters.AddWithValue("@LastName", model.LastName);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@City", model.City);
                    command.Parameters.AddWithValue("@State", model.State);
                    command.Parameters.AddWithValue("@Zip", model.Zip);
                    command.Parameters.AddWithValue("@PhoneNo", model.PhoneNo);
                    command.Parameters.AddWithValue("@Email", model.Email);
                    command.Parameters.AddWithValue("@AddressBookName", model.AddressBookName);
                    command.Parameters.AddWithValue("@ContactType", model.ContactType);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// UC 4:
        /// Updates the contact details with name
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateContact()
        {
            try
            {
                using (this.connection)
                {
                    connection.Open();
                    string query = @"update address_book set Zip=281006 where FirstName=Kumar";
                    SqlCommand command = new SqlCommand(query, this.connection);
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
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
        /// <summary>
        /// UC 5:
        /// Delete contact from table with given name
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteContact()
        {
            try
            {
                using (this.connection)
                {
                    connection.Open();
                    string query = @"delete from address_book where FirstName=Steven";
                    SqlCommand command = new SqlCommand(query, this.connection);
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
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
        /// <summary>
        /// UC 6:
        /// Retrieves data from table with given name
        /// </summary>
        public void GetPersonByCityOrState()
        {
            AddressBookModel model = new AddressBookModel();
            try
            {
                using (this.connection)
                {
                    string query = @"select * from address_book where City='Agra' or State='Uttar Pradesh'";
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
