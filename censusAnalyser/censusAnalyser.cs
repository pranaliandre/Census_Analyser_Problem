using System;
using System.IO;
using LumenWorks.Framework.IO.Csv;
namespace censusAnalyser
{
    public class CensusAnalyser
    {
        /// <summary>
        /// variable
        /// </summary>
        public int numberOfRecord = 0;
        public string filePath;
        public string[] header; 
        public char delimeter;
        /// <summary>
        /// Default constructor for invoking object.
        /// </summary>
        public CensusAnalyser() { }
        /// <summary>
        /// Parameterized constructor for different variables.
        /// </summary>
        /// <param name="filePath"></param>
        public CensusAnalyser(string filePath)
        {
            this.filePath = filePath;
        }
        /// <summary>
        /// Method to checking record for two csv file
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="in_delimeter"></param>
        /// <param name="in_header"></param>
        /// <returns></returns>
        public object ReadRecordCsvFile(string filePath, char in_delimeter, string[] in_header)
        {
            try
            {
                //if File type incorrect throw exception
                if (Path.GetExtension(filePath) != ".csv")
                    throw new CensusAnalyserException("File Type Incorrect", CensusAnalyserException.Exception_type.File_Type_Incorrect);
                //If file path incorrect throw exception
                if (filePath != "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCensusData.csv" && filePath != "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCode.csv")
                    throw new CensusAnalyserException("File Not Found", CensusAnalyserException.Exception_type.File_Not_Found);
                //Read record one by one in csv file
                CsvReader csv = new CsvReader(new StreamReader(filePath));
                {
                    while (csv.ReadNextRecord())
                        numberOfRecord++;
                    if (numberOfRecord == 0)
                        throw new CSVException("file has no data", CSVException.Exception_type.FILE_HAS_NO_DATA);
                    delimeter = csv.Delimiter;
                    //If delimeter are incorrect throw exception
                    if (!in_delimeter.Equals(delimeter))
                        throw new CensusAnalyserException("Delimeter incorrect", CensusAnalyserException.Exception_type.Delimeter_Incorrect);
                }
                //getting field headers
                string[] header = csv.GetFieldHeaders();
                //If header is incorrect throw exception
                if (!IsHeaderEqual(in_header, header))
                    throw new CensusAnalyserException("Header incorrect", CensusAnalyserException.Exception_type.Header_Incorrect);
                

            }
            catch(NullReferenceException exception)
            {
                return exception.Message;
            }
            catch(FileNotFoundException exception)
            {
                return exception.Message;
            }
            catch (CensusAnalyserException exception)
            {
                return exception.Message;
            }
            catch(Exception exception)
            {
                return exception.Message;
            }


            return numberOfRecord;
        }
        /// <summary>
        /// Method to compare two string arrays
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
        /// <summary>
        /// static variable
        /// </summary>
        public static string filePath1;
        public static string[] header1;
        public static char delimeter1;
        /// <summary>
        /// Main Method
        /// </summary>
        /// <param name="args"></param>
        static void Main(String[] args)
        {
            Console.WriteLine("!!!Welcome to census analyser!!!");
            CensusAnalyser object_CensusAnalyser = new CensusAnalyser();
            object_CensusAnalyser.ReadRecordCsvFile(filePath1, delimeter1, header1);
        }
    }
}
