///-----------------------------------------------------------------
///   Class:       Tests
///   Description: Test cases for  India Census data and USCensusData
///   Author:      Pranali Andre                   Date: 2/5/2020
///------------------------------------------------------------------
using censusAnalyser;
using NUnit.Framework;
using static censusAnalyser.StateCensusAnalyserDao;
using static censusAnalyser.StateCodeAnalyserDao;
using static censusAnalyser.UsCensusAnalyserDao;
namespace censusAnalyserTest
{
    public class Tests
    {
        readonly CsvStateCensusDao csvStateCensus = CSVFactory.DelegateOfStateCensusAnalyser();
        readonly CsvStateCodeDao csvStatesCode = CSVFactory.DelegateofStatecodeAnalyser();
        readonly CsvUscensusDao csvUsCensus = CSVFactory.DelegateofUSCensusAnalyser();
        public string STATE_CENSUS_CSV_FILE_PATH = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCensusData.csv";
        public string STATE_CODE_CSV_FILE_PATH = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCode.csv";
        public string US_CENSUS_DATA_FILE_PATH = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/USCensusData.csv";
        public string STATE_CENSUS_WRONG_FILE_PATH = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/CensusData.csv";
        public string STATE_CODE_WRONG_CSV_FILE_PATH = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCodecsv.csv";
        public string STATE_CENSUS_WRONG_FILE_TYPE = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCensusData.txt";
        public string STATE_CODE_WRONG_FILE_TYPE = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCode.txt";
        public string[] HEADER_STATE_CENSUS = { "State", "Population", "AreaInSqKm", "DensityPerSqKm" };
        public string[] HEADER_STATE_CODE = { "SrNo", "StateName", "TIN", "StateCode" };
        public string[] HEADER_US_CENSUS = { "State Id", "State", "Population", "Housing units", "Total area", "Water area", "Land area", "Population Density", "Housing Density" };
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
        public void GivenStateCensusCSVFileReturnsCorrectRecords()
        {
            try
            {
                int expected = 29;
                object actual = csvStateCensus(STATE_CENSUS_CSV_FILE_PATH, DELIMETER, HEADER_STATE_CENSUS);
                Assert.AreEqual(expected, actual);
            }
            catch(CensusAnalyserException exception)
            {
                throw new CensusAnalyserException(exception.Message, CensusAnalyserException.Exception_type.File_Not_Found);
            }
        }
        
        /// <summary>
        /// Test for Given state census CSV File if incorrect Returns a custom Exception
        /// </summary>
        [Test]
        public void GivenStateCensusData_WhenWrongFilePath_ShouldThrowException()
        {
            try
            {
                object expected = "File Not Found";
                object actual = csvStateCensus(STATE_CENSUS_WRONG_FILE_PATH, DELIMETER, HEADER_STATE_CENSUS);
                Assert.AreEqual(expected, actual);
            }
            catch (CensusAnalyserException exception)
            {
                throw new CensusAnalyserException(exception.Message, CensusAnalyserException.Exception_type.File_Not_Found);
            }
        }

        /// <summary>
        /// Test for Given state census file type incorrect return a custom exception
        /// </summary>
        [Test]

        public void GivenStateCensusCsvFile_WhenIncorrectType_ShouldThrowException()
        {
            try
            {
                object expected = "File Type Incorrect";
                object actual = csvStateCensus(STATE_CENSUS_WRONG_FILE_TYPE, DELIMETER, HEADER_STATE_CENSUS);
                Assert.AreEqual(expected, actual);
            }
            catch (CensusAnalyserException exception)
            {
                throw new CensusAnalyserException(exception.Message, CensusAnalyserException.Exception_type.File_Type_Incorrect);
            }
        }

        /// <summary>
        /// Test for Given state census csv delimeter incorrect return a custom exception
        /// </summary>
        [Test]
        public void GivenStateCensusCsvFile_WhenIncorrectDelimiter_ShouldThrowException()
        {
            try
            {
                object expected = "Delimeter incorrect";
                object actual = csvStateCensus(STATE_CENSUS_CSV_FILE_PATH, INCORRECT_DELIMETER, HEADER_STATE_CENSUS);
                Assert.AreEqual(expected, actual);
            }
            catch(CensusAnalyserException exception)
            {
                throw new CensusAnalyserException(exception.Message, CensusAnalyserException.Exception_type.Delimeter_Incorrect);
            }
        }
        /// <summary>
        /// Test for given state census csv file Header incorrect return a custom exception
        /// </summary>
        [Test]
        public void GivenStateCensusCsvFile_WhenIncorrectHeader_ShouldThrowException()
        {
            try
            {
                object expected = "Header incorrect";
                object actual = csvStateCensus(STATE_CENSUS_CSV_FILE_PATH, DELIMETER, INCORRECT_HEADER_STATE_CENSUS);
                Assert.AreEqual(expected, actual);
            }
            catch(CensusAnalyserException exception)
            {
                throw new CensusAnalyserException(exception.Message, CensusAnalyserException.Exception_type.Header_Incorrect);
            }
        }

