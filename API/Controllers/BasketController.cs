using System;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
public class BasketController(Data.StoreContext context) : BaseApiController
{
[HttpGet]
 public async Task<ActionResult<BasketDto>> GetBasket()
 {
   var basket =  await RetrieveBasket();
   if (basket == null) return NoContent();

    return basket.ToDto();
            
        
 }
 [HttpPost]
 public async Task<ActionResult<Basket>> AddItemToBasket(int productId, int quantity)//this is a transaction that will add an item to the basket, if the basket does not exist, it will create a new basket and add the item to it
 {
    var basket = await RetrieveBasket();//get basket from database using the basketId from the cookie
    basket ??=  CreateBasket();//create
    var product = await context.Products.FindAsync(productId);//get product from database using the productId(EF reaches over that connection, grabs the raw database row, and fits it into your internal Product Entity class)
    if (product == null) return BadRequest("Product not found");//if product is not found, return 404
    basket.AddItem(product, quantity);//add item to basket
    var result = await context.SaveChangesAsync() > 0;//save changes to database
    if (result) return CreatedAtAction(nameof(GetBasket), basket);//if the item was added to the basket, return 201
    return BadRequest("Problem updated item to basket");//if there is a problem saving the item to the basket, return 400
 }
 [HttpDelete]
 public async Task<ActionResult> RemoveBasketItem(int productId, int quantity)
 {
    //get basket
    //remove item from basket or reduce its quantity
    //save changes
    return Ok();
 }
 public Basket CreateBasket()
 {
    var basketId = Guid.NewGuid().ToString();
    var cookieOptions = new CookieOptions
    {
        IsEssential = true,
        Expires = DateTime.UtcNow.AddDays(30)
    };
    Response.Cookies.Append("basketId", basketId, cookieOptions);
    var basket = new Basket
    {
        BasketId = basketId
    };
    context.Baskets.Add(basket);
    return basket;
 }
 public async Task<Basket> RetrieveBasket()
 {
    return await context.Baskets
        .Include(x => x.Items)
        .ThenInclude(x => x.Product)
        .FirstOrDefaultAsync(x => x.BasketId == Request.Cookies["basketId"]);

      
 }
 
}
