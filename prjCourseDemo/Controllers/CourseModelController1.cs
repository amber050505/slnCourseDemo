using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prjCourseDemo.Models;
using prjCourseDemo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace prjCourseDemo.Controllers
{
    public class CourseModelController1 : Controller
    {
        public IActionResult List()
        {
            var datas = from t in (new dbDemoCourseContext()).TCourseModles.Where(c=>c.FModleSate.Equals(1))
                        select t;
            List<CCourseModelViewModel> list = new List<CCourseModelViewModel>();
            foreach (TCourseModle t in datas)
            {
                list.Add(new CCourseModelViewModel() { coursemodel = t });
            }
            return View(list);
        }

        public IActionResult Detail(string id)
        {
            //ViewBag.CategoryDropDown = new CMenu().CategoryDropDown;
            //List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> test = new CMenu().CategoryDropDown;
            CCourseModelAllViewModel1 cmodel_all = new CCourseModelAllViewModel1();
            if (id != null)
            {
                dbDemoCourseContext db = new dbDemoCourseContext();
                TCourseModle c_model = db.TCourseModles.FirstOrDefault(m => m.FCourseId == id);
                if (c_model != null)
                {
                    CCourseModelViewModel cmodel = new CCourseModelViewModel() { coursemodel = c_model };
                    cmodel_all.c_model = cmodel;

                    var c_model_detail = db.TCourseModleDetails.Where(m => m.FCourseId == id);
                    if (c_model_detail != null)
                    {
                        List<CCourseModelDetailViewModel> c_model_detai_list = new List<CCourseModelDetailViewModel>();
                        List<CCourseModelDetailViewModel> list = new List<CCourseModelDetailViewModel>();
                        foreach(TCourseModleDetail t in c_model_detail)
                        {
                            c_model_detai_list.Add(new CCourseModelDetailViewModel() { coursemodeldetail = t });
                            list.Add(new CCourseModelDetailViewModel() { coursemodeldetail = t });
                            //list.Add(new CCourseModelDetailViewModel()
                            //{
                            //    FCourseNumber = Convert.ToInt32(t.FCourseNumber),
                            //    FSchedule = t.FSchedule,
                            //    FScheduleDetail = t.FScheduleDetail,
                            //    FTeachingMethod = t.FTeachingMethod,
                            //    FRemark = t.FRemark
                            //});
                        }
                        cmodel_all.c_model_detail_list = c_model_detai_list;
                        string json = JsonSerializer.Serialize(list);
                        HttpContext.Session.SetString(CDictionary.SK_COURSE_MODELDETAIL, json);
                    }
                    return View(cmodel_all);
                }
                return View("List");
            }
            return View(cmodel_all);
        }

        //新增、修改
        [HttpPost]
        public IActionResult Detail(CCourseModelAllViewModel1 c)
        {
            string userID = "";
            DateTime now = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            if (HttpContext.Session.Keys.Contains(CDictionary.SK_LONGUNED_ID))
            {
                string json = HttpContext.Session.GetString(CDictionary.SK_LONGUNED_ID);
                userID = JsonSerializer.Deserialize<string>(json);
            }

            dbDemoCourseContext db = new dbDemoCourseContext();
            if (string.IsNullOrEmpty(c.c_model.FCourseId))
            {
                c.c_model.FCourseId = getCourseModelID(c.c_model.FCategory.ToString());
                c.c_model.FSaverDate = now;
                db.TCourseModles.Add(c.c_model.coursemodel);
                db.SaveChanges();
            }
            else
            {
                TCourseModle course = db.TCourseModles.FirstOrDefault(m => m.FCourseId == c.c_model.FCourseId);
                course.FCategory = c.c_model.FCategory;
                course.FName = c.c_model.FName;
                course.FTotalHours = c.c_model.FTotalHours;
                course.FTotalNumber = c.c_model.FTotalNumber;
                course.FGrade = c.c_model.FGrade;
                course.FSchoolYear = c.c_model.FSchoolYear;
                course.FSummary = c.c_model.FSummary;
                course.FModleSate = c.c_model.FModleSate;
                course.FTeachingMaterial = c.c_model.FTeachingMaterial;
                course.FOriginalPrice = c.c_model.FOriginalPrice;
                course.FSpecialOffer = c.c_model.FSpecialOffer;

                //建立人員
                course.FCreationUser = userID;
                //存檔人員
                course.FSaverUser = userID;
                course.FCreationDate = now;
                course.FSaverDate = now;
                db.SaveChanges();

                clearModelDetail(c.c_model.FCourseId);
                getModelDetail(c.c_model.FCourseId, userID, now);
            }
            return RedirectToAction("List");
        }

        [NonAction]
        private void clearModelDetail(string fCourseId)
        {
            dbDemoCourseContext db = new dbDemoCourseContext();
            var data = from t in db.TCourseModleDetails.Where(c => c.FCourseId == fCourseId)
                       select t;
            if (data.ToList().Count == 0)
                return;
            db.TCourseModleDetails.RemoveRange(data);
            db.SaveChanges();
        }

        [NonAction]
        private void getModelDetail(string coursemodelID, string userID, DateTime now)//,List<CCourseModelDetailViewModel> c_model_detail
        {
            if (!HttpContext.Session.Keys.Contains(CDictionary.SK_COURSE_MODELDETAIL))
                return;
            string json = HttpContext.Session.GetString(CDictionary.SK_COURSE_MODELDETAIL);
            List<CCourseModelDetailViewModel> c_model_detail = JsonSerializer.Deserialize<List<CCourseModelDetailViewModel>>(json);
            dbDemoCourseContext db = new dbDemoCourseContext();
            for(int i = 0; i < c_model_detail.Count; i++)
            {
                db.TCourseModleDetails.Add(new TCourseModleDetail()
                {
                    FCourseId = coursemodelID,
                    FCourseNumber = c_model_detail[i].FCourseNumber,
                    FSchedule = c_model_detail[i].FSchedule,
                    FScheduleDetail = c_model_detail[i].FScheduleDetail,
                    FTeachingMethod = c_model_detail[i].FTeachingMethod,
                    FRemark = c_model_detail[i].FRemark,
                    FCreationUser = userID,
                    FCreationDate = now,
                    FSaverUser = userID,
                    FSaverDate = now
                });
            }
            db.SaveChanges();
        }

        [NonAction]
        public string getCourseModelID(string category)
        {
            string now = DateTime.Now.ToString("yyyy") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + DateTime.Now.ToString("hh") + DateTime.Now.ToString("mm") + DateTime.Now.ToString("ss");
            Random r = new Random();
            return category.getCourseEName() + now + r.Next(0, 9);
        }
        public IActionResult Delete(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                dbDemoCourseContext db = new dbDemoCourseContext();
                TCourseModle modle = db.TCourseModles.FirstOrDefault(m => m.FCourseId == id);
                if (modle != null)
                {
                    db.Remove(modle);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }

        public IActionResult test1()
        {
            return View();
        }
    }
}
