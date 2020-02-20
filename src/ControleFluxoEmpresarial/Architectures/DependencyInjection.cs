﻿using ControleFluxoEmpresarial.DAOs.Associados;
using ControleFluxoEmpresarial.DAOs.Cidades;
using ControleFluxoEmpresarial.DAOs.Clients;
using ControleFluxoEmpresarial.DAOs.CondicaoPagamento;
using ControleFluxoEmpresarial.DAOs.Users;
using ControleFluxoEmpresarial.Models.Cidades;
using ControleFluxoEmpresarial.Models.Clients;
using ControleFluxoEmpresarial.Models.CondicaoPagamento;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFluxoEmpresarial.Architectures
{
    public static class DependencyInjection
    {
        public static void ResolveInjection(this IServiceCollection services)
        {
            services.AddScoped<UserDAO>();
            services.AddScoped<PaisDAO>();
            services.AddScoped<EstadoDAO>();
            services.AddScoped<CidadeDAO>();
            services.AddScoped<ClientDAO>();
            services.AddScoped<TitularDAO>();
            services.AddScoped<AssociadoDAO>();
            services.AddScoped<FormaPagamentoDAO>();


            services.AddTransient<IValidator<Pais>, PaisValidator>();
            services.AddTransient<IValidator<Estado>, EstadoValidator>();
            services.AddTransient<IValidator<Cidade>, CidadeValidator>();
            services.AddTransient<IValidator<Client>, ClientValidator>();
            services.AddTransient<IValidator<FormaPagamento>, FormaPagamentoValidator>();


        }
    }
}
