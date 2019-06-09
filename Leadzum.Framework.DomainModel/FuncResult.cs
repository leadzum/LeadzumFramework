using Leadzum.Framework.DomainModel.Enumerations;
using Leadzum.Utility.Extensions;
using System;

namespace Leadzum.Framework.DomainModel
{
    public class FuncResult<T>
    {
        private string _Message;

        public FuncResult()
        {
            Success = false;
            Code = FuncResultCode.Unknown;
            Message = string.Empty;
            Data = default;
        }

        public FuncResult(T data, FuncResultCode code = FuncResultCode.OK)
        {
            Success = code == FuncResultCode.OK;
            Code = code;
            Message = Code.GetDescription();
            Data = data;
        }

        public FuncResult(T data, bool success, FuncResultCode code, string message = null)
        {
            Success = success;
            Code = code;
            if (message == null)
            {
                Message = Code.GetDescription();
            }
            else
            {
                Message = message;
            }
            Data = data;
        }

        public bool Success { get; set; }
        public FuncResultCode Code { get; set; }
        public string Message
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_Message))
                {
                    _Message = Code.GetDescription();
                }
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }
        public T Data { get; set; }
    }

}
