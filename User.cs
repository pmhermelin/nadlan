namespace nadlan
{
    public class User
    {
        private string username;
        private string password;
        private string fullName;
        private string phone;
        private bool isAgent;
        private bool isManager;

        public User(string username, string password, string fullName, string phone, bool isAgent, bool isManager)
        {
            this.username = username;
            this.password = password;
            this.fullName = fullName;
            this.phone = phone;
            this.isAgent = isAgent;
            this.isManager = isManager;
        }

        public string GetUsername() { return username; }
        public string GetPassword() { return password; }
        public string GetFullName() { return fullName; }
        public void SetFullName(string fullName) { this.fullName = fullName; }
        public string GetPhone() { return phone; }
        public void SetPhone(string phone) { this.phone = phone; }
        public bool IsAgent() { return isAgent; }
        public bool IsManager() { return isManager; }
        public bool IsClient() { return !isAgent && !isManager; }

        public override string ToString()
        {
            string role = "לקוח";
            if (isAgent) role = "סוכן";
            else if (isManager) role = "מנהל";

            return "שם: " + fullName + " | טלפון: " + phone + " | תפקיד: " + role;
        }
    }
}