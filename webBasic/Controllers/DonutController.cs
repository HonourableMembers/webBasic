using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webBasic.Models;


namespace webBasic.Controllers
{
    public class DonutController :Controller
    {
        public DonutController()
        {
            if (DonutOrderContext.donutOrders.Count<=0)
            {
                DonutOrderContext.donutOrders.Add(new DonutOrder(1, "Reece", 3, 2));
                DonutOrderContext.donutOrders.Add(new DonutOrder(2, "Zim", 80, 9));
                DonutOrderContext.donutOrders.Add(new DonutOrder(3, "Josh", 1, 1));
            }
        }
        public IActionResult Index()
        {
            ViewBag.Wrong = "10%";
            return View();
        }
        public IActionResult ShowDonut(int id)
        {
            try
            {
                DonutOrder donut = DonutOrderContext.donutOrders.Where(
                    d => d.OrderID == id).Single();
                return View();
            }
            catch(Exception e)
            {
                return RedirectToAction("Error", "Home");
            }
            
        }
        public IActionResult ShowAllDonuts()
        {
            return View(DonutOrderContext.donutOrders);
        }

        public IActionResult AddDonut()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDonut(int orderID, string name, int qtyDonuts, int qtyCoffee)
        {
            if (qtyDonuts>=1 && qtyCoffee>=1)
            {
                DonutOrderContext.donutOrders.Add(new DonutOrder(orderID, name, qtyDonuts, qtyCoffee));
                return RedirectToAction("ShowAllDonuts", "Donut");
            }
            else
            {
                ViewBag.Error = "Please enter in valid order amounts";
                return View();
            }
            
            
        }
    }
}
