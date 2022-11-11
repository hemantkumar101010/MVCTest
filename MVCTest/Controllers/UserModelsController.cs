using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCTest.Data;
using MVCTest.Models;


namespace MVCTest.Controllers
{
    public class UserModelsController : Controller
    {
        private readonly UserDbContext _context;

        public UserModelsController(UserDbContext context)
        {
            _context = context;
        }

        // GET: UserModels
        public async Task<IActionResult> Index()
        {
            CommonModel commonModel = new CommonModel();
            var data = await _context.Users.ToListAsync();
            commonModel.Model1 = data;

            ViewBag.AllCList = new List<SelectListItem>()
            {
              new SelectListItem(){Text="MCA",Value="MCA"},
                new SelectListItem(){Text="BCA",Value="BCA"},
                  new SelectListItem(){Text="BTech",Value="BTech"},
                  new SelectListItem(){Text="BSc",Value="BSc"},
                new SelectListItem(){Text="MBA",Value="MBA"},
                  new SelectListItem(){Text="BBA",Value="BBA"}
            };
            return View(commonModel);
        }


        // POST: UserModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( CommonModel commonModel)
        {

            commonModel.userModel.Courses = "";
            //  var list = userModel.
            foreach ( var item in commonModel.courseModel.selectedCourses)
            {
                commonModel. userModel.Courses += $"{item} ";
            }
            _context.Add(commonModel.userModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]

        public bool CheckEmailExists(string email)
        {
            bool result = _context.Users.Any(x => x.Email == email);
            return result;
        }


        [AcceptVerbs("GET", "POST")]
        public  bool IsPhoneValid(string phoneNumber)
        {
            string regex = @"^([\+]?33[-]?|[0])?[1-9][0-9]{8}$";
            if (phoneNumber != null)
                return Regex.IsMatch(phoneNumber, regex);
            else return false;
        }
    }
}
