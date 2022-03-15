using api.Enums;
using api.Models;
using Microsoft.AspNetCore.Mvc;

/*
Olá, Rodolfo Lyu Shimotsu! Tudo bem?

Ficamos felizes de ver você chegar até aqui com a gente!

Gostamos do seu perfil e, por isso, selecionamos você para a 3ª etapa do nosso processo seletivo:
desafio técnico + entrevista com um Gerente de Desenvolvimento.

Abaixo, estão as instruções para o desenvolvimento do desafio:

A partir de hoje, vamos efetuar um teste de desenvolvimento Web. Nosso Gerente de Desenvolvimento
solicitou a criação de um projeto com as seguintes tecnologias:

• Angular JS 1.7.8 
• C# 

Ele solicitou que o projeto use a arquitetura MVC no C# para ser algo pequeno. Para os processos e regras, 
ele solicitou que: 

O sistema tenha um login que valide somente o usuário e senha. 
Usuário: SISTEMA
Senha: canditado123

O sistema deverá fazer login e, na tela principal, você poderá fazer:

• Um menu lateral para abrir o cadastro ou abrir diretamente o cadastro de usuário;

O cadastro de usuário deverá conter os campos de:

• Código; 
• Nome; 
• CPF; 
• Endereço; 
• Telefone; 

Observações: Os campos “nome” e “CPF” são obrigatórios; os demais, não.

Após o usuário clicar em “salvar”, o Angular deverá mandar para o C# uma requisição JSON para salvar o 
registro. Esta requisição deverá ser tratada e retornar para o Angular a mensagem "Pessoa cadastrada 
com sucesso, código " + Os primeiros 4 dígitos numerais do CPF. 

O desafio não exige conhecimentos de banco de dados, mas sinta-se livre para nos surpreender com melhorias 
nesse projeto. 

Caso você não consiga prosseguir em alguma parte, nos envie até onde você conseguiu ir neste projeto. 

* O prazo para finalização do desafio é de 7 dias a partir de amanhã. Depois de recebermos o projeto, 
* iremos marcar entrevista com o Gerente de Desenvolvimento.

Boa sorte! :)
 */
namespace api.Controllers
{
    [Route("Login")]
    public class LoginControl : Controller
    {
        [HttpPost("Login")]
        public RespostaModel Login([FromBody] LoginModel login)
        {
            //Precisa utilizar um método para verificar o usuario e senha em um banco de dados
            if (login.usuario == "SISTEMA" && login.senha == "canditado123")
            {
                return new RespostaModel
                {
                    Resultado = true,
                    Mensagem = "Login realizado com sucesso!"
                };
            }

            return new RespostaModel
            {
                Resultado = false,
                Mensagem = "USUÁRIO ou SENHA incorreto!"
            };
        }

        [HttpPost("Cadastro")]
        public RespostaCadastro Cadastro([FromBody] CadastroModel cadastro, RegisterValidate registerValidate)
        {
            //Os campos “nome” e “CPF” são obrigatórios; os demais, não.
            //login e senha obrigatório
            if (string.IsNullOrWhiteSpace(cadastro.Nome) || string.IsNullOrWhiteSpace(cadastro.Cpf) ||
                string.IsNullOrWhiteSpace(cadastro.Usuario) || string.IsNullOrWhiteSpace(cadastro.Senha))
            {
                return new RespostaCadastro
                {
                    Resultado = CadastroResultadoEnum.Validacao,
                    Mensagem = "Preencha os campos obrigatórios!"
                };
            }

            if (cadastro.Usuario == "adm")
            {
                return new RespostaCadastro
                {
                    Resultado = CadastroResultadoEnum.Erro,
                    Mensagem = "Erro! Nome de usuário não pode ser utilizado!"
                };
            }
            
            //Inserir validações************************
            if (registerValidate.CpfValidate(cadastro.Cpf) &&
                registerValidate.CpfValidate(cadastro.Telefone) &&
                registerValidate.CpfValidate(cadastro.Usuario) &&
                registerValidate.SenhaValidate(cadastro.Senha))
            {
                //Esta requisição deverá ser tratada e retornar para o Angular a mensagem "Pessoa cadastrada 
                //com sucesso, código " + Os primeiros 4 dígitos numerais do CPF. 

                return new RespostaCadastro
                {
                    Resultado = CadastroResultadoEnum.Sucesso,
                    Mensagem = "Usuário " + cadastro.Cpf.Substring(0, 4) + "... cadastrado com sucesso!"
                };
            }

            else
            {
                return new RespostaCadastro
                {
                    Resultado = CadastroResultadoEnum.Erro,
                    Mensagem = "As informações não estão corretas!"
                };
            }

            /*
            return new RespostaCadastro
            {
                Resultado = CadastroResultadoEnum.Sucesso,
                Mensagem = "Usuário " + cadastro.Cpf.Substring(0, 4) + "... cadastrado com sucesso!"
            };*/
        }
    }
}
