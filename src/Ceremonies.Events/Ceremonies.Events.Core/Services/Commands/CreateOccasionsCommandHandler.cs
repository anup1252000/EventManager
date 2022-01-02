namespace Ceremonies.Events.Core.Services.Commands
{
    public class CreateOccasionsCommandHandler : IRequestHandler<CreateOccasionsCommand>
    {
        #region Fields
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public CreateOccasionsCommandHandler(IApplicationDbContext applicationDbContext,IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }
        #endregion


        #region Methods
        public async Task<Unit> Handle(CreateOccasionsCommand request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return await Task.FromResult(Unit.Value);
            }

            Guard.Against.Null(request, nameof(CreateOccasionsCommand), "Request in the CreateOccasionsCommandHandler cannot be null");
            var occasion=_mapper.Map<Occasion>(request);
            await _applicationDbContext.Occasions.AddAsync(occasion, cancellationToken).ConfigureAwait(false);
            await _applicationDbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return await Task.FromResult(Unit.Value);
        }

        #endregion
    }
}
