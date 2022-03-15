namespace api.Enums
{
    public enum CadastroResultadoEnum
    {
        Sucesso,
        Validacao,
        Erro
    }

    public class RespostaEnums
    {
        public CadastroResultadoEnum Resultado { get; set; }
    }
}
