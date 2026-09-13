using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
namespace Dentistry
{
    public class JsonResponse<T>
    {
        #region Properties
        /// <summary>
        /// Gets or sets Data.
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// Gets or sets Message.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether Success.
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// Get or sets TotalCount of records
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// Get or sets CurrentPage of records    
        /// </summary>
        public int CurrentPage { get; set; }
        public int PageNumber { get; set; }
        /// <summary>
        /// Get or sets PageSize
        /// </summary>
        public int PageSize { get; set; }
        public dynamic DataInfo { get; set; }
        public dynamic ExtraInfo { get; set; }
        #endregion
    }
}
