using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ulib
{
    public static class Classes_Sistema
    {
        public static string mes_PorEscrito(this DateTime dt)
        {
            string mes = null;
            if (dt.Month.ToString().Equals("1"))
                mes = "Janeiro";
            else if (dt.Month.ToString().Equals("2"))
                mes = "Fevereiro";
            else if (dt.Month.ToString().Equals("3"))
                mes = "Março";
            else if (dt.Month.ToString().Equals("4"))
                mes = "Abril";
            else if (dt.Month.ToString().Equals("5"))
                mes = "Maio";
            else if (dt.Month.ToString().Equals("6"))
                mes = "Junho";
            else if (dt.Month.ToString().Equals("7"))
                mes = "Julho";
            else if (dt.Month.ToString().Equals("8"))
                mes = "Agosto";
            else if (dt.Month.ToString().Equals("9"))
                mes = "Setembro";
            else if (dt.Month.ToString().Equals("10"))
                mes = "Outubro";
            else if (dt.Month.ToString().Equals("11"))
                mes = "Novembro";
            else if (dt.Month.ToString().Equals("12"))
                mes = "Dezembro";
            return mes;
        }

    }
}
