namespace nadlan
{
    public partial class RealEstateSystem
    {
        // S-01 (Story G) - הוספת נכס חדש
        public void AddNewProperty(User agent)
        {
            // TODO
        }

        // S-04 (Story J) - הצגת הנכסים שלי
        public void PrintAgentProperties(User agent)
        {
            // TODO
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