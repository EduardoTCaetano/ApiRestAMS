using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apidotnet.Entity;
using apidotnet.Model;
using apidotnet.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace apidotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivroController : ControllerBase
    {
        public LivroRepository<Livro> Service { get; }
        public IMapper Mapper { get; }
        public LivroController(LivroRepository<Livro> service, IMapper mapper)
        {
            this.Mapper = mapper;
            this.Service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var entity = await this.Service.GetAll();
            var results = this.Mapper.Map<Livro[]>(entity);
            return Ok(entity);
        }

        [HttpGet("{LivroId}")]
        public async Task<IActionResult> GetById(string LivroId)
        {
            var entity = await this.Service.GetById(LivroId);
            var results = this.Mapper.Map<LivroModel>(entity);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Post(LivroModel livro)
        {
            var book = this.Mapper.Map<Livro>(livro);

            this.Service.Add(book);

            if (await this.Service.Save())
                return Created($"api/Livro/{livro.Id}", livro);
            return BadRequest();
        }


        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(string Id, LivroModel model)
        {
            var entity = await this.Service.GetById(Id);

            if (entity == null) return NotFound();
            this.Mapper.Map(model, entity);
            this.Service.Update(entity);

            if (await this.Service.Save())

                return Created($"api/Livro/{model.Id}", this.Mapper.Map<LivroModel>(entity));
            return BadRequest();
        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(string Id)
        {
            var entity = await this.Service.GetById(Id);

            if (entity == null) return NotFound();
            this.Service.Delete(entity);

            if (await this.Service.Save())
                return Ok();
            return BadRequest();
        }

    }
}