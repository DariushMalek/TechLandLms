
using TechLandTools.Common;
using AutoMapper;
using TechLandTools.Common.Data;

namespace TechLandLms.Infrastructure.Data
{
    public class EfRepository<T> : EfRepositoryBase<T, ApplicationDbContext>
         where T : BaseEntity
    {

        public EfRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }


    }
}
