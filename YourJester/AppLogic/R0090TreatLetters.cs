using System.Linq;

/// <summary>
/// *********************************************************************************************************************
/// Copyright©: 	2015 YourJester Company. All rights reserved.
/// *********************************************************************************************************************
/// Creation:	    June 2015
/// Author:	    	Rosemeire Deconti
/// Goal:           Treat field value and check that it has at least one letter (upper or lower)
/// *********************************************************************************************************************
/// Maintenance:    dd/mm/yyyy
/// Author:	    	name
/// Goal:           inform the description of maintenance
/// *********************************************************************************************************************
/// </summary>

namespace YourJester.AppLogic
{
    public class R0090TreatLetters
    {
        public bool Routine0090TreatLetters(string fieldValue)
        {
            if (fieldValue.Any(c => char.IsUpper(c)))
            {
                return true;
            }
            if (fieldValue.Any(c => char.IsLower(c)))
            {
                return true;
            }
            return false;
        }
    }
}