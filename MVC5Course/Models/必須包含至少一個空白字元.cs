using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace MVC5Course.Models
{
    class 必須包含至少一個空白字元Attribute : DataTypeAttribute
    {
        public 必須包含至少一個空白字元Attribute()  : base(DataType.Text)
         {
         }
 
         public override bool IsValid(object value)
         {
             var str = (string)value;
 
             return str.Contains(" ");
         }
    }
}
