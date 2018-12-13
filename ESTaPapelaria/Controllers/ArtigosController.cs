using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESTaPapelaria.Models;
using Microsoft.AspNetCore.Mvc;

namespace ESTaPapelaria.Controllers
{
    public class ArtigosController : Controller
    {
        private List<Artigo> artigos = new List<Artigo>
        {
            new Artigo
            {
                Id= 2,
                Nome = "Esferográfica EST",
                Descricao = "Esferográfica de gel",
                Preco=1.99,
                Desconto = 0.10,
                EmPromocao = true
            },
            new Artigo
            {
                Id= 5,
                Nome = "Pen EST",
                Descricao = "Pen de 16GB",
                Preco=7.90,
                Desconto = 0.15,
                EmPromocao = false
            },
            new Artigo
            {
                Id= 6,
                Nome = "Clip EST",
                Descricao = "Clips coloridos",
                Preco=2.99,
                Desconto = 0.15,
                EmPromocao = true
            }
        };

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Listar()
        {
            return View(artigos);
        }

        public IActionResult Promocoes()
        {
            return View(artigos.Where(a => a.EmPromocao));
        }

        [HttpPost]
        public IActionResult Listar(string filtro)
        {
            var artigosFiltrados = from a in artigos select a;

            if (!String.IsNullOrEmpty(filtro))
            {
                artigosFiltrados = artigosFiltrados.Where(a => a.Nome.Contains(filtro));
            }

            return View(artigosFiltrados.ToList());
        }
    }
}