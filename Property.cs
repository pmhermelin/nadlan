namespace nadlan
{
    public class Property
    {
        private int propertyId;
        private string city;
        private string street;
        private int rooms;
        private double area;
        private double price;
        private bool isForRent;
        private bool isAvailable;
        private User agent;

        public Property(int propertyId, string city, string street, int rooms, double area, double price, bool isForRent, User agent)
        {
            this.propertyId = propertyId;
            this.city = city;
            this.street = street;
            this.rooms = rooms;
            this.area = area;
            this.price = price;
            this.isForRent = isForRent;
            this.agent = agent;
            this.isAvailable = true;
        }

        public int GetPropertyId() { return propertyId; }
        public string GetCity() { return city; }
        public string GetStreet() { return street; }
        public int GetRooms() { return rooms; }
        public double GetArea() { return area; }
        public double GetPrice() { return price; }
        public void SetPrice(double price) { this.price = price; }
        public bool IsForRent() { return isForRent; }
        public bool IsAvailable() { return isAvailable; }
        public void SetAvailable(bool isAvailable) { this.isAvailable = isAvailable; }
        public User GetAgent() { return agent; }

        public double GetPricePerMeter() { return price / area; }

        public override string ToString()
        {
            string deal = isForRent ? "להשכרה" : "למכירה";
            string availability = isAvailable ? "זמין" : "לא זמין";

            return "נכס " + propertyId + ": " + city + ", " + street
                + " | " + rooms + " חד' | " + area + " מ\"ר | " + deal
                + " | " + availability + " | " + price + " ש\"ח | סוכן: " + agent.ToString();
        }
    }
}