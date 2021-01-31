using System;

namespace GradesBook
{
    public class NamedObject
    {
        private string name;

        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    name = value;
                }
                else
                {
                    throw new Exception("Name is empty");
                }
            }
        }
    }
}