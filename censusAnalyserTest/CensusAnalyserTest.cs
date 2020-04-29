///-----------------------------------------------------------------
///   Class:       Tests
///   Description: Test cases for India Census data
///   Author:      Pranali Andre                   Date: 28/4/2020
///------------------------------------------------------------------
using censusAnalyser;
using NUnit.Framework;
using static censusAnalyser.StateCensusAnalyserDao;
using static censusAnalyser.StateCodeAnalyserDao;
namespace censusAnalyserTest
{
    public class Tests
    {
        readonly csvStateCensusDao csvStateCensus = CSVFactory.DelegateOfStateCensusAnalyser();
        readonly csvStateCodeDao csvStatesCode = CSVFactory.DelegateofStatecodeAnalyser();
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
        public char INCORRECT_DELIMETER = '.';
        public string JSON_PATH_STATE_CENSUS = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCodeData.json";
        public string JSON_PATH_STATE_CODE = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCode.json";
        [SetUp]
        public void Setup()
        { }
        /// <summary>
        /// Test for Given States Census CSV file check to ensure the number of record
        /// </summary>
        [Test]
        public void givenStateCensusCSVFileReturnsCorrectRecords()
        {
            int expected = 29;
            object actual = csvStateCensus(STATE_CENSUS_CSV_FILE_PATH, DELIMETER, HEADER_STATE_CENSUS);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Test for Given state census CSV File if incorrect Returns a custom Exception
        /// </summary>
        [Test]
        public void givenStateCensusData_WhenWrongFilePath_ShouldThrowException()
        {
            object expected = "File Not Found";
            object actual = csvStateCensus(STATE_CENSUS_WRONG_FILE_PATH, DELIMETER, HEADER_STATE_CENSUS);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test for Given state census file type incorrect return a custom exception
        /// </summary>
        [Test]

        public void givenStateCensusCsvFile_WhenIncorrectType_ShouldThrowException()
        {
            object expected = "File Type Incorrect";
            object actual = csvStateCensus(STATE_CENSUS_WRONG_FILE_TYPE, DELIMETER, HEADER_STATE_CENSUS);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test for given state census csv delimeter incorrect return a custom exception
        /// </summary>
        [Test]
        public void givenStateCensusCsvFile_WhenIncorrectDelimiter_ShouldThrowException()
        {
            object expected = "Delimeter incorrect";
            object actual = csvStateCensus(STATE_CENSUS_CSV_FILE_PATH, INCORRECT_DELIMETER, HEADER_STATE_CENSUS);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Test for given state census csv file Header incorrect return a custom exception
        /// </summary>
        [Test]
        public void givenStateCensusCsvFile_WhenIncorrectHeader_ShouldThrowException()
        {
            object expected = "Header incorrect";
            object actual = csvStateCensus(STATE_CENSUS_CSV_FILE_PATH, DELIMETER, INCORRECT_HEADER_STATE_CENSUS);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test for given State Code CSV file check to ensure the number of record
        /// </summary>
        [Test]
        public void givenStateCodeCSVFileReturnsCorrectRecords()
        {
            object expected = 37;
            object actual = csvStatesCode(STATE_CODE_CSV_FILE_PATH, DELIMETER, HEADER_STATE_CODE);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test for Given the state code CSV File if incorrect Returns a custom Exception
        /// </summary>
        [Test]
        public void givenStateCode_WhenWrongFilePath_ShouldThrowException()
        {

            object expected = "File Not Found";
            object actual = csvStatesCode(STATE_CODE_WRONG_CSV_FILE_PATH, DELIMETER, HEADER_STATE_CODE);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test for Given state code file type incorrect return a custom exception
        /// </summary>
        [Test]
        public void givenStateCodeCsvFile_WhenIncorrectType_ShouldThrowException()
        {
            object expected = "File Type Incorrect";
            object actual = csvStatesCode(STATE_CODE_WRONG_FILE_TYPE, DELIMETER, HEADER_STATE_CODE);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test for given state code csv file delimeter incorrect return a custom exception
        /// </summary>
        [Test]
        public void givenStateCodeCsvFile_WhenIncorrectDelimiter_ShouldThrowException()
        {
            object expected = "Delimeter incorrect";
            object actual = csvStatesCode(STATE_CODE_CSV_FILE_PATH, INCORRECT_DELIMETER, HEADER_STATE_CODE);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Test for given state code file Header incorrect return a custom exception
        /// </summary>
        [Test]
        public void givenStateCodeCsvFile_WhenIncorrectHeader_ShouldThrowException()
        {
            object expected = "Header incorrect";
            object actual = csvStatesCode(STATE_CODE_CSV_FILE_PATH, DELIMETER, INCORRECT_HEADER_STATE_CODE);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///  Test for StateCensus csv and json path to add into json after sorting return return first state.
        /// </summary>
        [Test]
        public void givenStateCensusCSVAndJsonPathToAddIntoJSon_AfterSorting_ReturnFirstState()
        {
            string expected = "Andhra Pradesh";
            string actual = JSONCensus.returnFirstDataAfterSortingCsvFileWriteInJson(STATE_CENSUS_CSV_FILE_PATH, JSON_PATH_STATE_CENSUS, "State");
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Test for StateCensus csv and json path to add into json after sorting return return last state.
        /// </summary>
        [Test]
        public void givenStatusCensusCSVAndJsonPathToAddIntoJSon_AfterSorting_ReturnLastState()
        {
            string expected = "West Bengal";
            string lastValue = JSONCensus.returnLastDataAfterSortingCsvFileWriteInJson(STATE_CENSUS_CSV_FILE_PATH, JSON_PATH_STATE_CENSUS, "State");  Assert.AreEqual(expected, lastValue);
        }
        /// <summary>
        ///  Test for StateCensuscsv and json path to add into json after sorting return return first state.
        /// </summary>
        [Test]
        public void givenStateCodeCSVAndJsonPathToAddIntoJSon_AfterSorting_ReturnFirstState()
        {
            string expected = "AD";
            string actual = JSONCensus.returnFirstDataAfterSortingCsvFileWriteInJson(STATE_CODE_CSV_FILE_PATH, JSON_PATH_STATE_CODE, "StateCode");
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Test for StateCensuscsv and json path to add into json after sorting return return last state.
        /// </summary>
        [Test]
        public void givenStatusCodeCSVAndJsonPathToAddIntoJSon_AfterSorting_ReturnLastState()
        {
            string expected = "WB";
            string lastValue = JSONCensus.returnLastDataAfterSortingCsvFileWriteInJson(STATE_CODE_CSV_FILE_PATH, JSON_PATH_STATE_CODE, "StateCode");
            Assert.AreEqual(expected, lastValue);
        }
        /// <summary>
        ///  Test case for Given the CSV state census and json to sort from most populous to least return the number of states sorted.
        /// </summary>
        [Test]
        public void givenCsvStateCensusAndJson_ToSortFromMostPopulousToLeast_ReturnTheNumberOfSatetesSorted()
        {
            string expected="199812341";
            string population = JSONCensus.returnDataNumberOfStatesSortCSVFileAndWriteInJson(STATE_CENSUS_CSV_FILE_PATH, JSON_PATH_STATE_CENSUS, "Population");
            Assert.AreEqual(expected, population);
        }
        /// <summary>
        /// Test for Givens the state of the CSV and json path to add into json after sorting on density return largest value.
        /// </summary> 
        [Test]
        public void givenCSVAndJsonPathToAddIntoJSon_AfterSortingOnDensity_ReturnlastState()
        {
            string expected = "1102";
            string lastValue = JSONCensus.returnDataNumberOfStatesSortCSVFileAndWriteInJson(STATE_CENSUS_CSV_FILE_PATH, JSON_PATH_STATE_CENSUS, "DensityPerSqKm");
            Assert.AreEqual(expected, lastValue);
        }
        /// <summary>
        /// Test for Givens the state of the CSV and json path to add into json after sorting on density return smallest area.
        /// </summary>
        [Test]
        public void givenCSVAndJsonPathToAddIntoJSon_AfterSortingOnArea_ReturnlastState()
        {
            string expected = "3702";
            string firstValue = JSONCensus.returnDataNumberOfStatesFirstDataSortCSVFileAndWriteInJson(STATE_CENSUS_CSV_FILE_PATH, JSON_PATH_STATE_CENSUS, "AreaInSqKm");
            Assert.AreEqual(expected, firstValue);
        }
    }
}