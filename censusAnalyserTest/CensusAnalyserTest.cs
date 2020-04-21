using NUnit.Framework;
using censusAnalyser;
namespace censusAnalyserTest
{
    public class Tests
    {
        StateCensusAnalyser object_Analyser = new StateCensusAnalyser();
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

        /// <summary>
        /// Test for Given the CSV File if incorrect Returns a custom Exception
        /// </summary>
        [Test]
        public void CheckCsvFileIfIncorrect_ReturnthCensusAnalyserException()
        {
            object expected = "File Not Found";
            string filePath = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/CensusData.csv";
            object actual = object_Analyser.NumberOfRecord(filePath);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Test for Given file type incorrect return a custom exception
        /// </summary>
        [Test]
        public void CheckCsvFileTypeIncorrect_ReturnthCensusAnalyserException()
        {
            object expected = "File Type Incorrect";
            string filePath = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCensusData.txt";
            object actual = object_Analyser.NumberOfRecord(filePath);
            Assert.AreEqual(expected, actual);
        }
    }
}