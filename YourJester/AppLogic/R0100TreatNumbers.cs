using System.Linq;

/// <summary>
/// *********************************************************************************************************************
/// Copyright©: 	2015 YourJester Company. All rights reserved.
/// *********************************************************************************************************************
/// Creation:	    June 2015
/// Author:	    	Rosemeire Deconti
/// Goal:           Treat field value and check that it has at least one digit
/// *********************************************************************************************************************
/// Maintenance:    dd/mm/yyyy
/// Author:	    	name
/// Goal:           inform the description of maintenance
/// *********************************************************************************************************************
/// </summary>

namespace YourJester.AppLogic
{
    public class R0100TreatNumbers
    {
        public bool Routine0100TreatNumbers(string fieldValue)
        {
            if (!fieldValue.Any(c => char.IsDigit(c)))
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