using Assembler.Binary;
using Assembler.Sanitising;
using Ninject.Modules;

namespace Assembler
{
    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IAssembler>().To<HackAssembler>();
            Bind<ISanitiser>().To<Sanitiser>();
        }
    }
}