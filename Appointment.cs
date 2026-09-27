namespace nadlan
{
    public class Appointment
    {
        private int appointmentId;
        private Property property;
        private User client;
        private string date;
        private bool isConfirmed;

        public Appointment(int appointmentId, Property property, User client, string date)
        {
            this.appointmentId = appointmentId;
            this.property = property;
            this.client = client;
            this.date = date;
            this.isConfirmed = false;
        }

        public int GetAppointmentId() { return appointmentId; }
        public Property GetProperty() { return property; }
        public User GetClient() { return client; }
        public string GetDate() { return date; }
        public void SetDate(string date) { this.date = date; }
        public bool IsConfirmed() { return isConfirmed; }
        public void SetConfirmed(bool isConfirmed) { this.isConfirmed = isConfirmed; }

        public override string ToString()
        {
            string status = isConfirmed ? "מאושרת" : "ממתינה";

            return "פגישה " + appointmentId + " | מועד: " + date
                + " | לקוח: " + client.ToString()
                + " | " + property.ToString()
                + " | " + status;
        }
    }
}