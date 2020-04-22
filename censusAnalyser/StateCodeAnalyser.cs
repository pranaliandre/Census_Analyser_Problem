using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using LumenWorks.Framework.IO.Csv;
namespace censusAnalyser
{
    public class StateCodeAnalyser
    {
        /// <summary>
        /// variable
        /// </summary>
        public string stateCodeFilePath;
        public int StateCodeNumberOfrecord = 0;
        public char delimeter;
        /// <summary>
        /// Parameterized condtructor
        /// </summary>
        /// <param name="path"></param>
        public StateCodeAnalyser(string path= "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCode.csv")
        {
            this.stateCodeFilePath = path;
        }
        /// <summary>
        /// Method to check number of record state code
        /// </summary>
        /// <param name="stateCodeFilePath"></param>
        /// <returns></returns>
        public object NumberOfrecordStateCodeFile(string stateCodeFilePath,char in_delimeter)
        {
            try
            {
                //if File type incorrect throw exception
                if (!stateCodeFilePath.EndsWith(".csv"))
                    throw new CensusAnalyserException("File Type Incorrect", CensusAnalyserException.Exception_type.File_Type_Incorrect);
                ////If file path incorrect throw exception
                if (stateCodeFilePath != "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCode.csv")
                    throw new CensusAnalyserException("File Not Found", CensusAnalyserException.Exception_type.File_Not_Found);
                CsvReader csv = new CsvReader(new StreamReader(stateCodeFilePath));
                //Read data one by one
                while (csv.ReadNextRecord())
                    StateCodeNumberOfrecord++;
                delimeter = csv.Delimiter;
                //If delimeter are incorrect throw exception
                if (!in_delimeter.Equals(delimeter))
                {
                    throw new CensusAnalyserException("Delimeter incorrect", CensusAnalyserException.Exception_type.Delimeter_Incorrect);
                }
            }
            catch (CensusAnalyserException exception)
            {
                return exception.Message;
            }
            return StateCodeNumberOfrecord;
        }
    }
}
