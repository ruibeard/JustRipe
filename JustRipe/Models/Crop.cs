namespace JustRipe.Models
{
    public class Crop
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string _stage;

        public string Stage
        {
            get { return _stage; }
            set { _stage = value; }
        }

        private string _type;

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        private string _area;

        public string Area
        {
            get { return _area; }
            set { _area = value; }
        }
        private int _numContainers;

        public int NumContainers
        {
            get { return _numContainers; }
            set { _numContainers = value; }
        }

    }
}