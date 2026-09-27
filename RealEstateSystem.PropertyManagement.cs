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
            // TODO
        }

        // S-02 (Story H) - הסרת נכס
        public void RemoveProperty(User agent)
        {
            // TODO
        }
    }
}