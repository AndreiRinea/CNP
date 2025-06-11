namespace CNP.Tests;

public class CNPTest
{
    [Fact]
    public void A_Valid_CNP_IsValidated()
    {
        var systemUnderTest = new CNP(1800101420010);
        Assert.True(systemUnderTest.Validate());
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(180010142001)]
    [InlineData(18001014200100)]
    public void LongInt_Constructor_Rejects_OutOfRange_Values(long value)
    {
        Assert.Throws<ArgumentException>(() => new CNP(value));
    }
}