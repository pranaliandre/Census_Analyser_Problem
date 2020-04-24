using System;
using System.Collections.Generic;
using System.Text;
using censusAnalyser;
namespace censusAnalyser
{
    /// <summary>
    /// csv builder class for reading or fetching data from file 
    /// </summary>
    public interface CSVBuilder
    {
        public object CsvStateCensusReadRecord(string stateCensusFilePath, char delimeter, string[] header);
        public object CsvStateCodeReadRecord(string stateCodeFilePath, char delimeter, string[] header);
    }
}