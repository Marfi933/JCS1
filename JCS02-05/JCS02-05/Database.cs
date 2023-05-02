namespace Database;

public class Student : IComparable<Student>
{
    public string OsCislo { get; set; }
    public string Jmeno { get; set; }
    public string Prijmeni { get; set; }
    public string UserName { get; set; }
    public int Rocnik { get; set; }
    public string OborKomb { get; set; }
    
    
    public override string ToString()
    {
        return $"{OsCislo}, {Jmeno}, {Prijmeni}, {UserName}, {Rocnik}, {OborKomb}";
    }

    public int CompareTo(Student other)
    {
        if (other == null)
        {
            throw new ArgumentException("Object is not a Student");
        }

        if (String.Compare(this.Prijmeni, other.Prijmeni) == 0)
        {
            if (String.Compare(this.Jmeno, other.Jmeno) > 0)
            {
                return 1;
            }
            
            if (String.Compare(this.Jmeno, other.Jmeno) < 0)
            {
                return -1;
            }
            return 0;
        }

        else if (String.Compare(this.Prijmeni, other.Prijmeni) < 0)
        {
            return -1;
        }

        else if (String.Compare(this.Prijmeni, other.Prijmeni) > 0)
        {
            return 1;
        }

        return -1;
    }
}

public class ReadonlyDB
{
    public static Student[] Students =
    {
        new()
        {
            OsCislo = "R21621", Jmeno = "Vojtěch", Prijmeni = "BARNET", UserName = "barnvo00", Rocnik = 2,
            OborKomb = "IT"
        },
        new()
        {
            OsCislo = "R21379", Jmeno = "David", Prijmeni = "CINKL", UserName = "cinkda00", Rocnik = 2,
            OborKomb = "INF-PVS"
        },
        new()
        {
            OsCislo = "R21625", Jmeno = "Tobiáš", Prijmeni = "CVRČEK", UserName = "cvrcto00", Rocnik = 4,
            OborKomb = "IT"
        },
        new()
        {
            OsCislo = "R21381", Jmeno = "Tomáš", Prijmeni = "DAVIES", UserName = "davito01", Rocnik = 2,
            OborKomb = "INF-PVS"
        },
        new()
        {
            OsCislo = "R21382", Jmeno = "Matěj", Prijmeni = "DLUHOŠ", UserName = "dluhma00", Rocnik = 2,
            OborKomb = "INF-PVS"
        },
        new()
        {
            OsCislo = "R21383", Jmeno = "Ondřej", Prijmeni = "DRESLER", UserName = "dreson00", Rocnik = 2,
            OborKomb = "INF-PVS"
        },
        new()
        {
            OsCislo = "R21628", Jmeno = "Bohumil", Prijmeni = "FEDERMANN", UserName = "fedebo00", Rocnik = 2,
            OborKomb = "IT"
        },
        new()
        {
            OsCislo = "R21386", Jmeno = "Petr", Prijmeni = "GAJDOŠÍK", UserName = "gajdpe05", Rocnik = 7,
            OborKomb = "INF-PVS"
        },
        new()
        {
            OsCislo = "R21629", Jmeno = "Jakub", Prijmeni = "GALETA", UserName = "galeja00", Rocnik = 2, OborKomb = "IT"
        },
        new()
        {
            OsCislo = "R21631", Jmeno = "Lukáš", Prijmeni = "HAVRÁNEK", UserName = "havrlu05", Rocnik = 2,
            OborKomb = "IT"
        },
        new()
        {
            OsCislo = "R21632", Jmeno = "Damián", Prijmeni = "HEDIA", UserName = "hedida00", Rocnik = 2, OborKomb = "IT"
        },
        new()
        {
            OsCislo = "R21633", Jmeno = "Ondřej", Prijmeni = "HEJTMÁNEK", UserName = "hejton00", Rocnik = 2,
            OborKomb = "IT"
        },
        new()
        {
            OsCislo = "R21634", Jmeno = "Luboš", Prijmeni = "HOLEČEK", UserName = "holelu01", Rocnik = 2,
            OborKomb = "IT"
        },
        new()
        {
            OsCislo = "R21391", Jmeno = "Tomáš", Prijmeni = "HÖPFLER", UserName = "hopfto00", Rocnik = 2,
            OborKomb = "INF-PVS"
        },
        new()
        {
            OsCislo = "R210140", Jmeno = "Natálie", Prijmeni = "HRŮŠOVÁ", UserName = "hrusna00", Rocnik = 2,
            OborKomb = "IT"
        },
        new()
        {
            OsCislo = "R21635", Jmeno = "Ján", Prijmeni = "HYBEN", UserName = "hybeja00", Rocnik = 2, OborKomb = "IT"
        },
        new()
        {
            OsCislo = "R21637", Jmeno = "Vít", Prijmeni = "JANKO", UserName = "jankvi00", Rocnik = 7, OborKomb = "IT"
        },
        new()
        {
            OsCislo = "R21393", Jmeno = "Václav", Prijmeni = "JAROLÍM", UserName = "jarova00", Rocnik = 2,
            OborKomb = "INF-PVS"
        },
        new()
        {
            OsCislo = "R21394", Jmeno = "Vojtěch", Prijmeni = "JIŘÍČEK", UserName = "jirivo02", Rocnik = 2,
            OborKomb = "INF-PVS"
        },
        new()
        {
            OsCislo = "R21640", Jmeno = "František", Prijmeni = "JUREK", UserName = "jurefr00", Rocnik = 2,
            OborKomb = "IT"
        },
        new()
        {
            OsCislo = "R21395", Jmeno = "Tomáš", Prijmeni = "KARNÝ", UserName = "karnto01", Rocnik = 2,
            OborKomb = "INF-PVS"
        },
        new()
        {
            OsCislo = "R21396", Jmeno = "Jakub", Prijmeni = "KAŠPAR", UserName = "kaspja09", Rocnik = 2,
            OborKomb = "INF-PVS"
        },
        new()
        {
            OsCislo = "R21397", Jmeno = "Jan", Prijmeni = "KNÁPEK", UserName = "knapja03", Rocnik = 2,
            OborKomb = "INF-PVS"
        },
        new()
        {
            OsCislo = "R21400", Jmeno = "Petr", Prijmeni = "KUBIŠTA", UserName = "kubipe09", Rocnik = 2,
            OborKomb = "INF-PVS"
        },
        new()
        {
            OsCislo = "R21403", Jmeno = "Miroslav", Prijmeni = "LOS", UserName = "losmi00", Rocnik = 2,
            OborKomb = "INF-PVS"
        },
        new()
        {
            OsCislo = "R210161", Jmeno = "Mark", Prijmeni = "MARCHENKO", UserName = "marcma04", Rocnik = 2,
            OborKomb = "INF-PVS"
        },
        new()
        {
            OsCislo = "R21408", Jmeno = "Jakub", Prijmeni = "MAZEL", UserName = "mazeja00", Rocnik = 2,
            OborKomb = "INF-OI"
        },
        new()
        {
            OsCislo = "R21409", Jmeno = "Jiří", Prijmeni = "MLČOUŠEK", UserName = "mlcoji00", Rocnik = 2,
            OborKomb = "INF-OI"
        },
        new()
        {
            OsCislo = "R21410", Jmeno = "Lukáš", Prijmeni = "MODRÝ", UserName = "modrlu00", Rocnik = 2,
            OborKomb = "INF-PVS"
        },
        new()
        {
            OsCislo = "R21648", Jmeno = "Marek", Prijmeni = "NASTOUPIL", UserName = "nastma02", Rocnik = 2,
            OborKomb = "IT"
        },
        new()
        {
            OsCislo = "R20180", Jmeno = "Petr", Prijmeni = "NĚMEC", UserName = "nemepe04", Rocnik = 2,
            OborKomb = "INF-PVS"
        },
        new()
        {
            OsCislo = "R21412", Jmeno = "Vojtěch", Prijmeni = "NETRH", UserName = "netrvo00", Rocnik = 2,
            OborKomb = "INF-PVS"
        },
        new()
        {
            OsCislo = "R20668", Jmeno = "Jakub", Prijmeni = "NEVRLÝ", UserName = "nevrja03", Rocnik = 3, OborKomb = "IT"
        },
        new()
        {
            OsCislo = "R21650", Jmeno = "Barbora", Prijmeni = "OHNOUTKOVÁ", UserName = "ohnoba00", Rocnik = 2,
            OborKomb = "IT"
        },
        new()
        {
            OsCislo = "R21652", Jmeno = "Thanh Tú", Prijmeni = "PHAN", UserName = "phanth01", Rocnik = 2,
            OborKomb = "IT"
        },
        new()
        {
            OsCislo = "R21656", Jmeno = "Petr", Prijmeni = "POST", UserName = "postpe01", Rocnik = 2, OborKomb = "IT"
        },
        new()
        {
            OsCislo = "R21418", Jmeno = "Tomáš", Prijmeni = "PUDL", UserName = "pudlto00", Rocnik = 2,
            OborKomb = "INF-PVS"
        },
        new()
        {
            OsCislo = "R21420", Jmeno = "Jan", Prijmeni = "RÁDL", UserName = "radlja00", Rocnik = 2,
            OborKomb = "INF-PVS"
        },
        new()
        {
            OsCislo = "R21423", Jmeno = "Lukáš", Prijmeni = "RYBENSKÝ", UserName = "rybelu01", Rocnik = 2,
            OborKomb = "INF-PVS"
        },
        new()
        {
            OsCislo = "R21658", Jmeno = "Adam", Prijmeni = "RYŠAVÝ", UserName = "rysaad00", Rocnik = 2, OborKomb = "IT"
        },
        new()
        {
            OsCislo = "R21659", Jmeno = "Jan", Prijmeni = "SAMIEC", UserName = "samija01", Rocnik = 2, OborKomb = "IT"
        },
        new()
        {
            OsCislo = "R21430", Jmeno = "Adam", Prijmeni = "SOUKUP", UserName = "soukad01", Rocnik = 2,
            OborKomb = "INF-PVS"
        },
        new()
        {
            OsCislo = "R21432", Jmeno = "Michal", Prijmeni = "SVOBODA", UserName = "svobmi13", Rocnik = 2,
            OborKomb = "INF-PVS"
        },
        new()
        {
            OsCislo = "R21664", Jmeno = "Michael", Prijmeni = "ŠIROKÝ", UserName = "siromi01", Rocnik = 2,
            OborKomb = "IT"
        },
        new()
        {
            OsCislo = "R21434", Jmeno = "Martin", Prijmeni = "ŠLACHTA", UserName = "slacma02", Rocnik = 5,
            OborKomb = "INF-OI"
        },
        new()
        {
            OsCislo = "R20643", Jmeno = "Daniel", Prijmeni = "ŠTEFÁK", UserName = "stefda03", Rocnik = 2,
            OborKomb = "IT"
        },
        new()
        {
            OsCislo = "R21438", Jmeno = "Radek", Prijmeni = "VYMĚTALÍK", UserName = "vymera00", Rocnik = 2,
            OborKomb = "INF-PVS"
        },
        new()
        {
            OsCislo = "R21668", Jmeno = "Lucie", Prijmeni = "ZAPLETALOVÁ", UserName = "vacllu10", Rocnik = 2,
            OborKomb = "IT"
        }
    };
}