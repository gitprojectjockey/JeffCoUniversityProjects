namespace JeffCoUniversity.Common.EntityAssemblers
{
    public abstract class EntityAssembler<TEntity, TDto>
    {
        public abstract TEntity AssembleEntity(TDto source);
    }
}
