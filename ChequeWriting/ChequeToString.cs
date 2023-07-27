using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChequeWriting
{
    public class ChequeToString
    {
        public string ChangeToString(string input)
        {
            if (!float.TryParse(input, out float j))
            {
                return "Inputed value is not number";
            }

            var result = "";
            var strSplit = input.Split('.');
            var prevNumber = "";
            int i = 1;

            var numberInput = strSplit[0];
            var numberInputSplit = numberInput.ToCharArray().Reverse();
            var numberCount = numberInputSplit.Count();

            var numberInputList = numberInputSplit.ToList();
            var tmpNumberStr = "";
            var tmpThreeNumberList = new List<string>();
            for(int x = 0; x < numberCount; x++)
            {
                tmpNumberStr = numberInputList[x] + tmpNumberStr;
                if (tmpNumberStr.Length == 3 || x + 1 == numberCount)
                {
                    tmpThreeNumberList.Add(tmpNumberStr);
                    tmpNumberStr = "";
                }
            }

            result = ChangeNumberToStr(tmpThreeNumberList);

            #region old logic
            //foreach (var number in numberInputSplit)
            //{
            //    if (numberCount == 1)
            //    {
            //        result += ChangeNumberToString(i, number.ToString(), "0", numberCount);
            //    }
            //    else if (numberCount > 1)
            //    {
            //        result = ChangeNumberToString(i, number.ToString(), prevNumber, numberCount) + result;
            //        prevNumber = number.ToString();
            //    }

            //    i++;
            //}
            #endregion

            result += "Dollars";

            
            if (strSplit.Length > 1) 
            {
                Dictionary<int, string> decimalPairs = new Dictionary<int, string>();
                var decimalInput = strSplit[1];
                var decimalInputSplit = decimalInput.ToCharArray().Reverse();
                var decimalCount = decimalInputSplit.Count();
                i = 1;

               

                #region old logic
                //foreach (var number in decimalInputSplit)
                //{
                //    if (decimalCount == 1)
                //    {
                //        result = result + ChangeNumberToString(i, number.ToString(), "0", decimalCount);
                //    }
                //    else if (decimalCount > 1)
                //    {
                //        result = result + ChangeNumberToString(i, number.ToString(), prevNumber, decimalCount);
                //        prevNumber = number.ToString();
                //    }

                //    i++;
                //}
                #endregion

                var decimalInputList = decimalInputSplit.ToList();
                var tmpDecimalStr = "";
                var tmpThreeDecimalList = new List<string>();
                for (int x = 0; x < decimalCount; x++)
                {
                    tmpDecimalStr = decimalInputList[x] + tmpDecimalStr;
                    if (tmpDecimalStr.Length == 3 || x + 1 == decimalCount)
                    {
                        tmpThreeDecimalList.Add(tmpDecimalStr);
                        tmpDecimalStr = "";
                    }
                }

                var tmpDecimalResult = ChangeNumberToStr(tmpThreeDecimalList);
                if(tmpDecimalResult != "Zero ")
                {
                    result =  result + " and " + ChangeNumberToStr(tmpThreeDecimalList) + "Cents";   
                }
                
            }
            
            return result;
        }

        private string ChangeNumberToStr(List<string> tmpThreeNumberList)
        {
            string result = "";

            for (int n = 0; n < tmpThreeNumberList.Count; n++)
            {
                var tmpThreeNumberArray = tmpThreeNumberList[n].ToCharArray().ToList();
                
                if (tmpThreeNumberArray.Count == 3)
                {
                    var tmpResult = NumberStringOneToNine(tmpThreeNumberArray[0].ToString());
                    if (tmpResult == "Zero ")
                    {
                        tmpResult = "";
                    }

                    var doubleResult = "";
                    if(tmpThreeNumberArray[1].ToString() == "0")
                    {
                        if(tmpThreeNumberArray[2].ToString() != "0")
                        {
                            doubleResult = NumberStringOneToNine(tmpThreeNumberArray[2].ToString());
                        }
                    }
                    else
                    {
                        doubleResult = NumberStringTenUp(tmpThreeNumberArray[1].ToString(), tmpThreeNumberArray[2].ToString());
                    }
                    
                    if (doubleResult == "Zero " || doubleResult == "")
                    {
                        if(tmpResult != "")
                        {
                            doubleResult = GetValueName(n, 2, doubleResult);
                        }
                        else
                        {
                            doubleResult = "";
                        }
                    }
                    else
                    {
                        doubleResult = doubleResult + GetValueName(n, 2, doubleResult);
                    }

                    result = tmpResult + GetValueName(n, 3, tmpResult) + doubleResult + result;
                }
                else if (tmpThreeNumberArray.Count == 2)
                {
                    var tmpResult = NumberStringTenUp(tmpThreeNumberArray[0].ToString(), tmpThreeNumberArray[1].ToString());
                    result = tmpResult + GetValueName(n, 2, tmpResult) + result;
                }
                else if (tmpThreeNumberArray.Count == 1)
                {
                    var tmpResult = NumberStringOneToNine(tmpThreeNumberArray[0].ToString());
                    result = tmpResult + GetValueName(n, 1, tmpResult) + result;
                }
            }

            return result;
        }

        private string GetValueName(int n, int counter, string result)
        {
            if(counter == 3)
            {
                if(result != "")
                {
                    return "Hundred ";
                }
                else
                {
                    return "";
                }
            }
            else
            {
                if (n == 1)
                {
                    return "Thousand ";
                }
                else if(n == 2)
                {
                    return "Million ";
                }
                else if (n == 3)
                {
                    return "Billion ";
                }
                else if (n == 4)
                {
                    return "Trillion ";
                }
                else if (n == 5)
                {
                    return "Quadrillion ";
                }
                else if (n == 6)
                {
                    return "Quintrillion ";
                }
                else
                {
                    return "";
                }
            }
        }

        private string ChangeNumberToString(int key, string input, string inputPrevious, int length)
        {
            try
            {
                var result = "";
                if(key == 1 && length == 1) // single
                {
                    result += NumberStringOneToNine(input) + " ";
                }
                else if(key == 2) // double
                {
                    if(input == "0")
                    {
                        if(inputPrevious != "0")
                        {
                            result += NumberStringOneToNine(inputPrevious) + " ";
                        }
                    }
                    else
                    {
                        result += NumberStringTenUp(input, inputPrevious) + " ";
                    }
                    
                }
                else if (key % 3 == 0) // a hundred
                {
                    if(input != "0" )
                    {
                        result += NumberStringOneToNine(input) + " Hundred ";
                    }
                }
                else if (key == 4 || key == 5) // a thousand
                {
                    if(key == 4 && length == 4)
                    {
                        result += NumberStringOneToNine(input) + " Thousand ";
                    }
                    else if (key == 5 && length >= 5)
                    {
                        if(input == "0")
                        {
                            if(inputPrevious != "0")
                            {
                                result += NumberStringOneToNine(inputPrevious) + " Thousand ";
                            }
                            else if(inputPrevious == "0" && length >= 5)
                            {
                                result += "Thousand ";
                            }
                            
                        }
                        else
                        {
                            result += NumberStringTenUp(input, inputPrevious) + " Thousand ";
                        }
                        
                    }
                    
                }
                else if (key == 7 || key == 8) // a million
                {
                    if (key == 7 && length == 7)
                    {
                        result += NumberStringOneToNine(input) + " Million ";
                    }
                    else if (key == 8 && length >= 8)
                    {
                        if (input == "0")
                        {
                            if(inputPrevious != "0")
                            {
                                result += NumberStringOneToNine(inputPrevious) + " Million ";
                            }
                            else if(inputPrevious == "0" && (length == 8 || length == 9))
                            {
                                result += "Million ";
                            }
                        }
                        else
                        {
                            result += NumberStringTenUp(input, inputPrevious) + " Million ";
                        }

                    }
                }
                else if (key == 10 || key == 11) // a billion
                {
                    if (key == 10 && length == 10)
                    {
                        result += NumberStringOneToNine(input) + " Billion ";
                    }
                    else if (key == 11 && length >= 11)
                    {
                        if (input == "0")
                        {
                            if (inputPrevious != "0")
                            {
                                result += NumberStringOneToNine(inputPrevious) + " Billion ";
                            }
                            else if (inputPrevious == "0" && (length == 11 || length == 12))
                            {
                                result += "Billion ";
                            }
                        }
                        else
                        {
                            result += NumberStringTenUp(input, inputPrevious) + " Billion ";
                        }

                    }
                }
                else if (key == 13 || key == 14) // a trillion
                {
                    if (key == 13 && length == 13)
                    {
                        result += NumberStringOneToNine(input) + " Trillion ";
                    }
                    else if (key == 14 && length >= 14)
                    {
                        if (input == "0")
                        {
                            if (inputPrevious != "0")
                            {
                                result += NumberStringOneToNine(inputPrevious) + " Trillion ";
                            }
                            else if (inputPrevious == "0" && (length == 14 || length == 15))
                            {
                                result += "Trillion ";
                            }
                        }
                        else
                        {
                            result += NumberStringTenUp(input, inputPrevious) + " Trillion ";
                        }

                    }
                }
                else if (key == 16 || key == 17) // a quadrillion
                {
                    if (key == 16 && length == 16)
                    {
                        result += NumberStringOneToNine(input) + " Quadrillion ";
                    }
                    else if (key == 17 && length >= 17)
                    {
                        if (input == "0")
                        {
                            if (inputPrevious != "0")
                            {
                                result += NumberStringOneToNine(inputPrevious) + " Quadrillion ";
                            }
                            else if (inputPrevious == "0" && (length == 17 || length == 18))
                            {
                                result += "Quadrillion ";
                            }
                        }
                        else
                        {
                            result += NumberStringTenUp(input, inputPrevious) + " Quadrillion ";
                        }

                    }
                }
                else if (key == 19 || key == 20) // a quintrillion
                {
                    if (key == 19 && length == 19)
                    {
                        result += NumberStringOneToNine(input) + " Quintrillion ";
                    }
                    else if (key == 20 && length >= 20)
                    {
                        if (input == "0")
                        {
                            if (inputPrevious != "0")
                            {
                                result += NumberStringOneToNine(inputPrevious) + " Quintrillion ";
                            }
                            else if (inputPrevious == "0" && (length == 20 || length == 21))
                            {
                                result += "Quintrillion ";
                            }
                        }
                        else
                        {
                            result += NumberStringTenUp(input, inputPrevious) + " Quintrillion ";
                        }

                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

        private string NumberStringOneToNine(string input)
        {
            var inputInt = int.Parse(input);

            if(inputInt == 1)
            {
                return "One ";
            }
            else if(inputInt == 2)
            {
                return "Two ";
            }
            else if (inputInt == 3)
            {
                return "Three ";
            }
            else if (inputInt == 4)
            {
                return "Four ";
            }
            else if (inputInt == 5)
            {
                return "Five ";
            }
            else if (inputInt == 6)
            {
                return "Six ";
            }
            else if (inputInt == 7)
            {
                return "Seven ";
            }
            else if (inputInt == 8)
            {
                return "Eight ";
            }
            else if (inputInt == 9)
            {
                return "Nine ";
            }
            else
            {
                return "Zero ";
            }
        }

        private string NumberStringTenUp(string input, string inputPrevious)
        {
            var inputInt = int.Parse(input+inputPrevious);

            if (inputInt == 10)
            {
                return "Ten ";
            }
            else if (inputInt == 11)
            {
                return "Eleven ";
            }
            else if (inputInt == 12)
            {
                return "Twelve ";
            }
            else if (inputInt == 13)
            {
                return "Thirteen ";
            }
            else if (inputInt == 14)
            {
                return "FourTeen ";
            }
            else if (inputInt == 15)
            {
                return "FifTeen ";
            }
            else if (inputInt == 16)
            {
                return "SixTeen ";
            }
            else if (inputInt == 17)
            {
                return "SevenTeen ";
            }
            else if (inputInt == 18)
            {
                return "EightTeen ";
            }
            else if (inputInt == 19)
            {
                return "NineTeen ";
            }
            else if (inputInt == 20)
            {
                return "Twenty ";
            }
            else if (inputInt > 20 && inputInt < 30)
            {
                return "Twenty-" + NumberStringOneToNine(inputPrevious);
            }
            else if (inputInt == 30)
            {
                return "Thirty ";
            }
            else if (inputInt > 30 && inputInt < 40)
            {
                return "Thirty-" + NumberStringOneToNine(inputPrevious);
            }
            else if (inputInt == 40)
            {
                return "Fourty ";
            }
            else if (inputInt > 40 && inputInt < 50)
            {
                return "Fourty-" + NumberStringOneToNine(inputPrevious);
            }
            else if (inputInt == 50)
            {
                return "Fifty ";
            }
            else if (inputInt > 50 && inputInt < 60)
            {
                return "Fifty-" + NumberStringOneToNine(inputPrevious);
            }
            else if (inputInt == 60)
            {
                return "Sixty ";
            }
            else if (inputInt > 60 && inputInt < 70)
            {
                return "Sixty-" + NumberStringOneToNine(inputPrevious);
            }
            else if (inputInt == 70)
            {
                return "Seventy ";
            }
            else if (inputInt > 70 && inputInt < 80)
            {
                return "Seventy-" + NumberStringOneToNine(inputPrevious);
            }
            else if (inputInt == 80)
            {
                return "Eighty ";
            }
            else if (inputInt > 80 && inputInt < 90)
            {
                return "Eighty-" + NumberStringOneToNine(inputPrevious);
            }
            else if (inputInt == 90)
            {
                return "Ninety ";
            }
            else if (inputInt > 90 && inputInt < 100)
            {
                return "Ninety-" + NumberStringOneToNine(inputPrevious);
            }
            else
            {
                return "Zero ";
            }
        }
    }
}
