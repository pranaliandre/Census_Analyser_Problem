using System;
namespace censusAnalyser
{
    public class StateCodeAnalyserDao : ICSVBuilder
    {
        /// <summary>
        /// variable
        /// </summary>
        public string stateCodeFilePath;
        public char delimeter;
        public string[] header;
        public string filepath;
        public StateCodeAnalyserDao() { }
        /// <summary>
        ///  Parameterized constructor for different variables.
        /// </summary>
        /// <param name="stateCodeFilePath"></param>
        /// <param name="delimeter"></param>
        /// <param name="header"></param>
        public StateCodeAnalyserDao(string stateCodeFilePath, char delimeter,string[] header)
        {
           this.stateCodeFilePath = stateCodeFilePath;
           this.delimeter = delimeter;
           this.header = header;
        }
        /// <summary>
        /// Delegate is a reference type variable that hold the refenence to a method 
        /// </summary>
        /// <param name="stateCodeFilePath"></param>
        /// <param name="delimeter"></param>
        /// <param name="header"></param>
        /// <returns></returns>
        public delegate object CsvStateCodeDao(string stateCodeFilePath, char delimeter, string[] header);
        /// <summary>
        /// Method to read the record state code csv file and check the file type,file path, delimeter and header .
        /// </summary>
        /// <param name="stateCodeFilePath"></param>
        /// <param name="delimeter"></param>
        /// <param name="header"></param>
        /// <returns></returns>
        public static object CsvStateCodeReadRecord(string stateCodeFilePath, char delimeter, string[] header)
        {
            CensusAnalyser stateCodePathObject = new CensusAnalyser(stateCodeFilePath);
            object returnObject = stateCodePathObject.ReadRecordCsvFile(stateCodeFilePath, delimeter, header);
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
    }
}