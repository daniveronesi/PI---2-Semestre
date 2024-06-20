using System.ComponentModel.DataAnnotations;

namespace InnovaAgroTech.Models
{
    public class Cultivador
    {
        [Key]
        [Required(ErrorMessage = "Campo CNPJ é obrigatório!", AllowEmptyStrings = false)]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "CNPJ inválido.")]
        public int CNPJ { get; set; }

        [StringLength(20, MinimumLength = 8, ErrorMessage = "número inválido.")]
        public int Telefone { get; set; }

        [Required(ErrorMessage = "Campo Senha é obrigatório!", AllowEmptyStrings = false)]
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int Numero { get; set; }
        [StringLength(8, MinimumLength = 8, ErrorMessage = "CEP inválido.")]
        public int CEP { get; set; }
        public string NomeProp { get; set; }

        public string Nome { get; set; }
        public bool Sexo { get; set; }
        [Required(ErrorMessage = "Campo Registro CONFEA/CREA é obrigatório!", AllowEmptyStrings = false)]
        [StringLength(10, MinimumLength = 7, ErrorMessage = "Número inválido.")]
        public int Registro_Conselho { get; set; }
        [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF inválido.")]
        public int CPF { get; set; }
        public DateOnly Data_Nasc { get; set; }

        public int Cultura { get; set; }
        public string Cultivo { get; set; }
        public string Categoria { get; set; }
        
        [Required(ErrorMessage = "Campo Id é obrigatório!", AllowEmptyStrings = false)]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "Mínimo de 6 e máximo de 16 caracteres.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Senha é obrigatório!", AllowEmptyStrings = false)]
        public string Senha { get; set; }

        public string Usuario_Niveis { get; set; }

        public string Email { get; set; }

        public Cultivador()
        {
            this.CNPJ = 0;
            this.Telefone = 0;
            this.Logradouro = "";
            this.Complemento = "";
            this.Cidade = "";
            this.Estado = "";
            this.Numero = 0;
            this.CEP = 0;
            this.Nome = "";
            this.Sexo = false;
            this.Registro_Conselho = 0;
            this.CPF = 0;
            this.Data_Nasc = new DateOnly();
            this.Cultura = 0;
            this.Cultivo = string.Empty;
            this.Categoria = string.Empty;
            this.Id = 0;
            this.Senha = string.Empty;
            this.Usuario_Niveis = string.Empty;
            this.Email = string.Empty;
            this.NomeProp= string.Empty;
        }


    }
}
