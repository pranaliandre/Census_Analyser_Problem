///--------------------------------------------------------------------
///   Class:      ICSVBuilder
///   Description: Created a Interface for Classes
///   Author:      Pranali Andre                   Date: 28/4/2020
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
        public object csvStateCensusReadRecord(string stateCensusFilePath, char delimeter, string[] header);
        public object csvStateCodeReadRecord(string stateCodeFilePath, char delimeter, string[] header);
    }
}