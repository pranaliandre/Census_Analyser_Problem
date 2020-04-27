using censusAnalyser;
using NUnit.Framework;
using static censusAnalyser.StateCensusAnalyserDao;
using static censusAnalyser.StateCodeAnalyserDao;
namespace censusAnalyserTest
{
    public class Tests
    {
        readonly CsvStateCensusDao CsvStateCensus = CSVFactory.DelegateOfStateCensusAnalyser();
        readonly CsvStateCodeDao CsvStatesCode = CSVFactory.DelegateofStatecodeAnalyser();
        public string stateCensusFilePath = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCensusData.csv";
        public string stateCodeFilePath = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCode.csv";
        public string stateCensusWrongFilePath = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/CensusData.csv";
        public string stateCodeWrongFilePath = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCodecsv.csv";
        public string stateCensusWrongFileType = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCensusData.txt";
        public string stateCodeWrongFileType = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCode.txt";
        public string[] headerStateCensus = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
        public string[] headerStateCode = { "SrNo", "StateName", "TIN", "StateCode" };
        public string[] incorrectHeaderStateCensus = { "SrNo", "State", "AreaInSqkm", "MobileNo", "Statecode" };
        public string[] incorrectHeaderStateCode = { "SrNo", "StateName", "Mobile", "Statecode" };
        public char delimeter = ',';
        public char incorrectDelimeter='.';
        public string jsonPathstateCensus = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCodeData.json";
        public string jsonPathstatecode = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCode.json";
        [SetUp]
        public void Setup()
        { }
        /// <summary>
        /// Test for Given States Census CSV file check to ensure the number of record
        /// </summary>
        [Test]
        public void GivenStateCensusCSVFileReturnsCorrectRecords()
        {
            int expected = 29;
            object actual = CsvStateCensus(stateCensusFilePath, delimeter, headerStateCensus);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Test for Given state census CSV File if incorrect Returns a custom Exception
        /// </summary>
        [Test]
        public void GivenStateCensusData_WhenWrongFilePath_ShouldThrowException()
        {
            object expected = "File Not Found";
            object actual = CsvStateCensus(stateCensusWrongFilePath, delimeter, headerStateCensus);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test for Given state census file type incorrect return a custom exception
        /// </summary>
        [Test]
        
        public void GivenStateCensusCsvFile_WhenIncorrectType_ShouldThrowException()
        {
            object expected = "File Type Incorrect";
            object actual = CsvStateCensus(stateCensusWrongFileType, delimeter, headerStateCensus);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test for given state census csv delimeter incorrect return a custom exception
        /// </summary>
        [Test]
        public void GivenStateCensusCsvFile_WhenIncorrectDelimiter_ShouldThrowException()
        {
            object expected = "Delimeter incorrect";
            object actual = CsvStateCensus(stateCensusFilePath, incorrectDelimeter, headerStateCensus);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Test for given state census csv file Header incorrect return a custom exception
        /// </summary>
        [Test]
        public void GivenStateCensusCsvFile_WhenIncorrectHeader_ShouldThrowException()
        {
            object expected = "Header incorrect";
            object actual = CsvStateCensus(stateCensusFilePath, delimeter, incorrectHeaderStateCensus);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test for given State Code CSV file check to ensure the number of record
        /// </summary>
        [Test]
        public void GivenStateCodeCSVFileReturnsCorrectRecords()
        {
            object expected = 37;
            object actual = CsvStatesCode(stateCodeFilePath, delimeter, headerStateCode);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test for Given the state code CSV File if incorrect Returns a custom Exception
        /// </summary>
        [Test]
        public void GivenStateCode_WhenWrongFilePath_ShouldThrowException()
        {

            object expected = "File Not Found";
            object actual = CsvStatesCode(stateCodeWrongFilePath, delimeter, headerStateCode);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test for Given state code file type incorrect return a custom exception
        /// </summary>
        [Test]
        public void GivenStateCodeCsvFile_WhenIncorrectType_ShouldThrowException()
        {
            object expected = "File Type Incorrect";
            object actual = CsvStatesCode(stateCodeWrongFileType, delimeter, headerStateCode);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test for given state code csv file delimeter incorrect return a custom exception
        /// </summary>
        [Test]
        public void GivenStateCodeCsvFile_WhenIncorrectDelimiter_ShouldThrowException()
        {
            object expected = "Delimeter incorrect";
            object actual = CsvStatesCode(stateCodeFilePath, incorrectDelimeter, headerStateCode);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Test for given state code file Header incorrect return a custom exception
        /// </summary>
        [Test]
        public void GivenStateCodeCsvFile_WhenIncorrectHeader_ShouldThrowException()
        {
            object expected = "Header incorrect";
            object actual = CsvStatesCode(stateCodeFilePath, delimeter, incorrectHeaderStateCode);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///  Test for StateCensus csv and json path to add into json after sorting return return first state.
        /// </summary>
        [Test]
        public void GivenStateCensusCSVAndJsonPathToAddIntoJSon_AfterSorting_ReturnFirstState()
        {
            string expected = "Andhra Pradesh";
            string actual = JSONCensus.SortCsvFileWriteInJsonAndReturnFirstData(stateCensusFilePath, jsonPathstateCensus, "State");
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Test for StateCensus csv and json path to add into json after sorting return return last state.
        /// </summary>
        [Test]
        public void GivenStatusCensusCSVAndJsonPathToAddIntoJSon_AfterSorting_ReturnLastState()
        {
            string expected = "West Bengal";
            string lastValue = JSONCensus.SortCsvFileWriteInJsonAndReturnLastData(stateCensusFilePath, jsonPathstateCensus, "State");
            Assert.AreEqual(expected, lastValue);
        }
        /// <summary>
        ///  Test for StateCensuscsv and json path to add into json after sorting return return first state.
        /// </summary>
        [Test]
        public void GivenStateCodeCSVAndJsonPathToAddIntoJSon_AfterSorting_ReturnFirstState()
        {
            string expected = "AD";
            string actual = JSONCensus.SortCsvFileWriteInJsonAndReturnFirstData(stateCodeFilePath, jsonPathstatecode, "StateCode");
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Test for StateCensuscsv and json path to add into json after sorting return return last state.
        /// </summary>
        [Test]
        public void GivenStatusCodeCSVAndJsonPathToAddIntoJSon_AfterSorting_ReturnLastState()
        {
            string expected = "WB";
            string lastValue = JSONCensus.SortCsvFileWriteInJsonAndReturnLastData(stateCodeFilePath, jsonPathstatecode, "StateCode");
            Assert.AreEqual(expected, lastValue);
        }
       
    }
}