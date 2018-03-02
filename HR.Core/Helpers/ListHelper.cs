using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Core.Helpers
{
    public class ListHelper
    {
        public static List<string> CreateSex()
        {
            List<string> sex = new List<string>();
            sex.Add("-Please select-");
            sex.Add("Male");
            sex.Add("Female");
            return sex;
        }

        public static List<string> CreatJobPosition()
        {
            List<string> positions = new List<string>();
            positions.Add("-Please select-");
            positions.Add("Head");
            positions.Add("Vice");
            positions.Add("Leader");
            positions.Add("Staff");
            return null;
        }
    }
}
