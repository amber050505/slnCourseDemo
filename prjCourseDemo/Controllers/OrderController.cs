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
    public class OrderController : Controller
    {
        private dbDemoCourseContext _context;
        public OrderController(dbDemoCourseContext context)
        {
            _context = context;
        }
        public IActionResult Creat()
        {
            List<CShoppingCart> List = getShoppingCart();
            //if (List == null || List.Count == 0)
            //    return RedirectToAction("", "");
            COderCreatViewModel c = new COderCreatViewModel() { coursedata = new CShoppingCartViewModel() };
            string UserId = "", UserName = "";
            DateTime now;
            readUserData(out UserId, out UserName, out now);
            //付款人資料
            c.UserName = UserName;
            c.oder = new TOrder() { FUserId = UserId };
            //購買課程
            c.coursedata.ShoppingCart_List = List;
            c.oder_detail = getOderDetail(List.Count);
            return View(c);
        }

        public IActionResult checkReceiverId(string account)
        {
            var buycourse_user = _context.StudentProfiles.Any(t => t.UserName.Equals(account) || t.Email.Equals(account));
            return Content(buycourse_user.ToString());//, "text/plain"
        }

        //
        [NonAction]
        public List<TOrderDetail> getOderDetail(int count)
        {
            List<TOrderDetail> oder_detail_list = new List<TOrderDetail>();
            for(int i = 0; i < count; i++)
                oder_detail_list.Add(new TOrderDetail() { FReceiverId = "" });
            return oder_detail_list;
        }

        //new案件編號
        [NonAction]
        public string getOrderID()
        {
            string now = DateTime.Now.ToString("yyyy") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + DateTime.Now.ToString("hh") + DateTime.Now.ToString("mm") + DateTime.Now.ToString("ss");
            Random r = new Random();
            return "OR" + now + r.Next(0, 9);
        }

        //取出購買課程
        [NonAction]
        public List<CShoppingCart> getShoppingCart()
        {
            if (HttpContext.Session.Keys.Contains(CDictionary.SK_COURSE_PURCHASED_LIST))
            {
                string json = HttpContext.Session.GetString(CDictionary.SK_COURSE_PURCHASED_LIST);
                return JsonSerializer.Deserialize<List<CShoppingCart>>(json);
            }
            return null;
        }

        //取出userID、現在時間
        [NonAction]
        public void readUserData(out string userID, out string username, out DateTime now)
        {
            userID = "";
            username = "";
            string json = "";
            now = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            if (HttpContext.Session.Keys.Contains(CDictionary.SK_LONGUNED_ID))
            {
                //讀Session-userID
                json = HttpContext.Session.GetString(CDictionary.SK_LONGUNED_ID);
                userID = JsonSerializer.Deserialize<string>(json);
            }
            if (HttpContext.Session.Keys.Contains(CDictionary.SK_LOGINED_USER))
            {
                json = HttpContext.Session.GetString(CDictionary.SK_LOGINED_USER);
                username = JsonSerializer.Deserialize<string>(json);
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
