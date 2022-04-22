using System;
using System.Collections.Generic;

#nullable disable

namespace prjCourseDemo.Models
{
    public partial class TCourseInformation
    {
        public TCourseInformation()
        {
            TCourseInformationImgs = new HashSet<TCourseInformationImg>();
            TOrderDetails = new HashSet<TOrderDetail>();
            TShoppingCarts = new HashSet<TShoppingCart>();
        }

        public string FEchelonId { get; set; }
        public string FName { get; set; }
        public string FCourseId { get; set; }
        public DateTime? FStartTime { get; set; }
        public DateTime? FEndTime { get; set; }
        public string FTime { get; set; }
        public int? FBasicPeople { get; set; }
        public int? FLimitPeople { get; set; }
        public int? FClassState { get; set; }
        public string FCoverImg { get; set; }
        public string FClassRoom { get; set; }
        public string FTeacher { get; set; }
        public DateTime? FDiscountDate { get; set; }
        public string FCreationUser { get; set; }
        public DateTime? FCreationDate { get; set; }
        public string FSaverUser { get; set; }
        public DateTime? FSaverDate { get; set; }

        public virtual TCourseModle FCourse { get; set; }
        public virtual ICollection<TCourseInformationImg> TCourseInformationImgs { get; set; }
        public virtual ICollection<TOrderDetail> TOrderDetails { get; set; }
        public virtual ICollection<TShoppingCart> TShoppingCarts { get; set; }
    }
}
