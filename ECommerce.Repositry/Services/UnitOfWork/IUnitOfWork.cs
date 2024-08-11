
using ECommerce.Core.Repositories.Manager;
using ECommerce.Repository.Abstraction;
using ECommerce.Repository.Abstraction.UnitOfWork;

namespace ECommerce.Repository.Services.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Lazy<IBugReportServices> _lazyBugReportServices;

        private readonly Lazy<IProductServices> _lazyProductServices;

        private readonly Lazy<ICategoryServices> _lazyCategoryServices;

        private readonly Lazy<ISubCategoryServices> _lazySubCategoryServices;

        private readonly Lazy<IDiscountServices> _lazyIDiscountServices;

        private readonly Lazy<ISellerServices> _lazySellerServices;

        private readonly Lazy<IShopCartServices> _lazyShopCartServices;

        private readonly Lazy<ITransactionServices> _lazyTransactionServices;

        public UnitOfWork(IManagerRepository managerRepository, IUserServices userServices)
        {
            _lazyBugReportServices = new Lazy<IBugReportServices>(() => new BugReportServices(managerRepository, userServices));
            _lazyProductServices = new Lazy<IProductServices>(() => new ProductServices(managerRepository));
            _lazyCategoryServices = new Lazy<ICategoryServices>(() => new CategoryServices(managerRepository));
            _lazySubCategoryServices = new Lazy<ISubCategoryServices>(() => new SubCategoryServices(managerRepository));
            _lazyIDiscountServices = new Lazy<IDiscountServices>(() => new DiscountServices(managerRepository));
            _lazySellerServices = new Lazy<ISellerServices>(() => new SellerServices(managerRepository));
            _lazyShopCartServices = new Lazy<IShopCartServices>(() => new ShopCartServices(managerRepository));
            _lazyTransactionServices = new Lazy<ITransactionServices>(() => new TransactionServices(managerRepository, userServices));
        }

        public IBugReportServices BugReportServices => _lazyBugReportServices.Value;

        public IProductServices ProductServices => _lazyProductServices.Value;

        public ICategoryServices CategoryServices => _lazyCategoryServices.Value;

        public ISubCategoryServices SubCategoryServices => _lazySubCategoryServices.Value;

        public IDiscountServices IDiscountServices => _lazyIDiscountServices.Value;

        public ISellerServices SellerServices => _lazySellerServices.Value;

        public IShopCartServices ShopCartServices => _lazyShopCartServices.Value;

        public ITransactionServices TransactionServices => _lazyTransactionServices.Value;

    }
}
