using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class BookCategoryHelper:SQLFunction
    {

        DataGridView dgv;
        string SQLName = "BookCategory";
        public int bookCategoryID { get; set; }
        public string bookCategoryName { get; set; }

        public BookCategoryHelper(DataGridView dgv,int bookCateID,string bookCateName)
        {
            this.dgv = dgv;
            this.bookCategoryID = bookCateID;
            this.bookCategoryName = " ,"+"'"+bookCateName+"'";
        }

        public BookCategoryHelper(int bookCateID, string bookCateName)
        {
            this.bookCategoryID = bookCateID;
            this.bookCategoryName = " ," + "'" + bookCateName + "'";
        }

        public void Update()
        {

        }

        public void Insert()
        {
            string str1 = "bookCategoryID ," + "bookCategoryName";
            string str2 = bookCategoryID + bookCategoryName;
            SQLFunction.Insert(str1, str2, SQLName);
        }

        
    }
}
