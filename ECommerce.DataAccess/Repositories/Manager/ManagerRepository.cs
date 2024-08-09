using ECommerce.Core.Repositories;
using ECommerce.Core.Repositories.Manager;
using ECommerce.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Repositories.Manager
{
    public class ManagerRepository(ECommerceContext _context) : IManagerRepository
    {

        public IBugReportRepository BugReportRepository
        {
            get
            {
                return new BugReportRepository(_context);
            }
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                return new CategoryRepository(_context);
            }
        }

        public IDiscountRepository DiscountRepository
        {
            get
            {
                return new DiscountRepository(_context);
            }
        }

        public IProductRepository ProductRepository
        {
            get
            {
                return new ProductRepository(_context);
            }
        }

        public ISellerRepository SellerRepository
        {
            get
            {
                return new SellerRepository(_context);
            }
        }

        public IShopCartRepository ShopCartRepository
        {
            get
            {
                return new ShopCartRepository(_context);
            }
        }

        public ISubCategoryRepository SubCategoryRepository
        {
            get
            {
                return new SubCategoryRepository(_context);
            }
        }

        public ITransactionRepository TransactionRepository
        {
            get
            {
                return new TransactionRepository(_context);
            }
        }
    }
}
