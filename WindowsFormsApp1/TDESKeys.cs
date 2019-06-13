using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class TDESKeys
    {

        public List<string> TDES_Keys()
        {

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.GenerateKey();
            tdes.GenerateIV();

            byte[] TripleDESKey = tdes.Key;
            int size = 8;
            var array = new List<string>();


            for (var i = 0; i < (float)TripleDESKey.Length / size; i++)
            {
                array.Add(BitConverter.ToString(TripleDESKey.Skip(i * size).Take(size).ToArray()).Replace("-", string.Empty));
            }

            array.Add(BitConverter.ToString(tdes.IV).Replace("-", string.Empty));

            return array;
        }

    }
}       

            

