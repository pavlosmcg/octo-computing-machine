using Ninject.Modules;

namespace Assembler
{
    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IAssembler>().To<Assembler>();
            Bind<ISanitiser>().To<Sanitiser>();
        }
    }
}