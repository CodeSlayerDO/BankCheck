using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BankCheck.Web.Models;
using BankCheck.Web.Utils;


namespace BankCheck.Web.Controllers
{
    public class BankCheckController : Controller
    {

        
        public ActionResult Index() 
        {


            return View();
        
        }



        public ActionResult PrintCheck(BankCheckModel model) 
        {

            NumberConverter converter = new NumberConverter();

            var stringAmount = converter.turnString(model.Amount.ToString(),model.Currency);

            model.StringAmount = stringAmount;
           

            return View(model);
        }









    }
}