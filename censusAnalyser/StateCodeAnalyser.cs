using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using LumenWorks.Framework.IO.Csv;
namespace censusAnalyser
{
    public class StateCodeAnalyser
    {
        public string stateCodeFilePath;
        public int StateCodeNumberOfrecord = 0;
        public StateCodeAnalyser(string path= "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCode.csv")
        {
            this.stateCodeFilePath = path;
        }
        public object NumberOfrecordStateCodeFile(string stateCodeFilePath)
        {
            try
            {
                if (stateCodeFilePath != "C:/Users/intel/source/repos/censusAnalyser/censusAnalyser/StateCode.csv")
                    throw new CensusAnalyserException("File Not Found", CensusAnalyserException.Exception_type.File_Not_Found);
                CsvReader csv = new CsvReader(new StreamReader(stateCodeFilePath));
                while (csv.ReadNextRecord())
                    StateCodeNumberOfrecord++;
            }
            catch (CensusAnalyserException exception)
            {
                return exception.Message;
            }
            return StateCodeNumberOfrecord;
        }
    }
}
