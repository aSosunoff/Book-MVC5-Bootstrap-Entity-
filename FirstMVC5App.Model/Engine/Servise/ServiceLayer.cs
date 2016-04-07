using FirstMVC5App.Model.Engine.Repository.Interface;
using FirstMVC5App.Model.Engine.Servise.Interface;
using FirstMVC5App.Model.Engine.Servise.Logic;

namespace FirstMVC5App.Model.Engine.Servise
{
    public class ServiceLayer : Engine, IServiceLayer
    {
        public static IServiceLayer Instance(IServiceLayer serviceLayer)
        {
            serviceLayer.Get<IBookService>().SetRootService(serviceLayer);
            serviceLayer.Get<IHistoryService>().SetRootService(serviceLayer);
            return serviceLayer;
        }
        public ServiceLayer(IUnitOfWork unitOfWork)
        {
            Objects.Add(typeof(IBookService), new BookService(unitOfWork));
            Objects.Add(typeof(IHistoryService), new HistoryService(unitOfWork));
        }
    }
}