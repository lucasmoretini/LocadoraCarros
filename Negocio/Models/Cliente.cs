using Negocio.Models.Interface;
using Negocio.ServicoNegocio.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Models
{
    public class Cliente
    {

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Endereco { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public string CarteiraDeMotorista { get; private set; }
        public string CartaoDeCredito { get; private set; }

        public Cliente()
        {

        }

        public Cliente(int id, string nome, string endereco, string telefone, string email, string carteira, string cartaoCredito)
        {
            Id = id;
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            Email = email;
            CarteiraDeMotorista = carteira;
            CartaoDeCredito = cartaoCredito;
        }

        public bool EmailEstaDuplicado(IClienteServico clienteServico)
        {
            var clienteEmail = clienteServico.ObterClientePorEmail(this.Email);

            if (clienteEmail != null)
            {
                if (clienteEmail.Id != this.Id)
                    return true;
            }

            return false;
        }
    }
}
