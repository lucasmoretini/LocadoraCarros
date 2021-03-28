using AutoMapper;
using Dados.Contexts;
using Dados.Models;
using Negocio.Models;
using Negocio.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados.Repository
{
    public class ClienteRepository : ICliente
    {
        readonly IMapper _mapper;
        readonly LocadoraDbContext _dbContext;

        public ClienteRepository(IMapper mapper, LocadoraDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public Cliente ObterCliente(int id)
        {
            ClienteDataModel clienteDM = _dbContext.Cliente.FirstOrDefault(cliente => cliente.Id == id);

            return _mapper.Map<Cliente>(clienteDM);
        }

        public Cliente ObterClientePorEmail(string email)
        {
            ClienteDataModel clienteDM = _dbContext.Cliente.FirstOrDefault(cliente => cliente.Email == email);

            return _mapper.Map<Cliente>(clienteDM);
        }

        public List<Cliente> ObterListaCliente()
        {
            List<ClienteDataModel> lstClientes = _dbContext.Cliente.ToList();

            return _mapper.Map<List<Cliente>>(lstClientes);
        }

        public bool Editar(Cliente clienteEditado)
        {
            try
            {
                var clienteUpdade = _dbContext.Cliente.FirstOrDefault(cliente => cliente.Id == clienteEditado.Id);
                _mapper.Map(clienteEditado, clienteUpdade);
                _dbContext.Cliente.Update(clienteUpdade);
                _dbContext.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public bool Inserir(Cliente novoCliente)
        {
            try
            {
                _dbContext.Cliente.Add(_mapper.Map<ClienteDataModel>(novoCliente));
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Excluir(int id)
        {
            try
            {
                var clienteExcluir = _dbContext.Cliente.FirstOrDefault(cliente => cliente.Id == id);
                _dbContext.Cliente.Remove(clienteExcluir);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
           
        }
    }
}