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
    public class ADORoleRepository : IRepository<Role>
    {
        IDbConnection connection;
        string ConnectionString;
        public ADORoleRepository(IDbConnection connection)
        {
            ConnectionString = connection.ConnectionString;
            this.connection = connection;
        }
        public ADORoleRepository(string connectionString)
        {
            ConnectionString = connectionString;
            connection = new SqlConnection(connectionString);
        }

        public void Create(Role role)
        {
            using (connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(@"INSERT INTO Roles VALUES (@RoleName)", (SqlConnection)connection);
                command.Parameters.Add("@RoleName", SqlDbType.NVarChar, 50, "RoleName");
                command.Parameters["@RoleName"].Value = role.RoleName;
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public Role FindById(int id)
        {
            Role role = null;
            using (connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(@"select * from Roles r where (r.Id=@findId)", (SqlConnection)connection);
                command.Parameters.Add("@findId", SqlDbType.Int, 0, "Id");
                command.Parameters["@findId"].Value = id;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    role = new Role();
                    role.Id = reader.GetInt32(0);
                    role.RoleName = reader.GetString(1);
                }
                connection.Close();
            }
            return role;
        }

        public IEnumerable<Role> Get()
        {
            List<Role> roles = new List<Role>();
            using (connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(@"select * from Roles", (SqlConnection)connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Role r = new Role();
                    r.Id = reader.GetInt32(0);
                    r.RoleName = reader.GetString(1);
                    roles.Add(r);
                }
                connection.Close();
            }
            return roles;
        }

        public IEnumerable<Role> Get(Func<Role, bool> predicate)
        {
            return Get().Where(predicate);
        }

        public void Remove(Role role)
        {
            using (connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(@"DELETE FROM Roles WHERE (Id=@p)", (SqlConnection)connection);
                command.Parameters.Add("@p", SqlDbType.Int, 0, "Id");
                command.Parameters["@p"].Value = role.Id;
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Update(Role role)
        {
            using (connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(@"update Roles set RoleName=@p1 where (Id=@pp1)", (SqlConnection)connection);
                command.Parameters.Add("@p1", SqlDbType.NVarChar, 50, "RoleName");
                command.Parameters["@RoleName"].Value = role.RoleName;
                command.Parameters.Add("@pp1", SqlDbType.Int, 0, "Id");
                command.Parameters["@pp1"].SourceVersion = DataRowVersion.Original;
                command.ExecuteNonQuery();
                connection.Close();
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
