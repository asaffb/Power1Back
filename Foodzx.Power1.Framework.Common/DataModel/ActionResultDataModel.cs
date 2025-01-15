using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodzx.Power1.Framework.Common.DataModel
{
    public class ActionResultDataModel
    {
        /// <summary>
        /// Default success result
        /// </summary>
        public ActionResultDataModel()
        {

        }

        #region Error
        /// <summary>
        /// Error result with message
        /// </summary>
        /// <param name="errorMessage"></param>
        public ActionResultDataModel(string errorMessage)
        {
            this.IsOK = false;
            this.ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Error result with message format one argument
        /// </summary>
        /// <param name="errorMessage"></param>
        public ActionResultDataModel(string errorMessage, object arg0)
        {
            this.IsOK = false;
            this.ErrorMessage = string.Format(errorMessage, arg0);
        }

        /// <summary>
        /// Error result with message format two arguments
        /// </summary>
        /// <param name="errorMessage"></param>
        public ActionResultDataModel(string errorMessage, object arg0, object arg1)
        {
            this.IsOK = false;
            this.ErrorMessage = string.Format(errorMessage, arg0, arg1);
        }

        /// <summary>
        /// Error result with message format three arguments
        /// </summary>
        /// <param name="errorMessage"></param>
        public ActionResultDataModel(string errorMessage, object arg0, object arg1, object arg2)
        {
            this.IsOK = false;
            this.ErrorMessage = string.Format(errorMessage, arg0, arg1, arg2);
        }

        /// <summary>
        /// Error result with message format with argument array
        /// </summary>
        /// <param name="errorMessage"></param>
        public ActionResultDataModel(string errorMessage, params object[] args)
        {
            this.IsOK = false;
            this.ErrorMessage = string.Format(errorMessage, args);
        }
        #endregion

        #region Error & Inner Action Result
        /// <summary>
        /// Error result and inner result with message format one argument
        /// </summary>
        /// <param name="errorMessage"></param>
        public ActionResultDataModel(ActionResultDataModel innerAcctionResult, string errorMessage, object arg0)
        {
            this.IsOK = false;
            this.ErrorMessage = string.Format(errorMessage, arg0);
        }

        /// <summary>
        /// Error result and inner result with message format two arguments
        /// </summary>
        /// <param name="errorMessage"></param>
        public ActionResultDataModel(ActionResultDataModel innerAcctionResult, string errorMessage, object arg0, object arg1)
        {
            this.IsOK = false;
            this.ErrorMessage = string.Format(errorMessage, arg0, arg1);
        }

        /// <summary>
        /// Error result and inner result with message format three arguments
        /// </summary>
        /// <param name="errorMessage"></param>
        public ActionResultDataModel(ActionResultDataModel innerAcctionResult, string errorMessage, object arg0, object arg1, object arg2)
        {
            this.IsOK = false;
            this.ErrorMessage = string.Format(errorMessage, arg0, arg1, arg2);
        }

        /// <summary>
        /// Error result and inner result with message format with argument array
        /// </summary>
        /// <param name="errorMessage"></param>
        public ActionResultDataModel(ActionResultDataModel innerAcctionResult, string errorMessage, params object[] args)
        {
            this.IsOK = false;
            this.ErrorMessage = string.Format(errorMessage, args);
        }
        #endregion

        /// <summary>
        /// Error result according to exception
        /// </summary>
        /// <param name="ex"></param>
        public ActionResultDataModel(Exception ex)
        {
            this.IsOK = false;
            this.ErrorMessage = ex.Message;
            this.ErrorDescription = ex.StackTrace;

            this.ResultException = ex;
        }

        public bool IsOK { get; protected set; } = true;

        public string ErrorMessage { get; protected set; } = string.Empty;

        public string ErrorDescription { get; protected set; } = string.Empty;

        public Exception ResultException { get; protected set; } = null;

        public ActionResultDataModel InnerActionResultDataModel { get; protected set; } = null;
    }
}
