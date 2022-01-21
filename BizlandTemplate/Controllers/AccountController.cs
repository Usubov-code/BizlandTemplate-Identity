using BizlandTemplate.Data;
using BizlandTemplate.Models;
using BizlandTemplate.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizlandTemplate.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;
        public AccountController(AppDbContext context,UserManager<CustomUser> userManager, SignInManager<CustomUser> signInManager )
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(VmRegister model)
        {
            if (!ModelState.IsValid)
            {

                return View();
            }
            else
            {

                if (_context.CustomUsers.Any(c=>c.UserName==model.UserName))
                {
                    ModelState.AddModelError("", "Username Movcuddur!");
                    return View(model);

                }
                else
                {
                    if (_context.CustomUsers.Any(e=>e.Email==model.Email))
                    { 

                        ModelState.AddModelError("", "Email Movcuddur!");
                        return View(model);
                    }

                    CustomUser user = new CustomUser()
                    {
                        FullName=model.FullName,
                        UserName=model.UserName,
                        Email=model.Email,

                    };

                    var result = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, false);
                        return RedirectToAction("login", "account");

                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {

                            ModelState.AddModelError("", "Passworda problem var!");
                        }


                    }

                    return View(model);


                }


            }

        }
        
        public IActionResult Login()
        {


            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Login( VmLogin model)
        {

            if (!ModelState.IsValid)
            {

                return View();
            }

            CustomUser member = _userManager.Users.FirstOrDefault(x => x.NormalizedEmail == model.Email.ToUpper());

            if (member==null)
            {

                ModelState.AddModelError("", "Member Yoxdur");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if ( ! result.Succeeded)
            {
                ModelState.AddModelError("", "Email ve ya parol sehvdir!");

            }

            return RedirectToAction("index","home");
       
            
        }

      
        public async Task<IActionResult> Logout()
        {

            await _signInManager.SignOutAsync();
            return RedirectToAction("login");


        }



    }
}
