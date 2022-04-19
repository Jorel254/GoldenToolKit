using System;
using System.Collections.Generic;
using System.Text;

namespace GoldenToolKit
{
    public class ModClass
    {
        public static List<int> MultiTable { get; set; }= new List<int>();

        public static int ManualMod(int FirstValue, int ModValue)
        {
            int temp = 0;
            int multiplicative=0;
            int OpResult;
            if (MultiTable.Count <= 0 || MultiTable is null)
            {
                for (int i = 1; i <= 10; i++)
                {
                    temp = ModValue * i;
                    MultiTable.Add(temp);
                }
            }
            if (ModValue < 0)
            {
                temp*=-1;
            }
            foreach (var item in MultiTable)
            {
                
                if (item <=FirstValue)
                {
                    multiplicative = item;
                }else
                {
                    break;
                }
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
        public static void ClearMod()
        {
            MultiTable.Clear();
        }
    }
}
