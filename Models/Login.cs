using System.ComponentModel.DataAnnotations;

namespace InnovaAgroTech.Models
{
    public class Login
    {
        [Key]

        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Senha é obrigatório!", AllowEmptyStrings = false)]
        public string Senha { get; set; }

        public string Usuario_Niveis { get; set; }

        public string Email { get; set; }

        public Login()
        {
            this.Id = 0;
            this.Senha = string.Empty;
            this.Usuario_Niveis = string.Empty;
            this.Email = string.Empty;
        }
    }
}
