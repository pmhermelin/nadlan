namespace nadlan
{
    public partial class RealEstateSystem
    {
        // L-05 (Story E) - שליחת בקשה לפגישת צפייה
        public void ScheduleAppointment(User client)
        {
            if (client == null || !client.IsClient())
            {
                Console.WriteLine("שגיאה: פעולה זו זמינה ללקוחות בלבד");
                return;
            }

            if (appointmentCount >= APPOINTMENTS_MAX)
            {
                Console.WriteLine("לא ניתן להוסיף - המערכת מלאה");
                return;
            }

            PrintAllProperties();

            int id = ReadInt("הזן מזהה נכס לצפייה:");
            Property property = FindPropertyById(id);

            if (property == null)
            {
                Console.WriteLine("נכס לא נמצא");
                return;
            }

            if (!property.IsAvailable())
            {
                Console.WriteLine("הנכס אינו זמין לצפייה");
                return;
            }

            for (int i = 0; i < appointmentCount; i++)
            {
                if (appointments[i].GetClient() == client && appointments[i].GetProperty() == property)
                {
                    Console.WriteLine("כבר קיימת בקשה שלך לנכס זה");
                    return;
                }
            }

            string date;
            while (true)
            {
                date = ReadNotEmpty("הזן מועד בפורמט dd/MM/yyyy HH:mm:");
                DateTime parsed;
                if (DateTime.TryParseExact(date, "dd/MM/yyyy HH:mm",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out parsed))
                {
                    break;
                }
                Console.WriteLine("קלט לא תקין, נסה שוב");
            }

            Appointment newAppointment = new Appointment(nextAppointmentId, property, client, date);
            appointments[appointmentCount] = newAppointment;
            appointmentCount++;
            nextAppointmentId++;

            Console.WriteLine("הבקשה נשלחה בהצלחה, מזהה פגישה: " + newAppointment.GetAppointmentId());
            Console.WriteLine("הסוכן האחראי: " + property.GetAgent().GetFullName());
        }

        // L-06 (Story F) - הצגת הבקשות שלי
        public void PrintClientAppointments(User client)
        {
            if (client == null || !client.IsClient())
            {
                Console.WriteLine("שגיאה: פעולה זו זמינה ללקוחות בלבד");
                return;
            }

            bool found = false;
            for (int i = 0; i < appointmentCount; i++)
            {
                if (appointments[i].GetClient() == client)
                {
                    Console.WriteLine(appointments[i].ToString());
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("אין לך פגישות");
            }
        }

        // S-05 (Story K) - הצגת פגישות לנכס
        public void PrintPropertyAppointments(User agent)
        {
            if (agent == null || !agent.IsAgent())
            {
                Console.WriteLine("שגיאה: פעולה זו זמינה לסוכנים בלבד");
                return;
            }

            PrintAgentProperties(agent);

            int id = ReadInt("הזן מזהה נכס:");
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

            bool found = false;
            for (int i = 0; i < appointmentCount; i++)
            {
                if (appointments[i].GetProperty() == property)
                {
                    Console.WriteLine(appointments[i].ToString());
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("אין פגישות לנכס זה");
            }
        }

        // S-06 (Story L) - אישור בקשת פגישה
        public void ConfirmAppointment(User agent)
        {
            if (agent == null || !agent.IsAgent())
            {
                Console.WriteLine("שגיאה: פעולה זו זמינה לסוכנים בלבד");
                return;
            }

            bool hasPending = false;
            for (int i = 0; i < appointmentCount; i++)
            {
                if (appointments[i].GetProperty().GetAgent() == agent && !appointments[i].IsConfirmed())
                {
                    Console.WriteLine(appointments[i].ToString());
                    hasPending = true;
                }
            }

            if (!hasPending)
            {
                Console.WriteLine("אין בקשות ממתינות לאישור");
                return;
            }

            int id = ReadInt("הזן מזהה פגישה לאישור:");
            Appointment appointment = FindAppointmentById(id);

            if (appointment == null)
            {
                Console.WriteLine("פגישה לא נמצאה");
                return;
            }

            if (appointment.GetProperty().GetAgent() != agent)
            {
                Console.WriteLine("הפגישה אינה משויכת לנכס שלך");
                return;
            }

            if (appointment.IsConfirmed())
            {
                Console.WriteLine("הפגישה כבר אושרה");
                return;
            }

            appointment.SetConfirmed(true);

            Console.WriteLine("הפגישה אושרה בהצלחה");
        }

        // M-03 (Story O) - הצגת פגישות של משתמש
        public void PrintUserAppointments(User user)
        {
            if (user == null)
            {
                Console.WriteLine("שגיאה: משתמש לא מחובר");
                return;
            }

            bool found = false;
            for (int i = 0; i < appointmentCount; i++)
            {
                Appointment appointment = appointments[i];
                bool match;

                if (user.IsManager())
                {
                    match = true;
                }
                else if (user.IsAgent())
                {
                    match = appointment.GetProperty().GetAgent() == user;
                }
                else
                {
                    match = appointment.GetClient() == user;
                }

                if (match)
                {
                    Console.WriteLine(appointment.ToString());
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("לא נמצאו פגישות");
            }
        }
    }
}