using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Model
{
    internal class ProductValidate
    {
        /// <summary>
        /// 进行字符串长度验证
        /// </summary>
        [StringLength(10, MinimumLength = 2, ErrorMessage = "商品名称必须为2~10位")]
        [Required(ErrorMessage = "商品名称必须填写")]
        [DisplayName("商品名称")]         // 使用 html 帮助类 @Html.DisplayNameFor 时，展示的字段名为：
        public string Name { get; set; }

        /// <summary>
        /// 范围验证 Range (double min, double max) :
        /// 验证 值的 范围
        /// </summary>
        [Range(100, 200, ErrorMessage = "价格的范围错误！！应该为100~200之间")]
        [Required]
        public Nullable<decimal> OldPrice { get; set; }


        /// <summary>
        /// 使用正则表达式进行验证， 验证Sales 必须是 1 开头的三位数字
        /// </summary>
        [RegularExpression(@"^1\d{2}$", ErrorMessage = "销量不满足'必须是 1 开头的三位数字'")]
        public Nullable<int> Sales { get; set; }

      
        public string Detail { get; set; }
    }
}