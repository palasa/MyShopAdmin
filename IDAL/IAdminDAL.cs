using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public partial interface IAdminDAL : IBaseDAL<Admin>
    {
        Admin Login(Admin admin);
    }


}
