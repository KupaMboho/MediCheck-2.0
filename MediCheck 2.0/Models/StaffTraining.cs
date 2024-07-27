namespace MediCheck_2._0.Models
{
    public class StaffTraining
    {
        //variable declaration
        public int TRAINING_ID { get; set; }
        public string TRAINING_MATERIALS { get; set; }
        public bool COMPLETION_STATUS { get; set; }
        public string EMPLOYEE_ID { get; set; }

        //empty constructor
        public StaffTraining()
        {
            this.TRAINING_ID = 0;
            this.TRAINING_MATERIALS = "No training materials";
            this.COMPLETION_STATUS = false;
            this.EMPLOYEE_ID = "No employee id";
        }

        //populated constructor
        public StaffTraining(int tRAINING_ID, string tRAINING_MATERIALS, bool cOMPLETION_STATUS, string eMPLOYEE_ID)
        {
            TRAINING_ID = tRAINING_ID;
            TRAINING_MATERIALS = tRAINING_MATERIALS;
            COMPLETION_STATUS = cOMPLETION_STATUS;
            EMPLOYEE_ID = eMPLOYEE_ID;
        }
    }
}
