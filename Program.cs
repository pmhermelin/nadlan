namespace nadlan
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            RealEstateSystem system = new RealEstateSystem();
            User currentUser = null;
            bool running = true;

            while (running)
            {
                PrintLoginMenu();
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    system.CreateUser();
                }
                else if (choice == "2")
                {
                    currentUser = system.Login();
                    if (currentUser != null)
                    {
                        if (currentUser.IsManager())
                        {
                            RunManagerMenu(system, currentUser);
                        }
                        else if (currentUser.IsAgent())
                        {
                            RunAgentMenu(system, currentUser);
                        }
                        else
                        {
                            RunClientMenu(system, currentUser);
                        }
                        currentUser = null;
                    }
                }
                else if (choice == "3")
                {
                    Console.WriteLine("להתראות!");
                    running = false;
                }
                else
                {
                    Console.WriteLine("בחירה לא חוקית");
                }
            }
        }

        static void PrintLoginMenu()
        {
            Console.WriteLine();
            Console.WriteLine("=== מערכת ניהול לסוכנות נדל\"ן ===");
            Console.WriteLine("1. הרשמה");
            Console.WriteLine("2. התחברות");
            Console.WriteLine("3. יציאה");
            Console.WriteLine("בחר אפשרות:");
        }

        static void RunClientMenu(RealEstateSystem system, User client)
        {
            bool active = true;
            while (active)
            {
                Console.WriteLine();
                Console.WriteLine("=== תפריט לקוח ===");
                Console.WriteLine("1. הצגת כל הנכסים");
                Console.WriteLine("2. חיפוש וסינון נכסים");
                Console.WriteLine("3. שליחת בקשה לפגישת צפייה");
                Console.WriteLine("4. הצגת הבקשות שלי");
                Console.WriteLine("5. התנתקות");
                Console.WriteLine("בחר אפשרות:");
                string choice = Console.ReadLine();

                if (choice == "1") system.PrintAllProperties();
                else if (choice == "2") system.SearchProperties();
                else if (choice == "3") system.ScheduleAppointment(client);
                else if (choice == "4") system.PrintClientAppointments(client);
                else if (choice == "5") active = false;
                else Console.WriteLine("בחירה לא חוקית");
            }
        }

        static void RunAgentMenu(RealEstateSystem system, User agent)
        {
            bool active = true;
            while (active)
            {
                Console.WriteLine();
                Console.WriteLine("=== תפריט סוכן ===");
                Console.WriteLine("1. הוספת נכס חדש");
                Console.WriteLine("2. הסרת נכס");
                Console.WriteLine("3. הצגת הנכסים שלי");
                Console.WriteLine("4. עדכון זמינות נכס");
                Console.WriteLine("5. הצגת פגישות לנכס");
                Console.WriteLine("6. אישור בקשת פגישה");
                Console.WriteLine("7. התנתקות");
                Console.WriteLine("בחר אפשרות:");
                string choice = Console.ReadLine();

                if (choice == "1") system.AddNewProperty(agent);
                else if (choice == "2") system.RemoveProperty(agent);
                else if (choice == "3") system.PrintAgentProperties(agent);
                else if (choice == "4") system.UpdatePropertyAvailability(agent);
                else if (choice == "5") system.PrintPropertyAppointments(agent);
                else if (choice == "6") system.ConfirmAppointment(agent);
                else if (choice == "7") active = false;
                else Console.WriteLine("בחירה לא חוקית");
            }
        }

        static void RunManagerMenu(RealEstateSystem system, User manager)
        {
            bool active = true;
            while (active)
            {
                Console.WriteLine();
                Console.WriteLine("=== תפריט מנהל ===");
                Console.WriteLine("1. הצגת כל נכסי הסוכנות");
                Console.WriteLine("2. הצגת פגישות במערכת");
                Console.WriteLine("3. התנתקות");
                Console.WriteLine("בחר אפשרות:");
                string choice = Console.ReadLine();

                if (choice == "1") system.PrintAllRealEstate(manager);
                else if (choice == "2") system.PrintUserAppointments(manager);
                else if (choice == "3") active = false;
                else Console.WriteLine("בחירה לא חוקית");
            }
        }
    }
}