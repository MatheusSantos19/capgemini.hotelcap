using AutoFixture;
using Bogus;
using ExpectedObjects;
using HotelTDD.Domain;
using HotelTDD.Domain.Interface;
using HotelTDD.Services.Interface;
using HotelTest.Room.Room;
using NSubstitute;
using System.Collections.Generic;
using Xunit;

namespace HotelTest.Room
{
    public class RoomTest
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IRoomService _roomService;
        private readonly Faker _faker;
        private readonly Fixture _fixture = new Fixture();
        private readonly List<Rooms> _list;
        private readonly Rooms _rooms;


        public RoomTest()
        {
            _roomRepository = Substitute.For<IRoomRepository>();
            _rooms = _fixture.Create<Rooms>();
            _faker = new Faker();
            _list = _fixture.Create<List<Rooms>>();
            _roomService = Substitute.For<IRoomService>();
        }

        [Fact]
        public void ShouldCreateRoom()
        {
            var roomExpected = new Rooms(_faker.Random.Int(), _faker.Random.Int(), "A", _faker.Random.Int());
           

            var room = new Rooms(roomExpected.BuildingFloor, roomExpected.RoomNum, roomExpected.Situation, roomExpected.TypeRoomId);

            roomExpected.ToExpectedObject().ShouldMatch(room);
        }

        [Fact]
        public void Should_Update_SituationRoom()
        {
            var newDescriptionExpected = _faker.Random.String(1);
            var room = RoomBuilder.New().Build();
            
            room.ChangeSituation(newDescriptionExpected);

            Assert.Equal(newDescriptionExpected, room.Situation);
        }
    }
}
