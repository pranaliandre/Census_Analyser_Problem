using NUnit.Framework;
using censusAnalyser;
using static censusAnalyser.StateCensusAnalyser;
using static censusAnalyser.StateCodeAnalyser;
namespace censusAnalyserTest
{
    public class Tests
    {
        readonly CsvStateCensus CsvStateCensus = CSVFactory.DelegateOfStateCensusAnalyser();
        readonly CsvStateCode CsvStatesCode = CSVFactory.DelegateofStatecodeAnalyser();
        [SetUp]
        public void Setup()
        { }
        /// <summary>
        /// Test for Given States Census CSV file check to ensure the number of record
        /// </summary>
        [Test]
        public void CheckStateCensus_NumberOfRecord()
        {
            int expected = 29;
            char delimeter = ',';
            string[] header = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
            string stateCensusfilePath = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCensusData.csv";
            object actual = CsvStateCensus(stateCensusfilePath, delimeter, header);
            Assert.AreEqual(expected, actual);
        }
        
        /// <summary>
        /// Test for Given state census CSV File if incorrect Returns a custom Exception
        /// </summary>
        [Test]
        public void CheckCsvFileIfIncorrect_ReturnthCensusAnalyserException()
        {
            object expected = "File Not Found";
            char delimeter = ',';
            string[] header = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
            string stateCensusfilePath = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/CensusData.csv";
            object actual = CsvStateCensus(stateCensusfilePath, delimeter, header);
            Assert.AreEqual(expected, actual);
        }
        
        /// <summary>
        /// Test for Given state census file type incorrect return a custom exception
        /// </summary>
        [Test]
        public void CheckCsvFileTypeIncorrect_ReturnthCensusAnalyserException()
        {
            object expected = "File Type Incorrect";
            char delimeter = ',';
            string[] header = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
            string stateCensusfilePath = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCensusData.txt";
            object actual = CsvStateCensus(stateCensusfilePath, delimeter, header);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test for given state census csv delimeter incorrect return a custom exception
        /// </summary>
        [Test]
        public void DelimeterIncorrect_ReturnthCensusAnalyserException()
        {
            object expected = "Delimeter incorrect";
            char delimeter = '.';
            string[] header = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
            string stateCensusfilePath = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCensusData.csv";
            object actual = CsvStateCensus(stateCensusfilePath, delimeter, header);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Test for given state census csv file Header incorrect return a custom exception
        /// </summary>
        [Test]
        public void HeaderIncorrect_ReturnthCensusAnalyserException()
        {
            object expected = "Header incorrect";
            char delimeter = ',';
            string[] header = { "SrNo", "State", "AreaInSqkm", "MobileNo", "Statecode" };
            string stateCensusfilePath = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCensusData.csv";
            object actual = CsvStateCensus(stateCensusfilePath, delimeter, header);
            Assert.AreEqual(expected, actual);
        }
        
        /// <summary>
        /// Test for given State Code CSV file check to ensure the number of record
        /// </summary>
        [Test]
        public void CheckStateCodeFile_NumberOfRecord()
        {
            object expected = 37;
            char delimeter = ',';
            string[] header = { "SrNo", "State", "Name" , "TIN", "StateCode" };
            string stateCodeFilePath = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCode.csv";
            object actual = CsvStatesCode(stateCodeFilePath, delimeter, header);
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
            object actual = CsvStatesCode(stateCodeFilePath, delimeter, header);
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
            object actual = CsvStatesCode(stateCodeFilePath, delimeter, header);
            Assert.AreEqual(expected, actual);
        }
        
        /// <summary>
        /// Test for given state code csv file delimeter incorrect return a custom exception
        /// </summary>
        [Test]
        public void StateCodeDelimeterIncorrect_ReturnthCensusAnalyserException()
        {
            object expected = "Delimeter incorrect";
            char delimeter = '.';
            string[] header = { "SrNo", "State", "Name", "TIN", "StateCode" };
            string stateCodeFilePath = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCode.csv";
            object actual = CsvStatesCode(stateCodeFilePath, delimeter, header);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Test for given state code file Header incorrect return a custom exception
        /// </summary>
        [Test]
        public void StateCodeCsvHeaderIncorrect_ReturnthCensusAnalyserException()
        {
            object expected = "Header incorrect";
            char delimeter = ',';
            string[] header = { "SrNo", "State", "Name", "Mobile", "Statecode" };
            string stateCodeFilePath = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCode.csv";
            object actual = CsvStatesCode(stateCodeFilePath, delimeter, header);
            Assert.AreEqual(expected, actual);
        }
    }
}