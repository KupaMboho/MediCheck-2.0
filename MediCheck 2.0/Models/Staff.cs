namespace MediCheck_2._0.Models
{
    public class Staff
    {
        //variable declaration
        public string username { get; set; }
        public string password { get; set; }
        public string emp_id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string phone { get; set; }

        //empty constructor
        public Staff()
        {
            this.username = "No username";
            this.password = "No password";
            this.emp_id = "No employee id";
            this.name = "No name";
            this.surname = "No surname";
            this.phone = "No phone";
        }

        //constructor with all details except the username and passsword
        public Staff(string emp_id, string name, string surname, string phone)
        {
            this.emp_id = emp_id;
            this.name = name;
            this.surname = surname;
            this.phone = phone;
        }

        //constructor with username and password
        public Staff(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
