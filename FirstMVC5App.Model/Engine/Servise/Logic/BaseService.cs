using FirstMVC5App.Model.Engine.Servise.Interface;

namespace FirstMVC5App.Model.Engine.Servise.Logic
{
    public class BaseService : IBaseService
    {
        public IServiceLayer RootServiceLayer { get; set; }
        public void SetRootService(IServiceLayer serviceLayer)
        {
            RootServiceLayer = serviceLayer;
        }
    }
}
