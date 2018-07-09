using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAward.BLL.Interface
{
    public interface IAwardLogic
    {
        bool AddAward(string title, string description);
        bool UpdateAward(int id, string title, string description);
        bool DeleteAward(int id);
        Award GetAwardById(int id);
        IEnumerable<Award> GetAwardByLetter(char letter);
        IEnumerable<Award> GetAwardByWord(string word);
        IEnumerable<Award> GetAwardByTitle(string title);
        IEnumerable<Award> GetAwards();
    }
}
