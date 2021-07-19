/// <summary>
/// *********************************************************************************************************************
/// Copyright©: 	2015 YourJester Company. All rights reserved.
/// *********************************************************************************************************************
/// Creation:	    June 2015
/// Author:	    	Rosemeire Deconti
/// Goal:           Treat the length of a field that MUST have the value between a minimum and a maximun
/// *********************************************************************************************************************
/// Maintenance:    dd/mm/yyyy
/// Author:	    	name
/// Goal:           inform the description of maintenance
/// *********************************************************************************************************************
/// </summary>

namespace YourJester.AppLogic
{
    public class R0130TreatLength
    {
        public bool Routine0130TreatLength(string fieldValue, int fieldMinimum, int fieldMaximum)
        {
            if (fieldValue.Length < fieldMinimum || fieldValue.Length > fieldMaximum)
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