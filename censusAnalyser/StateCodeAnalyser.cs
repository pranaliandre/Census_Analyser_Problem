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
        public object NumberOfrecordStateCodeFile(string stateCodeFilePath,char in_delimeter,string[] in_header)
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
                //If delimeter are incorrect throw exception
                delimeter = csv.Delimiter;
                if (!in_delimeter.Equals(delimeter))
                {
                    throw new CensusAnalyserException("Delimeter incorrect", CensusAnalyserException.Exception_type.Delimeter_Incorrect);
                }
                //Read data one by one
                while (csv.ReadNextRecord())
                    StateCodeNumberOfrecord++;
                delimeter = csv.Delimiter;
               
                string[] header = csv.GetFieldHeaders();
                //If header is incorrect throw exception
                if (!IsHeaderEqual(in_header, header))
                    throw new CensusAnalyserException("Header incorrect", CensusAnalyserException.Exception_type.Header_Incorrect);

            }
            catch (CensusAnalyserException exception)
            {
                return exception.Message;
            }
            return StateCodeNumberOfrecord;
        }
        /// <summary>
        ///  Method to compare two string arrays
        /// </summary>
        /// <param name="header1"></param>
        /// <param name="header2"></param>
        /// <returns></returns>
        public bool IsHeaderEqual(string[] header1, string[] header2)
        {
            // if length os the strings different return false
            if (header1.Length != header2.Length)
                return false;
            // loop and check each and every value of 2 strings
            for (int i = 0; i < header1.Length; i++)
            {
                if (header1[i].CompareTo(header2[i]) != 0)
                    return false;
            }
            return true;
        }
    }
}