        /// <summary>
        /// Test for given State Code CSV file check to ensure the number of record
        /// </summary>
        [Test]
        public void GivenStateCodeCSVFileReturnsCorrectRecords()
        {
            try
            {
                object expected = 37;
                object actual = csvStatesCode(STATE_CODE_CSV_FILE_PATH, DELIMETER, HEADER_STATE_CODE);
                Assert.AreEqual(expected, actual);
            }
            catch (CensusAnalyserException exception)
            {
                throw new CensusAnalyserException(exception.Message, CensusAnalyserException.Exception_type.File_Not_Found);
            }
        }

        /// <summary>
        /// Test for Given the state code CSV File if incorrect Returns a custom Exception
        /// </summary>
        [Test]
        public void GivenStateCode_WhenWrongFilePath_ShouldThrowException()
        {
            try
            {
                object expected = "File Not Found";
                object actual = csvStatesCode(STATE_CODE_WRONG_CSV_FILE_PATH, DELIMETER, HEADER_STATE_CODE);
                Assert.AreEqual(expected, actual);
            }
            catch (CensusAnalyserException exception)
            {
                throw new CensusAnalyserException(exception.Message, CensusAnalyserException.Exception_type.File_Not_Found);
            }
        }

        /// <summary>
        /// Test for Given state code file type incorrect return a custom exception
        /// </summary>
        [Test]
        public void GivenStateCodeCsvFile_WhenIncorrectType_ShouldThrowException()
        {
            try
            {
                object expected = "File Type Incorrect";
                object actual = csvStatesCode(STATE_CODE_WRONG_FILE_TYPE, DELIMETER, HEADER_STATE_CODE);
                Assert.AreEqual(expected, actual);
            }
            catch (CensusAnalyserException exception)
            {
                throw new CensusAnalyserException(exception.Message, CensusAnalyserException.Exception_type.File_Type_Incorrect);
            }
        }

