///-----------------------------------------------------------------
///   Class:       CSVFactory
///   Description: Create a object for StateCensusData,StateCode
///   Author:      Pranali Andre                   Date: 28/4/2020
///-----------------------------------------------------------------
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
        public static csvStateCensusDao DelegateOfStateCensusAnalyser()
        {
            StateCensusAnalyserDao csvStateCensus = InstanceOfStateCensusAnalyser();
            csvStateCensusDao getCSVStateCensus = new csvStateCensusDao(StateCensusAnalyserDao.csvStateCensusReadRecord);
            return getCSVStateCensus;
        }
        /// <summary>
        /// Method to creating instance of StateCodeAnalyser
        /// </summary>
        /// <returns></returns>
        public static csvStateCodeDao DelegateofStatecodeAnalyser()
        {
            StateCodeAnalyserDao statesCodeCSV = InstanceOfStateCodeAnalyser();
            csvStateCodeDao getCSVStateCode = new csvStateCodeDao(StateCodeAnalyserDao.csvStateCodeReadRecord);
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