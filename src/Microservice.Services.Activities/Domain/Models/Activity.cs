using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice.Services.Activities.Domain.Models
{
    public class Activity
    {
        public Guid Id { get; protected set; }


        public string Category { get; protected set; }
        public Guid UserId { get; protected set; }
        public string Name { get; protected set; }
        public String Description { get; protected set; }
        public DateTime CreateAt  { get; protected set; }
        
        protected Activity()
        {

        }


        public Activity(Guid id, string category, Guid userId, string name , string description, DateTime createAt)
        {

            if(string.IsNullOrWhiteSpace(name))
                throw new Exception();



            Id = id;
            Category = category;
            UserId = userId;
            Name = name;
            Description = description;
            CreateAt = createAt;

        }


    }
}
