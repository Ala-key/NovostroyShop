using System.ComponentModel.DataAnnotations;

namespace NovostroyShop.Authentication
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Это обьязательное поле")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Это обьязательное поле")]
        public string Password { get; set; }
    }

}
