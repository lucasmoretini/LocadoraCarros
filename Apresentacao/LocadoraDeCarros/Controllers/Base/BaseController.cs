using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraDeCarros.Controllers.Base
{
    public class BaseController : Controller
    {
        public void MensagemGeral(string mensagem, string tipoMensagem)
        {
            if (tipoMensagem == "Error")
                ViewData["error"] = "erro";
            else if (tipoMensagem == "Warning")
                ViewData["warning"] = "warning";
            else if (tipoMensagem == "Success")
                ViewData["success"] = "success";
            else
                ViewData["info"] = "info";

            ViewData["Mensagem"] = mensagem;
        }
    }
}
