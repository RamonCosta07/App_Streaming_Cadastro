using DIO.Series.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIO.Series.Web.Controllers
{
    [Route("[Controller]")]
    public class SerieController : Controller
    {
        /* 
         * GET = RETORNAR ALGO
         * POST = INSERE ALGO
         * PUT = ALTERA ALGO
         * DELETE = EXCLUIR ALGO
         */

        private readonly IRepositorio<Serie> _repositorioSerie;

        public SerieController(IRepositorio<Serie> repositorioSerie)
        {
            _repositorioSerie = repositorioSerie;
        }

        [HttpGet("")] // Lista retorna algo
        public IActionResult Lista()
        {
            return Ok(_repositorioSerie.Lista().Select(s => new SerieModel(s)));
        }

        [HttpPut("{id}")]
        public IActionResult Atualiza(int id, [FromBody] SerieModel model)
        {
            _repositorioSerie.Atualiza(id, model.ToSerie());
            return NoContent(); // Ele não retorna nada
        }

        [HttpDelete("{id}")]
        public IActionResult Exclui(int id)
        {
            _repositorioSerie.Exclui(id);
            return NoContent();
        }

        [HttpPost("")]
        public IActionResult Insere([FromBody] SerieModel model)
        {
            model.Id = _repositorioSerie.Proximoid();

            Serie serie = model.ToSerie();

            _repositorioSerie.Insere(serie);
            return Created("", serie);
        }

        [HttpGet("{id}")]
        public IActionResult Consulta(int id)
        {
            return Ok(new SerieModel(_repositorioSerie.Lista().FirstOrDefault(s => s.Id == id)));
        }
    }
}
