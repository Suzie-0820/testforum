using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testholger
{
    public class Topics
    {
       public int TopicsId { get; set; }
        public string Title { get; set; }
        public Users User { get; set; } //Foreign key i databasen

        public string Author { get; set; }

        public string OriginalPost { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? DeletedAt { get; set; } //När en Post blir raderad försvinner den inte från databasen utan får en DeletedAt, för att admin eller lik ska alltid kunna se alla Post som har gjorts

        public Subjects TopicSubject { get; set; }

        public int NumberComments { get; set; } = 0;
    
    }
}
