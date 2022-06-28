using MobileAPPMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAPPMVC.Repository
{
   public interface IMobileRepository
    {
        List<Mobile> GetAllMobiles();

        Mobile AddMobile(Mobile mobile);
        Mobile GetMobileById(int id);
        void UpdateMobile(int id, Mobile mobile);
        Mobile GetFullMobileDetailsById(int id);
        void RemoveMobile(int id);






    }
}
