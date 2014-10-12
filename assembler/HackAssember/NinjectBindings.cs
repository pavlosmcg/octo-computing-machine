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

            // chain-of-responsibility of parsers [To<next>().WhenInjectedInto<previous>()]
            Bind<IInstructionParser>().To<ComputeInstructionParser>().WhenInjectedInto<Assembler.Assembler>();
            Bind<IInstructionParser>().To<VariableInstructionParser>().WhenInjectedInto<ComputeInstructionParser>();
            Bind<IInstructionParser>().To<AddressInstructionParser>().WhenInjectedInto<VariableInstructionParser>();
            Bind<IInstructionParser>().To<LabelInstructionParser>().WhenInjectedInto<AddressInstructionParser>();
            Bind<IInstructionParser>().To<UnknownInstructionParser>().WhenInjectedInto<LabelInstructionParser>();

            // helping classes for parsers
            Bind<ILabelParser>().To<LabelParser>();
            Bind<IComputeDestinationParser>().To<ComputeDestinationParser>();
            Bind<IComputeJumpParser>().To<ComputeJumpParser>();
        }
    }
}