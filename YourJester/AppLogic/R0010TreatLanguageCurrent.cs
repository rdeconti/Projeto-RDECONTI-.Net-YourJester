using System.Web;

/// <summary>
/// *********************************************************************************************************************
/// Copyright©: 	2015 YourJester Company. All rights reserved.
/// *********************************************************************************************************************
/// Creation:	    June 2015
/// Author:	    	Rosemeire Deconti
/// Goal:           Get the current culture and set the language parameter to be used in database reading routines
///                 and resources settings to be used in the screens. The allowed languages are:        
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
    class R0010TreatLanguageCurrent
    {
        public void Routine0010TreatLanguageCurrent(string userCulture)
        {
            string userLanguage = userCulture.Substring(0, 2);

            HttpContext.Current.Session["sessionUserCulture"] = userCulture;

            switch (userLanguage)
            {
                case "pt":
                    HttpContext.Current.Session["sessionUserLanguage"] = "POR";
                    break;
                case "es":
                    HttpContext.Current.Session["sessionUserLanguage"] = "SPA";
                    break;
                case "en":
                    HttpContext.Current.Session["sessionUserLanguage"] = "ENG";
                    break;
                case "fr":
                    HttpContext.Current.Session["sessionUserLanguage"] = "FRA";
                    break;
                case "de":
                    HttpContext.Current.Session["sessionUserLanguage"] = "ALE";
                    break;
                case "ar":
                    HttpContext.Current.Session["sessionUserLanguage"] = "ARA";
                    break;
                case "ja":
                    HttpContext.Current.Session["sessionUserLanguage"] = "JAP";
                    break;
                case "zh":
                    HttpContext.Current.Session["sessionUserLanguage"] = "CHI";
                    break;
                case "it":
                    HttpContext.Current.Session["sessionUserLanguage"] = "ITA";
                    break;
                default:
                    HttpContext.Current.Session["sessionUserLanguage"] = "ENG";
                    break;
            }
        }
    }
}
