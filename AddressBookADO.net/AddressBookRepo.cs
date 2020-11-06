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
    }
}
