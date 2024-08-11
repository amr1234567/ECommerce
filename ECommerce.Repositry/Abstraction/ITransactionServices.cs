using ECommerce.Core.Entities.Application;
using ECommerce.Repository.Models.InputModels;
using ECommerce.Repository.Models.OutputModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.Abstraction
{
    public interface ITransactionServices
    {
        Task<bool> AddTransaction(TransactionToAddModel model);
        Task<TransactionResponse> CancelTransaction(string transactionId);
        Task<TransactionResponse> ConfirmTransactionDelivered(string transactionId);
        Task<TransactionResponse> ConfirmTransactionGoToDelivery(string transactionId);
        Task<IQueryable<TransactionResponse>> GetAllTransactions(string? hour, string? day, string? month, string? year);
        Task<IQueryable<TransactionResponse>> GetAllTransactionForConsumer(string consumerId);
        Task<IQueryable<TransactionResponse>> GetAllCompletedTransactionForConsumer(string consumerId);
        Task<IQueryable<TransactionResponse>> GetAllUnderProgressTransactionForConsumer(string consumerId);
        Task<IQueryable<TransactionResponse>> GetAllTransactionForDelivery(string deliveryId);
        Task<IQueryable<TransactionResponse>> GetAllCompletedTransactionForDelivery(string DeliveryId);
        Task<IQueryable<TransactionResponse>> GetAllUnderProgressTransactionForDelivery(string deliveryId);
        Task<List<ProductResponse>> GetAllProductsInTransaction(string transactionId);
        Task<TransactionResponse> GetTransactionById(string transactionId);
        Task<bool> AssignDeliveryManToTransaction(string deliveryId, string transactionId);
        Task<bool> AssignDeliveryManToTransactions(string deliveryId, params string[] transactionsIds);
        Task<TransactionResponse> SetExpectedReceiveDate(string transactionId, DateTime date);
    }
}