        /// <summary>
        /// Test for given state code csv file delimeter incorrect return a custom exception
        /// </summary>
        [Test]
        public void GivenStateCodeCsvFile_WhenIncorrectDelimiter_ShouldThrowException()
        {
            try
            {
                object expected = "Delimeter incorrect";
                object actual = csvStatesCode(STATE_CODE_CSV_FILE_PATH, INCORRECT_DELIMETER, HEADER_STATE_CODE);
                Assert.AreEqual(expected, actual);
            }
            catch (CensusAnalyserException exception)
            {
                throw new CensusAnalyserException(exception.Message, CensusAnalyserException.Exception_type.Delimeter_Incorrect);
            }
        }
        /// <summary>
        /// Test for given state code file Header incorrect return a custom exception
        /// </summary>
        [Test]
        public void GivenStateCodeCsvFile_WhenIncorrectHeader_ShouldThrowException()
        {
            try
            {
                object expected = "Header incorrect";
                object actual = csvStatesCode(STATE_CODE_CSV_FILE_PATH, DELIMETER, INCORRECT_HEADER_STATE_CODE);
                Assert.AreEqual(expected, actual);
            }
            catch (CensusAnalyserException exception)
            {
                throw new CensusAnalyserException(exception.Message, CensusAnalyserException.Exception_type.Header_Incorrect);
            }
        }
        /// <summary>
        ///  Test for StateCensus csv and json path to add into json after sorting return return first state.
        /// </summary>
        [Test]
        public void GivenStateCensusCSVAndJsonPathToAddIntoJSon_AfterSorting_ReturnFirstState()
        {
            try
            {
                string expected = "Andhra Pradesh";
                string actual = JSONCensus.ReturnFirstDataAfterSortingCsvFileWriteInJson(STATE_CENSUS_CSV_FILE_PATH, JSON_PATH_STATE_CENSUS, "State");
                Assert.AreEqual(expected, actual);
            }
            catch (CensusAnalyserException exception)
            {
                throw new CensusAnalyserException(exception.Message, CensusAnalyserException.Exception_type.File_Not_Found);
            }
        }
        /// <summary>
        /// Test for StateCensus csv and json path to add into json after sorting return return last state.
        /// </summary>
        [Test]
        public void GivenStatusCensusCSVAndJsonPathToAddIntoJSon_AfterSorting_ReturnLastState()
        {
            try
            {
                string expected = "West Bengal";
                string lastValue = JSONCensus.ReturnLastDataAfterSortingCsvFileWriteInJson(STATE_CENSUS_CSV_FILE_PATH, JSON_PATH_STATE_CENSUS, "State"); Assert.AreEqual(expected, lastValue);
                Assert.AreEqual(expected, lastValue);
            }
            catch (CensusAnalyserException exception)
            {
                throw new CensusAnalyserException(exception.Message, CensusAnalyserException.Exception_type.File_Not_Found);
            }
        }
        /// <summary>
        ///  Test for StateCensuscsv and json path to add into json after sorting return return first state.
        /// </summary>
        [Test]
        public void GivenStateCodeCSVAndJsonPathToAddIntoJSon_AfterSorting_ReturnFirstState()
        {
            try
            {
                string expected = "AD";
                string actual = JSONCensus.ReturnFirstDataAfterSortingCsvFileWriteInJson(STATE_CODE_CSV_FILE_PATH, JSON_PATH_STATE_CODE, "StateCode");
                Assert.AreEqual(expected, actual);
            }
            catch (CensusAnalyserException exception)
            {
                throw new CensusAnalyserException(exception.Message, CensusAnalyserException.Exception_type.File_Not_Found);
            }
        }
        /// <summary>
        /// Test for StateCensuscsv and json path to add into json after sorting return return last state.
        /// </summary>
        [Test]
        public void GivenStatusCodeCSVAndJsonPathToAddIntoJSon_AfterSorting_ReturnLastState()
        {
            try
            {
                string expected = "WB";
                string lastValue = JSONCensus.ReturnLastDataAfterSortingCsvFileWriteInJson(STATE_CODE_CSV_FILE_PATH, JSON_PATH_STATE_CODE, "StateCode");
                Assert.AreEqual(expected, lastValue);
            }
            catch (CensusAnalyserException exception)
            {
                throw new CensusAnalyserException(exception.Message, CensusAnalyserException.Exception_type.File_Not_Found);
            }
        }
        /// <summary>
        ///  Test case for Given the CSV state census and json to sort from most populous to least return the number of states sorted.
        /// </summary>
        [Test]
        public void GivenCsvStateCensusAndJson_ToSortFromMostPopulousToLeast_ReturnTheNumberOfSatetesSorted()
        {
            try
            { 
                string expected = "199812341";
                string population = JSONCensus.ReturnDataNumberOfStatesSortCSVFileAndWriteInJson(STATE_CENSUS_CSV_FILE_PATH, JSON_PATH_STATE_CENSUS, "Population");
                Assert.AreEqual(expected, population);
            }
            catch (CensusAnalyserException exception)
            {
                throw new CensusAnalyserException(exception.Message, CensusAnalyserException.Exception_type.File_Not_Found);
            }
        }
        /// <summary>
        /// Test for Givens the state of the CSV and json path to add into json after sorting on density return largest value.
        /// </summary> 
        [Test]
        public void GivenCSVAndJsonPathToAddIntoJSon_AfterSortingOnDensity_ReturnlastState()
        {
            try
            {
                string expected = "1102";
                string lastValue = JSONCensus.ReturnDataNumberOfStatesSortCSVFileAndWriteInJson(STATE_CENSUS_CSV_FILE_PATH, JSON_PATH_STATE_CENSUS, "DensityPerSqKm");
                Assert.AreEqual(expected, lastValue);
            }
            catch (CensusAnalyserException exception)
            {
                throw new CensusAnalyserException(exception.Message, CensusAnalyserException.Exception_type.File_Not_Found);
            }
        }
        /// <summary>
        /// Test for Givens the state of the CSV and json path to add into json after sorting on density return smallest area.
        /// </summary>
        [Test]
        public void GivenCSVAndJsonPathToAddIntoJSon_AfterSortingOnArea_ReturnlastState()
        {
            try
            {
                string expected = "3702";
                string firstValue = JSONCensus.ReturnDataNumberOfStatesFirstDataSortCSVFileAndWriteInJson(STATE_CENSUS_CSV_FILE_PATH, JSON_PATH_STATE_CENSUS, "AreaInSqKm");
                Assert.AreEqual(expected, firstValue);
            }
            catch (CensusAnalyserException exception)
            {
                throw new CensusAnalyserException(exception.Message, CensusAnalyserException.Exception_type.File_Not_Found);
            }
        }
        /// <summary>
        /// Test case for check number of records
        /// </summary>
        [Test]
        public void GivenUSCensusCSVFileReturnsCorrectRecords()
        {
            try
            {
                int expected = 51;
                object actual = csvUsCensus(US_CENSUS_DATA_FILE_PATH, DELIMETER, HEADER_US_CENSUS);
                Assert.AreEqual(expected, actual);
            }
            catch (CensusAnalyserException exception)
            {
                throw new CensusAnalyserException(exception.Message, CensusAnalyserException.Exception_type.File_Not_Found);
            }
        }
        /// <summary>
        ///  Test case for Given the CSV sta census and json to sort from most populous to least return the number of states sorted.
        /// </summary>
        [Test]
        public void GivenCsvUSCensusAndJson_ToSortFromMostPopulousToLeast_ReturnTheNumberOfSatetesSorted()
        {
            try
            {
                string expected = "37253956";
                string population = JSONCensus.ReturnDataNumberOfStatesSortCSVFileAndWriteInJson(US_CENSUS_DATA_FILE_PATH, JSON_PATH_STATE_CENSUS, "Population");
                Assert.AreEqual(expected, population);
            }
            catch (CensusAnalyserException exception)
            {
                throw new CensusAnalyserException(exception.Message, CensusAnalyserException.Exception_type.File_Not_Found);
            }
        }
    }
}