using ChequeWriting.Test.Dto;

namespace ChequeWriting.Test
{
    public class ChequeWritingTests
    {
        #region initialization
        ChequeToString _chequeToString;
        DataTestsDto _dataTests;
        #endregion

        #region Unit Test

        public ChequeWritingTests()
        {
            _chequeToString = new ChequeToString();  
            _dataTests = new DataTestsDto();
        }

        [Fact]
        public void NetworkService_ChangeToString_ReturnString()
        {
            var result = _chequeToString.ChangeToString(_dataTests.initialValue);

            Assert.IsType<string>(result);
        }

        [Fact]
        public void NetworkService_ChangeToString_ReturnStringDollarsAndCentValue()
        {
            var result = _chequeToString.ChangeToString(_dataTests.initialValue);

            Assert.Equal("One Hundred Twenty-Three Dollars and Fourty-Five Cents", result);
        }

        [Fact]
        public void NetworkService_ChangeToString_ReturnValueIsNotNumberString()
        {
            var result = _chequeToString.ChangeToString(_dataTests.alphaValue);

            Assert.Equal("Inputed value is not number", result);
        }

        [Fact]
        public void NetworkService_ChangeToString_ReturnValueIsZero()
        {
            var result = _chequeToString.ChangeToString(_dataTests.zero);

            Assert.Equal("Zero Dollars", result);
        }

        [Fact]
        public void NetworkService_ChangeToString_ReturnValueIsSingleDollars()
        {
            var result = _chequeToString.ChangeToString(_dataTests.single);

            Assert.Equal("Nine Dollars", result);
        }

        [Fact]
        public void NetworkService_ChangeToString_ReturnValueIsDoubleDollars()
        {
            var result = _chequeToString.ChangeToString(_dataTests.doubles);

            Assert.Equal("Fifty-Five Dollars", result);
        }

        [Fact]
        public void NetworkService_ChangeToString_ReturnValueIsDoubleWithZeroDollars()
        {
            var result = _chequeToString.ChangeToString(_dataTests.doublesWithZero);

            Assert.Equal("Twenty Dollars", result);
        }

        [Fact]
        public void NetworkService_ChangeToString_ReturnValueIsHundredDollars()
        {
            var result = _chequeToString.ChangeToString(_dataTests.hundred);

            Assert.Equal("One Hundred Dollars", result);
        }

        [Fact]
        public void NetworkService_ChangeToString_ReturnValueIsHundredWithZeroDollars()
        {
            var result = _chequeToString.ChangeToString(_dataTests.hundredWithZero);

            Assert.Equal("Two Hundred Five Dollars", result);
        }

        [Fact]
        public void NetworkService_ChangeToString_ReturnValueIsThousandDollars()
        {
            var result = _chequeToString.ChangeToString(_dataTests.thousand);

            Assert.Equal("Two Thousand Dollars", result);
        }

        [Fact]
        public void NetworkService_ChangeToString_ReturnValueIsThousandFullDollars()
        {
            var result = _chequeToString.ChangeToString(_dataTests.thousandFull);

            Assert.Equal("Two Thousand Four Hundred Eighty-Six Dollars", result);
        }

        [Fact]
        public void NetworkService_ChangeToString_ReturnValueIsThousandWithZeroDollars()
        {
            var result = _chequeToString.ChangeToString(_dataTests.thousandWithZero);

            Assert.Equal("Two Thousand Fifty-Five Dollars", result);
        }

        [Fact]
        public void NetworkService_ChangeToString_ReturnValueIsMoreThousandDollars()
        {
            var result = _chequeToString.ChangeToString(_dataTests.moreThousand);

            Assert.Equal("Thirty Thousand Dollars", result);
        }

        [Fact]
        public void NetworkService_ChangeToString_ReturnValueIsMoreThousandFullDollars()
        {
            var result = _chequeToString.ChangeToString(_dataTests.moreThousandFull);

            Assert.Equal("Thirty-Five Thousand Nine Hundred Fourty-Two Dollars", result);
        }

