using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace depoTakip
{
    class sifreleme
    {

        public static string sifre(string text, int key)
        {
            char[] x = text.ToCharArray();//sezar şifrelemesi uygulandı
            string cryptText = null;
            foreach (char item in x)
            {
                cryptText += Convert.ToChar(item + key);
            }
            return cryptText;
        }

        public static string sifreCöz(string text, int key)
        {
            char[] x = text.ToCharArray();
            string decrypttext = null;
            foreach (char item in x)
            {
                decrypttext += Convert.ToChar(item - key);
            }
            return decrypttext;

        }



    }
}
