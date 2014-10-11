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
            Bind<ILabelParser>().To<LabelParser>();
            Bind<IInstructionParser>().To<AddressInstructionParser>();
            Bind<IInstructionParser>().To<LabelInstructionParser>();
            Bind<IInstructionParser>().To<VariableInstructionParser>();
            Bind<IInstructionParser>().To<ComputeInstructionParser>();
            Bind<IComputeDestinationParser>().To<ComputeDestinationParser>();
            Bind<IComputeJumpParser>().To<ComputeJumpParser>();
        }
    }
}