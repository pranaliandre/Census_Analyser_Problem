///-----------------------------------------------------------------
///   Class:     CSVException
///   Description: CSVException for throw Exception
///   Author:      Pranali Andre               Date: 2/5/2020
///-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace censusAnalyser
{
    public class CSVException : Exception
    {
        public string message;
        /// <summary>
        /// 
        /// </summary>
        public enum Exception_type
        {
            FILE_HAS_NO_DATA
        }
        /// <summary>
        /// parameterized constructor
        /// </summary>
        /// <param name="message"></param>
        public CSVException(string message)
        {
            this.message = message;
        }
        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public CSVException(string message, Exception_type exception) : this(message)
        {
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
