namespace nadlan
{
    public partial class RealEstateSystem
    {
        // L-01 (Story A) - הרשמת לקוח חדש
        public void CreateUser()
        {
            if (userCount >= USERS_MAX)
            {
                Console.WriteLine("לא ניתן להוסיף - המערכת מלאה");
                return;
            }

            string username;
            while (true)
            {
                username = ReadNotEmpty("הזן שם משתמש:");
                if (FindUserByUsername(username) != null)
                {
                    Console.WriteLine("שם משתמש כבר קיים, הזן שם אחר");
                }
                else
                {
                    break;
                }
            }

            string password;
            while (true)
            {
                password = ReadNotEmpty("הזן סיסמה (לפחות 4 תווים):");
                if (password.Length < 4)
                {
                    Console.WriteLine("קלט לא תקין, נסה שוב");
                }
                else
                {
                    break;
                }
            }

            string fullName = ReadNotEmpty("הזן שם מלא:");
            string phone = ReadNotEmpty("הזן טלפון:");

            User newUser = new User(username, password, fullName, phone, false, false);
            users[userCount] = newUser;
            userCount++;

            Console.WriteLine("ההרשמה הושלמה בהצלחה");
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