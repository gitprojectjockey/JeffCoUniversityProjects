namespace JeffCoUniversity.Common.DTOAssemblers
{
    public abstract class DTOAssembler<TDto,TEntity>
    {
        public  abstract TDto AssembleDTO(TEntity source);
    }
}
