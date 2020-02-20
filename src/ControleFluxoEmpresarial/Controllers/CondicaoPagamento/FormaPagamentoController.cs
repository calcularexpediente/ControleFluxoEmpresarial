﻿using ControleFluxoEmpresarial.DAOs;
using ControleFluxoEmpresarial.DAOs.CondicaoPagamento;
using ControleFluxoEmpresarial.Filters.ModelView;
using ControleFluxoEmpresarial.Models.CondicaoPagamento;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFluxoEmpresarial.Controllers.CondicaoPagamento
{
    [Route("api/forma-pagamento")]
    [ApiController]
    public class FormaPagamentoController : ControllerBase<FormaPagamento>
    {
        public FormaPagamentoController(FormaPagamentoDAO dAO) : base(dAO)
        {
        }

        [HttpPost("list")]
        public new IActionResult GetListPagined(PaginationQuery filter)
        {
            return Ok(this.DAO.GetPagined(filter));
        }
    }
}
