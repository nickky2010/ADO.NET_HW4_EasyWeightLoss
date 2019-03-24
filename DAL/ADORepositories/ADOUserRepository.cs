using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ADORepositories
{
    public class ADOUserRepository : IRepository<User>
    {
        IDbConnection connection;
        string ConnectionString;
        public ADOUserRepository(IDbConnection connection)
        {
            ConnectionString = connection.ConnectionString;
            this.connection = connection;
        }
        public ADOUserRepository(string connectionString)
        {
            ConnectionString = connectionString;
            connection = new SqlConnection(connectionString);
        }

        public void Create(User user)
        {
            using (connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = (SqlTransaction)connection.BeginTransaction();
                #region Clients
                SqlCommand commandClients = new SqlCommand(@"INSERT INTO Clients VALUES (@Nickname, @Password) SET @ClientId=SCOPE_IDENTITY()", (SqlConnection)connection);
                commandClients.Transaction = transaction;
                SqlParameter parameter = commandClients.Parameters.Add("@ClientId", SqlDbType.Int, 0, "ClientId");
                parameter.Direction = ParameterDirection.Output;
                commandClients.Parameters.Add("@Nickname", SqlDbType.NVarChar, 10, "Nickname");
                commandClients.Parameters.Add("@Password", SqlDbType.NVarChar, 50, "Password");
                commandClients.Parameters["@Nickname"].Value = user.Login;
                commandClients.Parameters["@Password"].Value = user.Password;
                #endregion Clients
                #region ClientProfiles
                SqlCommand commandCP = new SqlCommand(@"INSERT INTO ClientProfiles VALUES (@ClientId, @Age, @Sex, @ActivityLevel)", (SqlConnection)connection);
                commandCP.Transaction = transaction;
                commandCP.Parameters.Add("@ClientId", SqlDbType.Int, 0, "ClientId");
                commandCP.Parameters.Add("@Age", SqlDbType.Int, 0, "Age");
                commandCP.Parameters.Add("@Sex", SqlDbType.Int, 0, "Sex");
                commandCP.Parameters.Add("@ActivityLevel", SqlDbType.Int, 0, "ActivityLevel");
                commandCP.Parameters["@Age"].Value = user.Age;
                commandCP.Parameters["@Sex"].Value = (int)user.Sex;
                commandCP.Parameters["@ActivityLevel"].Value = (int)user.ActivityLevel;
                #endregion ClientProfiles
                #region Roles
                SqlCommand commandRoles = new SqlCommand(@"INSERT INTO ClientRoles VALUES (@ClientId, @RoleId)", (SqlConnection)connection);
                commandRoles.Transaction = transaction;
                commandRoles.Parameters.Add("@ClientId", SqlDbType.Int, 0, "ClientId");
                commandRoles.Parameters.Add("@RoleId", SqlDbType.Int, 0, "RoleId");
                #endregion Roles
                try
                {
                    commandClients.ExecuteNonQuery();
                    commandCP.Parameters["@ClientId"].Value = (int)parameter.Value;
                    commandCP.ExecuteNonQuery();
                    commandRoles.Parameters["@ClientId"].Value = (int)parameter.Value;
                    IRepository<Role> roleRepo = new ADORoleRepository(ConnectionString);
                    List<Role> roles = roleRepo.Get().ToList();
                    foreach (Role r in user.Roles)
                    {
                        Role tmp = roles.FirstOrDefault(t=>t.RoleName==r.RoleName);
                        if (tmp == null)
                        {
                            roleRepo.Create(new Role { RoleName = r.RoleName });
                            tmp = roles.FirstOrDefault(t => t.RoleName == r.RoleName);
                        }
                        commandRoles.Parameters["@RoleId"].Value = tmp.Id;
                        commandRoles.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        public User FindById(int id)
        {
            User user = null;
            using (connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                #region ClientProfiles
                SqlCommand commandCP = new SqlCommand(@"select * from ClientProfiles p where (p.ClientId=@findId)", (SqlConnection)connection);
                commandCP.Parameters.Add("@findId", SqlDbType.Int, 0, "ClientId");
                commandCP.Parameters["@findId"].Value = id;
                SqlDataReader reader = commandCP.ExecuteReader();
                while (reader.Read())
                {
                    user = new User();
                    user.ClientId = reader.GetInt32(0);
                    user.Age = reader.GetInt32(1);
                    user.Sex = (Sex)reader.GetInt32(2);
                    user.ActivityLevel = (ActivityLevel)reader.GetInt32(3);
                }
                reader.Close();
                #endregion ClientProfiles
                #region Clients
                if (user != null)
                {
                    SqlCommand commandClients = new SqlCommand(@"select Nickname, Password from Clients p where (p.ClientId=@findId)", (SqlConnection)connection);
                    commandClients.Parameters.Add("@findId", SqlDbType.Int, 0, "ClientId");
                    commandClients.Parameters["@findId"].Value = id;
                    SqlDataReader readerCl = commandClients.ExecuteReader();
                    while (readerCl.Read())
                    {
                        user.Login = readerCl.GetString(0);
                        user.Password = readerCl.GetString(1);
                    }
                    readerCl.Close();
                    #endregion Clients
                    #region Roles
                    SqlCommand commandRolesId = new SqlCommand(@"select RoleId from ClientRoles p where (p.ClientId=@findId)", (SqlConnection)connection);
                    commandRolesId.Parameters.Add("@findId", SqlDbType.Int, 0, "ClientId");
                    commandRolesId.Parameters["@findId"].Value = id;
                    SqlDataReader readerRId = commandRolesId.ExecuteReader();
                    List<int> rolesId = new List<int>();
                    while (readerRId.Read())
                    {
                        rolesId.Add(readerRId.GetInt32(0));
                    }
                    readerRId.Close();
                    SqlCommand commandRoles = new SqlCommand(@"select RoleName from Roles p where (p.Id=@findId)", (SqlConnection)connection);
                    commandRoles.Parameters.Add("@findId", SqlDbType.Int, 0, "Id");
                    List<Role> roles = new List<Role>();
                    foreach (int i in rolesId)
                    {
                        commandRoles.Parameters["@findId"].Value = i;
                        SqlDataReader readerR = commandRoles.ExecuteReader();
                        while (readerR.Read())
                        {
                            string roleName = readerR.GetString(0);
                            roles.Add(new Role { Id = i, RoleName = roleName });
                            break;
                        }
                        readerR.Close();
                    }
                    user.Roles = roles;
                    #endregion Roles
                }
            }
            return user;
        }

        public IEnumerable<User> Get()
        {
            List<User> users = new List<User>();
            using (connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                #region ClientProfiles
                SqlCommand commandCP = new SqlCommand(@"select * from ClientProfiles", (SqlConnection)connection);
                SqlDataReader reader = commandCP.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new User
                    {
                        ClientId = reader.GetInt32(0),
                        Age = reader.GetInt32(1),
                        Sex = (Sex)reader.GetInt32(2),
                        ActivityLevel = (ActivityLevel)reader.GetInt32(3)
                    });
                }
                reader.Close();
                #endregion ClientProfiles
                #region Clients
                SqlCommand commandClients = new SqlCommand(@"select * from Clients", (SqlConnection)connection);
                SqlDataReader readerCl = commandClients.ExecuteReader();
                while (readerCl.Read())
                {
                    User user = users.Find(a=>a.ClientId == readerCl.GetInt32(0));
                    user.Login = readerCl.GetString(1);
                    user.Password = readerCl.GetString(2);
                }
                readerCl.Close();
                #endregion Clients
                #region Roles
                SqlCommand commandRoleId = new SqlCommand(@"select * from ClientRoles", (SqlConnection)connection);
                Dictionary<int, List<int>> RoleId = new Dictionary<int, List<int>>();
                SqlDataReader readerRId = commandRoleId.ExecuteReader();
                while (readerRId.Read())
                {
                    int p0 = readerRId.GetInt32(0);
                    int p1 = readerRId.GetInt32(1);
                    if (RoleId.ContainsKey(p0))
                    {
                        RoleId[p0].Add(p1);
                    }
                    else
                    {
                        RoleId.Add(p0, new List<int>());
                        RoleId[p0].Add(p1);
                    }
                }
                readerRId.Close();
                SqlCommand commandRoleName = new SqlCommand(@"select * from Roles", (SqlConnection)connection);
                Dictionary<int, string> RoleName = new Dictionary<int, string>();
                SqlDataReader readerRName = commandRoleName.ExecuteReader();
                while (readerRName.Read())
                {
                    RoleName.Add(readerRName.GetInt32(0), readerRName.GetString(1));
                }
                foreach (User u in users)
                {
                    if (RoleId.Keys.Contains(u.ClientId))
                    {
                        foreach (int roleId in RoleId[u.ClientId])
                        {
                            u.Roles.Add(new Role { Id = roleId, RoleName = RoleName[roleId] });
                        }
                    }
                }
                #endregion Roles
            }
            return users;
        }

        public IEnumerable<User> Get(Func<User, bool> predicate)
        {
            return Get().Where(predicate);
        }

        public void Remove(User user)
        {
            using (connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = (SqlTransaction)connection.BeginTransaction();
                #region ClientProfiles
                SqlCommand commandCP = new SqlCommand(@"DELETE FROM ClientProfiles where (ClientId=@p1)", (SqlConnection)connection);
                commandCP.Transaction = transaction;
                commandCP.Parameters.Add("@p1", SqlDbType.Int, 0, "ClientId");
                commandCP.Parameters["@p1"].Value = user.ClientId;
                #endregion ClientProfiles
                #region Clients
                SqlCommand commandClients = new SqlCommand(@"DELETE FROM Clients where (ClientId=@p1)", (SqlConnection)connection);
                commandClients.Transaction = transaction;
                commandClients.Parameters.Add("@p1", SqlDbType.Int, 0, "ClientId");
                commandClients.Parameters["@p1"].Value = user.ClientId;
                #endregion Clients
                #region Roles
                SqlCommand commandRoles = new SqlCommand(@"DELETE FROM ClientRoles where (ClientId=@p1)", (SqlConnection)connection);
                commandRoles.Transaction = transaction;
                commandRoles.Parameters.Add("@p1", SqlDbType.Int, 0, "ClientId");
                commandRoles.Parameters["@p1"].Value = user.ClientId;
                #endregion Roles
                try
                {
                    commandCP.ExecuteNonQuery();
                    commandClients.ExecuteNonQuery();
                    commandRoles.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        public void Update(User user)
        {
            using (connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = (SqlTransaction)connection.BeginTransaction();
                #region ClientProfiles
                SqlCommand commandCP = new SqlCommand(@"update ClientProfiles set Age=@p1, Sex=@p2, ActivityLevel=@p3 where (ClientId=@pp1)", (SqlConnection)connection);
                commandCP.Transaction = transaction;
                commandCP.Parameters.Add("@Age", SqlDbType.Int, 0, "Age");
                commandCP.Parameters.Add("@Sex", SqlDbType.Int, 0, "Sex");
                commandCP.Parameters.Add("@ActivityLevel", SqlDbType.Int, 0, "ActivityLevel");
                commandCP.Parameters["@Age"].Value = user.Age;
                commandCP.Parameters["@Sex"].Value = user.Sex;
                commandCP.Parameters["@ActivityLevel"].Value = user.ActivityLevel;
                commandCP.Parameters.Add("@pp1", SqlDbType.Int, 0, "ClientId");
                commandCP.Parameters["@pp1"].SourceVersion = DataRowVersion.Original;
                #endregion ClientProfiles
                #region Clients
                SqlCommand commandClients = new SqlCommand(@"update Clients set Nickname=@p1, Password=@p2 where (ClientId=@pp1)", (SqlConnection)connection);
                commandClients.Transaction = transaction;
                commandClients.Parameters.Add("@Nickname", SqlDbType.NVarChar, 10, "Nickname");
                commandClients.Parameters.Add("@Password", SqlDbType.NVarChar, 50, "Password");
                commandClients.Parameters["@Nickname"].Value = user.Login;
                commandClients.Parameters["@Password"].Value = user.Password;
                commandClients.Parameters.Add("@pp1", SqlDbType.Int, 0, "ClientId");
                commandClients.Parameters["@pp1"].SourceVersion = DataRowVersion.Original;
                #endregion Clients
                #region Roles
                SqlCommand commandRoles = new SqlCommand(@"update ClientRoles set RoleId=@p1 where (ClientId=@pp1)", (SqlConnection)connection);
                commandRoles.Transaction = transaction;
                commandRoles.Parameters.Add("@RoleId", SqlDbType.Int, 0, "RoleId");
                #endregion Roles
                try
                {
                    commandCP.ExecuteNonQuery();
                    commandClients.ExecuteNonQuery();
                    foreach (Role r in user.Roles)
                    {
                        commandRoles.Parameters["@RoleId"].Value = r.Id;
                        commandRoles.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    connection.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
