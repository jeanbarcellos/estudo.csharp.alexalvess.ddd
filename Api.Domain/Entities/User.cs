using System;

namespace Api.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public string BirthDate { get; set; }

        public string Cpf { get; set; }
    }
}