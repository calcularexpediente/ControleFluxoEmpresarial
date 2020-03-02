﻿using ControleFluxoEmpresarial.DAOs.CondicaoPagamentos;
using ControleFluxoEmpresarial.Filters.ModelView;
using ControleFluxoEmpresarial.Models.CondicaoPagamentos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFluxoEmpresarial.Controllers.CondicaoPagamentos
{
    [Route("api/condicao-pagamento")]
    [ApiController]
    public class CondicaoPagamentoController : ControllerBase<CondicaoPagamento>
    {
        public CondicaoPagamentoController(CondicaoPagamentoDAO dAO) : base(dAO)
        {
        }

        [HttpPost("list")]
        public new IActionResult GetListPagined(PaginationQuery filter)
        {
            return Ok(this.DAO.GetPagined(filter));
        }
    }
}