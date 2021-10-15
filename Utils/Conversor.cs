using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeine_DinDin_Backend.Utils
{
    public class Conversor
    {
        //convert string para base64
        static public string EncodeToBase64(string texto)
        {
            try
            {
                byte[] textoAsBytes = System.Text.Encoding.ASCII.GetBytes(texto);
                string resultado = System.Convert.ToBase64String(textoAsBytes);
                return resultado;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //converte de base64 para texto
        static public string DecodeFrom64(string dados)
        {
            try
            {
                byte[] dadosAsBytes = System.Convert.FromBase64String(dados);
                string resultado = System.Text.ASCIIEncoding.ASCII.GetString(dadosAsBytes);
                return resultado;
            }
            catch (Exception)
            {
                throw;
            }
        }
        static public byte[] DecodeFrom64ToBytes(string dados)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(dados);
                return bytes;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
