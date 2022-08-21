using Interview_Schedule_Management.Data;
using Interview_Schedule_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Interview_Schedule_Management.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationContext context;
        public static int Id;
        static string adname;

        public AdminController(ApplicationContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminLogin(Admin ad)
        {
            var user = context.Admins.Where(x => x.AD_Username == ad.AD_Username && x.AD_Password==ad.AD_Password).ToList();

            if(user.Count>0)
            {
                Id = user[0].AD_ID;
                adname = user[0].AD_Username;
                return RedirectToAction("AdminIndex", "Admin");
            }

            return View();
        }


        public IActionResult AdminIndex()
        {
            TempData["ADID"] = Id;
            TempData["ADName"] = adname;
            return View();
        }

        public IActionResult AdminPanel()
        {
            var user = context.Admins.ToList();
            return View(user);
        }

        public IActionResult ViewAllJobs()
        {
            var res = context.Jobs.ToList();
            return View(res);
        }

        public IActionResult AdminViewHR()
        {
            var res = context.Candidates.Where(x => x.C_TYPE == "HR").ToList();
            return View(res);
        }

        public IActionResult AdminViewCandidates()
        {
            var res = context.Candidates.Where(x => x.C_TYPE != "HR").ToList();
            return View(res);
        }

        public IActionResult DeleteHR(int id)
        {
            var can = context.Candidates.SingleOrDefault(x => x.C_ID == id);
            context.Candidates.Remove(can);
            context.SaveChanges();
            return RedirectToAction("AdminViewHR", "Admin");
        }

        public IActionResult DeleteCandidate(int id)
        {
            var can = context.Candidates.SingleOrDefault(x => x.C_ID == id);
            context.Candidates.Remove(can);
            context.SaveChanges();
            return RedirectToAction("AdminViewCandidates", "Admin");
        }
    
        public IActionResult ApplicantView(int id)
        {
            var res = context.Applicants.Where(x => x.APP_REFF_ID == id).ToList();
            return View(res);
        }

        [HttpGet]
        public IActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAdmin(Admin ad)
        {
            var res = new Admin()
            {
                AD_Username = ad.AD_Username,
                AD_Password = ad.AD_Password,
                AD_Department = ad.AD_Department
            };

            context.Admins.Add(res);
            context.SaveChanges();

            return RedirectToAction("AdminPanel", "Admin");
        }

        public IActionResult DeleteAdmin(int id)
        {
            var ad = context.Admins.SingleOrDefault(x => x.AD_ID == id);
            context.Admins.Remove(ad);
            context.SaveChanges();
            return RedirectToAction("AdminPanel", "Admin");
        }
    }
}
