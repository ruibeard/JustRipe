namespace JustRipe.Models
{
    public class Task
    {

        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                if (value > 0 )
                {
                    id = value;
                }
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string _taskDate;
        public string TaskDate
        {
            get { return _taskDate; }
            set { _taskDate = value; }
        }


        private int crop_id;
        public int CropId
        {
            get { return crop_id; }
            set { crop_id = value; }
        }

        private string _cropName;
        public string CropName
        {
            get { return _cropName; }
            set { _cropName = value; }
        }

        private int _user_id;
        public int UserId
        {
            get { return _user_id; }
            set { _user_id = value; }
        }
        private string _createdBy;
        public string CreatedBy
        {
            get { return _createdBy; }
            set { _createdBy = value; }
        }

        private string _type;
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        private int _labourNeeded;

        public int LabourNeeded
        {
            get { return _labourNeeded; }
            set { _labourNeeded = value; }
        }
    }
}