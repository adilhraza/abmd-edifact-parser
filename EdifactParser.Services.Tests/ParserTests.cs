using EdifactParser.Services.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EdifactParser.Services.Tests
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void ParseEdifactString_NoInputGiven_ReturnNull()
        {
            var parser = new Parser();

            var res = parser.ParseEdifactString("");

            Assert.IsNull(res);
        }

        [TestMethod]
        public void ParseEdifactString_NoLocSegmentsFound_ReturnEmptyStringArray()
        {
            string Input = "UNA:+.? 'UNB+UNOC:3+2021000969+4441963198+180525:1225+3VAL2MJV6EH9IX+KMSV7HMD+CUSDECU-IE++1++1'UNH+EDIFACT+CUSDEC:D:96B:UN:145050'BGM+ZEM:::EX+09SEE7JPUV5HC06IC6+Z'DTM+9:20090527:102'DTM+268:20090626:102'DTM+182:20090527:102'";
            
            var parser = new Parser();

            var res = parser.ParseEdifactString(Input);

            Assert.AreEqual(res.Length, 0);
        }

        [TestMethod]
        public void ParseEdifactString_TwoLocSegmentsPassed_ShouldReturnFourElements()
        {
            string Input = "UNA:+.? 'UNB+UNOC:3+2021000969+4441963198+180525:1225+3VAL2MJV6EH9IX+KMSV7HMD+CUSDECU-IE++1++1'LOC+17+IT044100'LOC+18+SOL'UNH+EDIFACT+CUSDEC:D:96B:UN:145050'BGM+ZEM:::EX+09SEE7JPUV5HC06IC6+Z'DTM+9:20090527:102'DTM+268:20090626:102'DTM+182:20090527:102'";
            
            var parser = new Parser();

            var res = parser.ParseEdifactString(Input);

            Assert.AreEqual(res.Length, 4);
        }
    }
}
