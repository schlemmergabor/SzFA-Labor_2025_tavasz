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
                int index = int.Parse(filename.Substring(filename.Length - 6, 2));
                result.Costs[index] = MonthlyCosts.LoadFrom(filename);
            }
            return result;
        }
    }

}
