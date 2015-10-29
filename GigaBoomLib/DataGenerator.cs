using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigaBoomLib
{
    static public class DataGenerator
    {
        static private Random _random;

        static string[] firstNameList = new string[] { "David", "John", "Paul", "Mark", "James", "Andrew", "Scott", "Steven", "Robert", "Stephen", "William", "Craig", "Michael", "Stuart",
                                     "Christopher", "Alan", "Colin", "Brian", "Kevin", "Gary", "Richard", "Derek", "Martin", "Thomas", "Jackson", "Aiden", "Liam", "Lucas", "Noah", "Mason", "Jayden", "Ethan",
                                     "Sophia", "Emma", "Olivia", "Isabella", "Mia", "Ava", "Lily", "Zoe", "Emily", "Chloe", "Layla", "Madison", "Madelyn", "Abigail", "Aubrey",
                                     "Arthur", "Ryan", "Roger", "Joe", "Juan", "Jack", "Albert", "Jonathan", "Justin", "Terry",
                                     "Gerald", "Keith", "Samuel", "Willie", "Ralph", "Lawrence", "Nicholas", "Roy", "Benjamin", 
                                     "Bruce", "Brandon", "Adam", "Harry", "Fred", "Wayne", "Billy", "Steve", "Louis", "jeremy", "Aaron"};

        static string[] lastNameList = new string[] {"Smith","Johnson","Williams","Brown","Jones","Miller","Davis","Garcia","Rodriguez","Wilson","Martinez","Anderson","Taylor","Thomas",
                                  "Hernandez", "Moore", "Martin", "Jackson", "Thompson", "White", "Lopez", "Lee", "Gonzalez", "Harris", "Clark", "Lewis", "Robinson", "Walker",
                                  "Perez", "Hall", "Young", "Allen", "Sanchez", "Wright", "King", "Scott", "Green", "Baker", "Adams", "Nelson", "Hill", "Ramirez", "Campbell", "Mitchell",
                                  "Roberts", "Carter", "Phillips", "Evans", "Turner", "Torres", "Parker", "Collins", "Edwards", "Stewart", "Flores", "Morris",
                                  "Nguyen", "Murphy", "Rivera", "Cook", "Rogers", "Morgan", "Peterson", "Cooper", "Reed", "Bailey", "Bell", "Gomez", "Kelly",
                                  "Howard", "Ward", "Cox", "Diaz", "Richardson", "Wood", "Watson", "Brooks", "Bennett", "Gray", "James", "Reyes", "Cruz", "Hughes",
                                  "Price", "Myers", "Long", "Foster", "Sanders", "Ross", "Morales", "Powell", "Sullivan", "Russell", "Ortiz", "Jenkins", "Gutierrez", 
                                  "Perry", "Butler", "Barnes", "Fisher", "Suzuki", "Satō", "Takahashi", "Tanaka", "Watanabe", "Nakamura", "Kobayashi", "Yamamoto", "Sasaki", "Yamada", "Yoshida"  };



        static public string GetRandomFirstName()
        {
            return firstNameList[Random.Next(firstNameList.Count())];
        }

        static public string GetRandomLastName()
        {
            return lastNameList[Random.Next(lastNameList.Count())];
        }

        static public string GetRandomSSN()
        {
            String r = Random.Next(100000000, 999999999).ToString("D9");
            return r;
        }

        static public string GetRandomZipCode()
        {
            String r = Random.Next(10000, 99999).ToString("D5");
            return r;
        }

        static public string GetRandomNumber3()
        {
            String r = Random.Next(100, 999).ToString("D3");
            return r;
        }

        static public string GetRandomNumber4()
        {
            String r = Random.Next(1000, 9999).ToString("D4");
            return r;
        }

        public static char GetLetter()
        {
            int num = Random.Next(0, 26); // Zero to 25
            char let = (char)('a' + num);
            return let;
        }

        public static string GetLetters(int num)
        {
            string rv = "";
            for (int i = 0; i < num; i++ )
            {
                rv = rv + GetLetter();
            }
            return rv;
        }

        public static string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            while (0 < length--)
            {
                res.Append(valid[Random.Next(valid.Length)]);
            }
            return res.ToString();
        }

        static private Random Random
        {
            get
            {
                if (_random == null)
                    _random = new Random();
                return _random;
            }
        }

        static public PersonProfile GeneratePersonProfile()
        {
            PersonProfile person = new PersonProfile();
            person.Generate();
            return person;
        }
    }

    public class AddressProfile
    {
        public string Line1;
        public string Line2;
        public string City;
        public string State;
        public string Zip;

        private string streetName = "";
        private string houseNumber;

        static string[] streetNameList = new string[] { "Park", "Maple", "Lake", "Sunset", "Pine", "Main", "Oak", "North", "River", "First", "Second",
                                    "Dogwood", "Ridge", "Clay", "Cedar", "Cottonwood", "Aspen", "Fourth", "Juniper", "Broadway", "Spring", "Hall",
                                    "Cherry", "Pine", "Wortham", "Meadow", "Shore", "Church", "Magnolia", "Smith"};

        static private Random _random;

        public AddressProfile()
        {
            streetName = streetNameList[Random.Next(streetNameList.Count())];
            houseNumber = Random.Next(1000, 99999).ToString("D5");

            Line1 = string.Format("{0} {1}", houseNumber, streetName);
        }

        override public string ToString()
        {
            string rv = "";
            rv = string.Format("{0}\n{1} {2} {3}", Line1, City, State, Zip);
            return rv;
        }

        static private Random Random
        {
            get
            {
                if (_random == null)
                    _random = new Random();
                return _random;
            }
        }
    }

    public class PhoneProfile
    {
        public string AreaCode;
        public string PhoneDetail1;
        public string PhoneDetail2;
        public string PhoneNumber;
        public string PhoneType;

        override public string ToString()
        {
            string rv = "";
            rv = string.Format("({0}) {1}-{2}", AreaCode, PhoneDetail1, PhoneDetail2);
            return rv;
        }
    }

    public class PersonProfile
    {
        public string FirstName;
        public string LastName;
        public string Email;
        public string SSN;
        public AddressProfile Address;
        public PhoneProfile CellPhone;
        public string Password;
        public string LoginName;


        public PersonProfile()
        {
            Address = new AddressProfile();
            CellPhone = new PhoneProfile();
            Password = DataGenerator.CreatePassword(10);
        }

        public void Generate()
        {
            FirstName = DataGenerator.GetRandomFirstName();
            LastName = DataGenerator.GetRandomLastName();
            Email = string.Format("{0}.{1}@TestEmail.com", FirstName, LastName);
            SSN = DataGenerator.GetRandomSSN();

            UsaCity city = UsaCities.GetRandomCity();
            string zip = city.GetRandomZipCode();

            Address.Zip = zip;
            Address.State = city.StateCode;
            Address.City = city.CityName;


            UsaState state = UsaStates.GetState(city.StateCode);
            CellPhone.AreaCode = UsaStates.GetRandomAreaCode(state);
            CellPhone.PhoneDetail1 = DataGenerator.GetRandomNumber3();
            CellPhone.PhoneDetail2 = DataGenerator.GetRandomNumber4();
            CellPhone.PhoneNumber = CellPhone.ToString();

            if (city.AreaCodes.Length > 0)
            {
                CellPhone.AreaCode = city.GetRandomAreaCode();
                CellPhone.PhoneNumber = CellPhone.ToString();
            }

            LoginName = string.Format("{0}{1}", LastName, FirstName);
        }

        override public string ToString()
        {
            string rv = "";
            rv = string.Format("{0} {1}\n{2}\n{3}\n{4}\nLogin:{5}\nPass:{6}", FirstName, LastName, CellPhone.ToString(), Email, Address.ToString(), LoginName, Password);
            return rv;
        }
    }


    public class UsaCity
    {
        public string CityName;
        public string StateCode;
        public int Census2014;
        public int PopulationDensityPerMile;
        public int PopulationDensityPerKilometer;
        public int ZipStart;
        public int ZipEnd;
        public string AreaCodes = "";

        static private Random _random;

        public UsaCity(string stateCode, string cityName, int census2014, int populationDensityPerMile)
        {
            StateCode = stateCode;
            CityName = cityName;
            Census2014 = census2014;
            PopulationDensityPerMile = populationDensityPerMile;
        }

        public UsaCity(string stateCode, string cityName, int census2014, int populationDensityPerMile, int zipStart, int zipEnd)
        {
            StateCode = stateCode;
            CityName = cityName;
            Census2014 = census2014;
            PopulationDensityPerMile = populationDensityPerMile;
            ZipStart = zipStart;
            ZipEnd = zipEnd;
        }

        public UsaCity(string stateCode, string cityName, int census2014, int populationDensityPerMile, int zipStart, int zipEnd, string areaCodes)
        {
            StateCode = stateCode;
            CityName = cityName;
            Census2014 = census2014;
            PopulationDensityPerMile = populationDensityPerMile;
            ZipStart = zipStart;
            ZipEnd = zipEnd;
            AreaCodes = areaCodes;
        }

        public string GetRandomZipCode()
        {
            String zip = Random.Next(ZipStart, ZipEnd).ToString("D5");
            return zip;
        }

        public string GetRandomAreaCode()
        {
            string[] areaCodes = AreaCodes.Split('-');
            String areaCode = areaCodes[Random.Next(areaCodes.Count())];
            return areaCode;
        }


        static private Random Random
        {
            get
            {
                if (_random == null)
                    _random = new Random();
                return _random;
            }
        }
    }

    public class UsaCities
    {
        static private Random _random;

        //
        // https://en.wikipedia.org/wiki/List_of_United_States_cities_by_population
        //
        static UsaCity[] cityList = new UsaCity[] {
             new UsaCity("NY", "New York", 8491079, 27012, 10001, 10292, "212-347-646-718-917-929")
           , new UsaCity("CA", "Los Angeles", 3928864, 8092, 90001, 91607, "213-310-323-424-562-626-657-661-714-747-760-805-818-909")
           , new UsaCity("IL", "Chicago", 2722389, 11842, 60290, 60701, "312-773-872")
           , new UsaCity("TX", "Houston", 2239558, 3501, 77001, 77299, "281-346-713-832")
           , new UsaCity("PA", "Philadelphia", 1560297, 11379, 19019, 19255)
           , new UsaCity("AZ", "Phoenix", 1537058, 2798, 85001, 85099)
           , new UsaCity("TX", "San Antonio", 1436697, 2880, 78201, 78299)
           , new UsaCity("CA", "San Diego", 1381069, 4020, 92093, 92199)
           , new UsaCity("TX", "Dallas", 1281047, 3518, 75201, 75398)
           , new UsaCity("CA", "San Jose", 1015785, 5359, 95101, 95196)
           , new UsaCity("TX", "Austin", 912791, 2653, 73301, 78799)
           , new UsaCity("FL", "Jacksonville", 853382, 1120, 32099, 32277)
           , new UsaCity("CA", "San Francisco", 852469, 17179, 94101, 94199)
           , new UsaCity("IN", "Indianapolis", 848788, 2270, 46201, 46298)
           , new UsaCity("OH", "Columbus", 835957, 3624, 43085, 43291)
           , new UsaCity("TX", "Fort Worth", 812238, 2181, 76101, 76199)
           , new UsaCity("NC", "Charlotte", 809958, 2457, 28201, 28299)
           , new UsaCity("MI", "Detroit", 680250, 5144, 48201, 48288)
           , new UsaCity("TX", "El Paso", 679036, 2543, 79901, 88595)
           , new UsaCity("WA", "Seattle", 668342, 7251, 98101, 98199)
           , new UsaCity("CO", "Denver", 663862, 3923, 80123, 80299)
           , new UsaCity("TN", "Memphis", 656861, 2053, 37501, 38197)
           , new UsaCity("MA", "Boston", 655884, 12793, 02108, 02298)
           , new UsaCity("TN", "Nashville", 644014, 1265, 37115, 37250)
           , new UsaCity("MD", "Baltimore", 622793, 7672, 21117, 21229)
           , new UsaCity("OK", "Oklahoma", 620602, 956, 74011, 74012)
           , new UsaCity("OR", "Portland", 619360, 4375, 97201, 97299)
           , new UsaCity("NV", "Las vegas", 613599, 4298, 89101, 89199)
           , new UsaCity("KY", "Louisville", 612780, 1837, 40201, 40299)
           , new UsaCity("WI", "Milwaukee", 599642, 6188, 53202, 53205)
           , new UsaCity("NM", "Albuquerque", 557169, 2908, 87101, 87199)
           , new UsaCity("AZ", "Tucson", 527972, 2294, 85701, 85775)
           , new UsaCity("CA", "Fresno", 515986, 4418, 93650, 93888)
           , new UsaCity("CA", "Sacramento", 485199, 4764, 94203, 95899)
           , new UsaCity("CA", "Long Beach", 473577, 9191, 90801, 90899)
           , new UsaCity("MO", "Kansas City", 470800, 1460, 64101, 64999)
           , new UsaCity("AZ", "Mesa", 464704, 3218, 85201, 85277)
           , new UsaCity("GA", "Atlanta", 456002, 3154, 30301, 39901)
        };

        static public UsaCity GetRandomCity()
        {
            UsaCity city = cityList[Random.Next(cityList.Count())];

            String zip = Random.Next(city.ZipStart, city.ZipEnd).ToString("D5");
            return city;
        }

        static private Random Random
        {
            get
            {
                if (_random == null)
                    _random = new Random();
                return _random;
            }
        }
    }


    public class UsaState
    {
        public string Name;
        public string Abbrev;
        public string Capital;
        public string AreaCodes;

        public UsaState(string name, string abbrev)
        {
            Name = name;
            Abbrev = abbrev;
        }

        public UsaState(string name, string abbrev, string capital)
        {
            Name = name;
            Abbrev = abbrev;
            Capital = capital;
        }

        public UsaState(string name, string abbrev, string capital, string areaCodes)
        {
            Name = name;
            Abbrev = abbrev;
            Capital = capital;
            AreaCodes = areaCodes;
        }
    }

    public class UsaStates
    {
        static UsaState[] stateList = new UsaState[] { new UsaState("Alabama", "AL", "Montgomery", "205 - 251 - 256 - 334"), 
                                                       new UsaState("Alaska","AK", "Juneau", "907"), 
                                                       new UsaState("Arizona","AZ", "Phoenix", "480 - 520 - 602 - 623 - 928"), 
                                                       new UsaState("Arkansas","AR", "Little Rock", "501 - 870"), 
                                                       new UsaState("California","CA", "Sacramento", "209 - 213 - 310 - 323 - 408 - 415 - 510 - 530 - 559 - 562 - 619 - 626 - 650 - 661 - 707 - 714 - 760 - 805 - 818 - 831 - 858 - 909 - 916 - 925 - 949"),
                                                       new UsaState("Colorado", "CO", "Denver", "303 - 719 - 720 - 970"), 
                                                       new UsaState("Connecticut","CT", "Hartford", "203 - 860"), 
                                                       new UsaState("Delaware","DE", "Dover", "302"), 
                                                       new UsaState("Florida","FL", "Tallahassee", "305 - 321 - 352 - 386 - 407 - 561 - 727 - 754 - 772 - 786 - 813 - 850 - 863 - 904 - 941 - 954"), 
                                                       new UsaState("Georgia","GA", "Atlanta", "229 - 404 - 478 - 678 - 706 - 770 - 912"),
                                                       new UsaState("Hawaii","HI", "Honolulu", "808"), 
                                                       new UsaState("Idaho","ID", "Boise", "208"), 
                                                       new UsaState("Illinois","IL", "Springfield", "217 - 309 - 312 - 618 - 630 - 708 - 773 - 815 - 847"), 
                                                       new UsaState("Indiana","IN", "Indianapolis", "219 - 260 - 317 - 574 - 765 - 812"), 
                                                       new UsaState("Iowa","IA", "Des Moines", "319 - 515 -563 - 641 - 712"), 
                                                       new UsaState("Kansas","KS", "Topeka", "316 - 620 - 785 - 913"),
                                                       new UsaState("Kentucky", "KY", "Frankfort", "270 - 502 - 606 - 859"), 
                                                       new UsaState("Louisiana","LA", "Baton Rouge", "225 - 318 - 337 - 504 - 985"), 
                                                       new UsaState("Maine","ME", "Augusta", "207"), 
                                                       new UsaState("Maryland","MD", "Annapolis", "240 - 301 - 410 - 443"), 
                                                       new UsaState("Massachusetts","MA", "Boston", "339 - 351 - 413 - 508 - 617 - 774 - 781 - 857 - 978"),
                                                       new UsaState("Michigan","MI","Lansing", "231 - 248 - 269 - 313 - 517 - 586 - 616 - 734 - 810 - 906 - 989"), 
                                                       new UsaState("Minnesota","MN", "St. Paul", "218 - 320 - 507 - 612 - 651 - 763 - 952"), 
                                                       new UsaState("Mississippi","MS", "Jackson", "228 - 601 - 662"), 
                                                       new UsaState("Missouri","MO", "Jefferson City", "314 - 417 - 573 - 636 - 660 - 816"), 
                                                       new UsaState("Montana","MT", "Helena", "406"),
                                                       new UsaState("Nebraska","NE", "Lincoln", "308 - 402"), 
                                                       new UsaState("Nevada","NV", "Carson City", "702 - 775"), 
                                                       new UsaState("New Hampshire","NH", "Concord", "603"), 
                                                       new UsaState("New Jersey","NJ", "Trenton", "201 - 609 - 732 - 856 - 908 - 973"), 
                                                       new UsaState("New Mexico","NM", "Santa Fe", "505"),
                                                       new UsaState("New York","NY", "Albany", "212 - 315 - 347 - 516 - 518 - 607 - 631 - 646 - 716 - 718 - 845 - 914 - 917"), 
                                                       new UsaState("North Carolina", "NC", "Raleigh", "252 - 336 - 704 - 828 - 910 - 919 - 980"), 
                                                       new UsaState("North Dakota","ND", "Bismarck", "701"), 
                                                       new UsaState("Ohio","OH", "Columbus", "216 - 234 - 330 - 419 - 440 - 513 - 614 - 740 - 937"), 
                                                       new UsaState("Oklahoma","OK", "Oklahoma City", "405 - 580 - 918"),
                                                       new UsaState("Oregon","OR", "Salem", "503 - 541 - 971"), 
                                                       new UsaState("Pennsylvania","PA", "Harrisburg", "215 - 267 - 412 - 484 - 570 - 610 - 717 - 724 - 814 - 878"),  
                                                       new UsaState("Rhode Island","RI", "Providence", "401"), 
                                                       new UsaState("South Carolina","SC", "Columbia", "803 - 843 - 864"), 
                                                       new UsaState("South Dakota","SD", "Pierre", "605"), 
                                                       new UsaState("Tennessee","TN", "Nashville", "423 - 615 - 731 - 865 - 901 - 931"), 
                                                       new UsaState("Texas","TX", "Austin", "210 - 214 - 254 - 281 - 361 - 409 - 469 - 512 - 682 - 713 - 806 - 817 - 830 - 832 - 903 - 915 - 936 - 940 - 956 - 972 - 979"), 
                                                       new UsaState("Utah","UT", "Salt Lake City", "435 - 801"), 
                                                       new UsaState("Vermont","VT", "Montpelier", "802"), 
                                                       new UsaState("Virginia","VA", "Richmond", "276 - 434 - 540 - 571 - 703 - 757 - 804"),
                                                       new UsaState("Washington","WA", "Olympia", "206 - 253 - 360 - 425 - 509"), 
                                                       new UsaState("West Virginia","WV", "Charleston", "304"), 
                                                       new UsaState("Wisconsin","WI", "Madison", "262 - 414 - 608 - 715 - 920"), 
                                                       new UsaState("Wyoming","WY", "Cheyenne", "307") };

        static private Random _random;

        static private Random Random
        {
            get
            {
                if (_random == null)
                    _random = new Random();
                return _random;
            }
        }

        static public UsaState GetState(string StateCode)
        {
            UsaState state = null;

            foreach (UsaState item in stateList)
            {
                if (item.Abbrev.Equals(StateCode))
                    return item;
            }

            return state;
        }

        static public string GetRandomAreaCode(UsaState state)
        {
            string areaCode = "";

            string[] areaCodeList = state.AreaCodes.Split('-');
            areaCode = areaCodeList[Random.Next(areaCodeList.Count())];

            return areaCode.Trim();
        }

    }

    

}
