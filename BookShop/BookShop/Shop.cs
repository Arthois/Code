using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookClass;

namespace BookShop
{
    internal class Shop
    {
        private const int iMAXBOOKS = 10;

        private string sName;
        private int iBookCount;

        //Declaring refrence
        private Book[] bookList;


        public Shop(string psName)
        { 
            sName = psName;
            iBookCount = 0;
            bookList = new Book[iMAXBOOKS];
        }

        public String GetName()
        { 
            return sName;
        }

        public void SetName(String psName)
        {
            sName = psName;
        }

        public int GetMaxBooks()
        { 
            return iBookCount;
        }

        public bool AddBook(Book pBook)
        {
            if (iBookCount < iMAXBOOKS)
            {
                bookList[iBookCount] = pBook;
                iBookCount++;
                return true;
            }
            else
            { 
                return false;
            }
        }

        public Book GetBook(int piIndex)
        {
            if (piIndex < iBookCount)
            {
                return bookList[piIndex];
            }
            else
            {   
                return null;
            }
        }


    }
}
