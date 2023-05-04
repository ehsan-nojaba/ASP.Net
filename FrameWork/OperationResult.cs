using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork
{
    public class OperationResult
    {
        public string Operation { get; set; }
        public string Message { get; set; }
        public string TableName { get; set; }
        public bool Success { get; set; }
        public DateTime OperationDate { get; set; }
        public int? RecordId { get; set; }

        public OperationResult(string operation, string tableName)
        {
           this.Operation = operation;
           this.TableName = tableName;
            Success = false;
            OperationDate = DateTime.Now;
        }

        public OperationResult(string operation, string tableName, int recordId)
        {
            this.Operation = operation;
            this.TableName = tableName;
            Success = false;
            OperationDate = DateTime.Now;
            this.RecordId = recordId;
        }

        public OperationResult ToSuccess(string message)
        {
            this.Success = true;
            this.Message = message;
            return this;
        }

        public OperationResult ToSuccess(string message,int recordId)
        {
            this.Success = true;
            this.Message = message;
            this.RecordId = recordId;
            return this;
        }

        public OperationResult ToFail(string message)
        {
            this.Success = false;
            this.Message = message;
            return this;
        }

        public OperationResult ToFail(string message, int recordId)
        {
            this.Success = false;
            this.Message = message;
            this.RecordId = recordId;
            return this;
        }
    }
}
