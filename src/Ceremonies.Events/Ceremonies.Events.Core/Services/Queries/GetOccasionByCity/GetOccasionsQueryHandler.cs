using Ceremonies.Events.Core.Interfaces.Repository;

namespace Ceremonies.Events.Core.Services.Queries.GetOccasionByCity
{
    public class GetOccasionsQueryHandler : IRequestHandler<GetOccasionsQuery, IEnumerable< OccasionDto>>
    {
        #region Fields
        private readonly IOccasionRepository _occasionRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public GetOccasionsQueryHandler(IOccasionRepository occasionRepository,IMapper mapper)
        {
            _occasionRepository = occasionRepository;
            _mapper = mapper;
        }

        #endregion

        #region Methods
        public async Task<IEnumerable< OccasionDto>> Handle(GetOccasionsQuery request, CancellationToken cancellationToken)
        {
           return await _occasionRepository.GetOccasions(request.City,request.StartDate,request.EndDate,cancellationToken)
                .ProjectTo<OccasionDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken: cancellationToken);
        }
        #endregion
    }
}
