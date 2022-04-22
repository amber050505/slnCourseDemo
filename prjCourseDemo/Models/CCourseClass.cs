﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjCourseDemo.Models
{
    public class CourseData
    {
        //使用:CourseModel
        public static string[] c_name = new[] { "國文", "英文", "數學" };
        public static string[] c_ename = new[] { "CN", "EN", "MT" };
        public static string[] c_number = new[] { "1", "2", "3" };

        public string[] schoolyear_name = new[] { "上", "下" };
        public string[] schoolyear_number = new[] { "0", "1" };

        //使用:CourseInformation
        //尚未招生->(預排課表時)
        public string[] classstate_name = new[] { "尚未招生", "招生中", "額滿", "開課中", "已刪除" };
        public string[] classstate_number = new[] { "0", "1", "2", "3", "9" };

    }

    //科目代碼
    //使用:CourseModel
    public static class CCourseClass
    {
        public static string getCourseEName(this string cname)
        {
            if (Array.IndexOf(CourseData.c_name, cname) != -1)
                return CourseData.c_number[Array.IndexOf(CourseData.c_name, cname)];
            else if (Array.IndexOf(CourseData.c_number, cname) != -1)
                return CourseData.c_ename[Array.IndexOf(CourseData.c_number, cname)];
            else
                return "";
        }
    }

    public class CCourseDataChange
    {
        CourseData data = new CourseData();
        public string getCourseState(string cstate)
        {
            if (Array.IndexOf(data.classstate_number, cstate) != -1)
                return data.classstate_name[Array.IndexOf(data.classstate_number, cstate)];
            return "";
        }
    }

    //課程模板顯示狀態
    //使用:CourseModel
    public class CCourseModelShowState
    {
        //是否顯示
        string[] express = new[] { "Y", "N" };
        //狀態代表數字
        int[] startnumber = new[] { 1, 9 };
        public int showCourse(string show)
        {
            int p_express = Array.IndexOf(express, show);
            if (p_express != -1)
                return p_express + 1;
            else
                return 0;
        }
    }

    //讀取舊課程或新增課程
    //使用:CourseInformation
    public class CCourseShowState
    {
        string[] coursestatus_name = new[] { "old", "new" };
        int[] coursestatus_number = new[] { 1, 2 };

        public int showCourse(string show)
        {
            int p_name = Array.IndexOf(coursestatus_name, show);
            if (p_name != -1)
                return coursestatus_number[p_name];
            else
                return 0;
        }
    }

    //DropDownList (CourseModel)
    public class CourseModelMenu
    {
        public List<SelectListItem> CategoryDropDownList = new List<SelectListItem>();
        public List<SelectListItem> SchoolYearDropDownList = new List<SelectListItem>();
        public CourseModelMenu()
        {
            CourseData c_data = new CourseData();
            for (int i = 0; i < c_data.schoolyear_name.Length; i++)
            {
                SchoolYearDropDownList.Add(new SelectListItem() { Text = c_data.schoolyear_name[i], Value = c_data.schoolyear_number[i] });
            }
            for (int i = 0; i < CourseData.c_name.Length; i++)
            {
                CategoryDropDownList.Add(new SelectListItem() { Text = CourseData.c_name[i], Value = CourseData.c_number[i] });
            }
        }
    }

    //DropDownList (CourseInformation)
    public class CourseMenu
    {
        public List<SelectListItem> ClassStateDDL = new List<SelectListItem>();
        public CourseMenu()
        {
            CourseData c_data = new CourseData();
            for(int i = 0; i < c_data.classstate_name.Length; i++)
            {
                ClassStateDDL.Add(new SelectListItem() { Text = c_data.classstate_name[i], Value = c_data.classstate_number[i] });
            }
        }
    }

    //購物車session
    public class CShoppingCart
    {
        //public string FUserId { get; set; }
        public string EchelonId { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public decimal Course_TotalPrice
        {
            get
            {
                return this.Count * this.Price;
            }
            set
            {
                value = this.Count * this.Price;
            }
        }
        public string PhotoName { get; set; }
        //public TCourseInformation Course { get; set; }
    }

    //test
    public class CourseMenu1
    {
        private dbDemoCourseContext _context;
        public string courseID;
        //變數 欄位
        public List<SelectListItem> CourseModelDDL = new List<SelectListItem>();
        //屬性
        //public List<SelectListItem> CourseModelDDL { get; set; }
        public CourseMenu1(dbDemoCourseContext context)
        {
            _context = context;
            Menu();
        }
        public void Menu()
        {
            var data = from t in _context.TCourseModles
                       select t;
            foreach (var iteam in data)
            {
                CourseModelDDL.Add(new SelectListItem() { Text = iteam.FName, Value = iteam.FCourseId });
            }
        }
    }
}
