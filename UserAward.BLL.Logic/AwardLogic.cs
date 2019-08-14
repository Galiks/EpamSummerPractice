﻿using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using UserAward.BLL.Interface;
using UserAward.DAL_Interface.Interface;

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

        public bool DeleteAward(string id)
        {
            int awardId;
            if (Int32.TryParse(id, out awardId))
            {
                if (GetAwardById(id) != null)
                {
                    _awardDao.DeleteAward(awardId);

                    return true;
                }
                else
                {
                    Console.WriteLine($"DB has no information");
                    return false;
                }
            }
            else
            {
                Console.WriteLine($"Incorrect ID");
                return false;
            }
        }

        public Award GetAwardById(string id)
        {
            int awardId;
            if (Int32.TryParse(id, out awardId))
            {
                return _awardDao.GetAwardById(awardId);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Award> GetAwardByLetter(string letter)
        {
            char awardLetter;
            if (Char.TryParse(letter, out awardLetter))
            {
                return _awardDao.GetAwardByLetter(awardLetter).ToList();
            }
            else
            {
                Console.WriteLine($"Incorrect Letter");
                return null;
            }
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
        public bool UpdateAward(string id, string title, string description)
        {
            int awardId;

            if (Int32.TryParse(id, out awardId))
            {
                if (!String.IsNullOrEmpty(title) && GetAwardById(id) != null)
                {
                    if (description != null)
                    {
                        _awardDao.UpdateAward(awardId, title, description);

                        return true;
                    }
                    else
                    {
                        _awardDao.UpdateAward(awardId, title, null);

                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Console.WriteLine($"Incorrect ID");
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
