using Microsoft.AspNetCore.Mvc.Rendering;
using prjCourseDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjCourseDemo.ViewModel
{
    //目前沒使用
    public class CCourseModelAllViewModel1
    {
        public CCourseModelViewModel c_model { get; set; }
        //欄位名稱用
        public CCourseModelDetailViewModel c_model_detail { get; set; }
        public List<CCourseModelDetailViewModel> c_model_detail_list { get; set; }
        public List<SelectListItem> CategoryDDL = new CourseModelMenu().CategoryDropDownList;
        //public List<SelectListItem> CategoryDDL
        //{
        //    get { return new CMenu().CategoryDropDownList; }
        //    set { new CMenu().CategoryDropDownList = value; }
        //}
        public List<SelectListItem> SchoolYearDDL 
        { 
            get { return new CourseModelMenu().SchoolYearDropDownList; }
            set { new CourseModelMenu().SchoolYearDropDownList = value; }
        }
    }

    public class CCourseModelAllViewModel
    {
        public TCourseModle c_model { get; set; }
        //欄位名稱用
        public TCourseModleDetail c_model_detail { get; set; }
        public List<TCourseModleDetail> c_model_detail_list { get; set; }
        public List<SelectListItem> CategoryDDL = new CourseModelMenu().CategoryDropDownList;
        public List<SelectListItem> SchoolYearDDL
        {
            get { return new CourseModelMenu().SchoolYearDropDownList; }
            set { new CourseModelMenu().SchoolYearDropDownList = value; }
        }
    }
}
