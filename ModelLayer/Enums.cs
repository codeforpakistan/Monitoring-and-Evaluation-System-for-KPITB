using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Enums
    {

          public enum ProjectStatusFlag
          {
              Pending = 1,
              Approved = 2,
              Completed = 3
          }

        public enum IndicatorDataType
        {
            Text = 1,
            Integer = 2,
            Float = 3,
            Bool = 4
        }

    
    }
}
