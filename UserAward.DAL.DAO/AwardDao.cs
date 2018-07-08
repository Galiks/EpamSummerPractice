using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using UserAward.DAL.Interface;

namespace UserAward.DAL.DAO
{
    public class AwardDao : IAwardDao
    {
        private readonly string _connectionString;

        public AwardDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["userAward"].ConnectionString;
        }

        public int AddAward(Award award)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "AddAward";

                var title = new SqlParameter("@TITLE", System.Data.SqlDbType.VarChar)
                {
                    Value = award.Title
                };

                command.Parameters.Add(title);

                var description = new SqlParameter("@DESCRIPTION", System.Data.SqlDbType.VarChar)
                {
                    Value = award.Description
                };

                command.Parameters.Add(description);

                connection.Open();

                return (int)(decimal)command.ExecuteScalar();
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

        public IEnumerable<Award> GetAwardByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Award> GetAwardByWord(string word)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Award> GetAwards()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "GetAwards";

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Award
                    {
                        IdAward = (int)reader["id_award"],
                        Title = (string)reader["Title"],
                        Description = (string)reader["Description"]
                    };
                }
            }
        }

        public int UpdateAward(int id, string title, string description)
        {
            throw new NotImplementedException();
        }
    }
}
