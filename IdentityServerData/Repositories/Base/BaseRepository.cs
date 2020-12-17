using IdentityServerData.Context;

namespace IdentityServerData.Repositories.Base
{
    public abstract class BaseRepository
    {
        protected ResourceDbContext Context { get; }

        protected BaseRepository(ResourceDbContext context)
        {
            Context = context;
        }
    }
}
