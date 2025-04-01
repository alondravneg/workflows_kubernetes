namespace workflow_kubernetes.Models
{
    public class Classmate
    {
        public Classmate(int classmateId, string name, string lastname, int age, string description) { 
            this.ClassmateId = classmateId;
            this.Name = name;
            this.LastName = lastname;
            this.Age = age;
            this.Description = description;
        }


        public int ClassmateId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }


    }
}
