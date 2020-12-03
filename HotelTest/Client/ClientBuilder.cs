using Bogus;
using HotelTDD.Domain;
using System;

namespace HotelTest.Client
{
    public class ClientBuilder
    {
        protected int Id;
        protected string Name;
        protected string CPF;
        protected string Hash;

        public static ClientBuilder New()
        {
            var _faker = new Faker();

            return new ClientBuilder
            {
                Name = _faker.Random.String(),
                CPF = _faker.Random.String(),
                Hash = _faker.Random.Hash(),
            };
        }

        public ClientBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        public ClientBuilder WithCPF(string cpf)
        {
            CPF = cpf;
            return this;
        }

        public ClientBuilder WithHash(string hash)
        {
            Hash = hash;
            return this;
        }

        public Clients Build()
        {
            var clients = new Clients(Name, CPF, Hash);

            var propertyInfo = clients.GetType().GetProperty("Id");
            propertyInfo.SetValue(clients, Convert.ChangeType(Id, propertyInfo.PropertyType), null);

            return clients;
        }
    }
}
