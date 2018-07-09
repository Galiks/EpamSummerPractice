using System;
using System.Collections.Generic;
using Entity;

namespace UserAward.BLL.Logic
{
    public interface IUserLogic
    {
        bool AddUser(string name, string birthday);
        bool DeleteUser(int id);
        User GetUserById(int id);
        IEnumerable<User> GetUserByName(string name);
        IEnumerable<User> GetUserByLetter(char letter);
        IEnumerable<User> GetUserByWord(string word);
        IEnumerable<User> GetUsers();
        bool UpdateUser(int id, string name, string birthday);
        int SetAge(DateTime birthday);
        bool Rewarding(int idUser, int idAward);
        IDictionary<int, string> GetAwardFromUserAward(User user);
    }
}