using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankCheck.Web.Utils
{
    public class NumberConverter
    {

        public List<String> numbersTill15;

        public NumberConverter() 
        {

            numbersTill15 = new List<string>()
            {
                "Cero","Uno","Dos","Tres","Cuatro","Cinco","Seis","Siete","Ocho","Nueve","Diez","Once","Doce","Trece","Catorce","Quince"
            };        
        
        }

        public string turnString(string num, string currency)
        {
            string result = String.Empty;
            string stringDecimal = "";
            

            Int64 integer;
            int decimales;
            double number;

            try
            {
                number = Convert.ToDouble(num);
            }
            catch
            {
                return "";
            }

            integer = Convert.ToInt64(Math.Truncate(number));
            decimales = Convert.ToInt32(Math.Round((number - integer) * 100, 2));
            if (decimales > 0)
            {
                stringDecimal = " CON " + decimales.ToString() + "CENTAVOS";
            }

          

            result = NumberLooper(Convert.ToDouble(integer)) + " " + currency + stringDecimal ;

            return result;
        }

        private string NumberLooper(double value)
        {
            

            string numbToText = "";
            value = Math.Truncate(value);

            if (value == 0 || value <= 15)
            {
                for (var i = 0; i <= 15; i++) 
                {

                    if (value == i)                     
                    {

                        numbToText = numbersTill15.ElementAt(i).ToUpper();
                    
                    } 
                }

            }
            else if (value < 20) numbToText = "DIECI" + NumberLooper(value - 10);
            else if (value == 20) numbToText = "VEINTE";
            else if (value < 30) numbToText = "VEINTI" + NumberLooper(value - 20);
            else if (value == 30) numbToText = "TREINTA";
            else if (value == 40) numbToText = "CUARENTA";
            else if (value == 50) numbToText = "CINCUENTA";
            else if (value == 60) numbToText = "SESENTA";
            else if (value == 70) numbToText = "SETENTA";
            else if (value == 80) numbToText = "OCHENTA";
            else if (value == 90) numbToText = "NOVENTA";
            else if (value < 100) numbToText = NumberLooper(Math.Truncate(value / 10) * 10) + " Y " + NumberLooper(value % 10);
            else if (value == 100) numbToText = "CIEN";
            else if (value < 200) numbToText = "CIENTO " + NumberLooper(value - 100);
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) numbToText = NumberLooper(Math.Truncate(value / 100)) + "CIENTOS";
            else if (value == 500) numbToText = "QUINIENTOS";
            else if (value == 700) numbToText = "SETECIENTOS";
            else if (value == 900) numbToText = "NOVECIENTOS";
            else if (value < 1000) numbToText = NumberLooper(Math.Truncate(value / 100) * 100) + " " + NumberLooper(value % 100);
            else if (value == 1000) numbToText = "MIL";
            else if (value < 2000) numbToText = "MIL " + NumberLooper(value % 1000);
            else if (value < 1000000)
            {
                numbToText = NumberLooper(Math.Truncate(value / 1000)) + " MIL";
                if ((value % 1000) > 0) numbToText = numbToText + " " + NumberLooper(value % 1000);
            }

            else if (value == 1000000) numbToText = "UN MILLON";
            else if (value < 2000000) numbToText = "UN MILLON " + NumberLooper(value % 1000000);
            else if (value < 1000000000000)
            {
                numbToText = NumberLooper(Math.Truncate(value / 1000000)) + " MILLONES ";
                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0) numbToText = numbToText + " " + NumberLooper(value - Math.Truncate(value / 1000000) * 1000000);
            }

            else if (value == 1000000000000) numbToText = "UN BILLON";
            else if (value < 2000000000000) numbToText = "UN BILLON " + NumberLooper(value - Math.Truncate(value / 1000000000000) * 1000000000000);

            else
            {
                numbToText = NumberLooper(Math.Truncate(value / 1000000000000)) + " BILLONES";
                if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0) numbToText = numbToText + " " + NumberLooper(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            }
            return numbToText;

        }      

    }
}