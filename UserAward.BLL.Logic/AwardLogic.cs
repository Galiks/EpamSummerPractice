using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAward.BLL.Interface;
using UserAward.DAL.Interface;

namespace UserAward.BLL.Logic
{
    public class AwardLogic : IAwardLogic
    {
        private readonly IAwardDao _awardDao;

        public AwardLogic(IAwardDao awardDao)
        {
            _awardDao = awardDao;
        }

        public bool AddAward(string title, string description)
        {
            if (!String.IsNullOrEmpty(title))
            {
                if (description != null)
                {
                    var newAward = new Award { IdAward = SetIdAward(), Title = title, Description = description };

                    _awardDao.AddAward(newAward);

                    return true;
                }
                else
                {
                    var newAward = new Award { IdAward = SetIdAward(), Title = title, Description = null };

                    _awardDao.AddAward(newAward);

                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public bool DeleteAward(int id)
        {
            if (_awardDao.GetAwardById(id) != null)
            {
                _awardDao.DeleteAward(id);

                return true;
            }
            else
            {
                return false;
            }
        }

        public Award GetAwardById(int id)
        {
            return _awardDao.GetAwardById(id);
        }

        public IEnumerable<Award> GetAwardByLetter(char letter)
        {
            return _awardDao.GetAwardByLetter(letter).ToList();
        }

        public IEnumerable<Award> GetAwardByTitle(string title)
        {
            return _awardDao.GetAwardByTitle(title).ToList();
        }

        public IEnumerable<Award> GetAwardByWord(string word)
        {
            return _awardDao.GetAwardByWord(word);
        }

        public IEnumerable<Award> GetAwards()
        {
            return _awardDao.GetAwards().ToList();
        }

        //Добавить проверку на существование награды!
        public bool UpdateAward(int id, string title, string description)
        {
            if (!String.IsNullOrEmpty(title) && GetAwardById(id) != null)
            {
                if (description != null)
                {
                    _awardDao.UpdateAward(id, title, description);

                    return true;
                }
                else
                {
                    _awardDao.UpdateAward(id, title, null);

                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        private int SetIdAward()
        {
            if (GetAwards().ToList().Count == 0)
            {
                return 1;
            }
            else
            {
                return GetAwards().ToList().Last().IdAward + 1;
            }
        }
    }
}
