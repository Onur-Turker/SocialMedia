using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
    public interface ISharingRepository:IBaseRepository<Sharing>
    {
        List<Sharing> MyProfileList(int id);
        List<Sharing> ListHomePage(int id = -1);
    }
}
