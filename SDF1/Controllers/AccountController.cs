using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SDF1.Models;
using SDF1.ViewModels;

// your AppUser class (IdentityUser)

// your LoginViewModel & RegisterViewModel

namespace SDF1.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public AccountController(
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    // --------------------------------------------------------
    // REGISTER
    // --------------------------------------------------------

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Register(string returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel vm, string returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;

        if (!ModelState.IsValid)
            return View(vm);

        // 1) Check if email or username is already taken
        var existingByUserName = await _userManager.FindByNameAsync(vm.UserName.Trim());
        if (existingByUserName != null)
        {
            ModelState.AddModelError(string.Empty, "Username is already taken.");
            return View(vm);
        }

        var existingByEmail = await _userManager.FindByEmailAsync(vm.Email.Trim());
        if (existingByEmail != null)
        {
            ModelState.AddModelError(string.Empty, "Email is already registered.");
            return View(vm);
        }

        // 2) Create new AppUser
        var user = new AppUser
        {
            Email = vm.Email.Trim(),
            UserName = vm.UserName.Trim(),
            FullName = vm.FullName.Trim()
        };

        var createResult = await _userManager.CreateAsync(user, vm.Password);
        if (!createResult.Succeeded)
        {
            foreach (var error in createResult.Errors)
                ModelState.AddModelError(string.Empty, error.Description);
            return View(vm);
        }

        // 3) Auto-sign in after successful registration
        await _signInManager.SignInAsync(user, isPersistent: false);

        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            return Redirect(returnUrl);

        return RedirectToAction("Index", "Home");
    }

    // --------------------------------------------------------
    // LOGIN
    // --------------------------------------------------------

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Login(string returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel vm, string returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;

        if (!ModelState.IsValid)
            return View(vm);

        // 1) Try finding by username
        var user = await _userManager.FindByNameAsync(vm.Login.Trim());

        // 2) If not found by username, try by email
        if (user == null)
            user = await _userManager.FindByEmailAsync(vm.Login.Trim());

        // 3) If still null, reject
        if (user == null)
        {
            ModelState.AddModelError(string.Empty, "Wrong username/email or password.");
            return View(vm);
        }

        // 4) Attempt sign-in
        var result = await _signInManager.PasswordSignInAsync(
            user.UserName.Trim(),
            vm.Password,
            vm.RememberMe,
            lockoutOnFailure: false);

        if (result.Succeeded)
        {
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            return RedirectToAction("Index", "Home");
        }

        if (result.IsLockedOut)
        {
            ModelState.AddModelError(string.Empty, "This account has been locked out. Try again later.");
            return View(vm);
        }

        // Invalid credentials
        ModelState.AddModelError(string.Empty, "Wrong username/email or password.");
        return View(vm);
    }

    // --------------------------------------------------------
    // LOGOUT
    // --------------------------------------------------------

    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login", "Account");
    }
}
