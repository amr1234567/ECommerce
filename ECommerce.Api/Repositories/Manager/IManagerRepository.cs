using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Repositories.Manager
{
    public interface IManagerRepository
    {
        IBugReportRepository BugReportRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IDiscountRepository DiscountRepository { get; }
        IProductRepository ProductRepository { get; }
        ISellerRepository SellerRepository { get; }
        IShopCartRepository ShopCartRepository { get; }
        ISubCategoryRepository SubCategoryRepository { get; }
        ITransactionRepository TransactionRepository { get; }
    }
}
