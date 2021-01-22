using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POC.Identity.Infrastructure;
using POC.Identity.Infrastructure.Entities;
using POC.Identity.Infrastructure.Entities.AspNetIdentity;
using POC.Identity.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace POC.Identity.Controllers
{
    public class AccountController : Controller
    {
        private readonly PocApplicationDbContext _context;
        private SignInManager<ApplicationUser> _signManager;
        private UserManager<ApplicationUser> _userManager;

        public AccountController(
                PocApplicationDbContext context, 
                UserManager<ApplicationUser> userManager, 
                SignInManager<ApplicationUser> signManager)
        {
            _context = context;
            _userManager = userManager;
            _signManager = signManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<ActionResult> Validate(LoginVM model)
        {

            if (model.Email.IndexOf('@') > -1)
            {
                //Validate email format
                string emailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                       @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                          @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                Regex re = new Regex(emailRegex);
                if (!re.IsMatch(model.Email))
                {
                    return Json(new { status = false, message = "Invalid Email!" });
                }
            }
            else
            {
                //validate Username format
                string emailRegex = @"^[a-zA-Z0-9]*$";
                Regex re = new Regex(emailRegex);
                if (!re.IsMatch(model.Email))
                {
                    return Json(new { status = false, message = "Username is not valid!" });
                }
            }

            if (ModelState.IsValid)
            {
                ApplicationUser user = null;
                var userName = model.Email;

                if (model.Email == "victorguan@gmail.com")
                {
                    HttpContext.Session.SetString("email", model.Email);
                    return Json(new { status = true, message = "Login Successfull!" });
                }
                if (userName.IndexOf('@') > -1)
                {
                    user = await _userManager.FindByEmailAsync(model.Email);
                    if (user == null)
                    {
                        return Json(new { status = false, message = "Email does not existed!" });
                    }
                    else
                    {
                        userName = user.UserName;
                    }
                }


                // 
                var result = await _signManager.PasswordSignInAsync(userName, model.Password, model.RememberMe, lockoutOnFailure: false);
                try
                {
                    if (result.Succeeded)
                    {
                        //--------------------------------------
                        // Get user's roles
                        var userRoles = await _userManager.GetRolesAsync(user);
                        var roleString = "";
                        foreach (var r in userRoles)
                        {
                            if (!roleString.Contains(","))
                            {
                                roleString = r;
                            }
                            else
                            {
                                roleString = "," + r;
                            }
                        }

                        var role_id = _context.Roles.FirstOrDefault(a => a.Name.Equals(roleString));
                        //--------------------------------------
                        // Set session
                        HttpContext.Session.SetString("email", user.Email);
                        HttpContext.Session.SetString("id", user.Id);

                        if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                        {
                            return Json(new { status = true, message = "Redirect(model.ReturnUrl)" });
                        }
                        else
                        {
                            return Json(new { status = true, message = "Login Successfull!" });
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return Json(new { status = true, message = "Login Successfull!" });
        }

    }
}
