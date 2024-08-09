using ECommerce.Core.Entities.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Repositories
{
    public interface ITransactionRepository
    {
        Task<bool> AddTransaction(Transaction model);
        Task<Transaction> CancelTransaction(string transactionId);
        Task<Transaction> ConfirmTransactionDelivered(string transactionId);
        Task<Transaction> ConfirmTransactionGoToDelivery(string transactionId);
        Task<IQueryable<Transaction>> GetAllTransactionForConsumer(string consumerId);
        Task<IQueryable<Transaction>> GetAllCompletedTransactionForConsumer(string consumerId);
        Task<IQueryable<Transaction>> GetAllUnderProgressTransactionForConsumer(string consumerId);
        Task<IQueryable<Transaction>> GetAllTransactionForDelivery(string consumerId);
        Task<IQueryable<Transaction>> GetAllCompletedTransactionForDelivery(string DeliveryId);
        Task<IQueryable<Transaction>> GetAllUnderProgressTransactionForDelivery(string deliveryId);
        Task<List<Product>> GetAllProductsInTransaction(string transactionId);
        Task<Transaction> GetTransactionById(string transactionId);
    }
}
