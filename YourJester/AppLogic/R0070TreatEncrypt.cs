using System;
using System.Security.Cryptography;

/// <summary>
/// *********************************************************************************************************************
/// Copyright©: 	2015 YourJester Company. All rights reserved.
/// *********************************************************************************************************************
/// Creation:	    June 2015
/// Author:	    	Rosemeire Deconti
/// Goal:           Return the value of a encrypted field value
/// *********************************************************************************************************************
/// Maintenance:    dd/mm/yyyy
/// Author:	    	name
/// Goal:           inform the description of maintenance
/// *********************************************************************************************************************
/// </summary>

namespace YourJester.AppLogic
{
    public class R0070TreatEncrypt
    {
        public string Routine0070TreatEncrypt(string toBeEncrypted, string haveBeenEncrypted)
        {
            byte[] results;

            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();

            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(toBeEncrypted));

            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            byte[] DataToEncrypt = UTF8.GetBytes(haveBeenEncrypted);
            
            ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
            results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);

            HashProvider.Dispose();
            TDESAlgorithm.Dispose();

            return Convert.ToBase64String(results);
        }
    }
}