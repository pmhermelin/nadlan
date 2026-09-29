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
            // TODO
        }

        // S-05 (Story K) - הצגת פגישות לנכס
        public void PrintPropertyAppointments(User agent)
        {
            // TODO
        }

        // S-06 (Story L) - אישור בקשת פגישה
        public void ConfirmAppointment(User agent)
        {
            // TODO
        }

        // M-03 (Story O) - הצגת פגישות של משתמש
        public void PrintUserAppointments(User user)
        {
            // TODO
        }
    }
}