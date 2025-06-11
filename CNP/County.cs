namespace CNP;

public class County
{
    private readonly byte _code;
    private readonly string _name;

    private County(byte code, string name)
    {
        _code = code;
        _name = name;
    }

    public override string ToString()
    {
        return _name;
    }

    public override int GetHashCode()
    {
        return _code;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj)) return true;
        if (obj is not County other) return false;
        return _code == other._code;
    }

    public static IEnumerable<County> List() => [
        ALBA,
        ARAD,
        ARGES,
        BACAU,
        BIHOR,
        BISTRITA_NASAUD,
        BOTOSANI,
        BRASOV,
        BRAILA,
        BUZAU,
        CARAS_SEVERIN,
        CLUJ,
        CONSTANTA,
        COVASNA,
        DAMBOVITA,
        DOLJ,
        GALATI,
        GORJ,
        HARGHITA,
        HUNEDOARA,
        IALOMITA,
        IASI,
        ILFOV,
        MARAMURES,
        MEHEDINTI,
        MURES,
        NEAMT,
        OLT,
        PRAHOVA,
        SATU_MARE,
        SALAJ,
        SIBIU,
        SUCEAVA,
        TELEORMAN,
        TIMIS,
        TULCEA,
        VASLUI,
        VALCEA,
        VRANCEA,
        BUCURESTI,
        BUCURESTI_SECTOR_1,
        BUCURESTI_SECTOR_2,
        BUCURESTI_SECTOR_3,
        BUCURESTI_SECTOR_4,
        BUCURESTI_SECTOR_5,
        BUCURESTI_SECTOR_6,
        BUCURESTI_SECTOR_7,
        BUCURESTI_SECTOR_8,
        CALARASI,
        GIURGIU,
        COD_UNIC
     ];

    public static County? GetByCode(byte code)
    {
        switch (code)
        {
            case 01: return ALBA;
            case 02: return ARAD;
            case 03: return ARGES;
            case 04: return BACAU;
            case 05: return BIHOR;
            case 06: return BISTRITA_NASAUD;
            case 07: return BOTOSANI;
            case 08: return BRASOV;
            case 09: return BRAILA;
            case 10: return BUZAU;
            case 11: return CARAS_SEVERIN;
            case 12: return CLUJ;
            case 13: return CONSTANTA;
            case 14: return COVASNA;
            case 15: return DAMBOVITA;
            case 16: return DOLJ;
            case 17: return GALATI;
            case 18: return GORJ;
            case 19: return HARGHITA;
            case 20: return HUNEDOARA;
            case 21: return IALOMITA;
            case 22: return IASI;
            case 23: return ILFOV;
            case 24: return MARAMURES;
            case 25: return MEHEDINTI;
            case 26: return MURES;
            case 27: return NEAMT;
            case 28: return OLT;
            case 29: return PRAHOVA;
            case 30: return SATU_MARE;
            case 31: return SALAJ;
            case 32: return SIBIU;
            case 33: return SUCEAVA;
            case 34: return TELEORMAN;
            case 35: return TIMIS;
            case 36: return TULCEA;
            case 37: return VASLUI;
            case 38: return VALCEA;
            case 39: return VRANCEA;
            case 40: return BUCURESTI;
            case 41: return BUCURESTI_SECTOR_1;
            case 42: return BUCURESTI_SECTOR_2;
            case 43: return BUCURESTI_SECTOR_3;
            case 44: return BUCURESTI_SECTOR_4;
            case 45: return BUCURESTI_SECTOR_5;
            case 46: return BUCURESTI_SECTOR_6;
            case 47: return BUCURESTI_SECTOR_7;
            case 48: return BUCURESTI_SECTOR_8;
            case 51: return CALARASI;
            case 52: return GIURGIU;
            case 70: return COD_UNIC;
            default: return null;
        }
    }

    public static readonly County ALBA = new(01, "Alba");
    public static readonly County ARAD = new(02, "Arad");
    public static readonly County ARGES = new(03, "Argeș");
    public static readonly County BACAU = new(04, "Bacău");
    public static readonly County BIHOR = new(05, "Bihor");
    public static readonly County BISTRITA_NASAUD = new(06, "Bistrița-Năsăud");
    public static readonly County BOTOSANI = new(07, "Botoșani");
    public static readonly County BRASOV = new(08, "Brașov");
    public static readonly County BRAILA = new(09, "Brăila");
    public static readonly County BUZAU = new(10, "Buzău");
    public static readonly County CARAS_SEVERIN = new(11, "Caraș-Severin");
    public static readonly County CLUJ = new(12, "Cluj");
    public static readonly County CONSTANTA = new(13, "Constanța");
    public static readonly County COVASNA = new(14, "Covasna");
    public static readonly County DAMBOVITA = new(15, "Dâmbovița");
    public static readonly County DOLJ = new(16, "Dolj");
    public static readonly County GALATI = new(17, "Galați");
    public static readonly County GORJ = new(18, "Gorj");
    public static readonly County HARGHITA = new(19, "Harghita");
    public static readonly County HUNEDOARA = new(20, "Hunedoara");
    public static readonly County IALOMITA = new(21, "Ialomița");
    public static readonly County IASI = new(22, "Iași");
    public static readonly County ILFOV = new(23, "Ilfov");
    public static readonly County MARAMURES = new(24, "Maramureș");
    public static readonly County MEHEDINTI = new(25, "Mehedinți");
    public static readonly County MURES = new(26, "Mureș");
    public static readonly County NEAMT = new(27, "Neamț");
    public static readonly County OLT = new(28, "Olt");
    public static readonly County PRAHOVA = new(29, "Prahova");
    public static readonly County SATU_MARE = new(30, "Satu Mare");
    public static readonly County SALAJ = new(31, "Sălaj");
    public static readonly County SIBIU = new(32, "Sibiu");
    public static readonly County SUCEAVA = new(33, "Suceava");
    public static readonly County TELEORMAN = new(34, "Teleorman");
    public static readonly County TIMIS = new(35, "Timiș");
    public static readonly County TULCEA = new(36, "Tulcea");
    public static readonly County VASLUI = new(37, "Vaslui");
    public static readonly County VALCEA = new(38, "Vâlcea");
    public static readonly County VRANCEA = new(39, "Vrancea");
    public static readonly County BUCURESTI = new(40, "București");
    public static readonly County BUCURESTI_SECTOR_1 = new(41, "București - Sector 1");
    public static readonly County BUCURESTI_SECTOR_2 = new(42, "București - Sector 2");
    public static readonly County BUCURESTI_SECTOR_3 = new(43, "București - Sector 3");
    public static readonly County BUCURESTI_SECTOR_4 = new(44, "București - Sector 4");
    public static readonly County BUCURESTI_SECTOR_5 = new(45, "București - Sector 5");
    public static readonly County BUCURESTI_SECTOR_6 = new(46, "București - Sector 6");
    public static readonly County CALARASI = new(51, "Călărași");
    public static readonly County GIURGIU = new(52, "Giurgiu");
    public static readonly County BUCURESTI_SECTOR_7 = new(47, "Bucuresti - Sector 7 (desființat)");
    public static readonly County BUCURESTI_SECTOR_8 = new(48, "Bucuresti - Sector 8 (desființat)");
    public static readonly County COD_UNIC = new(70, "Cod unic pentru orice înregistrare, indiferent de județul/locul unde a avut loc nașterea");
}