

namespace DataManager.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Animal(string name)
        {
            Name = name;
        }

        // Chce, aby aplikacja działała tak, że użytkownik podaje nazwe zwierzecia ogólna
        // papuga po czym jezeli jest to w bazie danych to wypisuje te rzeczy ktore sa ponizej
        // oraz chcialem jeszcze zeby byl mozliwy dzwiek tego zwierzecia jezeli jest dostepny ale to na razie 
        // chce osiagnac to, zeby bylo tylko nazwa byla przyjmowana od uzytkownika i dostawal informacje o papugach

        //public string Kingdom { get; set; }

        //public string Phylum { get; set; }

        //public string Class { get; set; }
        //public string Order { get; set; }

        //public string Family { get; set; }

        //public string Genus { get; set; }

        //public string Species { get; set; }

        //public sound


    }
}
