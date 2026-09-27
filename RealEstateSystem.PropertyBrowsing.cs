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
            // TODO
        }

        // M-01 (Story M) - הצגת כל נכסי הסוכנות
        public void PrintAllRealEstate()
        {
            // TODO
        }
    }
}