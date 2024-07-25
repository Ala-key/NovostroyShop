using System.ComponentModel.DataAnnotations;

namespace NovostroyShop.Authentication
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Это обьязательное поле")]
        public string Username { get; set; }

        [EmailAddress(ErrorMessage = "Это не соотвествует формату Email")]
        [Required(ErrorMessage = "Это обьязательное поле")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Это обьязательное поле")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }

}
