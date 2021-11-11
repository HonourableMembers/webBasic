using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webBasic.Models
{
    public class DonutOrder
    {
        public DonutOrder(int orderID ,string name, int qtyDonuts, int qtyCoffee)
        {
            OrderID = orderID;
            Name = name;
            QtyDonuts = qtyDonuts;
            QtyCoffee = qtyCoffee;
        }


        public int OrderID { get; set; }
        public string Name { get; set; }
        public int QtyDonuts { get; set; }
        public int QtyCoffee { get; set; }
    }
}
