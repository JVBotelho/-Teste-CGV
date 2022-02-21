using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Advogado
{
    [Serializable]
    public class Advogado
    {
        public Guid ID { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }
        public string Nome { get; set; }
        public string Senioridade { get; set; }
        public string Endereco { get; set; }
    }
}
