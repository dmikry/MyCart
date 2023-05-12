namespace MyCartTests;

using NUnit.Framework;
using System;
using MyCart;

[TestFixture]
public class MyCartTests
{
	private MyCart cart;

	[SetUp]
	public void Setup()
	{
		cart = new MyCart(123);
	}

	[Test]
	public void AddItem() //increase cart amount
	{
		decimal initialAmount = cart.CartAmount;

		cart.AddItem("Item A", 2, 15.0m);

		decimal updatedAmount = cart.CartAmount;
		Assert.That(updatedAmount, Is.GreaterThan(initialAmount));
	}

	[Test]
	public void RemoveItem() //decrease cart amount
	{
		cart.AddItem("Item A", 2, 15.0m);
		decimal initialAmount = cart.CartAmount;

		cart.RemoveItem("Item A");

		decimal updatedAmount = cart.CartAmount;
		Assert.That(updatedAmount, Is.LessThan(initialAmount));
	}

	[Test]
	public void CartAmountCalculation() //calculation of cart amount
	{
		cart.AddItem("Item A", 2, 15.0m);
		cart.AddItem("Item B", 1, 10.0m);

		decimal cartAmount = cart.CartAmount;

		decimal expectedAmount = 2 * 15.0m + 1 * 10.0m;
		Assert.That(cartAmount, Is.EqualTo(expectedAmount));
	}
}