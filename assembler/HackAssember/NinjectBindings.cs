using Assembler;
using Assembler.Binary;
using Assembler.Binary.Hack;
using Assembler.Instructions;
using Assembler.Parsing;
using Assembler.Sanitising;
using Assembler.SymbolResolution;
using Assembler.SymbolResolution.Hack;
using Ninject.Modules;

namespace HackAssember
{
    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IAssembler>().To<Assembler.Assembler>();
            
            // input sanitising
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
            Bind<ISymbolParser>().To<SymbolParser>();
            Bind<IComputeDestinationParser>().To<ComputeDestinationParser>();
            Bind<IComputeJumpParser>().To<ComputeJumpParser>();

            // symbol resolution
            Bind<ISymbolResolver>().To<SymbolResolver>();

            // binary assembly
            Bind<IBinaryAssembler>().To<BinaryAssembler>();
            Bind<IInstructionVisitor<string[]>>().To<AssemblyInstructionVisitor>();

            // hack specific bindings
            Bind<IHackComputeBitsAssembler>().To<HackComputeBitsAssembler>();
            Bind<IInstructionAssembler<ComputeInstruction>>().To<HackComputeInstructionAssembler>();
            Bind<IInstructionAssembler<AddressInstruction>>().To<HackAddressInstructionAssembler>();
        }
    }
}