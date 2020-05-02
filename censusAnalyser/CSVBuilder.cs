///--------------------------------------------------------------------
///   Class:      ICSVBuilder
///   Description: Created a Interface for Classes
///   Author:      Pranali Andre                   Date: 29/4/2020
///--------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using censusAnalyser;
namespace censusAnalyser
{
    /// <summary>
    /// csv builder class for reading or fetching data from file 
    /// </summary>
    public interface ICSVBuilder
    {
        public object CsvStateCensusReadRecord(string stateCensusFilePath, char delimeter, string[] header);
        public object CsvStateCodeReadRecord(string stateCodeFilePath, char delimeter, string[] header);
        public object CsvUSCensusReadRecord(string USCensusDataFilePath, char delimeter, string[] header);
    }
}