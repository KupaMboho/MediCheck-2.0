namespace MediCheck_2._0.Models
{
    public class Administrator
    {
        //variable declaration
        public string username { get; set; }
        public string password { get; set; }

        //empty constructor
        public Administrator()
        {
            this.username = "No username";
            this.password = "No password";
        }

        //populated constructor
        public Administrator(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
