using System;
using System.Collections.Generic;
using System.Text;

namespace Panbor_ImportWebSO
{

    public enum MessageType
    {
        /// <summary>
        /// 無
        /// </summary>
        None = 0,
        /// <summary>
        /// 成功
        /// </summary>
        Success = 1,
        /// <summary>
        /// 警告
        /// </summary>
        Warning = 2,
        /// <summary>
        /// 錯誤
        /// </summary>
        Error = 3,
        /// <summary>
        /// 提示
        /// </summary>
        Help = 4,
    }

    //public enum SAPControlColor
    //{
    //    SAP_FormBackground = 0x123456,
    //    SAP_ReadOnly = 0x123456,
    //}

}
