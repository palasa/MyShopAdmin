using BLL;
using DAL;
using IBLL;
using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AdminBLL : BaseBLL<Admin>, IAdminBLL
    {
        IAdminDAL adminDal; 

        public AdminBLL( IAdminDAL adminDal)
        {
            this.SetDal(adminDal);
            this.adminDal = adminDal;
        }

        public Admin Login(Admin admin)
        {
            return this.adminDal.Login(admin);
        }
    }
}