        [Fact]
        public void NetworkService_ChangeToString_ReturnValueIsMoreThousandWithZeroDollars()
        {
            var result = _chequeToString.ChangeToString(_dataTests.moreThousandWithZero);

            Assert.Equal("Thirty Thousand Four Hundred Eighty-Seven Dollars", result);
        }

        [Fact]
        public void NetworkService_ChangeToString_ReturnValueIsHundredThousandDollars()
        {
            var result = _chequeToString.ChangeToString(_dataTests.hundredThousand);

            Assert.Equal("Four Hundred Thousand Dollars", result);
        }

        [Fact]
        public void NetworkService_ChangeToString_ReturnValueIsHundredThousandFullDollars()
        {
            var result = _chequeToString.ChangeToString(_dataTests.hundredThousandFull);

            Assert.Equal("Four Hundred Fourty-Two Thousand Six Hundred Eighty-Six Dollars", result);
        }

        [Fact]
        public void NetworkService_ChangeToString_ReturnValueIsHundredThousandWithZeroDollars()
        {
            var result = _chequeToString.ChangeToString(_dataTests.hundredThousandWithZero);

            Assert.Equal("Four Hundred Two Thousand Eighty-Six Dollars", result);
        }

        [Fact]
        public void NetworkService_ChangeToString_ReturnValueIsMillionDollars()
        {
            var result = _chequeToString.ChangeToString(_dataTests.million);

            Assert.Equal("Four Million Dollars", result);
        }

        [Fact]
        public void NetworkService_ChangeToString_ReturnValueIsMillionFullDollars()
        {
            var result = _chequeToString.ChangeToString(_dataTests.millionFull);

            Assert.Equal("Four Million Six Hundred Fourty-Two Thousand Six Hundred Eighty-Six Dollars", result);
        }

        [Fact]
        public void NetworkService_ChangeToString_ReturnValueIsMillionWithZeroDollars()
        {
            var result = _chequeToString.ChangeToString(_dataTests.millionFullWithZero);

            Assert.Equal("Four Million Four Hundred Sixty-Two Thousand Eighty-Six Dollars", result);
        }

        [Fact]
        public void NetworkService_ChangeToString_ReturnValueIsHundredMillionWithZeroDollars()
        {
            var result = _chequeToString.ChangeToString(_dataTests.hundredMillionFullWithZero);

            Assert.Equal("Five Hundred Million Four Hundred Sixty-Two Thousand Eighty-Six Dollars", result);
        }

        [Fact]
        public void NetworkService_ChangeToString_ReturnValueIsMillionFullWithCentDollars()
        {
            var result = _chequeToString.ChangeToString(_dataTests.millionFullWithCent);

            Assert.Equal("Four Million Six Hundred Fourty-Two Thousand Six Hundred Eighty-Six Dollars and Eighty-Three Cents", result);
        }

        [Fact]
        public void NetworkService_ChangeToString_ReturnValueIsBillionDollars()
        {
            var result = _chequeToString.ChangeToString(_dataTests.billion);

            Assert.Equal("Four Billion Dollars", result);
        }

        [Fact]
        public void NetworkService_ChangeToString_ReturnValueIsBillionFullDollars()
        {
            var result = _chequeToString.ChangeToString(_dataTests.billionFull);

            Assert.Equal("Four Billion Six Hundred Fourty-Two Million Six Hundred Eighty-Six Thousand Five Hundred Seventy-Six Dollars", result);
        }

        [Fact]
        public void NetworkService_ChangeToString_ReturnValueIsHundredBillionFullWithZeroDollars()
        {
            var result = _chequeToString.ChangeToString(_dataTests.hundredBillionFullWithZero);

            Assert.Equal("Five Hundred Billion Six Hundred Fourty-Two Million Six Hundred Eighty-Six Thousand Five Hundred Seventy-Six Dollars", result);
        }

        [Fact]
        public void NetworkService_ChangeToString_ReturnValueIsTrillionDollars()
        {
            var result = _chequeToString.ChangeToString(_dataTests.trillion);

            Assert.Equal("Four Trillion Dollars", result);
        }

