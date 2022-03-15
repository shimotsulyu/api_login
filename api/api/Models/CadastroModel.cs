/*
• Código; 
• Nome; 
• CPF; 
• Endereço; 
• Telefone; 
 */
namespace api.Models
{
    public class CadastroModel
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}
