using NUnit.Framework;
using censusAnalyser;
namespace censusAnalyserTest
{
    public class Tests
    {
        StateCensusAnalyser object_Analyser = new StateCensusAnalyser();
        StateCodeAnalyser objectStateCode_Analyser = new StateCodeAnalyser();
        public string filePath = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCensusData.csv";
        public string stateCodeFilePath = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCode.csv";
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
            char delimeter = ',';
            string[] header = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
            StateCensusAnalyser object_Analyser = new StateCensusAnalyser(filePath);
            object actual = object_Analyser.NumberOfRecord(filePath,delimeter,header);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test for Given the CSV File if incorrect Returns a custom Exception
        /// </summary>
        [Test]
        public void CheckCsvFileIfIncorrect_ReturnthCensusAnalyserException()
        {
            object expected = "File Not Found";
            char delimeter = ',';
            string[] header = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
            string filePath = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/CensusData.csv";
            object actual = object_Analyser.NumberOfRecord(filePath,delimeter,header);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Test for Given file type incorrect return a custom exception
        /// </summary>
        [Test]
        public void CheckCsvFileTypeIncorrect_ReturnthCensusAnalyserException()
        {
            object expected = "File Type Incorrect";
            char delimeter = ',';
            string[] header = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
            string filePath = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCensusData.txt";
            object actual = object_Analyser.NumberOfRecord(filePath, delimeter,header);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Test for delimeter incorrect return a custom exception
        /// </summary>
        [Test]
        public void DelimeterIncorrect_ReturnthCensusAnalyserException()
        {
            object expected = "Delimeter incorrect";
            char delimeter = '.';
            string[] header = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
            string filePath = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCensusData.csv";
            object actual = object_Analyser.NumberOfRecord(filePath, delimeter, header);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Test for Header incorrect return a custom exception
        /// </summary>
        [Test]
        public void HeaderIncorrect_ReturnthCensusAnalyserException()
        {
            object expected = "Header incorrect";
            char delimeter = ',';
            string[] header = { "SrNo", "State", "AreaInSqkm", "MobileNo", "Statecode" };
            string filePath = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCensusData.csv";
            object actual = object_Analyser.NumberOfRecord(filePath, delimeter,header);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Test for State Code CSV file check to ensure the number of record
        /// </summary>
        [Test]
        public void CheckStateCodeFile_NumberOfRecord()
        {
            object expected = 37;
            char delimeter = ',';
            string[] header = { "SrNo", "State", "Name" , "TIN", "StateCode" };
            string stateCodeFilePath = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCode.csv";
            object actual = objectStateCode_Analyser.NumberOfrecordStateCodeFile(stateCodeFilePath,delimeter,header);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Test for Given the state code CSV File if incorrect Returns a custom Exception
        /// </summary>
        [Test]
        public void CheckStateCodeCsvFileIfIncorrect_ReturnthCensusAnalyserException()
        {
            object expected = "File Not Found";
            char delimeter = ',';
            string[] header = { "SrNo", "State", "Name", "TIN", "StateCode" };
            string stateCodeFilePath = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCodecsv.csv";
            object actual = objectStateCode_Analyser.NumberOfrecordStateCodeFile(stateCodeFilePath, delimeter,header);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Test for Given state code file type incorrect return a custom exception
        /// </summary>
        [Test]
        public void CheckStateCodeCsvFileTypeIncorrect_ReturnthCensusAnalyserException()
        {
            object expected = "File Type Incorrect";
            char delimeter = ',';
            string[] header = { "SrNo", "State", "Name", "TIN", "StateCode" };
            string stateCodeFilePath = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCode.txt";
            object actual = objectStateCode_Analyser.NumberOfrecordStateCodeFile(stateCodeFilePath, delimeter,header);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Test for state code csv file delimeter incorrect return a custom exception
        /// </summary>
        [Test]
        public void StateCodeDelimeterIncorrect_ReturnthCensusAnalyserException()
        {
            object expected = "Delimeter incorrect";
            char delimeter = '.';
            string[] header = { "SrNo", "State", "Name", "TIN", "StateCode" };
            string stateCodeFilePath = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCode.csv";
            object actual = objectStateCode_Analyser.NumberOfrecordStateCodeFile(stateCodeFilePath, delimeter,header);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Test for state code Header incorrect return a custom exception
        /// </summary>
        [Test]
        public void StateCodeCsvHeaderIncorrect_ReturnthCensusAnalyserException()
        {
            object expected = "Header incorrect";
            char delimeter = ',';
            string[] header = { "SrNo", "State", "Name", "Mobile", "Statecode" };
            string stateCodeFilePath = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCode.csv";
            object actual = objectStateCode_Analyser.NumberOfrecordStateCodeFile(stateCodeFilePath, delimeter, header);
            Assert.AreEqual(expected, actual);
        }
    }
}