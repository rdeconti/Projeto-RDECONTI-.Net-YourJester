using System.Linq;

/// <summary>
/// *********************************************************************************************************************
/// Copyright©: 	2015 YourJester Company. All rights reserved.
/// *********************************************************************************************************************
/// Creation:	    June 2015
/// Author:	    	Rosemeire Deconti
/// Goal:           Treat field value and check that it has at least one special character
/// *********************************************************************************************************************
/// Maintenance:    dd/mm/yyyy
/// Author:	    	name
/// Goal:           inform the description of maintenance
/// *********************************************************************************************************************
/// </summary>

namespace YourJester.AppLogic
{
    public class R0120TreatSpecials
    {
        public bool Routine0120TreatSpecials(string fieldValue)
        {
            if (!fieldValue.Any(c => char.IsSymbol(c)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}