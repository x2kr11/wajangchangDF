using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eHR.Framework.Base
{
    public interface IClientPopMessage
    {
        /// <summary>
        ///  품의 중 에러 메시지
        /// </summary>
        void ClientApprovalError();
        /// <summary>
        /// 품의 중 에러 메시지
        /// </summary>
        /// <param name="callback"></param>
        void ClientApprovalError(string callback);
        /// <summary>
        /// 품의 완료 메시지
        /// </summary>
        void ClientApproval();
        /// <summary>
        /// 품의 완료 메시지
        /// </summary>
        /// <param name="callback"></param>
        void ClientApproval(string callback);
    }
}
