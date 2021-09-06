using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testholger
{
    public class Posts
    {
        public int PostsId { get; set; } //Foreign Key i databasen

        public Users user { get; set; } //Foreign key i databasen

        public string Author { get; set; }

        public string Comment { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? DeletedAt { get; set; } //När en Post blir raderad försvinner den inte från databasen utan får en DeletedAt, för att admin eller lik ska alltid kunna se alla Post som har gjorts

        public Topics Topic { get; set; }

        public int PostLikes { get; set; } = 0; 
    }
}
