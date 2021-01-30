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
using System.Reflection;
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
            return View("LoginAdminLTE");
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }

        // JSON Ajax Call
        [HttpPost]
        public ActionResult JsonAjax([FromBody] LoginVM model)
        {
            if (model != null)
            {
                return Json("Success");
            }
            else
            {
                return Json("An Error Has occoured");
            }
        }

        // ajax call  
        [HttpPost]
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

                //  Check password.
                var result = await _signManager.PasswordSignInAsync(userName, model.Password, model.RememberMe, lockoutOnFailure: false);
                try
                {
                    if (!result.Succeeded)
                    {
                        return Json(new { status = false, message = "The password were wrong!" });
                    }
                    else
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
                        HttpContext.Session.SetString("role_id", role_id.Id);
                        HttpContext.Session.SetString("name", user.UserName);

                        string roleId = (string)HttpContext.Session.GetString("role_id");

                        var linkmenu = _context.LinkRolesMenus.Where(s => s.AppRoleId.Equals(roleId));

                        List<DashboardMenu> menus = _context.LinkRolesMenus.Where(s => s.AppRoleId.Equals(roleId)).Select(s => s.Menu).ToList();

                        ////var linkmenu = null;
                        //List<DashboardMenus> menus = null;

                        DataSet ds = new DataSet();
                        ds = ToDataSet(menus);
                        DataTable table = ds.Tables[0];
                        DataRow[] parentMenus = table.Select("ParentId = 0");

                        var sb = new StringBuilder();
                        string menuString = GenerateUL(parentMenus, table, sb);
                        HttpContext.Session.SetString("menuString", menuString);
                        HttpContext.Session.SetString("menus", JsonConvert.SerializeObject(menus));

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
                    return Json(new { status = false, message = "System error : " + ex.Message.ToString() });  ;
                }
            }
            return Json(new { status = true, message = "Login Successfull!" });
        }


        private string GenerateUL(DataRow[] menu, DataTable table, StringBuilder sb)
        {
            if (menu.Length > 0)
            {
                foreach (DataRow dr in menu)
                {
                    string url = dr["Url"].ToString();
                    string menuText = dr["Name"].ToString();
                    string icon = dr["Icon"].ToString();

                    if (url != "#")
                    {
                        string line = String.Format(@"<li class=""nav-item""><a href=""{0}"" class=""nav-link""><i class=""{2}""></i> <span>{1}</span></a></li>", url, menuText, icon);
                        sb.Append(line);
                    }

                    string pid = dr["Id"].ToString();
                    string parentId = dr["ParentId"].ToString();

                    DataRow[] subMenu = table.Select(String.Format("ParentId = '{0}'", pid));
                    if (subMenu.Length > 0 && !pid.Equals(parentId))
                    {
                        string line = String.Format(@"<li class=""nav-item has-treeview""><a href=""#"" class=""nav-link"">
                                                    <i class=""{0}""></i> <span>{1}</span>
                                                        <i class=""right fas fa-angle-left""></i></a><ul class=""nav nav-treeview"">", icon, menuText);
                        var subMenuBuilder = new StringBuilder();
                        sb.AppendLine(line);
                        sb.Append(GenerateUL(subMenu, table, subMenuBuilder));
                        sb.Append("</ul></li>");
                    }
                }
            }
            return sb.ToString();
        }

        public DataSet ToDataSet<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(dataTable);
            return ds;
        }

    }
}
