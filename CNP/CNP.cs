using System.Text;

namespace CNP;

public class CNP : IEquatable<CNP>
{
    private static readonly byte[] ValidationConstant = [2, 7, 9, 1, 4, 6, 3, 5, 8, 2, 7, 9];

    private readonly byte[] _digits;

    public CNP(long value)
    {
        if (value < 1000000000000 || value > 9999999999999)
        {
            throw new ArgumentException("invalid value " + value);
        }
        _digits = new byte[13];
        int i = 12;
        while (value > 0)
        {
            var digit = value % 10;
            _digits[i] = (byte)digit;
            value /= 10;
            i--;
        }
    }

    public CNP(byte[] digits)
    {
        if (digits == null) throw new ArgumentNullException();
        if (digits.Length != 13) throw new ArgumentOutOfRangeException("value must be 13 digits");
        for (int i = 0; i < 13; i++)
        {
            if (digits[i] < 0 || digits[i] > 9)
                throw new ArgumentException("digit at index " + i + " has invalid value of " + digits[i]);
        }
        _digits = (byte[])digits.Clone();
    }

    public bool Validate()
    {
        int sum = 0;
        for (int i = 0; i < 12; i++)
        {
            sum += _digits[i] * ValidationConstant[i];
        }
        var controlDigit = sum % 11;
        return controlDigit == _digits[12];
    }

    public byte[] GetDigits()
    {
        return (byte[])_digits.Clone();
    }

    public override string ToString()
    {
        var result = new StringBuilder(13);
        for (int i = 0; i < 13; i++)
        {
            result.Append(_digits[i]);
        }
        return result.ToString();
    }

    public override int GetHashCode()
    {
        unchecked // allow overflow
        {
            int hash = 17;
            for (int i = 0; i < 13; i++)
            {
                hash = hash * 31 + _digits[i];
            }
            return hash;
        }
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as CNP);
    }

    public bool Equals(CNP? other)
    {
        if (ReferenceEquals(this, other)) return true;
        if (other == null) return false;
        return _digits.SequenceEqual(other._digits);
    }

    public static bool operator ==(CNP? left, CNP? right) => Equals(left, right);

    public static bool operator !=(CNP? left, CNP? right) => !Equals(left, right);
}