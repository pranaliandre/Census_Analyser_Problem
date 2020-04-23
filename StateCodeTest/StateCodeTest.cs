using NUnit.Framework;
using System;
using censusAnalyser;
using static censusAnalyser.StateCensusAnalyser;
using static censusAnalyser.StateCodeAnalyser;
namespace StateCodeTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        /// <summary>
        /// Test for State Code CSV file check to ensure the number of record
        /// </summary>
        [Test]
        public void CheckStateCodeFile_NumberOfRecord()
        {
            object expected = 37;
            char delimeter = ',';
            string[] header = { "SrNo", "State", "Name", "TIN", "StateCode" };
            string stateCodeFilePath = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCode.csv";
            object actual = StateCodeAnalyser.GetDataFromStateCodeCSVFile(stateCodeFilePath, delimeter, header);
            Assert.AreEqual(expected, actual);
        }
    }
}