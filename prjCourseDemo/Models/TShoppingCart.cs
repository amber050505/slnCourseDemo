using System;
using System.Collections.Generic;

#nullable disable

namespace prjCourseDemo.Models
{
    public partial class TShoppingCart
    {
        public int FId { get; set; }
        public string FUserId { get; set; }
        public string FEchelonId { get; set; }

        public virtual TCourseInformation FEchelon { get; set; }
    }
}
