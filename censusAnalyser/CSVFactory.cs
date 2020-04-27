using System;
using System.Collections.Generic;
using System.Text;
using censusAnalyser;
using static censusAnalyser.StateCensusAnalyserDao;
using static censusAnalyser.StateCodeAnalyserDao;
namespace censusAnalyser
{
    public class CSVFactory
    {
        /// <summary>
        /// Method to creating instance of StateCensusAnalyser
        /// </summary>
        /// <returns></returns>
        public static CsvStateCensusDao DelegateOfStateCensusAnalyser()
        {
            StateCensusAnalyserDao csvStateCensus = InstanceOfStateCensusAnalyser();
            CsvStateCensusDao getCSVStateCensus = new CsvStateCensusDao(StateCensusAnalyserDao.CsvStateCensusReadRecord);
            return getCSVStateCensus;
        }
        /// <summary>
        /// Method to creating instance of StateCodeAnalyser
        /// </summary>
        /// <returns></returns>
        public static CsvStateCodeDao DelegateofStatecodeAnalyser()
        {
            StateCodeAnalyserDao statesCodeCSV = InstanceOfStateCodeAnalyser();
            CsvStateCodeDao getCSVStateCode = new CsvStateCodeDao(StateCodeAnalyserDao.CsvStateCodeReadRecord);
            return getCSVStateCode;
        }
        public static StateCensusAnalyserDao InstanceOfStateCensusAnalyser()
        {
            return new StateCensusAnalyserDao();
        }
        public static StateCodeAnalyserDao InstanceOfStateCodeAnalyser()
        {
            return new StateCodeAnalyserDao();
        }
    }
}