using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Data.Repository.Transaction;

public interface IEfTransactionRepository
{
    List<TransactionView> GetAll();
    TransactionView GetById(int id);
    List<TransactionView> GetByReferenceNumber(string referenceNumber);
    List<TransactionView> GetByCustomerId(int customerId);
    List<TransactionView> GetByAccountId(int accountId);
}
