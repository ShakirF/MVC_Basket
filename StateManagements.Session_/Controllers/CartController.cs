﻿using Microsoft.AspNetCore.Mvc;
using StateManagements.Models.Data;
using StateManagements.Models.Models;
using StateManagements.Session_.Models;
using StateManagements.Session_.ServiceSession;

namespace StateManagements.Session_.Controllers;
public class CartController : Controller
{
    private readonly StateManagementContext _context;
    private const string CART_KEY = "_cart";
    public CartController(StateManagementContext context)
    {
        this._context = context;


        if (!_context.Products.Any())
        {
            _context.Categories.Add(new Category()
            {
                Name = "New Arrivals",
                Description = "Test",
                Products = new List<Product>
            {
                new Product{ Name = "Black Gray Hooded Jacket",   UnitPrice = 0, UnitsInStock = 0 , MainImage = "~/assets/images/index1/new_arrivals/01.png" , OverlayImage="~/assets/images/index1/new_arrivals/11.png", Kind="womens mens"  },
                new Product{ Name = "Kids Yellow Padded Jacket",  UnitPrice = 0, UnitsInStock = 0 , MainImage = "~/assets/images/index1/new_arrivals/02.png" , OverlayImage="~/assets/images/index1/new_arrivals/10.png", Kind="mens baby womens"  },
                new Product{ Name = "Dark Olive Padded Jacket",   UnitPrice = 0, UnitsInStock = 0 , MainImage = "~/assets/images/index1/new_arrivals/03.png" , OverlayImage="~/assets/images/index1/new_arrivals/12.png", Kind="womens baby mens"  },
                new Product{ Name = "Hald Padded Jacket",         UnitPrice = 0, UnitsInStock = 0 , MainImage = "~/assets/images/index1/new_arrivals/04.png" , OverlayImage="~/assets/images/index1/new_arrivals/07.png", Kind="womens"  },
                new Product{ Name = "Winter Sweaters",            UnitPrice = 0, UnitsInStock = 0 , MainImage = "~/assets/images/index1/new_arrivals/05.png" , OverlayImage="~/assets/images/index1/new_arrivals/08.png", Kind="womens"  },
                new Product{ Name = "Half Sleeve Padded Jacket",  UnitPrice = 0, UnitsInStock = 0 , MainImage = "~/assets/images/index1/new_arrivals/06.png" , OverlayImage="~/assets/images/index1/new_arrivals/12.png", Kind="baby mens"  },
                new Product{ Name = "Black Bomber Jacket",        UnitPrice = 0, UnitsInStock = 0 , MainImage = "~/assets/images/index1/new_arrivals/07.png" , OverlayImage="~/assets/images/index1/new_arrivals/04.png", Kind="baby mens"  },
                new Product{ Name = "Winter Sweaters",            UnitPrice = 0, UnitsInStock = 0 , MainImage = "~/assets/images/index1/new_arrivals/08.png" , OverlayImage="~/assets/images/index1/new_arrivals/05.png", Kind="womens"  },
                new Product{ Name = "Black Balloon Jacket",       UnitPrice = 0, UnitsInStock = 0 , MainImage = "~/assets/images/index1/new_arrivals/09.png" , OverlayImage="~/assets/images/index1/new_arrivals/04.png", Kind="womens"  },
                new Product{ Name = "Full Sleeve Balloon Jacket", UnitPrice = 0, UnitsInStock = 0 , MainImage = "~/assets/images/index1/new_arrivals/10.png" , OverlayImage="~/assets/images/index1/new_arrivals/02.png", Kind="mens"  },
                new Product{ Name = "Double Collar Jacket",       UnitPrice = 0, UnitsInStock = 0 , MainImage = "~/assets/images/index1/new_arrivals/11.png" , OverlayImage="~/assets/images/index1/new_arrivals/01.png", Kind="womens mens"  },
                new Product{ Name = "Winter Dark Olive Jacket",   UnitPrice = 0, UnitsInStock = 0 , MainImage = "~/assets/images/index1/new_arrivals/12.png" , OverlayImage="~/assets/images/index1/new_arrivals/06.png", Kind="mens"  }
            }
            });


            _context.Categories.Add(new Category()
            {
                Name = "Best Seller",
                Description = "Test",
                Products = new List<Product>
            {
                new Product{ Name = "Winter Dark Olive Jacket",   UnitPrice = 0, UnitsInStock = 0 , MainImage = "~/assets/images/index1/new_arrivals/12.png" , OverlayImage="~/assets/images/index1/new_arrivals/06.png"  },
                new Product{ Name = "Winter Sweaters",            UnitPrice = 0, UnitsInStock = 0 , MainImage = "~/assets/images/index1/new_arrivals/05.png" , OverlayImage="~/assets/images/index1/new_arrivals/08.png"  },
                new Product{ Name = "Half Sleeve Padded Jacket",  UnitPrice = 0, UnitsInStock = 0 , MainImage = "~/assets/images/index1/new_arrivals/06.png" , OverlayImage="~/assets/images/index1/new_arrivals/12.png"  },
                new Product{ Name = "Black Bomber Jacket",        UnitPrice = 0, UnitsInStock = 0 , MainImage = "~/assets/images/index1/new_arrivals/07.png" , OverlayImage="~/assets/images/index1/new_arrivals/04.png"  },
                new Product{ Name = "Winter Dark Olive Jacket",   UnitPrice = 0, UnitsInStock = 0 , MainImage = "~/assets/images/index1/new_arrivals/12.png" , OverlayImage="~/assets/images/index1/new_arrivals/06.png"  },
                new Product{ Name = "Full Sleeve Balloon Jacket", UnitPrice = 0, UnitsInStock = 0 , MainImage = "~/assets/images/index1/new_arrivals/10.png" , OverlayImage="~/assets/images/index1/new_arrivals/02.png"  }
            }
            });
            _context.SaveChanges();
        }
    }

