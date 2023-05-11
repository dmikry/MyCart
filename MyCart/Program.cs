namespace MyCart;

using System;
using System.Collections.Generic;

public class Program
{
	static void Main(string[] args)
	{
		MyCart cart = new MyCart(123);
		cart.AddItem("Item A", 2, 15.0m);
		cart.AddItem("Item B", 1, 10.0m);
		Console.WriteLine("Cart Amount: " + cart.CartAmount);
		cart.RemoveItem("Item B");
		Console.WriteLine("Cart Amount: " + cart.CartAmount);
	}
}

public class MyCart
{
	private readonly int userId;
	private readonly Dictionary<string, CartItem> items;

	public MyCart(int userId)
	{
		this.userId = userId;
		items = new Dictionary<string, CartItem>();
	}

	public decimal CartAmount
	{
		get
		{
			decimal total = 0;
			foreach (var item in items)
			{
				total += item.Value.Quantity * item.Value.Price;
			}
			return total;
		}
	}

	public void AddItem(string itemName, int quantity, decimal price)
	{
		if (price <= 0)
		{
			throw new ArgumentException("The price should be positive.", nameof(price));
		}

		if (items.ContainsKey(itemName))
		{
			var currentQuantity = items[itemName].Quantity;
			items[itemName] = new CartItem(itemName, currentQuantity + quantity, price);
		}
		else
		{
			items[itemName] = new CartItem(itemName, quantity, price);
		}
	}

	public void RemoveItem(string itemName)
	{
		if (items.ContainsKey(itemName))
		{
			items.Remove(itemName);
		}
	}
}

public class CartItem
{
	public string Name { get; }
	public int Quantity { get; }
	public decimal Price { get; }

	public CartItem(string name, int quantity, decimal price)
	{
		Name = name;
		Quantity = quantity;
		Price = price;
	}
}
