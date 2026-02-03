using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PP
{
    public class DatabaseHelper
    {
        private string connectionString = "Data Source=my_database.db;Version=3;";
        private string dbFileName = "my_database.db";

        public DatabaseHelper()
        {
            InitializeDatabase();
        }

        private string HashPassword(string password)
        {
            using (var sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password ?? "");
                var hash = sha.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
        }

        private void InitializeDatabase()
        {
            bool isNewDatabase = !File.Exists(dbFileName);

            if (isNewDatabase)
            {
                SQLiteConnection.CreateFile(dbFileName);
            }

            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                con.Open();

                string createTablesQuery = @"
                CREATE TABLE IF NOT EXISTS Abonements (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL UNIQUE, 
                    Price REAL NOT NULL,
                    DurationDays INTEGER,
                    VisitsCount INTEGER
                );

                CREATE TABLE IF NOT EXISTS Users (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT NOT NULL UNIQUE,
                    PasswordHash TEXT NOT NULL,
                    Role TEXT NOT NULL
                );

                CREATE TABLE IF NOT EXISTS Clients (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    FullName TEXT NOT NULL UNIQUE,
                    Phone TEXT,
                    DateOfBirth TEXT
                );

                CREATE TABLE IF NOT EXISTS Coaches (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    FullName TEXT NOT NULL UNIQUE,
                    Phone TEXT,
                    Specialization TEXT,
                    DateOfBirth TEXT,
                    ExperienceYears INTEGER DEFAULT 0
                );

                CREATE TABLE IF NOT EXISTS ClientSubscriptions (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    ClientId INTEGER NOT NULL,
                    AbonementId INTEGER NOT NULL,
                    PurchaseDate TEXT NOT NULL,
                    ExpiryDate TEXT NOT NULL,
                    RemainingVisits INTEGER NOT NULL,
                    IsActive INTEGER NOT NULL DEFAULT 1,
                    FOREIGN KEY (ClientId) REFERENCES Clients(Id),
                    FOREIGN KEY (AbonementId) REFERENCES Abonements(Id)
                );

                CREATE TABLE IF NOT EXISTS Schedule (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    ClientId INTEGER NOT NULL,
                    CoachId INTEGER NOT NULL,
                    AbonementId INTEGER,
                    ScheduleDate TEXT NOT NULL,
                    StartTime TEXT NOT NULL,
                    EndTime TEXT NOT NULL,
                    PoolArea TEXT NOT NULL,
                    Status TEXT DEFAULT 'Запланировано',
                    FOREIGN KEY (ClientId) REFERENCES Clients(Id),
                    FOREIGN KEY (CoachId) REFERENCES Coaches(Id),
                    FOREIGN KEY (AbonementId) REFERENCES ClientSubscriptions(Id)
                );";

                using (SQLiteCommand cmd = new SQLiteCommand(createTablesQuery, con))
                {
                    cmd.ExecuteNonQuery();
                }

                // ЗАПОЛНЯЕМ ТОЛЬКО ЕСЛИ ФАЙЛА НЕ БЫЛО
                if (isNewDatabase)
                {
                    SeedInitialData(con);
                }
            }
        }

        private void SeedInitialData(SQLiteConnection con)
        {
            // 1. Пользователи
            string insertUser = "INSERT OR IGNORE INTO Users (Username, PasswordHash, Role) VALUES (@u, @p, @r)";
            using (SQLiteCommand cmd = new SQLiteCommand(insertUser, con))
            {
                string[,] users = {
                    { "admin", HashPassword("admin"), "Admin" },
                    { "Klukina", HashPassword("123"), "Coach" },
                    { "Druzinina", HashPassword("123"), "Coach" },
                    { "Cvetkov", HashPassword("123"), "Coach" },
                    { "Shevelev", HashPassword("123"), "Coach" },
                    { "Kozlova", HashPassword("123"), "Coach" }
                };

                for (int i = 0; i < users.GetLength(0); i++)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@u", users[i, 0]);
                    cmd.Parameters.AddWithValue("@p", users[i, 1]);
                    cmd.Parameters.AddWithValue("@r", users[i, 2]);
                    cmd.ExecuteNonQuery();
                }
            }

            // 2. Остальные данные
            string seedData = @"
            INSERT OR IGNORE INTO Abonements (Id, Name, Price, DurationDays, VisitsCount) VALUES 
            (1, 'Безлимит (месяц)', 4000.0, 30, 999),
            (2, 'Безлимит (полгода)', 20000.0, 180, 999),
            (3, 'Груднички (12 занятий)', 5500.0, 45, 12),
            (4, 'Детский (8 занятий)', 3500.0, 30, 8),
            (5, 'Стандарт (12 занятий)', 4500.0, 30, 12),
            (6, 'Стандарт (8 занятий)', 3200.0, 30, 8);

            INSERT OR IGNORE INTO Coaches (Id, FullName, Phone, Specialization, DateOfBirth, ExperienceYears) VALUES 
            (1, 'Дружинина Надежда Викторовна', '+7(963)099-94-48', 'Любительское плавание', '1965-09-29', 10),
            (2, 'Клюкина Яна Сергеевна', '+7(912)111-22-33', 'Грудничковое плавание', '1990-05-15', 7),
            (3, 'Козлова Елена Васильевна', '+7(912)444-55-66', 'Синхронное плавание', '1985-03-10', 12),
            (4, 'Сидоров Петр Алексеевич', '+7(912)777-88-99', 'Спортивное плавание', '1982-11-20', 15),
            (5, 'Цветков Михаил Геннадьевич', '+7(912)000-11-22', 'Терапевтическое плавание', '1978-07-04', 20),
            (6, 'Шевелев Антон Викторович', '+7(912)333-44-55', 'Детское плавание', '1995-12-12', 4);

            INSERT OR IGNORE INTO Clients (Id, FullName, Phone, DateOfBirth) VALUES 
            (1, 'Воробьёв Данила Витальевич', '+7(987)463-59-20', '2020-02-29'),
            (2, 'Дейцева Валентина Сергеевна', '+7(900)100-20-30', '1995-06-15'),
            (3, 'Иванов Иван Иванович', '+7(900)300-40-50', '1988-01-10'),
            (4, 'Лапина Мария Александровна', '+7(900)500-60-70', '1992-03-25'),
            (5, 'Петрова Анна Сергеевна', '+7(900)700-80-90', '2001-09-12'),
            (6, 'Степанов Дмитрий Сергеевич', '+7(900)900-00-11', '1985-11-30');

            INSERT OR IGNORE INTO ClientSubscriptions (Id, ClientId, AbonementId, PurchaseDate, ExpiryDate, RemainingVisits, IsActive) VALUES 
            (1, 1, 3, '2026-01-01', '2026-02-15', 10, 1),
            (2, 2, 1, '2026-01-05', '2026-02-05', 999, 1),
            (3, 3, 5, '2026-01-10', '2026-02-10', 12, 1),
            (4, 4, 2, '2026-01-01', '2026-07-01', 999, 1),
            (5, 5, 4, '2026-01-05', '2026-02-05', 8, 1),
            (6, 6, 6, '2026-01-15', '2026-02-15', 8, 1);
            
            INSERT OR IGNORE INTO Schedule (ClientId, CoachId, AbonementId, ScheduleDate, StartTime, EndTime, PoolArea, Status) VALUES 
            (1, 2, 1, '2026-01-10', '10:00', '10:45', 'грудничковая зона', 'Проведено'),
            (1, 2, 1, '2026-01-13', '10:00', '10:45', 'грудничковая зона', 'Проведено'),
            (2, 1, 2, '2026-01-12', '18:00', '19:00', '1 зона', 'Проведено'),
            (3, 4, 3, '2026-01-12', '19:00', '20:00', '2 зона', 'Запланировано'),
            (4, 3, 4, '2026-01-15', '14:00', '15:00', 'VIP зона', 'Проведено'),
            (2, 1, 2, '2026-01-20', '18:00', '19:00', '1 зона', 'Проведено'),
            (5, 6, 5, '2026-01-22', '11:00', '12:00', 'детская зона', 'Запланировано'),
            (1, 2, 1, '2026-01-25', '10:00', '10:45', 'грудничковая зона', 'Проведено'),
            (6, 5, 6, '2026-01-28', '15:00', '16:00', '3 зона', 'Запланировано');";

            using (SQLiteCommand cmd = new SQLiteCommand(seedData, con))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public string GetUserRole(string login, string password)
        {
            string hashedPassword = HashPassword(password);
            string query = "SELECT Role FROM Users WHERE Username = @login AND PasswordHash = @passwordHash";

            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@passwordHash", hashedPassword);
                con.Open();
                object result = cmd.ExecuteScalar();
                return result?.ToString();
            }
        }


        // --- МЕТОДЫ ДЛЯ АБОНЕМЕНТОВ (ШАБЛОНОВ) ---
        public DataTable GetAbonements(string searchName = "")
        {
            DataTable dt = new DataTable();
            string query = "SELECT Id, Name, Price, DurationDays, VisitsCount FROM Abonements";
            if (!string.IsNullOrWhiteSpace(searchName))
            {
                query += " WHERE Name LIKE @search";
            }
            query += " ORDER BY Name";
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
            {
                if (!string.IsNullOrWhiteSpace(searchName))
                    cmd.Parameters.AddWithValue("@search", "%" + searchName + "%");
                con.Open(); dt.Load(cmd.ExecuteReader());
            }
            return dt;
        }

        public DataRow GetAbonementById(int id)
        {
            DataTable dt = new DataTable();
            string query = "SELECT Id, Name, Price, DurationDays, VisitsCount FROM Abonements WHERE Id = @id";
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                con.Open(); dt.Load(cmd.ExecuteReader());
                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }

        public int AddAbonement(string name, decimal price, int durationDays, int visitsCount)
        {
            string query = "INSERT INTO Abonements (Name, Price, DurationDays, VisitsCount) VALUES (@name, @price, @durationDays, @visitsCount)";
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@durationDays", durationDays);
                cmd.Parameters.AddWithValue("@visitsCount", visitsCount);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int UpdateAbonement(int id, string name, decimal price, int durationDays, int visitsCount)
        {
            string query = "UPDATE Abonements SET Name = @name, Price = @price, DurationDays = @durationDays, VisitsCount = @visitsCount WHERE Id = @id";
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@durationDays", durationDays);
                cmd.Parameters.AddWithValue("@visitsCount", visitsCount);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int DeleteAbonement(int id)
        {
            string query = "DELETE FROM Abonements WHERE Id = @id";
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // --- МЕТОДЫ ДЛЯ КЛИЕНТОВ ---
        public DataTable GetClients(string searchFullName = "", string searchPhone = "")
        {
            DataTable dt = new DataTable();
            string query = "SELECT Id, FullName, Phone, DateOfBirth FROM Clients WHERE 1=1";

            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            using (SQLiteCommand cmd = new SQLiteCommand())
            {
                if (!string.IsNullOrWhiteSpace(searchFullName))
                {
                    query += " AND FullName LIKE @name";
                    cmd.Parameters.AddWithValue("@name", "%" + searchFullName + "%");
                }
                if (!string.IsNullOrWhiteSpace(searchPhone))
                {
                    query += " AND Phone LIKE @phone";
                    cmd.Parameters.AddWithValue("@phone", "%" + searchPhone + "%");
                }
                query += " ORDER BY FullName";

                cmd.CommandText = query;
                cmd.Connection = con;
                con.Open(); dt.Load(cmd.ExecuteReader());
            }
            return dt;
        }

        public DataRow GetClientById(int id)
        {
            DataTable dt = new DataTable();
            string query = "SELECT Id, FullName, Phone, DateOfBirth FROM Clients WHERE Id = @id";
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                con.Open(); dt.Load(cmd.ExecuteReader());
                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }

        public int AddClient(string fullName, string phone, string dateOfBirth)
        {
            string query = "INSERT INTO Clients (FullName, Phone, DateOfBirth) VALUES (@fullName, @phone, @dateOfBirth)";
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@fullName", fullName);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int UpdateClient(int id, string fullName, string phone, string dateOfBirth)
        {
            string query = "UPDATE Clients SET FullName = @fullName, Phone = @phone, DateOfBirth = @dateOfBirth WHERE Id = @id";
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@fullName", fullName);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int DeleteClient(int id)
        {
            string query = "DELETE FROM Clients WHERE Id = @id";
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // --- МЕТОДЫ ДЛЯ ТРЕНЕРОВ ---
        public DataTable GetCoaches(string searchFullName = "", string searchPhone = "")
        {
            DataTable dt = new DataTable();
            // Оставляем только 2 параметра поиска, как ты просил
            string query = "SELECT Id, FullName, Phone, Specialization, DateOfBirth, ExperienceYears FROM Coaches WHERE 1=1";

            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            using (SQLiteCommand cmd = new SQLiteCommand())
            {
                if (!string.IsNullOrWhiteSpace(searchFullName))
                {
                    query += " AND FullName LIKE @name";
                    cmd.Parameters.AddWithValue("@name", "%" + searchFullName + "%");
                }
                if (!string.IsNullOrWhiteSpace(searchPhone))
                {
                    query += " AND Phone LIKE @phone";
                    cmd.Parameters.AddWithValue("@phone", "%" + searchPhone + "%");
                }
                query += " ORDER BY FullName";

                cmd.Connection = con;
                cmd.CommandText = query;
                con.Open();
                dt.Load(cmd.ExecuteReader());
            }
            return dt;
        }


        public DataRow GetCoachById(int id)
        {
            DataTable dt = new DataTable();
            string query = "SELECT Id, FullName, Phone, Specialization, DateOfBirth, ExperienceYears FROM Coaches WHERE Id = @id";
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                con.Open(); dt.Load(cmd.ExecuteReader());
                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }

        public int AddCoach(string fullName, string phone, string specialization, string dateOfBirth, int experienceYears)
        {
            string query = "INSERT INTO Coaches (FullName, Phone, Specialization, DateOfBirth, ExperienceYears) VALUES (@fullName, @phone, @specialization, @dateOfBirth, @experienceYears)";
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@fullName", fullName);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@specialization", specialization);
                cmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
                cmd.Parameters.AddWithValue("@experienceYears", experienceYears);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int UpdateCoach(int id, string fullName, string phone, string specialization, string dateOfBirth, int experienceYears)
        {
            string query = "UPDATE Coaches SET FullName = @fullName, Phone = @phone, Specialization = @specialization, DateOfBirth = @dateOfBirth, ExperienceYears = @experienceYears WHERE Id = @id";
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@fullName", fullName);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@specialization", specialization);
                cmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
                cmd.Parameters.AddWithValue("@experienceYears", experienceYears);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int DeleteCoach(int id)
        {
            string query = "DELETE FROM Coaches WHERE Id = @id";
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // --- МЕТОДЫ ДЛЯ РАСПИСАНИЯ ---
        public DataTable GetSchedule(string date = null)
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT s.Id, s.ClientId, s.CoachId, s.AbonementId,
                       c.FullName AS ClientName, co.FullName AS CoachName, 
                       cs.Id AS ClientSubscriptionId, a.Name AS AbonementName,
                       s.ScheduleDate, s.StartTime, s.EndTime, s.PoolArea, s.Status
                FROM Schedule s
                JOIN Clients c ON s.ClientId = c.Id
                JOIN Coaches co ON s.CoachId = co.Id
                LEFT JOIN ClientSubscriptions cs ON s.AbonementId = cs.Id 
                LEFT JOIN Abonements a ON cs.AbonementId = a.Id";

            if (date != null) query += " WHERE s.ScheduleDate = @date";
            query += " ORDER BY s.ScheduleDate, s.StartTime";

            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
            {
                if (date != null) cmd.Parameters.AddWithValue("@date", date);
                con.Open();
                dt.Load(cmd.ExecuteReader());
            }
            return dt;
        }

        public DataTable GetCoachSchedule(int coachId, string date = null)
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT s.Id, s.ClientId, s.CoachId, s.AbonementId,
                       c.FullName AS ClientName, co.FullName AS CoachName, 
                       cs.Id AS ClientSubscriptionId, a.Name AS AbonementName,
                       s.ScheduleDate, s.StartTime, s.EndTime, s.PoolArea, s.Status
                FROM Schedule s
                JOIN Clients c ON s.ClientId = c.Id
                JOIN Coaches co ON s.CoachId = co.Id
                LEFT JOIN ClientSubscriptions cs ON s.AbonementId = cs.Id 
                LEFT JOIN Abonements a ON cs.AbonementId = a.Id 
                WHERE s.CoachId = @coachId";
            if (date != null)
            {
                query += " AND s.ScheduleDate = @date";
            }
            query += " ORDER BY s.ScheduleDate, s.StartTime";

            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@coachId", coachId);
                if (date != null)
                {
                    cmd.Parameters.AddWithValue("@date", date);
                }

                con.Open();
                dt.Load(cmd.ExecuteReader()); // Возвращаем все необходимые колонки
            }
            return dt;
        }


        public DataRow GetScheduleEntryById(int id)
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT s.Id, s.ClientId, s.CoachId, s.AbonementId, 
                       s.ScheduleDate, s.StartTime, s.EndTime, s.PoolArea, s.Status
                FROM Schedule s
                WHERE s.Id = @id";
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                con.Open(); dt.Load(cmd.ExecuteReader());
                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }

        public int AddScheduleEntry(int clientId, int coachId, int? clientSubscriptionId, string scheduleDate, string startTime, string endTime, string poolArea, string status)
        {
            string query = "INSERT INTO Schedule (ClientId, CoachId, AbonementId, ScheduleDate, StartTime, EndTime, PoolArea, Status) VALUES (@clientId, @coachId, @clientSubscriptionId, @scheduleDate, @startTime, @endTime, @poolArea, @status)";
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@clientId", clientId);
                cmd.Parameters.AddWithValue("@coachId", coachId);
                cmd.Parameters.AddWithValue("@clientSubscriptionId", clientSubscriptionId.HasValue ? (object)clientSubscriptionId.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@scheduleDate", scheduleDate);
                cmd.Parameters.AddWithValue("@startTime", startTime);
                cmd.Parameters.AddWithValue("@endTime", endTime);
                cmd.Parameters.AddWithValue("@poolArea", poolArea);
                cmd.Parameters.AddWithValue("@status", status);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int UpdateScheduleEntry(int id, int clientId, int coachId, int? clientSubscriptionId, string scheduleDate, string startTime, string endTime, string poolArea, string status)
        {
            string query = "UPDATE Schedule SET ClientId = @clientId, CoachId = @coachId, AbonementId = @clientSubscriptionId, ScheduleDate = @scheduleDate, StartTime = @startTime, EndTime = @endTime, PoolArea = @poolArea, Status = @status WHERE Id = @id";
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@clientId", clientId);
                cmd.Parameters.AddWithValue("@coachId", coachId);
                cmd.Parameters.AddWithValue("@clientSubscriptionId", clientSubscriptionId.HasValue ? (object)clientSubscriptionId.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@scheduleDate", scheduleDate);
                cmd.Parameters.AddWithValue("@startTime", startTime);
                cmd.Parameters.AddWithValue("@endTime", endTime);
                cmd.Parameters.AddWithValue("@poolArea", poolArea);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int DeleteScheduleEntry(int id)
        {
            string query = "DELETE FROM Schedule WHERE Id = @id";
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public bool CheckForOverlap(int scheduleId, int coachId, string poolArea, string date, string startTime, string endTime)
        {
            // Этот метод теперь точно принимает 6 аргументов в нужном порядке
            string query = @"
        SELECT COUNT(*) FROM Schedule 
        WHERE ScheduleDate = @date 
          AND Status != 'Отменено' 
          AND Id != @scheduleId
          AND (
                (CoachId = @coachId AND (StartTime < @endTime AND EndTime > @startTime)) 
                OR 
                (PoolArea = @poolArea AND (StartTime < @endTime AND EndTime > @startTime))
              )";
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@scheduleId", scheduleId);
                cmd.Parameters.AddWithValue("@coachId", coachId);
                cmd.Parameters.AddWithValue("@poolArea", poolArea);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@startTime", startTime);
                cmd.Parameters.AddWithValue("@endTime", endTime);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }


        public DataTable GetCurrentPoolSessions(string filterPoolArea = "")
        {
            DataTable dt = new DataTable();
            // Используем C# для получения даты и времени, чтобы не было проблем с часовыми поясами БД
            string today = DateTime.Now.ToString("yyyy-MM-dd");
            string now = DateTime.Now.ToString("HH:mm");

            string query = @"
        SELECT s.Id, c.FullName AS ClientName, co.FullName AS CoachName, 
               s.StartTime, s.EndTime, s.PoolArea
        FROM Schedule s
        JOIN Clients c ON s.ClientId = c.Id
        JOIN Coaches co ON s.CoachId = co.Id
        WHERE s.ScheduleDate = @today 
          AND s.Status != 'Отменено' 
          AND @now >= s.StartTime AND @now <= s.EndTime"; // Показываем всё, что идет прямо сейчас

            if (!string.IsNullOrEmpty(filterPoolArea) && filterPoolArea != "Все зоны")
            {
                query += " AND s.PoolArea = @filterPoolArea";
            }
            query += " ORDER BY s.StartTime";

            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@today", today);
                cmd.Parameters.AddWithValue("@now", now);
                if (!string.IsNullOrEmpty(filterPoolArea) && filterPoolArea != "Все зоны")
                    cmd.Parameters.AddWithValue("@filterPoolArea", filterPoolArea);

                con.Open();
                dt.Load(cmd.ExecuteReader());
            }
            return dt;
        }

        // --- МЕТОДЫ ДЛЯ СТАТИСТИКИ ---

        // Общее количество клиентов
        public int GetTotalClients()
        {
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                con.Open();
                return Convert.ToInt32(new SQLiteCommand("SELECT COUNT(*) FROM Clients", con).ExecuteScalar());
            }
        }

        // Количество новых клиентов за период (на основе DateOfBirth)
        public int GetNewClientsCount(DateTime startDate, DateTime endDate)
        {
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                con.Open();
                var cmd = new SQLiteCommand("SELECT COUNT(*) FROM Clients WHERE DateOfBirth BETWEEN @startDate AND @endDate", con);
                cmd.Parameters.AddWithValue("@startDate", startDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@endDate", endDate.ToString("yyyy-MM-dd"));
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Количество проведенных занятий за период
        public int GetConductedSessionsCount(DateTime startDate, DateTime endDate)
        {
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                con.Open();
                var cmd = new SQLiteCommand("SELECT COUNT(*) FROM Schedule WHERE Status = 'Проведено' AND ScheduleDate BETWEEN @startDate AND @endDate", con);
                cmd.Parameters.AddWithValue("@startDate", startDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@endDate", endDate.ToString("yyyy-MM-dd"));
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Среднее количество занятий в день за период
        public double GetAvgSessionsPerDay(DateTime startDate, DateTime endDate)
        {
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                con.Open();
                var cmd = new SQLiteCommand("SELECT COUNT(*) FROM Schedule WHERE Status = 'Проведено' AND ScheduleDate BETWEEN @startDate AND @endDate", con);
                cmd.Parameters.AddWithValue("@startDate", startDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@endDate", endDate.ToString("yyyy-MM-dd"));
                int totalSessions = Convert.ToInt32(cmd.ExecuteScalar());

                TimeSpan duration = endDate - startDate;
                int totalDays = (int)Math.Floor(duration.TotalDays) + 1; // Включаем конечную дату

                if (totalDays > 0) return (double)totalSessions / totalDays;
                return 0.0;
            }
        }

        // Количество записей на сегодня (запланированных, не отмененных)
        public int GetTodaySessionsCount()
        {
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                con.Open();
                var cmd = new SQLiteCommand("SELECT COUNT(*) FROM Schedule WHERE ScheduleDate = @today AND Status != 'Отменено'", con);
                cmd.Parameters.AddWithValue("@today", DateTime.Today.ToString("yyyy-MM-dd"));
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Количество записей на завтра (запланированных, не отмененных)
        public int GetTomorrowSessionsCount()
        {
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                con.Open();
                var cmd = new SQLiteCommand("SELECT COUNT(*) FROM Schedule WHERE ScheduleDate = @tomorrow AND Status != 'Отменено'", con);
                cmd.Parameters.AddWithValue("@tomorrow", DateTime.Today.AddDays(1).ToString("yyyy-MM-dd"));
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Расчетный доход за период (исходя из цен абонементов на проведенные занятия)
        public decimal GetApproximateIncome(DateTime startDate, DateTime endDate)
        {
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                con.Open();
                var cmd = new SQLiteCommand(@"SELECT SUM(a.Price) FROM Schedule s 
                    JOIN ClientSubscriptions cs ON s.AbonementId = cs.Id 
                    JOIN Abonements a ON cs.AbonementId = a.Id 
                    WHERE s.Status = 'Проведено' AND s.ScheduleDate BETWEEN @startDate AND @endDate", con);
                cmd.Parameters.AddWithValue("@startDate", startDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@endDate", endDate.ToString("yyyy-MM-dd"));
                object result = cmd.ExecuteScalar();
                return result != DBNull.Value ? Convert.ToDecimal(result) : 0m;
            }
        }

        // Получение статистики по тренерам (количество проведенных занятий за период)
        public DataTable GetTrainerUsageStats(DateTime startDate, DateTime endDate)
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                con.Open();
                var cmd = new SQLiteCommand(@"SELECT co.FullName AS TrainerName, COUNT(s.Id) AS SessionCount 
                    FROM Schedule s
                    JOIN Coaches co ON s.CoachId = co.Id
                    WHERE s.Status = 'Проведено' AND s.ScheduleDate BETWEEN @startDate AND @endDate
                    GROUP BY co.FullName
                    ORDER BY SessionCount DESC", con);
                cmd.Parameters.AddWithValue("@startDate", startDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@endDate", endDate.ToString("yyyy-MM-dd"));
                dt.Load(cmd.ExecuteReader());
            }
            return dt;
        }

        // Получение статистики по абонементам (количество покупок за период)
        public DataTable GetAbonementUsageStats(DateTime startDate, DateTime endDate)
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                con.Open();
                var cmd = new SQLiteCommand(@"SELECT a.Name AS AbonementName, COUNT(cs.Id) AS Count 
                    FROM ClientSubscriptions cs
                    JOIN Abonements a ON cs.AbonementId = a.Id
                    WHERE cs.PurchaseDate BETWEEN @startDate AND @endDate
                    GROUP BY a.Name
                    ORDER BY Count DESC", con);
                cmd.Parameters.AddWithValue("@startDate", startDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@endDate", endDate.ToString("yyyy-MM-dd"));
                dt.Load(cmd.ExecuteReader());
            }
            return dt;
        }

        // --- МЕТОДЫ ДЛЯ ClientSubscriptions ---
        public int AddClientSubscription(int clientId, int abonementTemplateId, string purchaseDate, string expiryDate, int initialVisits)
        {
            string query = "INSERT INTO ClientSubscriptions (ClientId, AbonementId, PurchaseDate, ExpiryDate, RemainingVisits, IsActive) VALUES (@clientId, @abonementId, @purchaseDate, @expiryDate, @remainingVisits, 1)";
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@clientId", clientId);
                cmd.Parameters.AddWithValue("@abonementId", abonementTemplateId);
                cmd.Parameters.AddWithValue("@purchaseDate", purchaseDate);
                cmd.Parameters.AddWithValue("@expiryDate", expiryDate);
                cmd.Parameters.AddWithValue("@remainingVisits", initialVisits);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetActiveClientSubscriptions(int clientId)
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT cs.Id, a.Name AS AbonementName, cs.RemainingVisits, cs.ExpiryDate, cs.PurchaseDate
                FROM ClientSubscriptions cs
                JOIN Abonements a ON cs.AbonementId = a.Id
                WHERE cs.ClientId = @clientId 
                  AND cs.IsActive = 1 
                  AND date(cs.ExpiryDate) >= date('now') 
                  AND cs.RemainingVisits > 0 
                ORDER BY cs.ExpiryDate ASC";
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@clientId", clientId);
                con.Open(); dt.Load(cmd.ExecuteReader());
            }
            return dt;
        }

        public DataRow GetClientSubscriptionById(int subscriptionId)
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT cs.Id, cs.ClientId, cs.AbonementId, cs.PurchaseDate, cs.ExpiryDate, 
                       cs.RemainingVisits, cs.IsActive, a.Name AS AbonementTemplateName,
                       a.VisitsCount AS OriginalVisitsCount, a.DurationDays AS OriginalDurationDays
                FROM ClientSubscriptions cs
                JOIN Abonements a ON cs.AbonementId = a.Id
                WHERE cs.Id = @id";
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@id", subscriptionId);
                con.Open(); dt.Load(cmd.ExecuteReader());
                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }

        public int DeductVisitFromClientSubscription(int clientSubscriptionId)
        {
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                con.Open();
                string query = @"
                    UPDATE ClientSubscriptions 
                    SET RemainingVisits = RemainingVisits - 1 
                    WHERE Id = @id 
                      AND RemainingVisits > 0 
                      AND IsActive = 1
                      AND date(ExpiryDate) >= date('now')";

                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", clientSubscriptionId);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public int ReturnVisitToClientSubscription(int clientSubscriptionId)
        {
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE ClientSubscriptions SET RemainingVisits = RemainingVisits + 1 WHERE Id = @id";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", clientSubscriptionId);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateClientSubscriptionStatus(int clientSubscriptionId, bool isActive)
        {
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE ClientSubscriptions SET IsActive = @isActive WHERE Id = @id";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@isActive", isActive ? 1 : 0);
                    cmd.Parameters.AddWithValue("@id", clientSubscriptionId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetAbonementTemplatesForDropdown()
        {
            DataTable dt = new DataTable();
            string query = "SELECT Id, Name, VisitsCount, DurationDays, Price FROM Abonements ORDER BY Name";
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
            {
                con.Open(); dt.Load(cmd.ExecuteReader());
            }
            return dt;
        }

        public decimal GetAbonementTemplatePrice(int abonementId)
        {
            DataTable dt = new DataTable();
            string query = "SELECT Price FROM Abonements WHERE Id = @id";
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@id", abonementId);
                con.Open(); dt.Load(cmd.ExecuteReader());
                return dt.Rows.Count > 0 ? Convert.ToDecimal(dt.Rows[0]["Price"]) : 0;
            }
        }

        public DataTable GetClientSubscriptionsHistory(int clientId)
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT cs.Id, a.Name AS AbonementName, cs.PurchaseDate, cs.ExpiryDate, 
                       cs.RemainingVisits, 
                       CASE WHEN cs.IsActive = 1 AND date(cs.ExpiryDate) >= date('now') AND cs.RemainingVisits > 0 THEN 'Активен' 
                            WHEN cs.IsActive = 0 THEN 'Деактивирован'
                            WHEN date(cs.ExpiryDate) < date('now') THEN 'Истек'
                            WHEN cs.RemainingVisits <= 0 THEN 'Закончились посещения'
                            ELSE 'Неизвестно' END AS Status
                FROM ClientSubscriptions cs
                JOIN Abonements a ON cs.AbonementId = a.Id
                WHERE cs.ClientId = @clientId
                ORDER BY cs.PurchaseDate DESC";
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@clientId", clientId);
                con.Open(); dt.Load(cmd.ExecuteReader());
            }
            return dt;
        }
    }
}
