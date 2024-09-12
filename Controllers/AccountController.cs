using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Login(LoginViewModel userVM)
        {
            if (ModelState.IsValid)
            {
               ApplicationUser userModel= await userManager.FindByNameAsync(userVM.UserName);

                if(userModel is not null)
                {
                   var found= await userManager.CheckPasswordAsync(userModel, userVM.Password);

                    if (found)
                    {
                        //create cookie
                        await signInManager.SignInAsync(userModel, userVM.RememberMe);

                        return RedirectToAction ("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Username and Password invalid");
                }
            }
            return View(userVM);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel newUserVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = new ApplicationUser();
                applicationUser.UserName=newUserVM.Username;
                applicationUser.Email=newUserVM.Email;
                applicationUser.PasswordHash = newUserVM.Password;

               IdentityResult result= await userManager.CreateAsync(applicationUser,newUserVM.Password);

                if (result.Succeeded)
                {
                    //Add to role
                    await userManager.AddToRoleAsync(applicationUser,"User");
                    //Create Cookie

                    await signInManager.SignInAsync(applicationUser, false);
                    //signInManager.SignInWithClaimsAsync
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    //sent error to view

                    foreach (var errorItem in result.Errors)
                    {
                        ModelState.AddModelError("",errorItem.Description);
                    } 
                }
            }
            return View(newUserVM);
        }
        [HttpGet]
        public IActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAdmin(RegisterUserViewModel newUserVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = new ApplicationUser();
                applicationUser.UserName = newUserVM.Username;
                applicationUser.Email = newUserVM.Email;
                applicationUser.PasswordHash = newUserVM.Password;

                IdentityResult result = await userManager.CreateAsync(applicationUser, newUserVM.Password);

                if (result.Succeeded)
                {
                    //Add to role
                    await userManager.AddToRoleAsync(applicationUser, "Admin");
                    //Create Cookie

                    await signInManager.SignInAsync(applicationUser, false);
                    //signInManager.SignInWithClaimsAsync
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    //sent error to view

                    foreach (var errorItem in result.Errors)
                    {
                        ModelState.AddModelError("", errorItem.Description);
                    }
                }
            }
            return View(newUserVM);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
