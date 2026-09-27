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
            // TODO
        }

        // S-03 (Story I) - עדכון זמינות נכס
        public void UpdatePropertyAvailability(User agent)
        {
            // TODO
        }

        // S-02 (Story H) - הסרת נכס
        public void RemoveProperty(User agent)
        {
            // TODO
        }
    }
}