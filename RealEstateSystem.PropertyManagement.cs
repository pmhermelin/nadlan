namespace nadlan
{
    public partial class RealEstateSystem
    {
        // S-01 (Story G) - הוספת נכס חדש
        public void AddNewProperty(User agent)
        {
            if (agent == null || !agent.IsAgent())
            {
                Console.WriteLine("שגיאה: פעולה זו זמינה לסוכנים בלבד");
                return;
            }

            if (propertyCount >= PROPERTIES_MAX)
            {
                Console.WriteLine("לא ניתן להוסיף - המערכת מלאה");
                return;
            }

            string city = ReadNotEmpty("הזן עיר:");
            string street = ReadNotEmpty("הזן רחוב:");
            int rooms = ReadInt("הזן מספר חדרים:");
            double area = ReadDouble("הזן שטח (מ\"ר):");
            double price = ReadDouble("הזן מחיר:");

            string dealType;
            while (true)
            {
                dealType = ReadNotEmpty("סוג עסקה (1 = למכירה, 2 = להשכרה):");
                if (dealType == "1" || dealType == "2")
                {
                    break;
                }
                Console.WriteLine("קלט לא תקין, נסה שוב");
            }
            bool isForRent = (dealType == "2");

            Property newProperty = new Property(nextPropertyId, city, street, rooms, area, price, isForRent, agent);
            properties[propertyCount] = newProperty;
            propertyCount++;

            Console.WriteLine("הנכס נוסף בהצלחה, מזהה: " + nextPropertyId);
            nextPropertyId++;
        }

        // S-04 (Story J) - הצגת הנכסים שלי
        public void PrintAgentProperties(User agent)
        {
            if (agent == null || !agent.IsAgent())
            {
                Console.WriteLine("שגיאה: פעולה זו זמינה לסוכנים בלבד");
                return;
            }

            bool found = false;
            for (int i = 0; i < propertyCount; i++)
            {
                if (properties[i].GetAgent() == agent)
                {
                    Console.WriteLine(properties[i].ToString());
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("אין נכסים המשויכים אליך");
            }
        }

        // S-03 (Story I) - עדכון זמינות נכס
        public void UpdatePropertyAvailability(User agent)
        {
            if (agent == null || !agent.IsAgent())
            {
                Console.WriteLine("שגיאה: פעולה זו זמינה לסוכנים בלבד");
                return;
            }

            PrintAgentProperties(agent);

            int id = ReadInt("הזן מזהה נכס לעדכון:");
            Property property = FindPropertyById(id);

            if (property == null)
            {
                Console.WriteLine("נכס לא נמצא");
                return;
            }

            if (property.GetAgent() != agent)
            {
                Console.WriteLine("הנכס אינו משויך אליך");
                return;
            }

            string choice;
            while (true)
            {
                choice = ReadNotEmpty("זמינות חדשה (1 = זמין, 2 = לא זמין):");
                if (choice == "1" || choice == "2")
                {
                    break;
                }
                Console.WriteLine("קלט לא תקין, נסה שוב");
            }

            property.SetAvailable(choice == "1");

            Console.WriteLine("הזמינות עודכנה בהצלחה");
        }

        // S-02 (Story H) - הסרת נכס
        public void RemoveProperty(User agent)
        {
            // TODO
        }
    }
}