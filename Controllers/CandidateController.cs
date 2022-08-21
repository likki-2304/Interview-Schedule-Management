using Interview_Schedule_Management.Data;
using Interview_Schedule_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Interview_Schedule_Management.Controllers
{
    public class CandidateController : Controller
    {
        private readonly ApplicationContext context;
        static string uname;
        static int cid;

        public CandidateController(ApplicationContext context)
        {
            this.context = context;
        }

        public IActionResult CandidateIndex()
        {
            TempData["username"] = uname;
            TempData["c_id"] = cid;
            var res = context.Jobs.ToList();
            return View(res);
        }

        [HttpGet]
        public IActionResult CLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CLogin(Candidate can)
        {
            var res = context.Candidates.Where(x => x.C_EMAIL == can.C_EMAIL && x.C_PASSWORD == can.C_PASSWORD).ToList();

            if(res.Count>0)
            {
                if (res[0].C_TYPE=="HR")
                {
                    return RedirectToAction("HRLogin", "HR");
                }
                uname = res[0].C_FNAME+ " " +res[0].C_LNAME;
                cid = res[0].C_ID;
                return RedirectToAction("CandidateIndex", "Candidate");
            }
            return View();
        }

        [HttpGet]
        public IActionResult ApplyJob(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult ApplyJob(AspirantApplication app)
        {
            var res = new AspirantApplication()
            {
                APP_NAME=app.APP_NAME,
                APP_EXP=app.APP_EXP,
                APP_C_ID=app.APP_C_ID,
                APP_REFF_ID=app.APP_REFF_ID,
                APP_QUALI=app.APP_QUALI,
                APP_INT_TYPE=app.APP_INT_TYPE,
                INT_STAT=app.INT_STAT,
                INT_HR_MARKS=app.INT_HR_MARKS
            };

            context.Applicants.Add(res);
            context.SaveChanges();

            return RedirectToAction("CandidateIndex", "Candidate");
        }

        [HttpGet]
        public IActionResult CandidateReg()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CandidateReg(Candidate cad)
        {
            var res = new Candidate()
            {
                C_FNAME = cad.C_FNAME,
                C_LNAME = cad.C_LNAME,
                C_DOB = cad.C_DOB, 
                C_GENDER = cad.C_GENDER,
                C_PHONE = cad.C_PHONE,
                C_EMAIL = cad.C_EMAIL,
                C_PASSWORD = cad.C_PASSWORD,
                C_TYPE = cad.C_TYPE,
                C_AGENT_ID = cad.C_AGENT_ID
            };

            context.Candidates.Add(res);
            context.SaveChanges();

            return RedirectToAction("Index","Home");
        }

        public IActionResult ViewAppliedJobs()
        {
            TempData["c_i_d"] = cid;
            var res = context.Applicants.Where(x => x.APP_C_ID == cid).ToList();
            return View(res);
        }

    }
}