    [HttpPost]
    public async Task<IActionResult> Add(int id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null)
            return BadRequest();

        var carts = HttpContext.Session.Get<List<Cart>>(CART_KEY) ?? new List<Cart>();

        var existingCart = carts.FirstOrDefault(x => x.Id == id);
        if (existingCart == null)
        {
            var cart = new Cart
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.UnitPrice,
                Image= product.MainImage
                
            };
            carts.Add(cart);
        }
        else
            existingCart.Count++;

        HttpContext.Session.Set<List<Cart>>(CART_KEY, carts);

        return Json(data: carts);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
            return BadRequest();
        var carts=  HttpContext.Session.Get<List<Cart>> (CART_KEY);
        var cart = carts.FirstOrDefault(x=> x.Id== id);
        carts.Remove(cart);
        HttpContext.Session.Set<List<Cart>>(CART_KEY, carts);
        return Json(data: carts);
    }

    public async Task<IActionResult> Increase(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
            return BadRequest();
        var carts = HttpContext.Session.Get<List<Cart>>(CART_KEY);
        var cart = carts.FirstOrDefault(x => x.Id == id);
        cart.Count++;
        HttpContext.Session.Set<List<Cart>>(CART_KEY, carts);
        return Json(data: carts);
    }

    public async Task<IActionResult> Decrease(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
            return BadRequest();
        var carts = HttpContext.Session.Get<List<Cart>>(CART_KEY);
        var cart = carts.FirstOrDefault(x => x.Id == id);
        cart.Count--;
        if(cart.Count == 0)
        {
            carts.Remove(cart);
        }
        HttpContext.Session.Set<List<Cart>>(CART_KEY, carts);
        return Json(data: carts);
    }


    public IActionResult Index()
    {
        var datas = HttpContext.Session.Get<List<Cart>>(CART_KEY);
        return View(datas);
    }
}
