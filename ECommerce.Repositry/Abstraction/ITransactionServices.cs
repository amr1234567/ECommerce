using ECommerce.Core.Entities.Application;
using ECommerce.Repositry.Models.InputModels;
using ECommerce.Repositry.Models.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repositry.Abstraction
{
    public interface ITransactionServices
    {
        Task<bool> AddTransaction(TransactionToAddModel model);
        Task<TransactionResponse> CancelTransaction(string transactionId);
        Task<TransactionResponse> ConfirmTransactionDelivered(string transactionId);
        Task<TransactionResponse> ConfirmTransactionGoToDelivery(string transactionId);
        Task<List<TransactionResponse>> GetAllTransactionForConsumer(string consumerId);
        Task<List<TransactionResponse>> GetAllCompletedTransactionForConsumer(string consumerId);
        Task<List<TransactionResponse>> GetAllUnderProgressTransactionForConsumer(string consumerId);
        Task<List<TransactionResponse>> GetAllTransactionForDelivery(string consumerId);
        Task<List<TransactionResponse>> GetAllCompletedTransactionForDelivery(string DeliveryId);
        Task<List<TransactionResponse>> GetAllUnderProgressTransactionForDelivery(string deliveryId);
        Task<List<ProductResponse>> GetAllProductsInTransaction(string transactionId);
        Task<TransactionResponse> GetTransactionById(string transactionId);
    }
}
