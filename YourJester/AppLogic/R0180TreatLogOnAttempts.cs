namespace YourJester.AppLogic

/// <summary>
/// *********************************************************************************************************************
/// Copyright©: 	2015 YourJester Company. All rights reserved.
/// *********************************************************************************************************************
/// Creation:	    June 2015
/// Author:	    	Rosemeire Deconti
/// Goal:           Controls the number of failed LogOn attempts done by user
/// *********************************************************************************************************************
/// Maintenance:    dd/mm/yyyy
/// Author:	    	name
/// Goal:           inform the description of maintenance
/// *********************************************************************************************************************
/// </summary>
/// 
{
    public class R0180TreatLogOnAttempts
    {
        public bool Routine0180TreatLogOnAttempts(int logOnAttempt)
        {
            if (logOnAttempt > 3)
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