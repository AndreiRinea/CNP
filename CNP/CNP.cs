// Copyright 2025 Andrei Rinea
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Text;

namespace CNP;

public class CNP : IEquatable<CNP>
{
    private static readonly byte[] ValidationConstant = [2, 7, 9, 1, 4, 6, 3, 5, 8, 2, 7, 9];
    private static readonly DateOnly MaxDateForSector7And8 = new(1979, 12, 19);

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

    private byte ComputeChecksum()
    {
        int sum = 0;
        for (int i = 0; i < 12; i++)
        {
            sum += _digits[i] * ValidationConstant[i];
        }
        var controlDigit = sum % 11;
        return (byte)controlDigit;
    }

    private short GetYearData()
    {
        short year = 0;
        year += _digits[0] switch
        {
            1 or 2 => 1900,
            3 or 4 => 1800,
            5 or 6 => 2000,
            _ => 0,
        };
        year += (short)(_digits[1] * 10);
        year += _digits[2];
        return year;
    }

    private byte GetCountyCode()
    {
        var countyFirstDigit = _digits[7];
        var countySecondDigit = _digits[8];
        byte countyCode = (byte)(countyFirstDigit * 10 + countySecondDigit);
        return countyCode;
    }

    private short GetSequentialNumber()
    {
        var sequentialNumberFirstDigit = _digits[9];
        var sequentialNumberSecondDigit = _digits[10];
        var sequentialNumberThirdDigit = _digits[11];
        return (short)(
            sequentialNumberFirstDigit * 100 +
            sequentialNumberSecondDigit * 10 +
            sequentialNumberThirdDigit);
    }

    public ValidationError Validate()
    {
        var error = ValidationError.None;

        var sexDigit = _digits[0];
        if (sexDigit < 1 || sexDigit > 8) error |= ValidationError.InvalidSexDigit;

        var monthFirstDigit = _digits[3];
        var monthSecondDigit = _digits[4];
        if (monthFirstDigit > 1 ||
            (monthFirstDigit == 1 && monthSecondDigit > 2) ||
            (monthFirstDigit == 0 && monthSecondDigit == 0))
        {
            error |= ValidationError.InvalidMonth;
        }

        var dayFirstDigit = _digits[5];
        var daySecondDigit = _digits[6];
        if (dayFirstDigit > 3 ||
            (dayFirstDigit == 3 && daySecondDigit > 1) ||
            (dayFirstDigit == 0 && daySecondDigit == 0))
        {
            error |= ValidationError.InvalidDay;
        }

        var year = GetYearData();
        var month = _digits[3] * 10 + _digits[4];
        var day = _digits[5] * 10 + _digits[6];

        if (day > DateTime.DaysInMonth(year, month))
        {
            error |= ValidationError.InvalidDate;
        }

        var countyCode = GetCountyCode();
        var county = County.GetByCode(countyCode);
        if (county == null)
        {
            error |= ValidationError.InvalidCounty;
        }

        if (GetSequentialNumber() == 0)
        {
            error |= ValidationError.InvalidSequentialNumber;
        }

        if (county == County.BUCURESTI_SECTOR_7 || county == County.BUCURESTI_SECTOR_8)
        {
            var date = new DateOnly(year, month, day);
            if (date > MaxDateForSector7And8)
            {
                error |= ValidationError.InvalidDateForCounty;
            }
        }

        var computedControlDigit = ComputeChecksum();
        var suppliedControlDigit = _digits[12];
        if (suppliedControlDigit != computedControlDigit)
        {
            error |= ValidationError.ChecksumError;
        }

        return error;
    }

    public byte[] GetDigits()
    {
        return (byte[])_digits.Clone();
    }

    public override string ToString()
    {
        var result = new StringBuilder(13, 13);
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