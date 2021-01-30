//using Microsoft.AspNetCore.Mvc;
//using Poc.OData.WebApi.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Poc.OData.WebApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class TemplateWebApiController : ControllerBase
//    {
//        //private readonly TemplateDBContext _context;

//        public TemplateWebApiController()
//        {
//        }
//        //public TemplateWebApiController(TemplateDBContext context)
//        //{
//        //    _context = context;
//        //}

//        // GET: api/TemplateModel
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<TemplateModel>>> GetTemplateModels()
//        {
//            return await _context.TemplateModels.ToListAsync();
//        }

//        // GET: api/TemplateModel/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<TemplateModel>> GetTemplateModel(int id)
//        {
//            var dCandidate = await _context.TemplateModels.FindAsync(id);

//            if (dCandidate == null)
//            {
//                return NotFound();
//            }

//            return dCandidate;
//        }

//        // PUT: api/TemplateModel/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
//        // more details see https://aka.ms/RazorPagesCRUD.
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutTemplateModel(int id, TemplateModel templateModel)
//        {
//            templateModel.Id = id;

//            _context.Entry(templateModel).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!TemplateModelExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/TemplateModel
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
//        // more details see https://aka.ms/RazorPagesCRUD.
//        [HttpPost]
//        public async Task<ActionResult<TemplateModel>> PostTemplateModel(TemplateModel dCandidate)
//        {
//            _context.TemplateModels.Add(dCandidate);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetTemplateModel", new { id = dCandidate.Id }, dCandidate);
//        }

//        // DELETE: api/TemplateModel/5
//        [HttpDelete("{id}")]
//        public async Task<ActionResult<TemplateModel>> DeleteTemplateModel(int id)
//        {
//            var dCandidate = await _context.TemplateModels.FindAsync(id);
//            if (dCandidate == null)
//            {
//                return NotFound();
//            }

//            _context.TemplateModels.Remove(dCandidate);
//            await _context.SaveChangesAsync();

//            return dCandidate;
//        }

//        private bool TemplateModelExists(int id)
//        {
//            return _context.TemplateModels.Any(e => e.id == id);
//        }
//    }
//}
