using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using serview;
using serview.Models;

namespace SerieReview.Controllers
{
    [Authorize]
    [Route("/api/[controller]")]
    [Produces("application/json")]
    public class SeriesController : Controller
    {
        private readonly ServiewDBContext _context;

        public SeriesController(ServiewDBContext context)
        {
            _context = context;
        }

        // /api/series/getseries
        [HttpGet]
        public IActionResult GetSeries()
        {
            var entitys = _context.Series.Include(nameof(Serie.Ratings)).ToList();

            if (entitys == null)
            {
                return NotFound();
            }

            return Ok(entitys);
        }

        // /api/series/{serieId}
        [HttpGet("{serieId}")]
        public IActionResult GetSerie(int serieId)
        {
            var entity = _context.Series.Include(nameof(Serie.Ratings)).FirstOrDefault(q => q.SerieId == serieId);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        // /api/series
        [HttpPost]
        public IActionResult AddSerie([FromBody]Serie serie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _context.Series.Add(serie);
            _context.SaveChanges();
            return RedirectToAction(nameof(GetSerie), "Series", new { serieId = _context.Entry(serie).Entity.SerieId });
        }

        // /api/series/{serieId}
        [HttpPut("{serieId}")]
        public IActionResult PutSerie(int serieId, [FromBody]Serie serie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Serie serieDB = _context.Series.Find(serieId);

            serieDB.Name = serie.Name;
            serieDB.Description = serie.Description;
            serieDB.Image = serie.Image;

            _context.Series.Update(serieDB);
            _context.SaveChanges();

            return RedirectToAction(nameof(GetSerie), "Series", new { serieId = _context.Entry(serie).Entity.SerieId });
        }

        [HttpDelete("{serieId}")]
        public IActionResult DeleteSerie(int serieId)
        {
            _context.Series.Remove(_context.Series.Find(serieId));
            _context.SaveChanges();
            return Ok();
        }
    }
}