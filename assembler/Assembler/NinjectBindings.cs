using Assembler.Binary;
using Assembler.Parsing;
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
            Bind<IWhitespaceRemover>().To<WhitespaceRemover>();
            Bind<ICommentRemover>().To<CommentRemover>();
            Bind<ILineParser>().To<LineParser>();
        }
    }
}