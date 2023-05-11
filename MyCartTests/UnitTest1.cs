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
	public void AddItem_ShouldIncreaseCartAmount()
	{
		// Arrange
		decimal initialAmount = cart.CartAmount;

		// Act
		cart.AddItem("Item A", 2, 15.0m);

		// Assert
		decimal updatedAmount = cart.CartAmount;
		Assert.That(updatedAmount, Is.GreaterThan(initialAmount));
	}

	[Test]
	public void RemoveItem_ShouldDecreaseCartAmount()
	{
		// Arrange
		cart.AddItem("Item A", 2, 15.0m);
		decimal initialAmount = cart.CartAmount;

		// Act
		cart.RemoveItem("Item A");

		// Assert
		decimal updatedAmount = cart.CartAmount;
		Assert.That(updatedAmount, Is.LessThan(initialAmount));
	}

	[Test]
	public void CartAmount_ShouldCalculateCorrectly()
	{
		// Arrange
		cart.AddItem("Item A", 2, 15.0m);
		cart.AddItem("Item B", 1, 10.0m);

		// Act
		decimal cartAmount = cart.CartAmount;

		// Assert
		decimal expectedAmount = 2 * 15.0m + 1 * 10.0m;
		Assert.That(cartAmount, Is.EqualTo(expectedAmount));
	}
}