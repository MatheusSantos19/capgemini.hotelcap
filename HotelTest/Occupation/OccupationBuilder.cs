using Bogus;
using HotelTDD.Domain;
using System;

namespace HotelTest.Occupation
{
    public class OccupationBuilder
    {
        protected int Id;
        protected int DailyAmount;
        protected DateTime Date;
        protected int ClientId;
        protected int RoomId;

        public static OccupationBuilder New()
        {
            var faker = new Faker();

            return new OccupationBuilder
            {
                DailyAmount = faker.Random.Int(),
                Date = DateTime.Now,
                ClientId = faker.Random.Int(),
                RoomId = faker.Random.Int()
            };
        }

        public OccupationBuilder WithDailyAmount(int dailyAmount)
        {
            DailyAmount = dailyAmount;
            return this;
        }

        public OccupationBuilder WithDate(DateTime date)
        {
            Date = date;
            return this;
        }

        public OccupationBuilder WithClientId(int clientId)
        {
            clientId = clientId;
            return this;
        }

        public OccupationBuilder WithRoomId(int roomId)
        {
            RoomId = roomId;
            return this;
        }

        public Occupations Build()
        {
            var occupations = new Occupations(DailyAmount, Date, ClientId, RoomId);

            var propertyInfo = occupations.GetType().GetProperty("Id");
            propertyInfo.SetValue(occupations, Convert.ChangeType(Id, propertyInfo.PropertyType), null);

            return occupations;
        }
    }
}
