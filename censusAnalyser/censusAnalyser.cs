﻿///--------------------------------------------------------------------------------------------
///   Class:       censusAnalyser
///   Description: All methods are created for delimiter,count,header,Records,Sorting etc.
///   Author:      Pranali Andre                   Date: 27/4/2020
///--------------------------------------------------------------------------------------------
using System;
using System.IO;
using LumenWorks.Framework.IO.Csv;
using System.Collections;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
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
        public object readRecordCsvFile(string filePath, char inDelimeter, string[] inHeader)
        {
            try
            {
                //if File type incorrect throw exception
                if (Path.GetExtension(filePath) != ".csv")
                {
                    throw new CensusAnalyserException("File Type Incorrect", CensusAnalyserException.Exception_type.File_Type_Incorrect);
                }
                //If file path incorrect throw exception
                if (filePath != "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCensusData.csv" && filePath != "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCode.csv")
                {
                    throw new CensusAnalyserException("File Not Found", CensusAnalyserException.Exception_type.File_Not_Found);
                }
                //Read record one by one in csv file
                CsvReader csv = new CsvReader(new StreamReader(filePath));
                {
                    int fieldCount = csv.FieldCount;
                    //get fields of files
                    string[] headers = csv.GetFieldHeaders();
                    //add array list 
                    ArrayList fileData = new ArrayList();
                    fileData.Add(fileData);
                    //the record from csv file to temp record line by line
                    while (csv.ReadNextRecord())
                    {
                        numberOfRecord++;
                    }
                    //iterate the record from csv file to temp record line by line
                    while (csv.ReadNextRecord())
                    {
                        string[] records = new string[fieldCount];
                        //copy csv file record in temp record line by line
                        csv.CopyCurrentRecordTo(records);
                        //add temprecord in array list
                        fileData.Add(records);
                    }
                    if (numberOfRecord == 0)
                    {
                        throw new CSVException("file has no data", CSVException.Exception_type.FILE_HAS_NO_DATA);
                    }
                    delimeter = csv.Delimiter;
                    //If delimeter are incorrect throw exception
                    if (!inDelimeter.Equals(delimeter))
                    {
                        throw new CensusAnalyserException("Delimeter incorrect", CensusAnalyserException.Exception_type.Delimeter_Incorrect);
                    }

                    //getting field headers
                    string[] header = csv.GetFieldHeaders();
                    //If header is incorrect throw exception
                    if (!isHeaderEqual(inHeader, header))
                    {
                        throw new CensusAnalyserException("Header incorrect", CensusAnalyserException.Exception_type.Header_Incorrect);
                    }
                }
            }
            catch (NullReferenceException exception)
            {
                return exception.Message;
            }
            catch (FileNotFoundException exception)
            {
                return exception.Message;
            }
            catch (CensusAnalyserException exception)
            {
                return exception.Message;
            }
            catch (Exception exception)
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
        public bool isHeaderEqual(string[] header1, string[] header2)
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
        /// Method for count record using map
        /// </summary>
        /// <param name="records"></param>
        /// <returns></returns>
        public int countRecordsUSingMap(string[] records)
        {
            int j = 1;
            Dictionary<int, Dictionary<string, string>> map = new Dictionary<int, Dictionary<string, string>>();
            string[] key = records[0].Split(',');
            for (int i = 1; i < records.Length; i++)
            {
                string[] value = records[i].Split(',');
                Dictionary<string, string> maping = new Dictionary<string, string>()
                {
                  { key[0], value[0] },
                  { key[1], value[1] },
                  { key[2], value[2] },
                  { key[3], value[3] },
                };
                map.Add(j, maping);
                j++;
            }
            return map.Count;
        }
        /// <summary>
        ///Method for sorting the state 
        /// </summary>
        public static JArray sortingJsonBasedOnKey(string jsonFilePath, string key)
        {
            string jsonFile = File.ReadAllText(jsonFilePath);
            JArray CensusArray = JArray.Parse(jsonFile);
            //bubble sort
            for (int i = 0; i < CensusArray.Count - 1; i++)
            {
                for (int j = 0; j < CensusArray.Count - i - 1; j++)
                {
                    if (CensusArray[j][key].ToString().CompareTo(CensusArray[j + 1][key].ToString()) > 0)
                    {
                        var temp = CensusArray[j + 1];
                        CensusArray[j + 1] = CensusArray[j];
                        CensusArray[j] = temp;
                    }
                }
            }
            return CensusArray;
        }

        /// <summary>
        /// Method to retrive the first state data
        /// </summary>
        /// <param name="jsonPath"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string retriveFirstDataOnKey(string jsonPath, string key)
        {
            string jsonFileText = File.ReadAllText(jsonPath);
            JArray jArray = JArray.Parse(jsonFileText);
            string firstValue = jArray[0][key].ToString();
            return firstValue;
        }

        /// <summary>
        /// Method to retrive the last state data
        /// </summary>
        /// <param name="jsonPath"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string retriveLastDataOnKey(string jsonPath, string key)
        {
            string jsonFileText = File.ReadAllText(jsonPath);
            JArray jArray = JArray.Parse(jsonFileText);
            string lastValue = jArray[jArray.Count - 1][key].ToString();
            return lastValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jsonPath"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static JArray sortJsonBasedOnKeyAndValueIsNumber(string jsonPath, string key)
        {
            string jsonFile = File.ReadAllText(jsonPath);
            //parsing a json file
            JArray CensusArray = JArray.Parse(jsonFile);
            //sorting in sorting in ascending order
            for (int i = 0; i < CensusArray.Count - 1; i++)
            {
                for (int j = 0; j < CensusArray.Count - i - 1; j++)
                {
                    if ((int)CensusArray[j][key] > (int)CensusArray[j + 1][key])
                    {
                        var temp = CensusArray[j + 1];
                        CensusArray[j + 1] = CensusArray[j];
                        CensusArray[j] = temp;
                    }
                }
            }
            return CensusArray;
        }
        public static string filePath1;
        public static char in_delimeter1;
        public static string[] in_header1;
        public static string jsonFilePath1;
        public static string key1;
        public static string jsonPath1;
        public static string[] record;
        static void Main(string[] args)
        {
            CensusAnalyser CensusAnalyse = new CensusAnalyser();
            CensusAnalyse.readRecordCsvFile(filePath1, in_delimeter1, in_header1);
            CensusAnalyse.countRecordsUSingMap(record);
            sortingJsonBasedOnKey(jsonFilePath1, key1);
            retriveFirstDataOnKey(jsonPath1, key1);
            retriveLastDataOnKey(jsonPath1, key1);
        }
    }
}