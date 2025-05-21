using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JoseCarlos.Domain.Seguridad
{
    public static class Encriptacion
    {
        public static string ClaveSeguridad = "1234";
        public static string ClaveDefecto { get; set; }
        public static string Desencriptar(string textoEncriptado)
        {
            try
            {
                string key = ClaveSeguridad;

                byte[] keyArray;
                byte[] ArrayADescrifrar = Convert.FromBase64String(textoEncriptado);
                //Algoritmo que hace un hash de un conjunto de datos
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

                hashmd5.Clear();

                AesCryptoServiceProvider tdes = new AesCryptoServiceProvider();

                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateDecryptor();

                byte[] resultArray = cTransform.TransformFinalBlock(ArrayADescrifrar, 0, ArrayADescrifrar.Length);

                tdes.Clear();

                textoEncriptado = UTF8Encoding.UTF8.GetString(resultArray);
            }
            catch (Exception)
            {

            }
            return textoEncriptado;
        }
        public static string Encriptar(string texto)
        {
            try
            {
                string key = ClaveSeguridad;

                byte[] keyArray;
                byte[] ArregloADescifrar = UTF8Encoding.UTF8.GetBytes(texto);
                //Usamos la clave MD5 para generar la clave de 128 bits
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

                hashmd5.Clear();

                //Algoritmo TripleDES para encriptar el texto en base 64
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;
                //Cambiar a CreateEncryptor() para encriptar

                ICryptoTransform cTransform = tdes.CreateEncryptor();

                byte[] ArrayResultado = cTransform.TransformFinalBlock(ArregloADescifrar, 0, ArregloADescifrar.Length);

                tdes.Clear();

                return Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length).Trim();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}