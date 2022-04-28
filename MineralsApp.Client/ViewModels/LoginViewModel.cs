using System.ComponentModel.DataAnnotations;

namespace MineralsApp.Client.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Логин")]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [UIHint("password")]
        [Display(Name = "пароль")]
        public string Password { get; set; } = string.Empty;
        [Display(Name = "Запомнить меня")]
        public bool RememberMe { get; set; }
    }
}
