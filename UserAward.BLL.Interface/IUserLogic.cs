﻿using System;
using System.Collections.Generic;
using Entity;

namespace UserAward.BLL.Logic
{
    public interface IUserLogic
    {
        bool AddUser(string name, string birthday);
        bool DeleteUser(int id);
        User GetUserById<T>(T id);
        IEnumerable<User> GetUserByName(string name);
        IEnumerable<User> GetUserByLetter(string letter);
        IEnumerable<User> GetUserByWord(string word);
        IEnumerable<User> GetUsers();
        bool UpdateUser(string id, string name, string birthday);
        int SetAge(DateTime birthday);
        bool Rewarding(string idUser, string idAward);
        void GetAwardFromUserAward(string id);
    }
}