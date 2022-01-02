namespace Ceremonies.Events.UnitTest
{
    public class EventsControllerTest
    {

        #region Fields
        public static readonly object[][] CorrectData =
       {
           new object[]{
               "",new DateTime(2010,1,1), new DateTime(2010, 1, 1),
          },
        };

        public static readonly object[][] InCorrectDate =
        {
            new object[]{"a",null, new DateTime(2010, 1, 1) },
            new object[]{ "a", new DateTime(2010, 1, 1),null }

        };
        #endregion

        [Fact]
        public async Task CreateEvent_ThrowNullException()
        {
            //Arrange
            var dbContextMock = new Mock<IApplicationDbContext>();
            var mapperMock = new Mock<IMapper>();

            //Act
            var handler = new CreateOccasionsCommandHandler(dbContextMock.Object, mapperMock.Object);

            //Assert
            await Assert.ThrowsAnyAsync<ArgumentNullException>(() => handler.Handle(null, CancellationToken.None));
        }

        [Fact]
        public async Task CreateEvent_MediatorCalled()
        {
            //Arrange
            var mediatorMock = new Mock<IMediator>();
            OccasionController occasionController = new(mediatorMock.Object);

            //Act
            await occasionController.CreateOccasion(new CreateOccasionsCommand(),CancellationToken.None);

            //Assert
            mediatorMock.Verify(x=>x.Send(It.IsAny<CreateOccasionsCommand>(), CancellationToken.None));
        }

        [Theory]
        [MemberData(nameof(CorrectData))]
        public async Task GetOccasionByCity_ThrowNullException(string city,DateTime startDate,DateTime endDate )
        {
            //Arrange
            var mediatorMock = new Mock<IMediator>();
            OccasionController occasionController = new(mediatorMock.Object);

            //Act
           
            //Assert
            await Assert.ThrowsAsync<System.ArgumentException>(()=> occasionController.GetAllCityOccasions(city, startDate,
                endDate, CancellationToken.None));
        }

       [Theory]
       [MemberData(nameof(InCorrectDate))]
        public async Task GetOccasionByCity_ThrowOutOfRangeStandAndEndDate(string city, DateTime startDate, DateTime endDate)
        {
            //Arrange
            var mediatorMock = new Mock<IMediator>();
            OccasionController occasionController = new(mediatorMock.Object);

            //Act

            //Assert
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => occasionController.GetAllCityOccasions(city, startDate, endDate,
                CancellationToken.None));
        }

        [Fact]
        public async Task GetOccasionByCity_MediatorWasCalled()
        {
            //Arrange
            var mediatorMock = new Mock<IMediator>();
            OccasionController occasionController = new(mediatorMock.Object);

            //Act
            await occasionController.GetAllCityOccasions("a",DateTime.Now,DateTime.Now, CancellationToken.None);

            //Assert
            mediatorMock.Verify(x => x.Send(It.IsAny<GetOccasionsQuery>(), CancellationToken.None));
        }
    }
}