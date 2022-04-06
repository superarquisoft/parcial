namespace Domain.Models.Entities.Base
{
    /// <summary>
    /// Controller base response
    /// </summary>
    public class ResponseEntity
    {
        #region Properties
        /// <summary>
        /// Function invoked
        /// </summary>
        public string Function { get; private set; }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// ErrorCode
        /// </summary>
        public int ErrorCode { get; private set; }

        /// <summary>
        /// Error
        /// </summary>
        public bool Error { get; private set; }

        /// <summary>
        /// Data
        /// </summary>
        public dynamic Data { get; private set; }
        #endregion Properties

        public ResponseEntity Build(string function, string message, int errorcode, bool error, dynamic data)
        {
            Function = function;
            Message = message;
            ErrorCode = errorcode;
            Error = error;
            Data = data;

            return this;
        }
    }
}
