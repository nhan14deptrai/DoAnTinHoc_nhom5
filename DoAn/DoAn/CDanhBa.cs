using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn
{
    public class CDanhBa
    {
        private string m_sdt;
        private string m_hoten;
        private string m_email;
        private string m_diachi;
        public string SDT
        {
            get { return m_sdt; }
            set { m_sdt = value; }
        }public string Hoten
        {
            get { return m_hoten; }
            set { m_hoten = value; }
        }public string Email
        {
            get { return m_email; } 
            set { m_email = value; }
        }public string Diachi
        {
            get { return m_diachi; }
            set { m_diachi = value; }
        }public CDanhBa()
        {
            m_sdt = "";
            m_hoten = "";
            m_email = "";
            m_diachi = "";
        }public CDanhBa(string Sdt,string Hoten, string Email,string Diachi)
        {
            m_sdt = Sdt;
            m_hoten = Hoten;
            m_email= Email;
            m_diachi = Diachi;
        }
    }
}
