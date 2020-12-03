using Bogus;
using ExpectedObjects;
using HotelTDD.Domain;
using HotelTDD.Utils;
using System;
using Xunit;

namespace HotelTest.TypeRoom
{
    public class TypeRoomTest
    {
        private readonly Faker _faker;

        public TypeRoomTest()
        {
            _faker = new Faker();
        }

        [Fact]
        public void ShouldCreateTypeRoom()
        {
            var roomExpected = new TypeRooms(_faker.Random.String(), Convert.ToDouble(_faker.Finance.Amount()));

            var room = new TypeRooms(roomExpected.Description, roomExpected.Value);

            roomExpected.ToExpectedObject().ShouldMatch(room);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNot_Create_With_Invalid_Description(string invalidDiscription)
        {
            Assert.Throws<DomainException>(() =>
                    TypeRoomBuilder.New().WithDescription(invalidDiscription).Build());
        }

        [Theory]
        [InlineData(0)]
        public void ShouldNot_Create_With_Invalid_Value(double value)
        {
            Assert.Throws<DomainException>(() =>
                    TypeRoomBuilder.New().WithValue(value).Build());
        }
    }
}
