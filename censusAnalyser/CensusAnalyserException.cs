using System;
namespace censusAnalyser
{
    public class CensusAnalyserException:Exception
    {
        /// <summary>
        ///Variable
        /// </summary>
        public string message;
        
        public string GetMessage { get => this.message; }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="message"></param>
        public CensusAnalyserException(string message) 
        {
            this.message = message;
        }        
    }
}
