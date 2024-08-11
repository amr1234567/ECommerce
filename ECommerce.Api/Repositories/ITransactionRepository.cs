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
        Task<IQueryable<Transaction>> GetAllTransactions(string? hour, string? day, string? month, string? year);
        Task<IQueryable<Transaction>> GetAllCompletedTransactionForConsumer(string consumerId);
        Task<IQueryable<Transaction>> GetAllUnderProgressTransactionForConsumer(string consumerId);
        Task<IQueryable<Transaction>> GetAllTransactionForDelivery(string consumerId);
        Task<IQueryable<Transaction>> GetAllCompletedTransactionForDelivery(string DeliveryId);
        Task<IQueryable<Transaction>> GetAllUnderProgressTransactionForDelivery(string deliveryId);
        Task<List<Product>> GetAllProductsInTransaction(string transactionId);
        Task<Transaction> GetTransactionById(string transactionId);
        Task<bool> AssignDeliveryManToTransaction(string deliveryId, string transactionId);
        Task<bool> AssignDeliveryManToTransactions(string deliveryId, params string[] transactionsIds);
        Task<Transaction> SetExpectedReceiveDate(string transactionId, DateTime date);
    }
}
