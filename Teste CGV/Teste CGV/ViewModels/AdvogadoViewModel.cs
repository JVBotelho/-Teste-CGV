using System;
using System.ComponentModel.DataAnnotations;

namespace Teste_CGV.ViewModels
{
    [Serializable]
    public class AdvogadoViewModel
    {
        [Key]
        public Guid ID { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }

        [Required(ErrorMessage = "Campo Nome Obrigatorio")]
        [MinLength(2, ErrorMessage = "Minimo de {0} Caracteres")]
        public string Nome { get; set; }
        public string Senioridade { get; set; }
        public string Endereco { get; set; }
    }
}
