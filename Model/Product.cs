//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    [MetadataType( typeof(ProductValidate) )]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.OrderDetail = new HashSet<OrderDetail>();
            this.ProductImage = new HashSet<ProductImage>();
        }

        [DisplayName("商品编号")]
        public int Id { get; set; }

        [DisplayName("商品名称")]
        public string Name { get; set; }
        public Nullable<int> TypeId { get; set; }

        [DisplayName("原价")]
        public Nullable<decimal> OldPrice { get; set; }
        [DisplayName("现价")]
        public Nullable<decimal> NewPrice { get; set; }
        public Nullable<int> ProductColorId { get; set; }
        public Nullable<int> ProductSizeId { get; set; }
        [DisplayName("商品销量")]
        public Nullable<int> Sales { get; set; }
        [DisplayName("商品库存量")]
        public Nullable<int> Amount { get; set; }
        [DisplayName("上架状态")]
        public Nullable<bool> OnSale { get; set; }

        [DisplayName("商品详情")]
        public string Detail { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        public virtual ProductColor ProductColor { get; set; }
        public virtual ProductSize ProductSize { get; set; }
        public virtual ProductType ProductType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductImage> ProductImage { get; set; }
    }
}
