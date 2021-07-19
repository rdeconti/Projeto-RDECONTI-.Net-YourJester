/// <summary>
/// *********************************************************************************************************************
/// Copyright©: 	2015 YourJester Company. All rights reserved.
/// *********************************************************************************************************************
/// Creation:	    June 2015
/// Author:	    	Rosemeire Deconti
/// Goal:           Treat field value and check that it does not have repeated characters (any kind of character)
/// *********************************************************************************************************************
/// Maintenance:    dd/mm/yyyy
/// Author:	    	name
/// Goal:           inform the description of maintenance
/// *********************************************************************************************************************
/// </summary>

namespace YourJester.AppLogic
{
    public class R0110TreatRepetition
    {
        public bool Routine0110TreatRepetition(string fieldValue)
        {
            var w_count_repetead = 0;
            var w_last_character = '\0';

            foreach (var c in fieldValue)
            {
                if (c == w_last_character)
                {
                    w_count_repetead++;
                }
                else
                {
                    w_count_repetead = 0;

                    if (w_count_repetead == 2)
                    {
                        return false;
                    }
                    else
                    {
                        w_last_character = c;
                    }
                }
            }
            return true;
        }
    }
}