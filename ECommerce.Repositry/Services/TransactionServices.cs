using ECommerce.Core.Repositories.Manager;
using ECommerce.Repositry.Abstraction;
using ECommerce.Repositry.Models.InputModels;
using ECommerce.Repositry.Models.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repositry.Services
{
    internal class TransactionServices(IManagerRepository managerRepository) : ITransactionServices
    {
        public Task<bool> AddTransaction(TransactionToAddModel model)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionResponse> CancelTransaction(string transactionId)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionResponse> ConfirmTransactionDelivered(string transactionId)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionResponse> ConfirmTransactionGoToDelivery(string transactionId)
        {
            throw new NotImplementedException();
        }

        public Task<List<TransactionResponse>> GetAllCompletedTransactionForConsumer(string consumerId)
        {
            throw new NotImplementedException();
        }

        public Task<List<TransactionResponse>> GetAllCompletedTransactionForDelivery(string DeliveryId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductResponse>> GetAllProductsInTransaction(string transactionId)
        {
            throw new NotImplementedException();
        }

        public Task<List<TransactionResponse>> GetAllTransactionForConsumer(string consumerId)
        {
            throw new NotImplementedException();
        }

        public Task<List<TransactionResponse>> GetAllTransactionForDelivery(string consumerId)
        {
            throw new NotImplementedException();
        }

        public Task<List<TransactionResponse>> GetAllUnderProgressTransactionForConsumer(string consumerId)
        {
            throw new NotImplementedException();
        }

        public Task<List<TransactionResponse>> GetAllUnderProgressTransactionForDelivery(string deliveryId)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionResponse> GetTransactionById(string transactionId)
        {
            throw new NotImplementedException();
        }
    }
}
