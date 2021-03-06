﻿///-----------------------------------------------------------------
///   Class:       JSONCensus
///   Description: CSV to JSON Conversion functions.
///   Author:      Pranali Andre                   Date: 4/5/2020
///-----------------------------------------------------------------
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using ChoETL;
namespace censusAnalyser
{
    public class JSONCensus
    {
        /// <summary>
        /// Method to write the First state data using json
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="jsonFilepath"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string ReturnFirstDataAfterSortingCsvFileWriteInJson(string filePath, string jsonFilepath, string key)
        {
            string readFile = File.ReadAllText(filePath);
            StringBuilder stringbuilder = new StringBuilder();
            using (var loadText = ChoCSVReader.LoadText(readFile)
                                            .WithFirstLineHeader())
            {
                using (var writer = new ChoJSONWriter(stringbuilder)) writer.Write(loadText);
            }
            File.WriteAllText(jsonFilepath, stringbuilder.ToString());
            JArray array = CensusAnalyser.SortingJsonBasedOnKey(jsonFilepath, key);
            //serialize JSON to a string and then write string to a file
            var jsonArray = JsonConvert.SerializeObject(array, Formatting.Indented);
            File.WriteAllText(jsonFilepath, jsonArray);
            return CensusAnalyser.RetriveFirstDataOnKey(jsonFilepath, key);
        }
        /// <summary>
        /// Method to write the last state data using json
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="jsonFilepath"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string ReturnLastDataAfterSortingCsvFileWriteInJson(string filePath, string jsonFilepath, string key)
        {
            string readFile = File.ReadAllText(filePath);
            StringBuilder stringbuilder = new StringBuilder();
            using (var loadText = ChoCSVReader.LoadText(readFile)
                                            .WithFirstLineHeader())
            {
                using (var writer = new ChoJSONWriter(stringbuilder)) writer.Write(loadText);
            }
            File.WriteAllText(jsonFilepath, stringbuilder.ToString());
            JArray array = CensusAnalyser.SortingJsonBasedOnKey(jsonFilepath, key);
            // serialize JSON to a string and then write string to a file
            var jsonArray = JsonConvert.SerializeObject(array, Formatting.Indented);
            File.WriteAllText(jsonFilepath, jsonArray);
            return CensusAnalyser.RetriveLastDataOnKey(jsonFilepath, key);
        }
       /// <summary>
       /// Method to sorting the most population ,density largest value
       /// </summary>
       /// <param name="filePath"></param>
       /// <param name="jsonFilepath"></param>
       /// <param name="key"></param>
       /// <returns></returns>
        public static string ReturnDataNumberOfStatesSortCSVFileAndWriteInJson(string filePath, string jsonFilepath, string key)
        {
            string readFile = File.ReadAllText(filePath);
            StringBuilder stringbuilder = new StringBuilder();
            using (var loadText = ChoCSVReader.LoadText(readFile)
                                            .WithFirstLineHeader())
            {
                using (var writer = new ChoJSONWriter(stringbuilder))writer.Write(loadText);
            }
            File.WriteAllText(jsonFilepath, stringbuilder.ToString());
            JArray array = CensusAnalyser.SortJsonBasedOnKeyAndValueIsNumber(jsonFilepath, key);
            var jsonArray = JsonConvert.SerializeObject(array, Formatting.Indented);
            File.WriteAllText(jsonFilepath, jsonArray);
            return CensusAnalyser.RetriveLastDataOnKey(jsonFilepath, key);
        }
        /// <summary>
        /// Method to sorting the area of small area value
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="jsonFilepath"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string ReturnDataNumberOfStatesFirstDataSortCSVFileAndWriteInJson(string filePath, string jsonFilepath, string key)
        {
            string readFile = File.ReadAllText(filePath);
            StringBuilder stringbuilder = new StringBuilder();
            using (var loadText = ChoCSVReader.LoadText(readFile)
                                            .WithFirstLineHeader())
            {
                using (var writer = new ChoJSONWriter(stringbuilder)) writer.Write(loadText);
            }
            File.WriteAllText(jsonFilepath, stringbuilder.ToString());
            JArray array = CensusAnalyser.SortJsonBasedOnKeyAndValueIsNumber(jsonFilepath, key);
            var jsonArray = JsonConvert.SerializeObject(array, Formatting.Indented);
            File.WriteAllText(jsonFilepath, jsonArray);
            return CensusAnalyser.RetriveFirstDataOnKey(jsonFilepath, key);
        }
    }
}