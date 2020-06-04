using System;
using System.Text.RegularExpressions;
using System.Web;
using System.Configuration;
using System.Web.UI;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;

namespace Coeno.Common.Utility
{
    /// <summary>
    /// Collection of utility methods for DateTime tier
    /// </summary>
    public static class DateTimes {


        //*****日期数据约束性检查************
        //create:  wh_zhang
        //date:    2006/09/26
        //*******************************

        #region 日期数据约束性检查--

        /// <summary>
        /// Check the DateTime String Correctly.
        /// </summary>
        /// <param name="startDateTime">Start DateTime String</param>
        /// <param name="endDateTime">End DateTime String</param>
        /// <param name="invalidDay">Check Date.(-1:not check)</param>
        /// <returns></returns>
        public static string Chk_Invalid_DateTime(string startDateTime,string endDateTime,int invalidDay)
		{
			DateTime TempStartDateTime;
			DateTime TempEndDateTime;
           
            TempStartDateTime=Convert.ToDateTime(startDateTime);
			TempEndDateTime=Convert.ToDateTime(endDateTime);

			if (TempStartDateTime>TempEndDateTime)
			{
				return "Start date can not larger than end date!!!";
			}

			if (invalidDay!=-1)
			{
				if (TempStartDateTime.AddDays(invalidDay)<TempEndDateTime)
				{
					return "You can set the longer timespan!!!(limits:"+invalidDay.ToString()+")";
				}
			}

			//Return the result data
			return "1";
		}


		/// <summary>
		/// Check the DateTime String Correctly.
		/// </summary>
		/// <param name="startDateTime">Start DateTime</param>
		/// <param name="endDateTime">End DateTime</param>
		/// <param name="invalidDay">Check Date.(-1:not check)</param>
		/// <returns></returns>
		public static string Chk_Invalid_DateTime(DateTime startDateTime,DateTime endDateTime,int invalidDay)
		{
			if (startDateTime>endDateTime)
			{
				return "Start date can not larger than end date!!!";
			}

			if (invalidDay!=-1)
			{
				if (startDateTime.AddDays(invalidDay)<endDateTime)
				{
					return "You can set the longer timespan!!!(limits:"+invalidDay.ToString()+")";
				}
			}

			//Return the result data
			return "1";
		}

        /*检查日期控件值的约束性：不可为空，可以转换成DateTime类型*/
        public static void Chk_Invalid_DateTime(string v_DateID,out int v_ResultID,out string v_ResultMsg)
        {
            v_ResultID = 999;
            v_ResultMsg = "";
            if (string.IsNullOrWhiteSpace(v_DateID))
            {
                v_ResultMsg = "The date format is  Null Or WhiteSpace.";
                return;
            }
            if (v_DateID.Length != 10)
            {
                v_ResultMsg = "The date format is  error.";
                return;
            }
            DateTime chk_sdate;
            try
            {
                chk_sdate = Convert.ToDateTime(v_DateID);
            }
            catch
            {
                v_ResultMsg = "The date format is  error.";
                return;
            }
            v_ResultID = 0;
            v_ResultMsg = "The date format is OK.";
        }

        public static void Chk_Invalid_DateTime(string v_DateID)
        {
            if (string.IsNullOrWhiteSpace(v_DateID))
            {
                return;
            }
            if (v_DateID.Length != 10)
            {
                return;
            }
            DateTime chk_sdate;
            try
            {
                chk_sdate = Convert.ToDateTime(v_DateID);
            }
            catch
            {
                return;
            }
        }


        #endregion




    }
}