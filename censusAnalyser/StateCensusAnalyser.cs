using System;

namespace censusAnalyser
{
    public class StateCensusAnalyser : CSVBuilder
    {
        /// <summary>
        /// variable
        /// </summary>
        /// 
        public string stateCensusFilePath;
        public string[] header;
        public char delimeter;
        public StateCensusAnalyser() { }
        /// <summary></summary>
        /// <summary>
        /// Parameterized constructor for different variables.
        /// </summary>
        /// <param name="stateCensusFilePath"></param>
        /// <param name="delimeter"></param>
        /// <param name="header"></param>
        public StateCensusAnalyser(string stateCensusFilePath, char delimeter, string[] header)
        {
            this.stateCensusFilePath = stateCensusFilePath;
            this.delimeter = delimeter;
            this.header = header;
        }
        /// <summary>
        ///  Delegate is a reference type variable that hold the refenence to a method
        /// </summary>
        /// <param name="stateCensusFilePath"></param>
        /// <param name="delimeter"></param>
        /// <param name="header"></param>
        /// <returns></returns>
        public delegate object CsvStateCensus(string stateCensusFilePath, char delimeter, string[] header);
        /// <summary>
        /// Method to read the record state census csv file and check the file type,file path, delimeter and header .
        /// </summary>
        /// <param name="stateCensusFilePath"></param>
        /// <param name="delimeter"></param>
        /// <param name="header"></param>
        /// <returns></returns>
        public static object CsvStateCensusReadRecord(string stateCensusFilePath, char delimeter, string[] header)
        {
            CensusAnalyser stateCensusPathObject = new CensusAnalyser(stateCensusFilePath);
            object returnObject = stateCensusPathObject.ReadRecordCsvFile(stateCensusFilePath, delimeter, header);
            return returnObject;
        }
        object CSVBuilder.CsvStateCensusReadRecord(string stateCensusFilePath, char delimeter, string[] header)
        {
            throw new NotImplementedException();
        }
        object CSVBuilder.CsvStateCodeReadRecord(string stateCodeFilePath, char delimeter, string[] header)
        {
            throw new NotImplementedException();
        }
    }
}