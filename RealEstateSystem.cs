namespace nadlan
{
    public partial class RealEstateSystem
    {
        private const int USERS_MAX = 100;
        private const int PROPERTIES_MAX = 100;
        private const int APPOINTMENTS_MAX = 200;

        private User[] users;
        private int userCount;
        private Property[] properties;
        private int propertyCount;
        private Appointment[] appointments;
        private int appointmentCount;
        private int nextPropertyId;
        private int nextAppointmentId;

        public RealEstateSystem()
        {
            users = new User[USERS_MAX];
            properties = new Property[PROPERTIES_MAX];
            appointments = new Appointment[APPOINTMENTS_MAX];
            userCount = 0;
            propertyCount = 0;
            appointmentCount = 0;

            users[userCount++] = new User("manager", "1234", "דנה מנהלת", "050-0000000", false, true);
            User agent1 = new User("agent1", "1234", "יוסי סוכן", "050-1111111", true, false);
            User agent2 = new User("agent2", "1234", "רונית סוכנת", "050-2222222", true, false);
            User agent3 = new User("agent3", "1234", "אבי סוכן", "050-3333333", true, false);
            users[userCount++] = agent1;
            users[userCount++] = agent2;
            users[userCount++] = agent3;

            string[] cities = { "ירושלים", "תל אביב", "חיפה", "באר שבע", "נתניה", "כפר סבא", "רעננה", "אשדוד" };
            string[] streets = { "הרצל", "ויצמן", "בן גוריון", "רוטשילד", "הנשיא" };
            User[] agentList = { agent1, agent2, agent3 };

            for (int i = 0; i < 15; i++)
            {
                string city = cities[i % cities.Length];
                string street = streets[i % streets.Length] + " " + (i + 1);
                int rooms = 2 + (i % 4);
                double area = 50 + i * 7;
                bool isForRent = (i % 3 == 1);
                double price = isForRent ? 3000 + i * 150 : 1200000 + i * 90000;
                User agent = agentList[i % 3];

                properties[propertyCount++] = new Property(i + 1, city, street, rooms, area, price, isForRent, agent);
            }

            nextPropertyId = 16;
            nextAppointmentId = 1;
        }

        private User FindUserByUsername(string username)
        {
            for (int i = 0; i < userCount; i++)
            {
                if (users[i].GetUsername() == username)
                {
                    return users[i];
                }
            }
            return null;
        }

        private Property FindPropertyById(int id)
        {
            for (int i = 0; i < propertyCount; i++)
            {
                if (properties[i].GetPropertyId() == id)
                {
                    return properties[i];
                }
            }
            return null;
        }

        private int FindPropertyIndex(int id)
        {
            for (int i = 0; i < propertyCount; i++)
            {
                if (properties[i].GetPropertyId() == id)
                {
                    return i;
                }
            }
            return -1;
        }

        private Appointment FindAppointmentById(int id)
        {
            for (int i = 0; i < appointmentCount; i++)
            {
                if (appointments[i].GetAppointmentId() == id)
                {
                    return appointments[i];
                }
            }
            return null;
        }

        private bool HasAppointments(Property property)
        {
            for (int i = 0; i < appointmentCount; i++)
            {
                if (appointments[i].GetProperty() == property)
                {
                    return true;
                }
            }
            return false;
        }

        private string ReadNotEmpty(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();
                if (input != null && input.Trim() != "")
                {
                    return input.Trim();
                }
                Console.WriteLine("קלט לא תקין, נסה שוב");
            }
        }

        private int ReadInt(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();
                int value;
                if (int.TryParse(input, out value) && value > 0)
                {
                    return value;
                }
                Console.WriteLine("קלט לא תקין, נסה שוב");
            }
        }

        private double ReadDouble(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();
                double value;
                if (double.TryParse(input, out value) && value > 0)
                {
                    return value;
                }
                Console.WriteLine("קלט לא תקין, נסה שוב");
            }
        }
    }
}