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
                        ModelState.AddModelError("Password",errorItem.Description);
                    } 
                }
            }
            return View(newUserVM);
        }
    }
}
