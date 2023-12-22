using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang_Winform.DAO
{
    public class InvoiceDAO
    {

        private static InvoiceDAO instance;

        public static InvoiceDAO Instance
        {
            get { return instance ?? (instance = new InvoiceDAO()); }
            private set { instance = value; }
        }
        private InvoiceDAO() { }
    }
}
