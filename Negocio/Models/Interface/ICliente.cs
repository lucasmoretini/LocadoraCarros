using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Models.Interface
{
    public interface ICliente
    {
        Cliente ObterCliente(int id);
        Cliente ObterClientePorEmail(string email);
        List<Cliente> ObterListaCliente();
        bool Inserir(Cliente novoCliente);
        bool Editar(Cliente clienteEditado);
        bool Excluir(int id);
    }
}
