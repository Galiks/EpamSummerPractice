﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using Entity;
using Newtonsoft.Json;
using UserAward.DAL_Interface.Interface;

namespace UserAward.DAL_File.DAO
{
    public class AwardDaoFile : IAwardDao
    {
        private readonly string pathToAwardsFile;

        public AwardDaoFile()
        {
            pathToAwardsFile = ConfigurationManager.ConnectionStrings["awardFile"].ConnectionString;

            using (var file = File.Open(pathToAwardsFile, FileMode.OpenOrCreate))
            {
                file.Close();
            }
        }

        public int AddAward(Award award)
        {
            using (StreamWriter writer = File.AppendText(pathToAwardsFile))
            {
                try
                {
                    writer.WriteLine(award);
                    return 1;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        public int DeleteAward(int id)
        {
            throw new NotImplementedException();
        }

        public Award GetAwardById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Award> GetAwardByLetter(char letter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Award> GetAwardByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Award> GetAwardByWord(string word)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Award> GetAwards()
        {
            using (StreamReader reader = new StreamReader(pathToAwardsFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        Award award = DeserializeAward(line);
                        yield return award;
                    }
                }
            }
        }

        private Award DeserializeAward(string line)
        {
            string[] informations = line.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            if (int.TryParse(informations[0], out int ID))
            {
                return new Award { IdAward = ID, Title = informations[1], Description = informations[2] };
            }
            else
            {
                return null;
            }    
        }

        public int UpdateAward(int id, string title, string description)
        {
            throw new NotImplementedException();
        }

        private byte[] ConvertTextOnBytes(string text)
        {
            return Encoding.UTF8.GetBytes(text);
        }
    }
}
