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
            var result = "";
            var strSplit = input.Split('.');
            var prevNumber = "";
            int i = 1;

            var numberInput = strSplit[0];
            var numberInputSplit = numberInput.ToCharArray().Reverse();
            var numberCount = numberInputSplit.Count();
            foreach ( var number in numberInputSplit )
            {
                if(numberCount == 1)
                {
                    result += ChangeNumberToString(i, number.ToString(), "0", numberCount);
                }
                else if (numberCount > 1)
                {
                    result = ChangeNumberToString(i, number.ToString(), prevNumber, numberCount) + result;
                    prevNumber = number.ToString();
                }
                
                i++;
            }

            result += " Dollars ";

            if (strSplit.Length > 1) 
            {
                Dictionary<int, string> decimalPairs = new Dictionary<int, string>();
                var decimalInput = strSplit[1];
                var decimalInputSplit = decimalInput.ToCharArray().Reverse();
                var decimalCount = decimalInputSplit.Count();
                i = 1;

                result += " and ";

                foreach (var number in decimalInputSplit)
                {
                    if (decimalCount == 1)
                    {
                        result += ChangeNumberToString(i, number.ToString(), "0", decimalCount);
                    }
                    else if (decimalCount > 1)
                    {
                        result = ChangeNumberToString(i, number.ToString(), prevNumber, decimalCount) + result;
                        prevNumber = number.ToString();
                    }

                    i++;
                }
            }
            
            //result += strInput[0];
            return result;
        }

        private string ChangeNumberToString(int key, string input, string inputPrevious, int length)
        {
            try
            {
                var result = "";
                if(key == 1 && length == 1) // single
                {
                    result += NumberStringOneToNine(input);
                }
                else if(key == 2) // double
                {
                    if(input == "0")
                    {
                        result += NumberStringOneToNine(inputPrevious);
                    }
                    else
                    {
                        result += NumberStringTenUp(input, inputPrevious);
                    }
                    
                }
                else if (key % 3 == 0) // a hundred
                {
                    if(input != "0")
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
                            result += NumberStringOneToNine(inputPrevious) + " Thousand ";
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
                            result += NumberStringOneToNine(inputPrevious) + " Million ";
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
                            result += NumberStringOneToNine(inputPrevious) + " Billion ";
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
                            result += NumberStringOneToNine(inputPrevious) + " Trillion ";
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
                            result += NumberStringOneToNine(inputPrevious) + " Quadrillion ";
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
                            result += NumberStringOneToNine(inputPrevious) + " Quintrillion ";
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
                return "One";
            }
            else if(inputInt == 2)
            {
                return "Two";
            }
            else if (inputInt == 3)
            {
                return "Three";
            }
            else if (inputInt == 4)
            {
                return "Four";
            }
            else if (inputInt == 5)
            {
                return "Five";
            }
            else if (inputInt == 6)
            {
                return "Six";
            }
            else if (inputInt == 7)
            {
                return "Seven";
            }
            else if (inputInt == 8)
            {
                return "Eight";
            }
            else if (inputInt == 9)
            {
                return "Nine";
            }
            else
            {
                return "Zero";
            }
        }

        private string NumberStringTenUp(string input, string inputPrevious)
        {
            var inputInt = int.Parse(input+inputPrevious);

            if (inputInt == 10)
            {
                return "Ten";
            }
            else if (inputInt == 11)
            {
                return "Eleven";
            }
            else if (inputInt == 12)
            {
                return "Twelve";
            }
            else if (inputInt == 13)
            {
                return "Thirteen";
            }
            else if (inputInt == 14)
            {
                return "FourTeen";
            }
            else if (inputInt == 15)
            {
                return "FifTeen";
            }
            else if (inputInt == 16)
            {
                return "SixTeen";
            }
            else if (inputInt == 17)
            {
                return "SevenTeen";
            }
            else if (inputInt == 18)
            {
                return "EightTeen";
            }
            else if (inputInt == 19)
            {
                return "NineTeen";
            }
            else if (inputInt == 20)
            {
                return "Twenty";
            }
            else if (inputInt > 20 && inputInt < 30)
            {
                return "Twenty-" + NumberStringOneToNine(inputPrevious);
            }
            else if (inputInt == 30)
            {
                return "Thirty";
            }
            else if (inputInt > 30 && inputInt < 40)
            {
                return "Thirty-" + NumberStringOneToNine(inputPrevious);
            }
            else if (inputInt == 40)
            {
                return "Fourty";
            }
            else if (inputInt > 40 && inputInt < 50)
            {
                return "Fourty-" + NumberStringOneToNine(inputPrevious);
            }
            else if (inputInt == 50)
            {
                return "Fifty";
            }
            else if (inputInt > 50 && inputInt < 60)
            {
                return "Fifty-" + NumberStringOneToNine(inputPrevious);
            }
            else if (inputInt == 60)
            {
                return "Sixty";
            }
            else if (inputInt > 60 && inputInt < 70)
            {
                return "Sixty-" + NumberStringOneToNine(inputPrevious);
            }
            else if (inputInt == 70)
            {
                return "Seventy";
            }
            else if (inputInt > 70 && inputInt < 80)
            {
                return "Seventy-" + NumberStringOneToNine(inputPrevious);
            }
            else if (inputInt == 80)
            {
                return "Eighty";
            }
            else if (inputInt > 80 && inputInt < 90)
            {
                return "Eighty-" + NumberStringOneToNine(inputPrevious);
            }
            else if (inputInt == 90)
            {
                return "Ninety";
            }
            else if (inputInt > 90 && inputInt < 100)
            {
                return "Ninety-" + NumberStringOneToNine(inputPrevious);
            }
            else
            {
                return "Zero";
            }
        }
    }
}
