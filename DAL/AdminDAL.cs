using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class AdminDAL : BaseDAL<Admin>, IAdminDAL
    {
        public Admin Login(Admin admin)
        {
            return this.db.Admin.Where(a => a.Username == admin.Username && a.Password == admin.Password).FirstOrDefault();
        }
    }
}
