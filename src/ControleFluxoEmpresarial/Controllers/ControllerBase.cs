﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleFluxoEmpresarial.DAOs;
using ControleFluxoEmpresarial.Filters.DTO;
using ControleFluxoEmpresarial.Models;
using ControleFluxoEmpresarial.DTO.Filters.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleFluxoEmpresarial.Controllers
{
    //[AllowAnonymous]
    public class ControllerBase<TEntity, TPaginationQuery> : ControllerBase<TEntity, TPaginationQuery, int> where TEntity : IBaseModel<int> where TPaginationQuery : PaginationQuery
    {
        public ControllerBase(IDAO<TEntity, int> dao) : base(dao)
        {
        }
    }

    [Authorize]
    public abstract class ControllerBase<TEntity, TPaginationQuery, TId> : ControllerBase where TEntity : IBaseModel<TId> where TPaginationQuery : PaginationQuery
    {
        protected ControllerBase(IDAO<TEntity, TId> dao)
        {
            DAO = dao ?? throw new ArgumentNullException(nameof(dao));
        }

        public IDAO<TEntity, TId> DAO { get; set; }

        // GET: api/Default/5
        [HttpGet("{id}")]
        public virtual IActionResult Get(TId id)
        {
            var entity = this.DAO.GetByID(id);
            if (entity == null)
            {
                return Ok();
            }

            return Ok(entity);
        }

        // POST: api/Default
        [HttpPost]
        public virtual IActionResult Post([FromBody] TEntity entity)
        {
            var id = this.DAO.Insert(entity);
            return Ok(new CreateResult(id));
        }

        // PUT: api/Default/5
        [HttpPut("{id}")]
        public virtual IActionResult Put([FromBody] TEntity entity, TId id)
        {
            entity.Id = id;
            this.DAO.Update(entity);
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public virtual IActionResult Delete(TId id)
        {
            this.DAO.VerifyRelationshipDependence(id);
            this.DAO.Delete(id);
            return Ok();
        }

        [HttpPost("list")]
        public new IActionResult GetListPagined(TPaginationQuery filter)
        {
            return Ok(this.DAO.GetPagined(filter));
        }
    }
}
