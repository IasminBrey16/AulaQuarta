using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using API.Data;
using API.Models;
using System;

namespace API.Controllers
{
    [ApiController]
    [Route("api/produto")]
    public class ProdutoController : ControllerBase
    {
        private readonly DataContext _context;
        public ProdutoController(DataContext context)
        {
            _context = context;
        }

        // POST: /api/produto/create
        [Route("create")]
        [HttpPost]
        public IActionResult Create([FromBody] Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return Created("", produto);
        }

        // GET: /api/produto/list
        [Route("list")]
        [HttpGet]
        public IActionResult List() => Ok(_context.Produtos.ToList());

        //GET api/produto/getbyid/1
        [Route("getbyid/{id}")]
        [HttpGet]
        public IActionResult GetById([FromRoute] int id)
        {
            //buscar um obj pela chave primária
            Produto produto = _context.Produtos.Find(id);
            if (produto == null)
            {
                return NotFound();//404
            }
            return Ok(produto);//200
        }

        //DELETE: api/produto/delete/1
        [Route("delete/{id}")]
        [HttpDelete]
        public IActionResult Delete([FromRoute] int id)
        {
            Produto produto = _context.Produtos.Find(id);
            if (produto == null)
            {
                return NotFound();
            }
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return Ok(_context.Produtos.ToList());
        }

        //PUT: /api/produto/update
        [Route("update")]
        [HttpPut]
        public IActionResult Update([FromBody] Produto produto)
        {
            _context.Produtos.Update(produto);
            _context.SaveChanges();
            return Ok(produto);
        }

    }
}