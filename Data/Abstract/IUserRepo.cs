using RideShare.Model;
using System.Collections.Generic;

namespace RideShare.Data
{
    public interface IUserRepo
    {
        IEnumerable<User> GetUsers();

        User GetUser(string email);
        User Authentication(string Email,string password);
    }
}