using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClass
{
    internal class Book
    {
        private String sTitle;
        private String sAuthor;
        private double dCost;
        private int iQuantity;

        public Book()
        {
            sTitle = "Not set";
            sAuthor = "Not set";
            dCost = 0;
            iQuantity = 0;
        }

        public Book(String psTitle, String psAuthor, double pdCost, int piQuantity)
        { 
            sTitle = psTitle;
            sAuthor = psAuthor;
            dCost = pdCost;
            iQuantity = piQuantity;
        }

        public override string ToString()
        {
            return $"{sTitle} by {sAuthor}";
        }

        public String GetTitle()
        { 
            return sTitle;
        }

        public void SetTitle(String psTitle)
        {
            sTitle = psTitle;
        }

        public String GetAuthor()
        {
            return sAuthor;
        }

        public void SetAuthor(String psAuthor)
        { 
            sAuthor = psAuthor;
        }

        public double GetCost()
        { 
            return dCost;
        }

        public void SetCost(double pdCost)
        { 
            dCost = pdCost;
        }

        public int GetQuantity()
        { 
            return iQuantity;
        }

        public void SetQuantity(int piQuantity)
        { 
            iQuantity = piQuantity;
        }

        public double SalesPrice()
        {
            return dCost * 1.25;
        }


    }
}
