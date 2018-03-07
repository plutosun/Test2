using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

    }

    #region 6.1
    class ICoreService
    {

    }
    class UserICoreService
    {
        public ICoreService CoreService
        {
            get;
            protected set;
        }
    }
    #endregion

    #region 6.2
    class Contact
    {

    }
    class UseContact
    {
        private Contact _FirstEmergencyContact;
        public Contact FirstEmergencyContact
        {
            get { return _FirstEmergencyContact; }
            set { SetProperty( _FirstEmergencyContact, value); }
        }
        private Contact _SecondEmergencyContact;
        public Contact SecondEmergencyContact
        {
            get { return _SecondEmergencyContact; }
            set { SetProperty( _FirstEmergencyContact, value); }
        }

       Contact SetProperty(Contact contact, object value) {
            return contact;
        }
    }
    
    #endregion


}
