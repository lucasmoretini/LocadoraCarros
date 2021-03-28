using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraDeCarros.Models
{
    public class ClienteViewModel
    {
        public int Id { get; private set; }
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [Display(Name = "Nome e sobrenome")]
        public string Nome { get; set; }
        public string Telefone { get; set; }
        [Required]
        [Display(Name = "Endereço do cliente")]
        public string Endereco { get; set; }
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
        public string CarteiraDeMotorista { get; set; }

    }
}
