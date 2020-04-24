using System;
using System.Collections.Generic;
using System.Text;
using censusAnalyser;
using static censusAnalyser.StateCensusAnalyser;
using static censusAnalyser.StateCodeAnalyser;
namespace censusAnalyser
{
    public class CSVFactory
    {
        /// <summary>
        /// Method to creating instance of StateCensusAnalyser
        /// </summary>
        /// <returns></returns>
        public static CsvStateCensus DelegateOfStateCensusAnalyser()
        {
            StateCensusAnalyser csvStateCensus = InstanceOfStateCensusAnalyser();
            CsvStateCensus getCSVStateCensus = new CsvStateCensus(StateCensusAnalyser.CsvStateCensusReadRecord);
            return getCSVStateCensus;
        }
        /// <summary>
        /// Method to creating instance of StateCodeAnalyser
        /// </summary>
        /// <returns></returns>
        public static CsvStateCode DelegateofStatecodeAnalyser()
        {
            StateCodeAnalyser statesCodeCSV = InstanceOfStateCodeAnalyser();
            CsvStateCode getCSVStateCode = new CsvStateCode(StateCodeAnalyser.CsvStateCodeReadRecord);
            return getCSVStateCode;
        }
        public static StateCensusAnalyser InstanceOfStateCensusAnalyser()
        {
            return new StateCensusAnalyser();
        }
        public static StateCodeAnalyser InstanceOfStateCodeAnalyser()
        {
            return new StateCodeAnalyser();
        }
    }
}