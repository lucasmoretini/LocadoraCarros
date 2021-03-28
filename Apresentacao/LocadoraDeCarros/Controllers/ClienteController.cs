using AutoMapper;
using LocadoraDeCarros.Controllers.Base;
using LocadoraDeCarros.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Models;
using Negocio.ServicoNegocio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraDeCarros.Controllers
{
    public class ClienteController : BaseController
    {
        readonly IMapper _mapper;
        readonly IClienteServico _clienteServico;
        public ClienteController(IMapper mapper, IClienteServico clienteServico)
        {
            _mapper = mapper;
            _clienteServico = clienteServico;
        }

        // GET: ClienteController
        public ActionResult Index()
        {
            var listaClienteVM = _mapper.Map<List<ClienteViewModel>>(_clienteServico.ObterListaClientes());

            return View(listaClienteVM);
        }

        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {
            ClienteViewModel clienteVM = _mapper.Map<ClienteViewModel>(_clienteServico.ObterClientePorID(id));

            return View(clienteVM);
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View(new ClienteViewModel());
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel clienteVM)
        {
            try
            {
                var novoCliente = _mapper.Map<Cliente>(clienteVM);

                //TO DO: validar regra de negócio   
                if (novoCliente.EmailEstaDuplicado(_clienteServico))
                    ModelState.AddModelError("Email", "O email ja existe no banco de dados");

                if (ModelState.IsValid)
                {
                    if (_clienteServico.Inserir(novoCliente))
                    {
                        MensagemGeral("Cliente foi inserido com sucesso", "Info");
                        return RedirectToAction(nameof(Index));
                    }
                }

                MensagemGeral("Ocorreu algum erro ao inserir o novo cliente", "Error");
                return View(clienteVM);

            }
            catch
            {
                MensagemGeral("Ocorreu alguma exception ao inserir o novo cliente", "Error");
                return View(clienteVM);
            }
        }

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            var clienteEditar = _mapper.Map<ClienteViewModel>(_clienteServico.ObterClientePorID(id));

            return View(clienteEditar);
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel clienteVM)
        {
            try
            {
                var clienteEditado = _mapper.Map<Cliente>(clienteVM);

                //TO DO: validar regra de negócio   
                if (clienteEditado.EmailEstaDuplicado(_clienteServico))
                    ModelState.AddModelError("Email", "O email ja existe no banco de dados");

                if (ModelState.IsValid)
                {
                    if (_clienteServico.Editar(clienteEditado))
                    {
                        MensagemGeral("Cliente foi editado com sucesso", "Info");
                        return RedirectToAction(nameof(Index));
                    }
                }

                MensagemGeral("Ocorreu algum erro ao editar o cliente", "Error");
                return View(clienteVM);

            }
            catch
            {
                MensagemGeral("Ocorreu alguma exception ao editar o cliente", "Error");
                return View(clienteVM);
            }
        }

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            var clienteExcluir = _mapper.Map<ClienteViewModel>(_clienteServico.ObterClientePorID(id));

            return View(clienteExcluir);
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ClienteViewModel clienteExcluir)
        {
            try
            {
                if (_clienteServico.Excluir(clienteExcluir.Id))
                {
                    MensagemGeral("Cliente foi excluido com sucesso", "Info");
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    MensagemGeral("Ocorreu algum erro ao excluir o cliente", "Error");
                    return View(clienteExcluir);
                }
            }
            catch
            {
                MensagemGeral("Ocorreu alguma exception ao excluir o novo cliente", "Error");
                return View(clienteExcluir);
            }
        }
    }
}
