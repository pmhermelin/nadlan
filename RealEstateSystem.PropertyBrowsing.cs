namespace nadlan
{
    public partial class RealEstateSystem
    {
        // L-03 (Story C) - הצגת כל הנכסים
        public void PrintAllProperties()
        {
            if (propertyCount == 0)
            {
                Console.WriteLine("אין נכסים במערכת");
                return;
            }

            for (int i = 0; i < propertyCount; i++)
            {
                Console.WriteLine(properties[i].ToString());
            }
        }

        // L-04 (Story D) - חיפוש וסינון נכסים
        public void SearchProperties()
        {
            Console.WriteLine("סינון לפי (השאר ריק לדילוג על קריטריון):");
            string city = ReadNotEmpty("עיר (או Enter לדילוג):");

            string minPriceInput = ReadNotEmpty("מחיר מינימלי (או Enter לדילוג):");
            double minPrice = -1;
            if (minPriceInput != "")
            {
                double.TryParse(minPriceInput, out minPrice);
            }

            string maxPriceInput = ReadNotEmpty("מחיר מקסימלי (או Enter לדילוג):");
            double maxPrice = -1;
            if (maxPriceInput != "")
            {
                double.TryParse(maxPriceInput, out maxPrice);
            }

            string roomsInput = ReadNotEmpty("מספר חדרים (או Enter לדילוג):");
            int rooms = -1;
            if (roomsInput != "")
            {
                int.TryParse(roomsInput, out rooms);
            }

            string onlyAvailableInput = ReadNotEmpty("רק נכסים זמינים? (כן / Enter לדילוג):");
            bool onlyAvailable = (onlyAvailableInput == "כן");

            bool found = false;
            for (int i = 0; i < propertyCount; i++)
            {
                Property p = properties[i];

                if (city != "" && p.GetCity() != city)
                {
                    continue;
                }
                if (minPrice >= 0 && p.GetPrice() < minPrice)
                {
                    continue;
                }
                if (maxPrice >= 0 && p.GetPrice() > maxPrice)
                {
                    continue;
                }
                if (rooms >= 0 && p.GetRooms() != rooms)
                {
                    continue;
                }
                if (onlyAvailable && !p.IsAvailable())
                {
                    continue;
                }

                Console.WriteLine(p.ToString());
                found = true;
            }

            if (!found)
            {
                Console.WriteLine("לא נמצאו נכסים התואמים לחיפוש");
            }
        }

        // M-01 (Story M) - הצגת כל נכסי הסוכנות
        public void PrintAllRealEstate()
        {
            Console.WriteLine("=== סקירת כלל נכסי הסוכנות ===");

            if (propertyCount == 0)
            {
                Console.WriteLine("אין נכסים במערכת");
                return;
            }

            int availableCount = 0;
            double totalPrice = 0;

            for (int i = 0; i < propertyCount; i++)
            {
                Console.WriteLine(properties[i].ToString());

                if (properties[i].IsAvailable())
                {
                    availableCount++;
                }
                totalPrice += properties[i].GetPrice();
            }

            Console.WriteLine("--- סיכום ---");
            Console.WriteLine("סך הכול נכסים: " + propertyCount);
            Console.WriteLine("זמינים: " + availableCount);
            Console.WriteLine("לא זמינים: " + (propertyCount - availableCount));
            Console.WriteLine("סכום המחירים: " + totalPrice.ToString("N0") + " ש\"ח");
        }
    }
}