namespace CommonDLL
{
    public class Person
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Geschlecht { get; set; }
        public int Alter { get; set; }
        public Person(string vorname, string nachname, string geschlecht, int alter)
        {
            Vorname = vorname;
            Nachname = nachname;
            Geschlecht = geschlecht;
            Alter = alter;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            Person other = (Person)obj;
            return Vorname == other.Vorname && Nachname == other.Nachname && Geschlecht == other.Geschlecht && Alter == other.Alter;
        }
    }
}