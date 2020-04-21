using NUnit.Framework;
using censusAnalyser;
namespace censusAnalyserTest
{
    public class Tests
    {
        public string filePath = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCensusData.csv";
        [SetUp]
        public void Setup()
        {
        }
        /// <summary>
        /// Test for States Census CSV file check to ensure the number of record
        /// </summary>
        [Test]
        public void CheckStateCensus_NumberOfRecord()
        {
            object expected = 29;
            StateCensusAnalyser object_Analyser = new StateCensusAnalyser(filePath);
            object actual = object_Analyser.NumberOfRecord(filePath);
            Assert.AreEqual(expected, actual);
        }
    }
}