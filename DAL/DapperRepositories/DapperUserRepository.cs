using DAL.Interfaces;
using DAL.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DapperRepositories
{
    public class DapperUserRepository : IRepository<User>
    {
        IDbConnection connection;
        public DapperUserRepository(IDbConnection connection)
        {
            this.connection = connection;
        }
        public DapperUserRepository(string connectionString)
        {
            this.connection = new SqlConnection(connectionString);
        }

        public void Create(User item)
        {
            throw new NotImplementedException();
        }

        public User FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Get()
        {
            List<User> users = new List<User>();
            var userDictionary = new Dictionary<int, User>();
            users = connection.Query<User, Role, User>
                ("select * from (SELECT c.ClientId,NickName,Password,Age,ActivityLevel,Sex FROM Clients c,ClientProfiles cp WHERE c.ClientId=cp.ClientId) AS tmp LEFT JOIN ClientRoles cr ON cr.ClientId = tmp.ClientId LEFT JOIN Roles r ON r.Id = cr.RoleId", (u, r) => {
                User userEntry;
                if (!userDictionary.TryGetValue(u.ClientId, out userEntry))
                {
                    userEntry = u;
                    userEntry.Roles = new List<Role>();
                    userDictionary.Add(userEntry.ClientId, userEntry);
                }
                userEntry.Roles.Add(r);
                //userEntry.Login=
                return userEntry;
            },
            splitOn: "ClientId").Distinct().ToList();
            return users;
        }

        public IEnumerable<User> Get(Func<User, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Remove(User item)
        {
            throw new NotImplementedException();
        }

        public void Update(User item)
        {
            throw new NotImplementedException();
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
