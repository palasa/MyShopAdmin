using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public partial interface IAdminBLL : IBaseBLL<Admin>
    {
        Admin Login(Admin admin);
    }
}
