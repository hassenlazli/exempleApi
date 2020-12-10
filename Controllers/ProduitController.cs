using exempleApi.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace exempleApi.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduitController : ControllerBase
    {

        private readonly ApiDbContext _context;

        public ProduitController(ApiDbContext context)
        {
            _context = context;
        }
        //Get      api/produit
        [HttpGet]
        public ActionResult<IEnumerable<Produit>> GetAllProducts()
        {
            return _context.Produits;
        }
        //Get      api/produit/n
        [HttpGet("{id}")]
        public ActionResult<Produit> GetProductById(int id)
        {
            var produit = _context.Produits.Find(id);
            if (produit == null)
            {
                return NotFound();

            }
            return produit;
        }

        //POST    api/produit
        [HttpPost]
        public ActionResult<Produit> AddProduct(Produit produit)
        {
            _context.Produits.Add(produit);
            _context.SaveChanges();
            return CreatedAtAction("GetAllProduct", new Produit { Id = produit.Id }, produit);
        }

        // PUT   api/commands/n
        [HttpPut("{id}")]
        public ActionResult PutProduit(int id, Produit produit)
        {
            if (id != produit.Id)
            {
                return BadRequest();
            }
            _context.Entry(produit).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();

        }

        //DELETE   api/produit/n
        [HttpDelete("{id}")]
        public ActionResult<Produit> DeleteProduit(int id)
        {
            var produitItem = _context.Produits.Find(id);
            if (produitItem == null)
            {
                return NotFound();

            }
            _context.Produits.Remove(produitItem);
            _context.SaveChanges();
            return produitItem;
        }



    }
}