namespace MyBikeResults.Domain.Entities
{
    //These are the entities that I excpect to retrieve from the JSON file
    public class Bike
    {
        public int BikeID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Displacement { get; set; }
        public int Price { get; set; }
        public string Terrain { get; set; }
        public string Description { get; set; }
    }
}
