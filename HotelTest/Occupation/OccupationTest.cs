using Bogus;
using ExpectedObjects;
using HotelTDD.Domain;
using HotelTDD.Utils;
using System;
using Xunit;

namespace HotelTest.Occupation
{
    public class OccupationTest
    {
        private readonly Faker _faker;

        public OccupationTest()
        {
            _faker = new Faker();
        }

        [Fact]
        public void ShouldCreateRoom()
        {
            var occupationExpected = new Occupations(_faker.Random.Int(0, 600), DateTime.Now, _faker.Random.Int(0, 600), _faker.Random.Int(0, 600));

            var occupation = new Occupations(occupationExpected.DailyAmount, occupationExpected.Date, occupationExpected.ClientId, occupationExpected.RoomId);

            occupationExpected.ToExpectedObject().ShouldMatch(occupation);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void ShouldNot_Create_With_Invalid_DailyAmount(int dailyAmount)
        {
            Assert.Throws<DomainException>(() =>
                    OccupationBuilder.New().WithDailyAmount(dailyAmount).Build());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void ShouldNot_Create_With_Invalid_ClientId(int clientId)
        {
            Assert.Throws<DomainException>(() =>
                    OccupationBuilder.New().WithClientId(clientId).Build());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void ShouldNot_Create_With_Invalid_RoomId(int roomId)
        {
            Assert.Throws<DomainException>(() =>
                    OccupationBuilder.New().WithRoomId(roomId).Build());
        }
    }
}
