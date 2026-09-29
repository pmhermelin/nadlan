namespace nadlan
{
    public partial class RealEstateSystem
    {
        // L-01 (Story A) - הרשמת לקוח חדש
        public void CreateUser()
        {
            // TODO
        }

        // L-02 (Story B) - התחברות
        public User Login()
        {
            string username = ReadNotEmpty("הזן שם משתמש:");
            string password = ReadNotEmpty("הזן סיסמה:");

            User user = FindUserByUsername(username);

            if (user == null || user.GetPassword() != password)
            {
                Console.WriteLine("שם משתמש או סיסמה שגויים");
                return null;
            }

            Console.WriteLine("ברוך הבא, " + user.GetFullName() + "!");
            return user;
        }
    }
}