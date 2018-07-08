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

        

        public IEnumerable<Award> GetAwards()
        {
            return _awardDao.GetAwards().ToList();
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
