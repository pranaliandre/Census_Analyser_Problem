using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using LumenWorks.Framework.IO.Csv;
namespace censusAnalyser
{
    public class StateCensusAnalyser
    {
        /// <summary>
        /// variable
        /// </summary>
        public string filePath;
        public int numberOfRecord = 0;
        public char delimeter;
        /// <summary>
        ///parameterized constructor is used to provide different values to the objects
        /// </summary>
        /// <param name="path"></param>
        public StateCensusAnalyser(string path = "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCensusData.csv")
        {
            this.filePath = path;
        }
        /// <summary>
        /// Method to check number of record in file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public object NumberOfRecord(string filePath,char in_delimeter)
        {
            try
            {
                //if File type incorrect throw exception
                if (!filePath.EndsWith(".csv"))
                    throw new CensusAnalyserException("File Type Incorrect", CensusAnalyserException.Exception_type.File_Type_Incorrect);
                //If file path incorrect throw exception
                if (filePath != "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCensusData.csv")
                    throw new CensusAnalyserException("File Not Found", CensusAnalyserException.Exception_type.File_Not_Found);

                //Read record one by one in csv file
                CsvReader csv = new CsvReader(new StreamReader(filePath));
                {
                    while (csv.ReadNextRecord())
                        numberOfRecord++;
                    delimeter = csv.Delimiter;
                    //If delimeter are incorrect throw exception
                    if (!in_delimeter.Equals(delimeter))
                    {
                        throw new CensusAnalyserException("Delimeter incorrect", CensusAnalyserException.Exception_type.Delimeter_Incorrect);
                    }
                }
            }
            catch (CensusAnalyserException exception)
            {
                return exception.Message;
            }
            return numberOfRecord;
        }
    }
}