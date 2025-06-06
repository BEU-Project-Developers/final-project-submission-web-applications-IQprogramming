﻿using System.ComponentModel.DataAnnotations;

namespace SDF1.ViewModels;

public class LoginViewModel
{
    [Required]
    [Display(Name = "Username or Email")]
    public string Login { get; set; }

    [Required, DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [Display(Name = "Remember Me")] public bool RememberMe { get; set; }
}
