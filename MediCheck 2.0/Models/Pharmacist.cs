namespace MediCheck_2._0.Models
{
    public class Pharmacist
    {
        //variable declaration
        public string Id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string contact_number { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        //empty declaration
        public Pharmacist()
        {
            this.Id = "No ID";
            this.name = "No name";
            this.surname = "No surname";
            this.contact_number = "No contact number";
            this.username = "username";
            this.password = "password";
        }

        //populated declaration with all details
        public Pharmacist(string id, string name, string surname, string contact_number)
        {
            Id = id;
            this.name = name;
            this.surname = surname;
            this.contact_number = contact_number;
        }

        //contructor with farmer username and password
        public Pharmacist(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public Pharmacist(string id, string name, string surname, string contact_number, string username, string password) : this(id, name, surname, contact_number)
        {
            this.username = username;
            this.password = password;
        }
    }
}
