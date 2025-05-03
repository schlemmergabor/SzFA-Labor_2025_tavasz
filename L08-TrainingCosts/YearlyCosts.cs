using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L08_TrainingCosts
{
    public class YearlyCosts
    {
        public MonthlyCosts[] Costs { get; set; } = new MonthlyCosts[12];

        public static YearlyCosts LoadFrom(string folderName)
        {
            if (!Directory.Exists(folderName)) throw new DirectoryNotFoundException();

            YearlyCosts result = new YearlyCosts();
            foreach (string filename in Directory.GetFiles(folderName))
            {
                // itt kell egy -1, mert anélkül 1-es indexre teszi a költést.
                int index = int.Parse(filename.Substring(filename.Length - 6, 2)) - 1;
                result.Costs[index] = MonthlyCosts.LoadFrom(filename);
            }
            return result;
        }

        //////////////////////////////////////////
        //                                      //
        // Innen kezdődik a feladatok megoldása //
        //                                      //
        //////////////////////////////////////////
        
        // 2.1. Melyik hónapban volt a legtöbb költés?
        public int MonthlyMaxCost()
        {
            // maxindex 
            int maxIndex = 1 - 1; // -1 az indexlés miatt
            for (int i = 1; i < this.Costs.Length; i++)
            {
                if (this.Costs[i] is not null)
                    if (this.Costs[i].TotalCost() > this.Costs[maxIndex].TotalCost() )
                        maxIndex = i;
            }
            return maxIndex; // 0. lesz a január
        }

    }
}
