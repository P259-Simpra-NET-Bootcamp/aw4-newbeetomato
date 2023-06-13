using SimApi.Data.Context;
using SimApi.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SimApi.Data.Repository.Transaction;

public class EfTransactionRepository : IEfTransactionRepository
{
    private readonly SimEfDbContext context;
    public EfTransactionRepository(SimEfDbContext context)
    {
        this.context = context;
    }
    public List<TransactionView> GetAll()
    {
        return context.Set<TransactionView>().ToList();
    }
    public List<TransactionView> GetByAccountId(int AccountId)
    {
        var list = context.Set<TransactionView>().Where(c => c.AccountId == AccountId).ToList();
        return list;
    }
    public List<TransactionView> GetByCustomerId(int CustomerId)
    {
        var list = context.Set<TransactionView>().Where(c => c.CustomerId == CustomerId).ToList();
        return list;
    }
    public TransactionView GetById(int Id)
    {
        var list = context.Set<TransactionView>().Where(c => c.Id == Id).FirstOrDefault();
        return list;
    }
    public List<TransactionView> GetByReferenceNumber(string ReferenceNumber)
    {
        var list = context.Set<TransactionView>().Where(c => c.ReferenceNumber == ReferenceNumber).ToList();
        return list;
    }
}
