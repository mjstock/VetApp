using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetApp
{

    [Serializable]
    public class Customer
    {

        private string petName;
        private string lastName;
        private string firstName;
        private string phoneNumber;
        private string appColor;
        private string petNotes;
        /// <summary>
        /// Customer class constructor required for xml serializ
        /// </summary>
        public Customer()
        {
            PetName = "";
            LastName = "";
            FirstName = "";
            PhoneNumber = "";
            appColor = "Transparent";
            PetNotes = "";
        }
     

        public string PetName
        {
            get { return petName; }
            set { petName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value;}
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }  
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string AppColor
        {
            get { return appColor; }
            set { appColor = value; }
        }

        public string PetNotes
        {
            get { return petNotes; }
            set { petNotes = value; }
        }

     
    }
}
