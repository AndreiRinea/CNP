namespace CNP.Tests;

public class CNPTest
{
    private readonly CNP validCNP1 = new CNP(1800101420010);
    private readonly CNP validCNP2 = new CNP(1810101420019);
    private readonly byte[] CNP1ByteArray = [1, 8, 0, 0, 1, 0, 1, 4, 2, 0, 0, 1, 0];

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(180010142001)]
    [InlineData(18001014200100)]
    public void LongInt_Constructor_Rejects_OutOfRange_Values(long value)
    {
        Assert.Throws<ArgumentException>(() => new CNP(value));
    }

    [Fact]
    public void LongInt_Constructor_InitiatesCorrectly()
    {
        var digits = validCNP1.GetDigits();
        Assert.Equal(CNP1ByteArray, digits);
    }

    [Fact]
    public void ByteArrayConstructor_Rejects_NullArray()
    {
        Assert.Throws<ArgumentNullException>(() => new CNP(null));
    }

    [Theory]
    [InlineData(new byte[] { })]
    [InlineData(new byte[] { 1, 1, 1, 1 })]
    [InlineData(new byte[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 })]
    public void ByteArrayConstructor_Rejects_ArrayOfBadLength(byte[] digits)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new CNP(digits));
    }

    [Fact]
    public void ByteArrayConstructor_Rejects_BadDigitsValue()
    {
        Assert.Throws<ArgumentException>(() => new CNP([1, 8, 0, 0, 1, 0, 1, 4, 2, 0, 10, 1, 0]));
    }

    [Fact]
    public void A_Valid_CNP_IsValidated()
    {
        Assert.True(validCNP1.Validate());
    }

    [Fact]
    public void Invalid_CNP_IsNotValidated()
    {
        Assert.False(new CNP(1800101420011).Validate());
    }

    [Fact]
    public void GetDigits_ReturnsCorrectValue()
    {
        var digits = validCNP1.GetDigits();
        Assert.Equal(CNP1ByteArray, digits);
    }

    [Fact]
    public void ToString_ReturnsCorrectValue()
    {
        var str = validCNP1.ToString();
        Assert.Equal("1800101420010", str);
    }

    [Fact]
    public void GetHashCode_ReturnsCorrectValue()
    {
        var hashCode = validCNP1.GetHashCode();
        Assert.Equal(-68890393, hashCode);
    }

    [Fact]
    public void Equals_ReturnsTrue_ForSameInstance()
    {
        var eq = validCNP1.Equals(validCNP1);
        Assert.True(eq);
    }

    [Fact]
    public void Equals_ReturnsFalse_ForNull()
    {
        Assert.False(validCNP1.Equals(null));
    }

    [Fact]
    public void Equals_ReturnsTrue_ForDifferentInstance_WhichIsEqual()
    {
        var differentInstance = new CNP(1800101420010);
        Assert.True(validCNP1.Equals(differentInstance));
    }

    [Fact]
    public void Equals_ReturnsFalse_ForDifferentInstance_WhichIsNotEqual()
    {
        Assert.False(validCNP1.Equals(validCNP2));
    }
}