using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ListViewWPF
{
    [Serializable]
    public class ListView
    {
        private int id;
        private static int nextId;
        public int ID
        {
            get
            {
                return id;
            }
            set { }
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public int DateOfBirth
        {
            get
            {
                return GetDateOfBirth();
            }
            set { }
        }

        public ListView(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            nextId++;
            id = nextId;
        }

        public ListView()
        {

        }

        private int GetDateOfBirth()
        {
            return DateTime.Now.Year - this.Age;
        }
        
        public string Created
        {
            get
            {
                return DateTime.Now.ToString("dd-MM-yyyy");
            }
            set
            { }
        }
    }
}
