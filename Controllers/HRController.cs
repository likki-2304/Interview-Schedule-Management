using Interview_Schedule_Management.Data;
using Interview_Schedule_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Interview_Schedule_Management.Controllers
{
    public class HRController : Controller
    {
        private readonly ApplicationContext context;
        public static int Id;
        static string hrname;

        public HRController(ApplicationContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult HRLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult HRLogin(Candidate candidate)
        {
            if(ModelState.IsValid)
            {
                var data = context.Candidates.Where(e => e.C_EMAIL == candidate.C_EMAIL).SingleOrDefault();
                
                if (data != null)
                {
                    bool isValid = (data.C_EMAIL == candidate.C_EMAIL && data.C_PASSWORD == candidate.C_PASSWORD);
                    if (isValid)
                    {
                        //TempData["ID"] = data.C_ID;
                        Id = data.C_ID;
                        hrname = data.C_FNAME + " " + data.C_LNAME;
                        return RedirectToAction("HRIndex", "HR");
                    }
                    else
                    {
                        TempData["msgPass"] = "Passowrd Invalid!";
                        return View(candidate);
                    }
                }
                else
                {
                    TempData["msgUsername"] = "Username not found!";
                    return View(candidate);
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult HRIndex()
        {
            //Id = Convert.ToInt32(TempData["ID"]);
            TempData["ID"] = Id;
            TempData["hr_name"] = hrname;
            var result = context.Jobs.Where(e => e.HR_ID == Id).ToList();
            return View(result);
        }

        [HttpGet]
        public IActionResult AddNewJobs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewJobs(Job job)
        {
            if (ModelState.IsValid)
            {
                var jb = new Job()
                {
                    HR_ID=Id,
                    REQ_ID=job.REQ_ID,
                    COMPANY_NAME=job.COMPANY_NAME,
                    REQ_VAC=job.REQ_VAC,
                    REQ_EXP=job.REQ_EXP,
                    DOMAIN=job.DOMAIN,
                    CLOSING_DATE=job.CLOSING_DATE,
                    PRIORITY=job.PRIORITY,
                    INT_TYPE=job.INT_TYPE
                };
                context.Jobs.Add(jb);
                context.SaveChanges();

                return RedirectToAction("HRIndex","HR");
            }
     
           return View(job);
        }

        [HttpGet]
        public IActionResult EditJob(int id)
        {
            var job = context.Jobs.SingleOrDefault(e => e.JOB_ID == id);

            var res = new Job()
            {
                JOB_ID=job.JOB_ID,
                HR_ID = job.HR_ID,
                REQ_ID = job.REQ_ID,
                COMPANY_NAME = job.COMPANY_NAME,
                REQ_VAC = job.REQ_VAC,
                REQ_EXP = job.REQ_EXP,
                DOMAIN = job.DOMAIN,
                CLOSING_DATE = job.CLOSING_DATE,
                PRIORITY = job.PRIORITY,
                INT_TYPE = job.INT_TYPE
            };
            return View(res);
        }

        [HttpPost]
        public IActionResult EditJob(Job job)
        {
            var adm = new Job()
            {
                JOB_ID = job.JOB_ID,
                HR_ID = job.HR_ID,
                REQ_ID = job.REQ_ID,
                COMPANY_NAME = job.COMPANY_NAME,
                REQ_VAC = job.REQ_VAC,
                REQ_EXP = job.REQ_EXP,
                DOMAIN = job.DOMAIN,
                CLOSING_DATE = job.CLOSING_DATE,
                PRIORITY = job.PRIORITY,
                INT_TYPE = job.INT_TYPE
            };
            context.Jobs.Update(adm);
            context.SaveChanges();

            return RedirectToAction("HRIndex","HR");
        }

        public IActionResult DeleteJob(int id)
        {
            var adm = context.Jobs.SingleOrDefault(x => x.JOB_ID == id);
            context.Jobs.Remove(adm);
            context.SaveChanges();
            //TempData["error"] = "Record Deleted!";
            return RedirectToAction("HRIndex","HR");
        }

        [HttpGet]
        public IActionResult EditAspirants(int id)
        {
            var app = context.Applicants.SingleOrDefault(x => x.APP_ID == id);

            var res = new AspirantApplication()
            {
                APP_ID=app.APP_ID,
                APP_NAME = app.APP_NAME,
                APP_EXP = app.APP_EXP,
                APP_C_ID = app.APP_C_ID,
                APP_REFF_ID = app.APP_REFF_ID,
                APP_QUALI = app.APP_QUALI,
                APP_INT_TYPE = app.APP_INT_TYPE,
                INT_STAT = app.INT_STAT,
                INT_HR_MARKS = app.INT_HR_MARKS
            };

            return View(res);
        }

        [HttpPost]
        public IActionResult EditAspirants(AspirantApplication app)
        {
            var res = new AspirantApplication()
            {
                APP_ID = app.APP_ID,
                APP_NAME = app.APP_NAME,
                APP_EXP = app.APP_EXP,
                APP_C_ID = app.APP_C_ID,
                APP_REFF_ID = app.APP_REFF_ID,
                APP_QUALI = app.APP_QUALI,
                APP_INT_TYPE = app.APP_INT_TYPE,
                INT_STAT = app.INT_STAT,
                INT_HR_MARKS = app.INT_HR_MARKS
            };

            context.Applicants.Update(res);
            context.SaveChanges();

            return RedirectToAction("ViewAllJobs", "Admin");
        }

        public IActionResult HRApplicantView(int id)
        {
            var res = context.Applicants.Where(x => x.APP_REFF_ID == id).ToList();
            return View(res);
        }
    }
}
