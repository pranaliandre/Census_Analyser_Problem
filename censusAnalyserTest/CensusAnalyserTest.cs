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
        public string STATE_CENSUS_CSV_FILE_PATH = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCensusData.csv";
        public string STATE_CODE_CSV_FILE_PATH = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCode.csv";
        public string STATE_CENSUS_WRONG_FILE_PATH = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/CensusData.csv";
        public string STATE_CODE_WRONG_CSV_FILE_PATH = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCodecsv.csv";
        public string STATE_CENSUS_WRONG_FILE_TYPE = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCensusData.txt";
        public string STATE_CODE_WRONG_FILE_TYPE = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCode.txt";
        public string[] HEADER_STATE_CENSUS = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
        public string[] HEADER_STATE_CODE = { "SrNo", "StateName", "TIN", "StateCode" };
        public string[] INCORRECT_HEADER_STATE_CENSUS = { "SrNo", "State", "AreaInSqkm", "MobileNo", "Statecode" };
        public string[] INCORRECT_HEADER_STATE_CODE = { "SrNo", "StateName", "Mobile", "Statecode" };
        public char DELIMETER = ',';
        public char INCORRECT_DELIMETER='.';
        public string JSON_PATH_STATE_CENSUS = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCodeData.json";
        public string JSON_PATH_STATE_CODE = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCode.json";
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
            object actual = CsvStateCensus(STATE_CENSUS_CSV_FILE_PATH, DELIMETER, HEADER_STATE_CENSUS);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Test for Given state census CSV File if incorrect Returns a custom Exception
        /// </summary>
        [Test]
        public void GivenStateCensusData_WhenWrongFilePath_ShouldThrowException()
        {
            object expected = "File Not Found";
            object actual = CsvStateCensus(STATE_CENSUS_WRONG_FILE_PATH, DELIMETER, HEADER_STATE_CENSUS);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test for Given state census file type incorrect return a custom exception
        /// </summary>
        [Test]
        
        public void GivenStateCensusCsvFile_WhenIncorrectType_ShouldThrowException()
        {
            object expected = "File Type Incorrect";
            object actual = CsvStateCensus(STATE_CENSUS_WRONG_FILE_TYPE, DELIMETER, HEADER_STATE_CENSUS);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test for given state census csv delimeter incorrect return a custom exception
        /// </summary>
        [Test]
        public void GivenStateCensusCsvFile_WhenIncorrectDelimiter_ShouldThrowException()
        {
            object expected = "Delimeter incorrect";
            object actual = CsvStateCensus(STATE_CENSUS_CSV_FILE_PATH, INCORRECT_DELIMETER, HEADER_STATE_CENSUS);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Test for given state census csv file Header incorrect return a custom exception
        /// </summary>
        [Test]
        public void GivenStateCensusCsvFile_WhenIncorrectHeader_ShouldThrowException()
        {
            object expected = "Header incorrect";
            object actual = CsvStateCensus(STATE_CENSUS_CSV_FILE_PATH, DELIMETER, INCORRECT_HEADER_STATE_CENSUS);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test for given State Code CSV file check to ensure the number of record
        /// </summary>
        [Test]
        public void GivenStateCodeCSVFileReturnsCorrectRecords()
        {
            object expected = 37;
            object actual = CsvStatesCode(STATE_CODE_CSV_FILE_PATH, DELIMETER, HEADER_STATE_CODE);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test for Given the state code CSV File if incorrect Returns a custom Exception
        /// </summary>
        [Test]
        public void GivenStateCode_WhenWrongFilePath_ShouldThrowException()
        {

            object expected = "File Not Found";
            object actual = CsvStatesCode(STATE_CODE_WRONG_CSV_FILE_PATH, DELIMETER, HEADER_STATE_CODE);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test for Given state code file type incorrect return a custom exception
        /// </summary>
        [Test]
        public void GivenStateCodeCsvFile_WhenIncorrectType_ShouldThrowException()
        {
            object expected = "File Type Incorrect";
            object actual = CsvStatesCode(STATE_CODE_WRONG_FILE_TYPE, DELIMETER, HEADER_STATE_CODE);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test for given state code csv file delimeter incorrect return a custom exception
        /// </summary>
        [Test]
        public void GivenStateCodeCsvFile_WhenIncorrectDelimiter_ShouldThrowException()
        {
            object expected = "Delimeter incorrect";
            object actual = CsvStatesCode(STATE_CODE_CSV_FILE_PATH, INCORRECT_DELIMETER, HEADER_STATE_CODE);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Test for given state code file Header incorrect return a custom exception
        /// </summary>
        [Test]
        public void GivenStateCodeCsvFile_WhenIncorrectHeader_ShouldThrowException()
        {
            object expected = "Header incorrect";
            object actual = CsvStatesCode(STATE_CODE_CSV_FILE_PATH, DELIMETER, INCORRECT_HEADER_STATE_CODE);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///  Test for StateCensus csv and json path to add into json after sorting return return first state.
        /// </summary>
        [Test]
        public void GivenStateCensusCSVAndJsonPathToAddIntoJSon_AfterSorting_ReturnFirstState()
        {
            string expected = "Andhra Pradesh";
            string actual = JSONCensus.ReturnFirstDataAfterSortingCsvFileWriteInJson(STATE_CENSUS_CSV_FILE_PATH, JSON_PATH_STATE_CENSUS, "State");
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Test for StateCensus csv and json path to add into json after sorting return return last state.
        /// </summary>
        [Test]
        public void GivenStatusCensusCSVAndJsonPathToAddIntoJSon_AfterSorting_ReturnLastState()
        {
            string expected = "West Bengal";
            string lastValue = JSONCensus.ReturnLastDataAfterSortingCsvFileWriteInJson(STATE_CENSUS_CSV_FILE_PATH, JSON_PATH_STATE_CENSUS, "State");
            Assert.AreEqual(expected, lastValue);
        }
        /// <summary>
        ///  Test for StateCensuscsv and json path to add into json after sorting return return first state.
        /// </summary>
        [Test]
        public void GivenStateCodeCSVAndJsonPathToAddIntoJSon_AfterSorting_ReturnFirstState()
        {
            string expected = "AD";
            string actual = JSONCensus.ReturnFirstDataAfterSortingCsvFileWriteInJson(STATE_CODE_CSV_FILE_PATH, JSON_PATH_STATE_CODE, "StateCode");
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Test for StateCensuscsv and json path to add into json after sorting return return last state.
        /// </summary>
        [Test]
        public void GivenStatusCodeCSVAndJsonPathToAddIntoJSon_AfterSorting_ReturnLastState()
        {
            string expected = "WB";
            string lastValue = JSONCensus.ReturnLastDataAfterSortingCsvFileWriteInJson(STATE_CODE_CSV_FILE_PATH, JSON_PATH_STATE_CODE, "StateCode");
            Assert.AreEqual(expected, lastValue);
        }
        /// <summary>
        /// Test for state census csv file pass to report number of states sorted
        /// </summary>
        [Test]
        public void GivenCsvStateCensusCsvAndJson_ToSortFromMostPopulousToLeastReturnTheNumberOfStetesSorted()
        {
            int count = JSONCensus.ReturnNumberOfStatesAfterSortingCsvFileWriteInJson(STATE_CENSUS_CSV_FILE_PATH, JSON_PATH_STATE_CENSUS, "Population");
            Assert.NotZero(count);
        }   
    }
}