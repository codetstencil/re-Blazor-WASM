﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRentalManagement.Server.IRepository;
using CarRentalManagement.Shared.Domain;

namespace CarRentalManagement.Server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ModelsController : ControllerBase
  {
    private readonly IUnitOfWork _unitOfWork;

    public ModelsController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    // GET: /Models
    [HttpGet]
    public async Task<IActionResult> GetModels()
    {
      var Models = await _unitOfWork.Models.GetAll();
      return Ok(Models);
    }

    // GET: /Models/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetModel(int id)
    {
      var Model = await _unitOfWork.Models.Get(q => q.Id == id);

      if (Model == null)
      {
        return NotFound();
      }

      return Ok(Model);
    }

    // PUT: api/Models/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutModel(int id, Model model)
    {
      if (id != model.Id)
      {
        return BadRequest();
      }

      _unitOfWork.Models.Update(model);

      try
      {
        await _unitOfWork.Save(HttpContext);
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!await ModelExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // POST: api/Models
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Model>> PostModel(Model model)
    {
      await _unitOfWork.Models.Insert(model);
      await _unitOfWork.Save(HttpContext);

      return CreatedAtAction("GetModel", new { id = model.Id }, model);
    }

    // DELETE: api/Models/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteModel(int id)
    {
      var model = await _unitOfWork.Models.Get(q => q.Id == id);
      if (model == null)
      {
        return NotFound();
      }
      await _unitOfWork.Models.Delete(id);
      await _unitOfWork.Save(HttpContext);

      return NoContent();
    }

    private async Task<bool> ModelExists(int id)
    {
      var model = await _unitOfWork.Models.Get(q => q.Id == id);
      return model == null;
    }
  }
}