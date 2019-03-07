using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ProductTypeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Pid { get; set; }
        public virtual ICollection<ProductType> ChildProductTypes { get; set; }
    }
}
