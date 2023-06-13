using SimApi.Base;
using SimApi.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Operation.Transaction;

public interface IEfTransactionReportService
{
    ApiResponse<List<TransactionViewResponse>> GetAll();
    ApiResponse<TransactionViewResponse> GetById(int id);
    ApiResponse<List<TransactionViewResponse>> GetByReferenceNumber(string referenceNumber);
    ApiResponse<List<TransactionViewResponse>> GetByCustomerId(int customerId);
    ApiResponse<List<TransactionViewResponse>> GetByAccountId(int accountId);
}
