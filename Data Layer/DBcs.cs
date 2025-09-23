using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Phumla_Kamnandi.Data_Layer
{
    public class DB
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=PhumlaKamnandiDB;Integrated Security=True";

        public DB()
        {
            CreateTables(); 
        }

        #region CREATE DATABASE TABLES
        public void CreateTables()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string createTablesSQL = @"
                        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Guests' AND xtype='U')
                        BEGIN
                            CREATE TABLE Guests (
                                GuestID INT PRIMARY KEY IDENTITY(1,1),
                                FirstName VARCHAR(50) NOT NULL,
                                LastName VARCHAR(50) NOT NULL,
                                Email VARCHAR(100),
                                PhoneNumber VARCHAR(20),
                                Address VARCHAR(255),
                                City VARCHAR(50),
                                PostalCode VARCHAR(10),
                                DateCreated DATETIME DEFAULT GETDATE()
                            );
                        END

                        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Rooms' AND xtype='U')
                        BEGIN
                            CREATE TABLE Rooms (
                                RoomID INT PRIMARY KEY IDENTITY(1,1),
                                RoomNumber VARCHAR(10) NOT NULL,
                                RoomType VARCHAR(20) DEFAULT 'Standard',
                                MaxOccupancy INT DEFAULT 4,
                                Status VARCHAR(20) DEFAULT 'Available',
                                BaseRate DECIMAL(10,2) DEFAULT 0
                            );
                        END

                        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Reservations' AND xtype='U')
                        BEGIN
                            CREATE TABLE Reservations (
                                ReservationID INT PRIMARY KEY IDENTITY(1,1),
                                GuestID INT NOT NULL,
                                RoomID INT NOT NULL,
                                CheckInDate DATE NOT NULL,
                                CheckOutDate DATE NOT NULL,
                                NumberOfAdults INT DEFAULT 1,
                                NumberOfChildren INT DEFAULT 0,
                                TotalAmount DECIMAL(10,2),
                                DepositAmount DECIMAL(10,2),
                                DepositPaid BIT DEFAULT 0,
                                Status VARCHAR(20) DEFAULT 'Pending',
                                BookingReference VARCHAR(20) UNIQUE,
                                DateCreated DATETIME DEFAULT GETDATE()
                            );
                        END";

                    #endregion 

                    using (var command = new SqlCommand(createTablesSQL, connection))
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Tables created successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating tables: " + ex.Message);
            }
        }

        public void TestConnection()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    MessageBox.Show("Database connected successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}