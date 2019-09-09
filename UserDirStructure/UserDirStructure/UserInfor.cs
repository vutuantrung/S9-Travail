using System;
using System.Collections.Generic;
using System.Text;

namespace UserDirStructure
{
    public class UserInfor
    {
        string _name;
        string _lastname;
        int _age;


        public string FirstName
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException("Invalid First name.", nameof(value));
                _name = value;
            }
        }

        public string LastName
        {
            get { return _lastname; }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException("Invalid Last name.", nameof(value));
                _lastname = value;
            }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 0) throw new ArgumentException("Invalid Age.", nameof(value));
                _age = value;
            }
        }

        public UserType UserType { get; set; }
    }
}
