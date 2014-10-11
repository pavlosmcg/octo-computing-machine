using Assembler;
using Assembler.Parsing;
using Assembler.Sanitising;
using Ninject.Modules;

namespace HackAssember
{
    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IAssembler>().To<Assembler.Assembler>();
            
            Bind<ISanitiser>().To<Sanitiser>();
            Bind<IWhitespaceRemover>().To<WhitespaceRemover>();
            Bind<ICommentRemover>().To<CommentRemover>();
            
            Bind<ILineParser>().To<LineParser>();
            Bind<IInstructionParser>().To<AddressInstructionParser>();
            Bind<IInstructionParser>().To<ComputeInstructionParser>();
            Bind<IInstructionParser>().To<LabelInstructionParser>();
            Bind<IComputeDestinationParser>().To<ComputeDestinationParser>();
            Bind<IComputeJumpParser>().To<ComputeJumpParser>();
        }
    }
}