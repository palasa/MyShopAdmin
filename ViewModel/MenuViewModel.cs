using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class MenuViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Nullable<int> ParentId { get; set; }

        public string Controller { get; set; }
        public string Action { get; set; }

        public virtual ICollection<Menu> ChildMenus { get; set; }
    }
}
