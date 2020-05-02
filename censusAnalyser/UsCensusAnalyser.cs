using System;
using System.Collections.Generic;
using System.Text;
using censusAnalyser;
namespace censusAnalyser
{
    public class UsCensusAnalyserDao : ICSVBuilder
    {
        /// <summary>
        /// variable
        /// </summary>
        public string usCensusFilePath;
        public char delimeter;
        public string[] header;
        public UsCensusAnalyserDao() { }
        /// <summary>
        ///  Parameterized constructor for different variables.
        /// </summary>
        /// <param name="usCensusFilePath"></param>
        /// <param name="delimeter"></param>
        /// <param name="header"></param>
        public UsCensusAnalyserDao(string usCensusFilePath, char delimeter, string[] header)
        {
            this.usCensusFilePath = usCensusFilePath;
            this.delimeter = delimeter;
            this.header = header;
        }
        /// <summary>
        /// Delegate is a reference type variable that hold the refenence to a method 
        /// </summary>
        /// <param name="usCensusFilePath"></param>
        /// <param name="delimeter"></param>
        /// <param name="header"></param>
        /// <returns></returns>
        public delegate object CsvUscensusDao(string usCensusFilePath, char delimeter, string[] header);
        /// <summary>
        /// Method to read the record state code csv file and check the file type,file path, delimeter and header .
        /// </summary>
        /// <param name="usCensusFilePath"></param>
        /// <param name="delimeter"></param>
        /// <param name="header"></param>
        /// <returns></returns>
        public static object CsvUsCensusReadRecord(string usCensusFilePath, char delimeter, string[] header)
        {
            CensusAnalyser usCensusPathObject = new CensusAnalyser(usCensusFilePath);
            object returnObject = usCensusPathObject.ReadRecordCsvFile(usCensusFilePath, delimeter, header);
            return returnObject;
        }

        object ICSVBuilder.CsvStateCensusReadRecord(string stateCensusFilePath, char delimeter, string[] header)
        {
            throw new NotImplementedException();
        }
        object ICSVBuilder.CsvStateCodeReadRecord(string stateCodeFilePath, char delimeter, string[] header)
        {
            throw new NotImplementedException();
        }
        object ICSVBuilder.CsvUSCensusReadRecord(string USCensusDataFilePath, char delimeter, string[] header)
        {
            throw new NotImplementedException();
        }
    }
}