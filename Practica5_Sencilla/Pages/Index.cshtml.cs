using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Practica5_Sencilla.Pages
{

    public class Producto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int categoriaID { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public float precio { get; set; }
    }

    public class Categoria
    {
        public int id { get; set; }
        public string nombre { get; set; }
    }


    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<Producto> Productos { get; set; }
        public List<Categoria> Categorias { get; set; }

        public List<Producto> ProductosCategoria { get; set; }
        public List<Producto> ProductosFiltrados { get; set; }
        public List<Categoria> CategoriasProductosRegistrados { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

            //Llenando Arreglo de Productos
            Productos = new List<Producto> {
                new Producto { id = 1, nombre = "Fitbit Versa 2", categoriaID = 1, marca = "Fitbit", modelo = "Versa 2", precio = 9000 },
                new Producto { id = 2, nombre = "Apple Watch", categoriaID = 1, marca = "Apple Watch", modelo = "Serie 6", precio = 22000 },
                new Producto { id = 3, nombre = "AGPTEK Watch", categoriaID = 1, marca = "AGPTEK", modelo = "LW11", precio = 3000 },
                new Producto { id = 4, nombre = "Garmin Vivoactive 3", categoriaID = 1, marca = "Garmin", modelo = "VivoActive", precio = 4500 },
                new Producto { id = 5, nombre = "Apple Iphone", categoriaID = 2, marca = "Apple", modelo = "13 PRO", precio = 85000 },
                new Producto { id = 6, nombre = "Samsumg Galaxy", categoriaID = 2, marca = "Samsumg", modelo = "S21", precio = 65000 },
                new Producto { id = 7, nombre = "Samsung Galaxy Flip", categoriaID = 2, marca = "Samsumg", modelo = "Flip", precio = 60000 },
                new Producto { id = 8, nombre = "OnePlus 8", categoriaID = 2, marca = "OnePlus", modelo = "Glacial", precio = 15000 },
                new Producto { id = 9, nombre = "Netvue", categoriaID = 3, marca = "NetVue", modelo = "ND2", precio = 2500 },
                new Producto { id = 10, nombre = "Blink Outdoor", categoriaID = 3, marca = "Blink", modelo = "OutDoor", precio = 1500 }
            };

            //Llenando Arreglo de Categorias
            Categorias = new List<Categoria> {
                new Categoria { id = 1, nombre = "SmartWatch" },
                new Categoria { id = 2, nombre = "SmartPhone" },
                new Categoria { id = 3, nombre = "Camara Seguridad" },
                new Categoria { id = 4, nombre = "Categoria sin uso" }
            };

            //Filtrando Productos Categoria SmartWatch
            ProductosCategoria = (from p in Productos
                                  where p.categoriaID == 1
                                  select p).ToList();

            //Filtrando Productos Filtrado Rango de Precio
            ProductosFiltrados = (from p in Productos
                                  where p.precio >= 3000 && p.precio <= 5000
                                  select p).ToList();

            //Filtrando Productos Filtrado Rango de Precio
            CategoriasProductosRegistrados = (from c in Categorias
                                              join p in Productos on c.id equals p.categoriaID
                                              select c).ToList();

            CategoriasProductosRegistrados = CategoriasProductosRegistrados.Distinct().ToList();




        }
    }
}
