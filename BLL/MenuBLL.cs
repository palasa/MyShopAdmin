﻿using DAL;
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
    public class MenuBLL : BaseBLL<Menu>, IMenuBLL
    {
        IMenuDAL menuDal = new MenuDAL();

        public MenuBLL()
        {
            this.SetDal(menuDal);
        }
    }
}
