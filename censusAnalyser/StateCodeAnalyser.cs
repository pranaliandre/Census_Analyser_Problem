using System;

namespace censusAnalyser
{
    public class StateCodeAnalyser
    {
        /// <summary>
        /// variable
        /// </summary>
        public string stateCodeFilePath;
        public char delimeter;
        public string[] header;
        /// <summary>
        /// Default constructor for invoking object.
        /// </summary>
        public StateCodeAnalyser(){ }
        /// <summary>
        ///  Parameterized constructor for different variables.
        /// </summary>
        /// <param name="stateCodeFilePath"></param>
        /// <param name="delimeter"></param>
        /// <param name="header"></param>
        public StateCodeAnalyser(string stateCodeFilePath, char delimeter,string[] header)
        {
            this.stateCodeFilePath = stateCodeFilePath;
            this.delimeter = delimeter;
            this.header = header;
        }
        /// <summary>
        /// Method to read the record state code csv file and check the file type,file path, delimeter and header .
        /// </summary>
        /// <param name="stateCodeFilePath"></param>
        /// <param name="delimeter"></param>
        /// <param name="header"></param>
        /// <returns></returns>
        public object CsvStateCodeReadRecord(string stateCodeFilePath, char delimeter, string[] header)
        {
            CensusAnalyser stateCodePathObject = new CensusAnalyser(stateCodeFilePath);
            object returnObject = stateCodePathObject.ReadRecordCsvFile(stateCodeFilePath, delimeter, header);
            return returnObject;
        }
    }
}