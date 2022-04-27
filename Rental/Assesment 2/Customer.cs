using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment_2
{
    public class Customer
    {
        public String sFirstName;
        public String sSurName;
        public String sFullName;
        public String sAddress;
        public int iAge;
        public String sLicense;
        public DateTime dtBirthday;

        public Customer()
        {
            sFirstName = "Not Set";
            sSurName = "Not Set";
            sFullName = "Not Set";
            sAddress = "Not Set";
            iAge = 0;
            sLicense = "Not Set";
            dtBirthday = DateTime.Now;
        }

        public Customer(String psFirstName, String psSurName, String psAddress, int piAge, String psLicense, DateTime pdtBirthday)
        { 
            sFirstName = psFirstName;
            sSurName = psSurName;
            sFullName = $"{sFirstName} {sSurName}";
            sAddress = psAddress;
            iAge = piAge;
            sLicense = psLicense;
            dtBirthday = pdtBirthday;

        }

        public void SetBirthday(DateTime pdtBirthday)
        { 
            dtBirthday = pdtBirthday;
        }

        public DateTime GetBirthday()
        { 
            return dtBirthday;
        }

        public String GetFirstName()
        { 
            return sFirstName;
        }

        public void SetFirstName(String psName)
        { 
            sFirstName = psName;
        }

        public String GetSurName()
        {
            return sSurName;
        }

        public void SetSurName(String psSurName)
        { 
            sSurName = psSurName;
        }

        public void SetFullName(String psFirstName, String psSurName)
        {
            sFullName = $"{psFirstName} {psSurName}";
        }

        public String GetFullName()
        {
            return sFullName;
        }

        public void SetAddress(String psAddress)
        { 
            sAddress = psAddress;
        }

        public String GetAddress()
        {
            return sAddress;
        }

        public void SetAge(int piAge)
        { 
            iAge = piAge;
        }

        public int GetAge()
        { 
            return iAge;
        }

        public void SetLicense(String psLicense)
        {
            sLicense = psLicense;
        }

        public String GetLicense()
        {
            return sLicense;
        }
    }
}
