using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;


namespace CoffeeShop
{
    public class DatabaseManager
    {
        public static DatabaseManager Instance { get; private set; }
        
        private readonly string _databasePath;
        private const string UsersTableName = "Users";
        private const string TicketsTableName = "Tickets";
        public enum eUserRole
        {
            ROLE_USER = 1,
            ROLE_ADMIN = 777
        };
        public DatabaseManager(string databasePath)
        {
            _databasePath = databasePath;
            EnsureDatabaseCreated();
            Instance = this;
        }



        private void EnsureDatabaseCreated()
        {
            if (!File.Exists(_databasePath))
            {
                SQLiteConnection.CreateFile(_databasePath);
                CreateTables();
            }
        }

        private void CreateTables()
        {
            using (var connection = new SQLiteConnection($"Data Source={_databasePath};Version=3;"))
            {
                connection.Open();

                // Создание таблицы пользователей
                string createUsersTableSql = $@"
            CREATE TABLE IF NOT EXISTS {UsersTableName} (
                UserID TEXT PRIMARY KEY,
                User TEXT UNIQUE NOT NULL,
                Password TEXT NOT NULL,
                Role INTEGER NOT NULL,
                Points INTEGER NOT NULL
            );";

                // Создание таблицы покупок/чеков
                string createTicketsTableSql = $@"
            CREATE TABLE IF NOT EXISTS {TicketsTableName} (
                TicketID TEXT PRIMARY KEY,
                UserID TEXT NOT NULL,
                Sum REAL NOT NULL,
                Date INTEGER NOT NULL,
                FOREIGN KEY (UserID) REFERENCES {UsersTableName}(UserID)
            );";

                using (var command = new SQLiteCommand(createUsersTableSql, connection))
                {
                    command.ExecuteNonQuery();
                }

                using (var command = new SQLiteCommand(createTicketsTableSql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        //Приведение номера телефона/логина к единому/нормированному формату.
        public string NormalizePhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber)) return null;
            // Удаление лишних символов, таких как пробелы, тире, плюс и скобки
            string cleanedNumber = Regex.Replace(phoneNumber, @"[\s\-\(\)\+]", "");
            // Удаляем +7 или 8 в начале
            if (cleanedNumber.StartsWith("7"))
            {
                cleanedNumber = cleanedNumber.Substring(1);
            }
            else if (cleanedNumber.StartsWith("8"))
            {
                cleanedNumber = cleanedNumber.Substring(1);
            }
            // Проверяем, что осталось 10 цифр
            if (cleanedNumber.Length == 10 && Regex.IsMatch(cleanedNumber, @"^\d{10}$"))
            {
                return cleanedNumber;
            }
            return null;
        }

        //Метод регистрации нового пользователя. Проверяет уникальность User.
        public bool RegisterUser(string phoneNumber, string password, out string userId, eUserRole role = eUserRole.ROLE_USER)
        {
            userId = null;
            string normalizedPhoneNumber = NormalizePhoneNumber(phoneNumber);
            if (normalizedPhoneNumber == null)
            {
                return false; // Некорректный номер телефона
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                return false; // Пароль не должен быть пустым
            }
            userId = Guid.NewGuid().ToString();
            try
            {
                using (var connection = new SQLiteConnection($"Data Source={_databasePath};Version=3;"))
                {
                    connection.Open();
                    // Проверка, существует ли пользователь с таким номером телефона
                    string checkUserSql = $"SELECT COUNT(*) FROM {UsersTableName} WHERE User = @User";
                    using (var checkCommand = new SQLiteCommand(checkUserSql, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@User", normalizedPhoneNumber);
                        int userCount = Convert.ToInt32(checkCommand.ExecuteScalar());
                        if (userCount > 0)
                        {
                            return false; // Пользователь уже существует
                        }
                    }

                    // Вставка нового пользователя
                    string insertUserSql = $"INSERT INTO {UsersTableName} (UserID, User, Password, Role, Points) " +
                                          "VALUES (@UserID, @User, @Password, @Role, @Points)";

                    using (var command = new SQLiteCommand(insertUserSql, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userId);
                        command.Parameters.AddWithValue("@User", normalizedPhoneNumber);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@Role", (int)role);
                        command.Parameters.AddWithValue("@Points", 0);
                        command.ExecuteNonQuery();
                    }

                    return true; // Регистрация прошла успешно
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine($"Ошибка при регистрации пользователя: {ex.Message}");
                return false;
            }
        }
        public bool AuthenticateUser(string phoneNumber, string password, out string userId, out int userRole)
        {
            userId = null;
            userRole = 0;
            string normalizedPhoneNumber = NormalizePhoneNumber(phoneNumber);
            if (normalizedPhoneNumber == null)
            {
                return false;
            }
            try
            {
                using (var connection = new SQLiteConnection($"Data Source={_databasePath};Version=3;"))
                {
                    connection.Open();
                    string selectUserSql = $"SELECT UserID, Role FROM {UsersTableName} WHERE User = @User AND Password = @Password";
                    using (var command = new SQLiteCommand(selectUserSql, connection))
                    {
                        command.Parameters.AddWithValue("@User", normalizedPhoneNumber);
                        command.Parameters.AddWithValue("@Password", password);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                userId = reader["UserID"].ToString();
                                userRole = Convert.ToInt32(reader["Role"]);
                                return true;
                            }
                        }
                    }
                }

                return false;
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine($"Ошибка при авторизации пользователя: {ex.Message}");
                return false;
            }
        }
        public bool AddPoints(string userId, int pointsToAdd)
        {
            if (string.IsNullOrEmpty(userId)) return false;
            try
            {
                using (var connection = new SQLiteConnection($"Data Source={_databasePath};Version=3;"))
                {
                    connection.Open();
                    string updateUserSql = $"UPDATE {UsersTableName} SET Points = Points + @PointsToAdd WHERE UserID = @UserID";
                    using (var command = new SQLiteCommand(updateUserSql, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userId);
                        command.Parameters.AddWithValue("@PointsToAdd", pointsToAdd);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine($"Ошибка при добавлении баллов: {ex.Message}");
                return false;
            }
        }
        public bool CreateTicket(string userId, double sum)
        {
            if (string.IsNullOrEmpty(userId) || sum <= 0) return false;

            try
            {
                using (var connection = new SQLiteConnection($"Data Source={_databasePath};Version=3;"))
                {
                    connection.Open();
                    string insertTicketSql = $"INSERT INTO {TicketsTableName} (TicketID, UserID, Sum, Date) " +
                                             "VALUES (@TicketID, @UserID, @Sum, @Date)";
                    using (var command = new SQLiteCommand(insertTicketSql, connection))
                    {
                        command.Parameters.AddWithValue("@TicketID", Guid.NewGuid().ToString());
                        command.Parameters.AddWithValue("@UserID", userId);
                        command.Parameters.AddWithValue("@Sum", sum);
                        command.Parameters.AddWithValue("@Date", DateTimeOffset.Now.ToUnixTimeSeconds());
                        command.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine($"Ошибка при создании чека: {ex.Message}");
                return false;
            }
        }
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            try
            {
                using (var connection = new SQLiteConnection($"Data Source={_databasePath};Version=3;"))
                {
                    connection.Open();
                    string selectUsersSql = $"SELECT UserID, User, Password, Role, Points FROM {UsersTableName}";
                    using (var command = new SQLiteCommand(selectUsersSql, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                users.Add(new User
                                {
                                    UserId = reader["UserID"].ToString(),
                                    PhoneNumber = reader["User"].ToString(),
                                    Password = reader["Password"].ToString(),
                                    Role = Convert.ToInt32(reader["Role"]),
                                    Points = Convert.ToInt32(reader["Points"])
                                });
                            }
                        }
                    }
                }
                return users;
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine($"Ошибка при получении списка пользователей: {ex.Message}");
                return null;
            }
        }
        public User GetUserById(string userId)
        {
            if (string.IsNullOrEmpty(userId)) return null;

            try
            {
                using (var connection = new SQLiteConnection($"Data Source={_databasePath};Version=3;"))
                {
                    connection.Open();
                    string selectUserSql = $"SELECT UserID, User, Password, Role, Points FROM {UsersTableName} WHERE UserID = @UserID";
                    using (var command = new SQLiteCommand(selectUserSql, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userId);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new User
                                {
                                    UserId = reader["UserID"].ToString(),
                                    PhoneNumber = reader["User"].ToString(),
                                    Password = reader["Password"].ToString(),
                                    Role = Convert.ToInt32(reader["Role"]),
                                    Points = Convert.ToInt32(reader["Points"])
                                };
                            }
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine($"Ошибка при получении пользователя по ID: {ex.Message}");
            }
            return null;
        }
        
        public User GetUserByPhone(string userPhone)
        {
            if (string.IsNullOrEmpty(userPhone)) return null;

            string normalizedPhoneNumber = NormalizePhoneNumber(userPhone);
            try
            {
                using (var connection = new SQLiteConnection($"Data Source={_databasePath};Version=3;"))
                {
                    connection.Open();
                    string selectUserSql = $"SELECT UserID, User, Password, Role, Points FROM {UsersTableName} WHERE User = @UserPhone";
                    using (var command = new SQLiteCommand(selectUserSql, connection))
                    {
                        command.Parameters.AddWithValue("@UserPhone", normalizedPhoneNumber);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new User
                                {
                                    UserId = reader["UserID"].ToString(),
                                    PhoneNumber = reader["User"].ToString(),
                                    Password = reader["Password"].ToString(),
                                    Role = Convert.ToInt32(reader["Role"]),
                                    Points = Convert.ToInt32(reader["Points"])
                                };
                            }
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine($"Ошибка при получении пользователя по номеру телефона: {ex.Message}");
            }
            return null;
        }
        public List<Ticket> GetUserTickets(string userId)
        {
            List<Ticket> tickets = new List<Ticket>();
            if (string.IsNullOrEmpty(userId)) return tickets;
            try
            {
                using (var connection = new SQLiteConnection($"Data Source={_databasePath};Version=3;"))
                {
                    connection.Open();
                    string selectTicketsSql = $"SELECT TicketID, Sum, Date FROM {TicketsTableName} WHERE UserID = @UserID";
                    using (var command = new SQLiteCommand(selectTicketsSql, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userId);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tickets.Add(new Ticket
                                {
                                    TicketId = reader["TicketID"].ToString(),
                                    Sum = Convert.ToDouble(reader["Sum"]),
                                    Date = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(reader["Date"])).DateTime
                                });
                            }
                        }
                    }
                }
                return tickets;
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine($"Ошибка при получении списка чеков пользователя: {ex.Message}");
                return null;
            }
        }

        public List<Ticket> GetAllTickets()
        {
            List<Ticket> tickets = new List<Ticket>();
            try
            {
                using (var connection = new SQLiteConnection($"Data Source={_databasePath};Version=3;"))
                {
                    connection.Open();
                    string selectTicketsSql = $"SELECT TicketID, Sum, Date, UserID FROM {TicketsTableName}";
                    using (var command = new SQLiteCommand(selectTicketsSql, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tickets.Add(new Ticket
                                {
                                    TicketId = reader["TicketID"].ToString(),
                                    Sum = Convert.ToDouble(reader["Sum"]),
                                    Date = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(reader["Date"])).DateTime,
                                    UserId = reader["UserID"].ToString()
                                });
                            }
                        }
                    }
                }
                return tickets;
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine($"Ошибка при получении списка всех чеков: {ex.Message}");
                return null;
            }
        }
#if DEBUG
        public void PrintShortData()
        {
            try
            {
                using (var connection = new SQLiteConnection($"Data Source={_databasePath};Version=3;"))
                {
                    connection.Open();

                    // 1. Общее количество пользователей
                    string countUsersSql = $"SELECT COUNT(*) FROM {UsersTableName}";
                    using (var command = new SQLiteCommand(countUsersSql, connection))
                    {
                        int userCount = Convert.ToInt32(command.ExecuteScalar());
                        Console.WriteLine($"Общее количество пользователей: {userCount}");
                    }

                    // 2. Общее количество чеков
                    string countTicketsSql = $"SELECT COUNT(*) FROM {TicketsTableName}";
                    using (var command = new SQLiteCommand(countTicketsSql, connection))
                    {
                        int ticketCount = Convert.ToInt32(command.ExecuteScalar());
                        Console.WriteLine($"Общее количество чеков: {ticketCount}");
                    }

                    // 3. Информация о пользователях с ролью администратора (777)
                    string adminUsersSql = $"SELECT UserID, User FROM {UsersTableName} WHERE Role = 777";
                    using (var command = new SQLiteCommand(adminUsersSql, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            Console.WriteLine("Администраторы:");
                            while (reader.Read())
                            {
                                Console.WriteLine($"  UserID: {reader["UserID"]}, Phone: {reader["User"]}");
                            }
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine($"Ошибка при выводе краткой сводки: {ex.Message}");
            }
        }
    }
#endif
    public class User
    {
        public string UserId { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public int Points { get; set; }
    }

    public class Ticket
    {
        public string TicketId { get; set; }
        public string UserId { get; set; }
        public double Sum { get; set; }
        public DateTime Date { get; set; }
    }
}