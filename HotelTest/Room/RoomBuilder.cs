using Bogus;
using HotelTDD.Domain;
using System;

namespace HotelTest.Room.Room
{
    public class RoomBuilder
    {
        protected int Id;
        protected int BuildingFloor;
        protected int RoomNum;
        protected string Situation;
        protected int TypeRoomId;

        public static RoomBuilder New()
        {
            var faker = new Faker();

            return new RoomBuilder
            {
                BuildingFloor = faker.Random.Int(),
                RoomNum = faker.Random.Int(),
                Situation = "A",
                TypeRoomId = faker.Random.Int()
            };
        }

        public Rooms Build()
        {
            var room = new Rooms(BuildingFloor, RoomNum, Situation, TypeRoomId);

            var propertyInfo = room.GetType().GetProperty("Id");
            propertyInfo.SetValue(room, Convert.ChangeType(Id, propertyInfo.PropertyType), null);

            return room;
        }
    }
}
