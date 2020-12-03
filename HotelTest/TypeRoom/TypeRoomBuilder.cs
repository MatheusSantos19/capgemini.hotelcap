using Bogus;
using HotelTDD.Domain;
using System;

namespace HotelTest.TypeRoom
{
    public class TypeRoomBuilder
    {
        protected int Id;
        protected string Description;
        protected double Value;

        public static TypeRoomBuilder New()
        {
            var faker = new Faker();

            return new TypeRoomBuilder
            {
                Description = faker.Random.String(),
                Value = faker.Random.Int(),
            };
        }

        public TypeRoomBuilder WithDescription(string description)
        {
            Description = description;
            return this;
        }

        public TypeRoomBuilder WithValue(double value)
        {
            Value = value;
            return this;
        }


        public TypeRooms Build()
        {
            var typeRoom = new TypeRooms(Description, Value);

            var propertyInfo = typeRoom.GetType().GetProperty("Id");
            propertyInfo.SetValue(typeRoom, Convert.ChangeType(Id, propertyInfo.PropertyType), null);

            return typeRoom;
        }
    }
}
