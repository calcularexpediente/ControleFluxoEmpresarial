﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFluxoEmpresarial.Models.Pessoas
{
    public class Pessoa : BaseEntity
    {
        public string Apelido { get; set; }

        public string Bairro { get; set; }

        public string Cep { get; set; }

        public int CidadeId { get; set; }

        public string Complemento { get; set; }

        public int CondicaoPagamentoId { get; set; }

        public string CPFCPNJ { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Email { get; set; }

        public string Endereco { get; set; }

        public string Nacionalidade { get; set; }

        public string Nome { get; set; }

        public string Numero { get; set; }

        public string Observacao { get; set; }

        public string RgInscricaoEstadual { get; set; }

        public string Telefone { get; set; }
    }
}
