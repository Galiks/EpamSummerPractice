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
        IEnumerable<Award> GetAwards();
    }
}
