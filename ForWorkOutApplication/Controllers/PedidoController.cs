using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ForWorkOutRepositories.EntitiesRepositories;
using ForWorkOutModels.Entities;
using ForWorkOutModels.Contexts;
using ForWorkOutApplication.ModelsHelper;
using Newtonsoft.Json;

namespace ForWorkOutApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                List<Pedido> listPedido = null;

                using (var repositorio = new PedidoRepository())
                {
                    listPedido = repositorio.ListAll().ToList();
                }

                return Ok(listPedido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpGet("{id}")]
        public ActionResult<object> Get(long id)
        {
            try
            {
                Pedido model = null;

                using (var repositorio = new ForWorkOutContext())
                {
                    model = repositorio.Set<Pedido>().Find(id);

                    model.Produtos = repositorio.Set<Produtos>().Where(p => p.IdPedido == model.Id).ToList();
                }

                if (model == null)
                    return NotFound();

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Pedido model)
        {
            try
            {
                if (model == null || model.Produtos == null || model.Produtos.Count() < 0)
                    return BadRequest();

                model.Data = DateTime.Now;            

                using (var repositorio = new ForWorkOutContext())
                {                                     
                    repositorio.Set<Pedido>().Add(model);                 
                    repositorio.SaveChanges();

                    foreach (var item in model.Produtos)
                    { 
                        item.IdPedido = model.Id;
                        model.Valor += item.PrecoProduto;
                        repositorio.Set<Produtos>().Add(item);
                    }

                    repositorio.SaveChanges();
                }

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody]Pedido model)
        {
            try
            {
                if (model == null || id != model.Id)
                    return BadRequest();

                using (var repositorio = new PedidoRepository())
                {
                    repositorio.Update(model);
                    repositorio.SaveAll();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                using (var repositorio = new PedidoRepository())
                {
                    var model = repositorio.FindById(id);

                    if (model == null)
                        return BadRequest();

                    repositorio.Delete(model);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
