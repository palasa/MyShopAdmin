using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBLL;
using Model;
using IDAL;
using DAL;

namespace BLL
{
    public class UserBLL : BaseBLL<User> , IUserBLL
    {
        IBaseDAL<User> userDAL = new UserDAL();

        public UserBLL()
        {
            this.SetDal(userDAL);
        }
    }
}
