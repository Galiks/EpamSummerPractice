using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAward.DAL.DAO;

namespace UserAward.BLL.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserDao _userDao;

        public UserLogic(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public bool AddUser(string name, string birthday)
        {
            if (DateTime.TryParse(birthday, out DateTime dateTime) && !String.IsNullOrEmpty(name))
            {
                var rightBirthday = DateTime.Parse(birthday);

                var newUser = new User { IdUser = SetIdUser(), Name = name, Birthday = rightBirthday, Age = SetAge(rightBirthday) };

                _userDao.AddUser(newUser);

                return true;
            }

            return false;
        }

        public IEnumerable<User> GetUsers()
        {
            return _userDao.GetUsers().ToList();
        }

        private int SetIdUser()
        {
            if (GetUsers().ToList().Count == 0)
            {
                return 1;
            }
            else
            {
                return GetUsers().ToList().Last().IdUser + 1;
            }
        }

        public int SetAge(DateTime birthday)
        {

            if (DateTime.Today.Month > birthday.Month)
            {
                return (DateTime.Today.Year - birthday.Year);
            }
            else
            {
                return (DateTime.Today.Year - birthday.Year) - 1;
            }
        }

        public bool DeleteUser(int id)
        {
            var userForDelete = GetUserById(id);

            if (userForDelete != null)
            {
                _userDao.DeleteUser(id);

                return true;
            }
            else
            {
                return false;
            }
        }

        public User GetUserById(int id)
        {
            return _userDao.GetUserById(id);
        }

        public IEnumerable<User> GetUserByName(string name)
        {
            return _userDao.GetUserByName(name);
        }

        public IEnumerable<User> GetUserByLetter(char letter)
        {
            return _userDao.GetUserByLetter(letter);
        }

        public IEnumerable<User> GetUserByWord(string word)
        {
            return _userDao.GetUserByWord(word);
        }

        public bool UpdateUser(int id, string name, string birthday)
        {
            if (DateTime.TryParse(birthday, out DateTime dateTime) && (GetUserById(id) != null))
            {
                _userDao.UpdateUser(id, name, DateTime.Parse(birthday), SetAge(DateTime.Parse(birthday)));

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
