using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CollatzConj
{
    #region - Class - 

    public class CollatzConjecture
    {

        #region - Methods -

        /// <summary>
        /// Get the calculation according to the pattern f(n) = {n/2 - if n is even or 3n+1 id n is odd}
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private ValNum GetCalculationConjecture(string s)
        {

            ValNum vn = new ValNum();
            List<byte> lVal = new List<byte>();
            var isValidNumber = true;
            byte result = 0;

            //Add valid values to the collection
            for (int i = 0; i < s.Length; i++)
            {
                isValidNumber = byte.TryParse(s[i].ToString(), out result);

                if (!isValidNumber)
                {
                    return vn;
                }

                else
                {
                    lVal.Add(result);
                }
            }

            vn.MaxNumbers = string.Join("", lVal);
            vn.InputNumbers.Add(string.Join("", lVal));

            while (IscheckIfNumberIsGreaterThanOne(lVal))
            {
                if (GetOddAndEvenNumbers(lVal))
                {
                    decimal rest = 0;

                    //Division x/2
                    for (int i = 0; i < lVal.Count; i++)
                    {
                        if (i == 0 && lVal[i] == 1)
                        {
                            string exp = lVal[i].ToString() + lVal[i + 1].ToString();
                            byte bytNum = byte.Parse(exp);
                            lVal[i] = (byte)(bytNum / 2);
                            rest = (byte)(bytNum % 2);
                            lVal.RemoveAt(i + 1);
                        }

                        else
                        {
                            if (rest != 0)
                            {
                                string exp = rest + lVal[i].ToString();
                                lVal[i] = byte.Parse(exp);
                            }

                            byte resultDivision = (byte)(lVal[i] / 2);
                            rest = lVal[i] - (resultDivision * 2);
                            lVal[i] = resultDivision;
                        }

                    }

                    vn.MaxNumbers = string.Join("", lVal);
                    vn.InputNumbers.Add(string.Join("", lVal));
                    vn.SNumbers.Add(string.Join("", lVal));
                }

                else
                {
                    //Multiplication                   
                    byte rest = 0;
                    for (int i = lVal.Count - 1; i > -1; i--)
                    {
                        string resultOfMultiplication = (lVal[i] * 3 + rest).ToString();

                        if (resultOfMultiplication.Length == 1)
                        {
                            lVal[i] = byte.Parse(resultOfMultiplication[0].ToString());
                            rest = 0;
                        }

                        else
                        {
                            if (i == 0 && resultOfMultiplication.Length > 1)
                            {
                                lVal[i] = byte.Parse(resultOfMultiplication[1].ToString());
                                lVal.Insert(0, byte.Parse(resultOfMultiplication[0].ToString()));
                            }

                            else
                            {
                                lVal[i] = byte.Parse(resultOfMultiplication[1].ToString());
                                rest = byte.Parse(resultOfMultiplication[0].ToString());
                            }
                        }
                    }

                    //To calculate + 1
                    for (int i = lVal.Count - 1; i > -1; i--)
                    {
                        string calculationresult = (lVal[i] + 1).ToString();

                        if (calculationresult.Length > 1)
                        {
                            lVal[i] = 0;
                        }

                        else
                        {
                            lVal[i] = (byte)(lVal[i] + 1);
                            break;
                        }
                    }

                    vn.MaxNumbers = string.Join("", lVal);
                    vn.InputNumbers.Add(string.Join("", lVal));
                    vn.LNumbers.Add(string.Join("", lVal));
                }
            }

            return vn;
        }

        /// <summary>
        /// Return value if insert > 1
        /// </summary>
        /// <param name="lVal"></param>
        /// <returns></returns>
        private bool IscheckIfNumberIsGreaterThanOne(List<byte> lVal)
        {
            var stringsArray = string.Join("", lVal);
            string pattern = @"([2-9][0-9]*|1[0-9]+)";
            Regex rgL = new Regex(pattern);

            if (rgL.IsMatch(stringsArray))
            {
                return true;
            }

            return false;

        }

        /// <summary>
        /// Get value true is Odd and false even
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private bool GetOddAndEvenNumbers(List<byte> lVal)
        {
            var stringsArray = string.Join("", lVal);
            string pattern = @"^\d*[13579]$";
            Regex rgL = new Regex(pattern);

            if (rgL.IsMatch(stringsArray))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Get async the calculation according to the pattern f(n) = {n/2 - if n is even or 3n+1 id n is odd}
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public async Task<ValNum> GetCalculationConjectureAsync(string val)
        {
            return await Task.Run<ValNum>(() => GetCalculationConjecture(val));
        }

        #endregion
    }

    #endregion
}
