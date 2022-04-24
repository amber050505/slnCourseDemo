using prjCourseDemo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace prjCourseDemo.ViewModel
{
    public class COderCreateViewModel
    {
        [DisplayName("付款人帳號")]
        public string UserName { get; set; }
        public TOrder oder { get; set; }
        public List<TOrderDetail> oder_detail { get; set; }

        public CShoppingCartViewModel coursedata { get; set; }
    }
}
