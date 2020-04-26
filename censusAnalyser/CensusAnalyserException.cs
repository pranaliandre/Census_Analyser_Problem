using System;
using censusAnalyser;
namespace censusAnalyser
{
    public class CensusAnalyserException:Exception
    {
        public enum Exception_type
        {
            File_Not_Found,
            File_Type_Incorrect,
            Delimeter_Incorrect,
            Header_Incorrect
        }
        /// <summary>
        ///Variable
        /// </summary>
        public string message;
        

        /// <summary>
        /// parameterized constructor
        /// </summary>
        /// <param name="message"></param>
        public CensusAnalyserException(string message) 
        {
            this.message = message;
        }
        readonly public Exception_type exception;
        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public CensusAnalyserException(string message, Exception_type exception) : this(message)
        {
            this.exception = exception;
        }
        public override string Message
        {
            get
            {
                return this.message;
            }
        }
    }
}
