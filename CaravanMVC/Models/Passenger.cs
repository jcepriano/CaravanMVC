namespace CaravanMVC.Models
{
    public class Passenger
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Destination { get; set; }
        public Wagon Wagon { get; set; }
    
        public Passenger(string name, int age, string destination)
        {
            Name = name;
            Age = age;
            Destination = destination;
        }

    }

}
