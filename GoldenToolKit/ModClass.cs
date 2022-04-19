namespace GoldenToolKit
{
    public class ModClass
    {

        public static int ManualMod(int FirstValue, int ModValue)
        {
            int multiplicative;
            int OpResult;
            int i = 1;
            do
            {
                multiplicative = ModValue * i;
                i++;
            } while (multiplicative < FirstValue);

            if (multiplicative > FirstValue)
                multiplicative -= ModValue;

            if (ModValue < 0)
            {
                multiplicative *= -1;
            }
            if (multiplicative <= FirstValue)
            {
                OpResult = FirstValue - multiplicative;

            }
            else
            {
                OpResult = FirstValue;

            }
            return OpResult;
        }
    }
}
