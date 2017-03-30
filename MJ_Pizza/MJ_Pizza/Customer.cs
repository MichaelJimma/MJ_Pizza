using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJ_Pizza
{
    class Customer
    {
        private string customerName;
        private string phoneNumber;
        private string email;
        private string address;
        public Customer() {}

        public Customer(string custName,string phoneNo,string eml,string addrs)
        {
            this.customerName = custName;
            this.phoneNumber = phoneNo;
            this.email = eml;
            this.address = addrs;
        }

        public string CustomerName
        {
            get { return this.customerName; }
            set { this.customerName = value; }
        }
        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            set { this.phoneNumber = value; }
        }
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }
        public string Address
        {
            get { return this.address; }
            set { this.address = value; }
        }

        public override string ToString()
        {
            return string.Format("Customer Name: {0} \n Phone Number: {1} \n Email: {2} \n Address: {3}",this.customerName,this.phoneNumber,this.email,this.address);
        }
    }
}
