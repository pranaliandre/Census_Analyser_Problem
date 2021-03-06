﻿///-----------------------------------------------------------------
///   Class:       StateCensusAnalyserDAO
///   Description: Method for StateCensusData File
///   Author:      Pranali Andre                   Date: 29/4/2020
///-----------------------------------------------------------------
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using ChoETL;
namespace censusAnalyser
{
    public class StateCensusAnalyserDao : ICSVBuilder
    {
        /// <summary>
        /// variable
        /// </summary>
        /// 
        public string stateCensusFilePath { get; set; }
        public char delimeter { get; set; }
        public string[] header { get; set; }
        public string filepath { get; set; }
        public StateCensusAnalyserDao() { }
        /// <summary></summary>
        /// <summary>
        /// Parameterized constructor for different variables.
        /// </summary>
        /// <param name="stateCensusFilePath"></param>
        /// <param name="delimeter"></param>
        /// <param name="header"></param>
        public StateCensusAnalyserDao(string stateCensusFilePath, char delimeter, string[] header)
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
        public delegate object CsvStateCensusDao(string stateCensusFilePath, char delimeter, string[] header);
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
      
        object ICSVBuilder.CsvStateCensusReadRecord(string stateCensusFilePath, char delimeter, string[] header)
        {
            throw new NotImplementedException();
        }
        object ICSVBuilder.CsvStateCodeReadRecord(string stateCodeFilePath, char delimeter, string[] header)
        {
            throw new NotImplementedException();
        }
        object ICSVBuilder.CsvUSCensusReadRecord(string USCensusDataFilePath, char delimeter, string[] header)
        {
            throw new NotImplementedException();
        }
    }
}