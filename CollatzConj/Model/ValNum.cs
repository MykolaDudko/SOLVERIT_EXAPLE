using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollatzConj
{
    #region - Class -

    public class ValNum
    {
        #region  - Properties -

        public List<string> InputNumbers { get; set; }
        public List<string> LNumbers { get; set; }
        public List<string> SNumbers { get; set; }

        private string maxNumber = string.Empty;
        public string MaxNumbers
        {
            get { return maxNumber; }
            set
            {

                if (value.Length > maxNumber.Length)
                {
                    maxNumber = value;
                }

                else if (value.Length == maxNumber.Length)
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        byte a = byte.Parse(value[i].ToString());
                        byte b = byte.Parse(maxNumber[i].ToString());

                        if (a > b)
                        {
                            maxNumber = value;
                            break;
                        }

                        else
                        {
                            break;
                        }
                    }
                }
            }
        }

        #endregion

        #region  - Constructors -

        public ValNum()
        {
            InputNumbers = new List<string>();
            LNumbers = new List<string>();
            SNumbers = new List<string>();
            MaxNumbers = string.Empty;
        }

        #endregion
    }

    #endregion
}