        [Fact]
        public void NetworkService_ChangeToString_ReturnValueIsTrillionFullDollars()
        {
            var result = _chequeToString.ChangeToString(_dataTests.trillionFull);

            Assert.Equal("Seven Trillion Eight Hundred Ninety-Four Billion Six Hundred Fourty-Two Million Six Hundred Eighty-Six Thousand Five Hundred Seventy-Six Dollars", result);
        }

        [Fact]
        public void NetworkService_ChangeToString_ReturnValueIsHundredTrillionFullWithZeroDollars()
        {
            var result = _chequeToString.ChangeToString(_dataTests.hundredTrillionFull);

            Assert.Equal("Seven Hundred Trillion Eight Hundred Ninety-Four Billion Six Hundred Fourty-Two Million Six Hundred Eighty-Six Thousand Five Hundred Seventy-Six Dollars", result);
        }

        [Fact]
        public void NetworkService_ChangeToString_ReturnValueIsQuadrillionDollars()
        {
            var result = _chequeToString.ChangeToString(_dataTests.quadrillion);

            Assert.Equal("Four Quadrillion Dollars", result);
        }

        [Fact]
        public void NetworkService_ChangeToString_ReturnValueIsQuadrillionFullDollars()
        {
            var result = _chequeToString.ChangeToString(_dataTests.quadrillionFull);

            Assert.Equal("Three Quadrillion Four Hundred Fifty-Seven Trillion Eight Hundred Ninety-Four Billion Six Hundred Fourty-Two Million Six Hundred Eighty-Six Thousand Five Hundred Seventy-Six Dollars", result);
        }

        [Fact]
        public void NetworkService_ChangeToString_ReturnValueIsHundredQuadrillionFullWithZeroDollars()
        {
            var result = _chequeToString.ChangeToString(_dataTests.hundredQuadrillionFull);

            Assert.Equal("One Hundred Quadrillion Four Hundred Fifty-Seven Trillion Eight Hundred Ninety-Four Billion Six Hundred Fourty-Two Million Six Hundred Eighty-Six Thousand Five Hundred Seventy-Six Dollars", result);
        }

        [Fact]
        public void NetworkService_ChangeToString_ReturnValueIsQuintrillionDollars()
        {
            var result = _chequeToString.ChangeToString(_dataTests.quintrillion);

            Assert.Equal("Four Quintrillion Dollars", result);
        }

        [Fact]
        public void NetworkService_ChangeToString_ReturnValueIsQuintrillionFullDollars()
        {
            var result = _chequeToString.ChangeToString(_dataTests.quintrillionFull);

            Assert.Equal("Seven Quintrillion Eight Hundred Ninety-Three Quadrillion Four Hundred Fifty-Seven Trillion Eight Hundred Ninety-Four Billion Six Hundred Fourty-Two Million Six Hundred Eighty-Six Thousand Five Hundred Seventy-Six Dollars", result);
        }

        [Fact]
        public void NetworkService_ChangeToString_ReturnValueIsHundredQuintrillionFullWithZeroDollars()
        {
            var result = _chequeToString.ChangeToString(_dataTests.hundredQuintrillionFull);

            Assert.Equal("One Hundred Quintrillion Eight Hundred Ninety-Three Quadrillion Four Hundred Fifty-Seven Trillion Eight Hundred Ninety-Four Billion Six Hundred Fourty-Two Million Six Hundred Eighty-Six Thousand Five Hundred Seventy-Six Dollars", result);
        }

        [Fact]
        public void NetworkService_ChangeToString_ReturnValueIsFullValue()
        {
            var result = _chequeToString.ChangeToString(_dataTests.fullValue);

            Assert.Equal("One Hundred Quintrillion Eight Hundred Quadrillion Four Hundred Trillion Eight Hundred Billion Six Hundred Million Six Hundred Thousand Five Hundred Dollars", result);
        }
        #endregion
    }
}