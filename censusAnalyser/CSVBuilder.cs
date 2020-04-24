using System;
using System.Collections.Generic;
using System.Text;

namespace censusAnalyser
{
    /// <summary>
    /// csv builder class for reding or fetching data from file 
    /// </summary>
    public interface CSVBuilder
    {
        public object CsvStateCensusReadRecord(string stateCensusFilePath, char delimeter, string[] header);
        public object CsvStateCodeReadRecord(string stateCodeFilePath, char delimeter, string[] header);
    }
}
