using JeffCoUniversity.Data.Core.UnitOfWork;
using Ninject.Modules;


namespace JeffCoUniversity.Common.Bindings
{
    public class ServiceDependencyBindingModule : NinjectModule
    {
        //NInject accross all 3 layers, 
        //without the TopLayer (JeffcO.API) knowing about the Buttom layer (JeffCo.Data) layer.
        //This means there will be no reference between the TopLayer (JeffcO.API)  and the BottomLayer (JeffCo.Data).
        //The only way JeffcO.API can talk to JeffcO.Data is through JeffCo.Service layer :>

        public override void Load()
        { 
            Bind<IUnitOfWork>().To<UnitOfWork>().InTransientScope();
        }
    }
}
