using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;
namespace DomainTests;


public class MoneySpecs
{
    static T A<T>(Func<T, T>? customization = null)
    {
        var t = new Fixture().Create<T>();
        if (null != customization)
            t = customization(t);
        return t;
    }

    Money aValidMoney() => A<Money>(with => new Money(Math.Abs(with.Amount)));

    [Theory, AutoData]
    public void Money_cannot_be_negative(decimal amount)
    {
        amount = -Math.Abs(amount);

        var action = () => new Money(amount);

        action.Should().Throw<Exception>();
    }

    [Theory, AutoData]
    public void Supports_subtraction(uint five)
    {
        var smallerNumber = aValidMoney();
        var biggerNumber = new Money(smallerNumber.Amount + five);

        var expected = biggerNumber - smallerNumber;

        expected.Amount.Should().Be(five);
    }

    [Theory, AutoData]
    public void PlusOperator_should_return_correct_total_amount(
        Money left, Money right)
    {
        var totalAmount = left.Amount + right.Amount;

        var expected = left + right;

        expected.Amount.Should().Be(totalAmount);
    }
}