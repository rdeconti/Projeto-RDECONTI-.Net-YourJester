using System.Web;

/// <summary>
/// *********************************************************************************************************************
/// Copyright©: 	2015 YourJester Company. All rights reserved.
/// *********************************************************************************************************************
/// Creation:	    June 2015
/// Author:	    	Rosemeire Deconti
/// Goal:           Get the language choosed by user and set the culture and the parameter to be used 
///                 in database reading routines and resources settings to be used in the screens. 
///                 The allowed languages are:
///                 1 menu_language.Items.Add("Portuguese"); 
///                 2 menu_language.Items.Add("Spanish");
///                 3 menu_language.Items.Add("English");
///                 4 menu_language.Items.Add("French");
///                 5 menu_language.Items.Add("German");
///                 6 menu_language.Items.Add("Arabic");
///                 7 menu_language.Items.Add("Japanes");
///                 8 menu_language.Items.Add("Chinese");
///                 9 menu_language.Items.Add("Italian");
/// *********************************************************************************************************************
/// Maintenance:    dd/mm/yyyy
/// Author:	    	name
/// Goal:           inform the description of maintenance
/// *********************************************************************************************************************
/// </summary>

namespace YourJester.AppLogic
{
    class R0020TreatLanguageUser 
    {
        public string userCulture;
       
        public string Routine0020TreatLanguageUser(string w_user_option)
        {
            switch (w_user_option)
            {
                case "1":
                    userCulture = "pt-BR";
                    HttpContext.Current.Session["sessionUserLanguage"] = "POR";
                    break;
                case "2":
                    userCulture = "es-ES";
                    HttpContext.Current.Session["sessionUserLanguage"] = "SPA";
                    break;
                case "3":
                    userCulture = "en-US";
                    HttpContext.Current.Session["sessionUserLanguage"] = "ENG";
                    break;
                case "4":
                    userCulture = "fr-FR";
                    HttpContext.Current.Session["sessionUserLanguage"] = "FRA";
                    break;
                case "5":
                    userCulture = "de-DE";
                    HttpContext.Current.Session["sessionUserLanguage"] = "ALE";
                    break;
                case "6":
                    userCulture = "ar-AR";
                    HttpContext.Current.Session["sessionUserLanguage"] = "ARA";
                    break;
                case "7":
                    userCulture = "ja-JA";
                    HttpContext.Current.Session["sessionUserLanguage"] = "JAP";
                    break;
                case "8":
                    userCulture = "zh-ZH";
                    HttpContext.Current.Session["sessionUserLanguage"] = "CHI";
                    break;
                case "9":
                    userCulture = "it-IT";
                    HttpContext.Current.Session["sessionUserLanguage"] = "ITA";
                    break;
                default:
                    userCulture = "en-US";
                    HttpContext.Current.Session["sessionUserLanguage"] = "ENG";
                    break;
            }

            HttpContext.Current.Session["sessionUserCulture"] = userCulture.ToString();
            return userCulture;
        }
    }
}