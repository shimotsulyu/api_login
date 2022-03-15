using api.Enums;

namespace api.Models
{
    public class RespostaModel
    {
        public bool Resultado { get; set; }
        public string Mensagem { get; set; }

    }

    public class RespostaCadastro
    {
        public CadastroResultadoEnum Resultado { get; set; }
        public string Mensagem { get; set; }
    }
}
