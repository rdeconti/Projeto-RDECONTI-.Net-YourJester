using System;

/// <summary>
/// *********************************************************************************************************************
/// Copyright©: 	2015 YourJester Company. All rights reserved.
/// *********************************************************************************************************************
/// Creation:	    June 2015
/// Author:	    	Rosemeire Deconti
/// Goal:           Get current date and return the value
/// *********************************************************************************************************************
/// Maintenance:    dd/mm/yyyy
/// Author:	    	name
/// Goal:           inform the description of maintenance
/// *********************************************************************************************************************
/// </summary>

namespace YourJester.AppLogic
{
    class R0050TreatDatetime
    {
        public string Routine0050TreatDatetime()
        {
            int w_year = DateTime.Now.Year;
            int w_month = DateTime.Now.Month;
            int w_day = DateTime.Now.Day;
            int w_hour = DateTime.Now.Hour;
            int w_minute = DateTime.Now.Minute;
            int w_second = DateTime.Now.Second;

            string currentDate = w_year + "-" + w_month + "-" + w_day + " " + w_hour + ":" + w_minute + ":" + w_second;
            return currentDate;
        }
    }
}
