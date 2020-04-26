using System;

namespace censusAnalyser
{
    public class StateCensusAnalyser : ICSVBuilder
    {
        /// <summary>
        /// variable
        /// </summary>
        /// 
        public string stateCensusFilePath;
        public string[] header;
        public char delimeter;

        public object State { get; internal set; }
        public string filepath;
        public static string jsonPathstateCensus;

        
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
        /// <summary>
        /// Main Method
        /// </summary>
        static void Main(string[] args)
        {
            // Console.WriteLine("Welcome to India state census Analyzer");
            string firstValue = CensusAnalyser.RetriveFirstDataOnKey(jsonPathstateCensus, "State");
            string lastValue = CensusAnalyser.RetriveLastDataOnKey(jsonPathstateCensus, "State");

            Console.WriteLine(firstValue);
            Console.WriteLine(lastValue);
        }
        object ICSVBuilder.CsvStateCensusReadRecord(string stateCensusFilePath, char delimeter, string[] header)
        {
            throw new NotImplementedException();
        }
        object ICSVBuilder.CsvStateCodeReadRecord(string stateCodeFilePath, char delimeter, string[] header)
        {
            throw new NotImplementedException();
        }
        //public string CheckForState(string jsonPathstateCensus, string v1, string v2)
        //{
          //  throw new NotImplementedException();
        //}
    }
}