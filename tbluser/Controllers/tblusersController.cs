using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Linq.Expressions;
using tbluser.Controllers.Data;
using tbluser.Migrations;
using tbluser.Models;

namespace tbluser.Controllers
{
    public class tblusersController : Controller
    {
        private readonly UserDbContext _context;

        public tblusersController(UserDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var Users = _context.Users.ToList();
            List<UserViewModel> userlist = new List<UserViewModel>();
            if (Users != null)
            {

                foreach (var User in Users)
                {
                    var UserViewModel = new UserViewModel()
                    {
                        ID = User.ID,
                        FirstName = User.FirstName,
                        LastName = User.LastName,
                        Address = User.Address,
                        PhoneNumber = User.PhoneNumber,
                        EMail = User.EMail,
                        Password = User.Password
                    };
                    userlist.Add(UserViewModel);
                }
                return View(userlist);
            }
            return View(userlist);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(UserViewModel userData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = new tbluser.Models.DBEntities.User()
                    {
                        ID = userData.ID,
                        FirstName = userData.FirstName,
                        LastName = userData.LastName,
                        Address = userData.Address,
                        PhoneNumber = userData.PhoneNumber,
                        EMail = userData.EMail,
                        Password = userData.Password
                    };
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    TempData["successMessage"] = "User Created Successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Model Data is not valid.";
                    return View();
                }

            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }       
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                var user = _context.Users.SingleOrDefault(x => x.ID == id);
                if (user != null)
                {
                    var userView = new tbluser.Models.UserViewModel()
                    {
                        ID = user.ID,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Address = user.Address,
                        PhoneNumber = user.PhoneNumber,
                        EMail = user.EMail,
                        Password = user.Password
                    };
                    return View(userView);
                }
                else
                {
                    TempData["errorMessage"] = $"User Details Not Avialable with the id = {id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
            
            }
        [HttpPost]
        public IActionResult Edit(UserViewModel userView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = new tbluser.Models.DBEntities.User()
                    {
                        ID = userView.ID,
                        FirstName = userView.FirstName,
                        LastName = userView.LastName,
                        Address = userView.Address,
                        PhoneNumber = userView.PhoneNumber,
                        EMail = userView.EMail,
                        Password = userView.Password
                    };
                    _context.Users.Update(user);
                    _context.SaveChanges();
                    TempData["successMessage"] = "User Updated Successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Model Data is not valid.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
           
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                var user = _context.Users.SingleOrDefault(x => x.ID == id);
                if (user != null)
                {
                    var userView = new tbluser.Models.UserViewModel()
                    {
                        ID = user.ID,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Address = user.Address,
                        PhoneNumber = user.PhoneNumber,
                        EMail = user.EMail,
                        Password = user.Password
                    };
                    return View(userView);
                }
                else
                {
                    TempData["errorMessage"] = $"User Details Not Avialable with the id = {id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }

        }
        [HttpPost]
        public IActionResult Delete(UserViewModel userView)
        {
            try
            {
                var user = _context.Users.SingleOrDefault(x => x.ID == userView.ID);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    _context.SaveChanges();
                    TempData["successMessage"] = "User Deleted Successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = $"User Details Not Avialable with the id = {userView.ID}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
                return View();

            }
           
        }


    }

}
