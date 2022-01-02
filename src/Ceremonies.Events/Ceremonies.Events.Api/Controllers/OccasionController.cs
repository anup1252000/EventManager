using Ardalis.GuardClauses;
using Ceremonies.Events.Core.Services.Queries.GetOccasionByCity;

namespace Ceremonies.Events.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccasionController : ApiController
    {

        #region fields
        private readonly IMediator _mediator;
        #endregion

        #region Constructor
        public OccasionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Method can be used to filter the events based on the city,start date and end date. 
        /// </summary>
        /// <param name="city"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<OccasionDto>>> GetAllCityOccasions([FromRoute]string city,[FromRoute] DateTime startDate,[FromRoute] DateTime endDate, CancellationToken cancellationToken)
        {
            Guard.Against.NullOrEmpty(city, nameof(city));
            Guard.Against.OutOfSQLDateRange(startDate, nameof(startDate));
            Guard.Against.OutOfSQLDateRange(endDate, nameof(endDate));
            var occasionRequest = new GetOccasionsQuery
            {
                City = city,
                StartDate = startDate,
                EndDate = endDate
            };
            var response=await _mediator.Send(occasionRequest,cancellationToken);
            return Ok(response);
        }

        /// <summary>
        /// Method can be used to create a new event.
        /// </summary>
        /// <param name="createOccasionsCommand"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("occasion/create")]
        public async Task<ActionResult<Unit>> CreateOccasion(CreateOccasionsCommand createOccasionsCommand,CancellationToken cancellationToken)
        {
            return await _mediator.Send(createOccasionsCommand,cancellationToken).ConfigureAwait(false);
        }
        #endregion
    }
}
