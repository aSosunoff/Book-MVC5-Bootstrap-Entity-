using FirstMVC5App.Model.Business;
using FirstMVC5App.Model.Engine.Business;

namespace FirstMVC5App.Model.Engine.Servise.Logic
{
    public class BaseService
    {
        public readonly IBusinessLayer BusinessLayer;

        public BaseService(IBusinessLayer businessLayer)
        {
            BusinessLayer = businessLayer;
        }

        
    }
}
