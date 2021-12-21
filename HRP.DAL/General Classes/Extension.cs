using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HRP.DAL.General_Classes
{
    public static class Extension
    {
        public enum Month
        {
            فروردین = 1,
            اردیبهشت = 2,
            خرداد = 3,
            تیر = 4,
            مرداد = 5,
            شهریور = 6,
            مهر = 7,
            آبان = 8,
            آذر = 9,
            دی = 10,
            بهمن = 11,
            اسفند = 12
        }
        /// <summary>
        /// تبدیل تاریخ شمسی به میلادی
        /// String Param
        /// </summary>
        /// <param name="persianDate"></param>
        /// <returns></returns>
        public static DateTime ToMiladyDate(this string persianDate)
        {
            try
            {
                if (persianDate.Length > 10)
                    persianDate = persianDate.Substring(0, 10);
                var date = persianDate.Split('/');

                System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                return pc.ToDateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2]), 0, 0, 0, 0);

            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message + "\n\u202Bتاریخ ارد شده صحیح نمی باشد");

            }
        }
        /// <summary>
        /// تبدیل تاریخ عدی شمسی به میلادی
        /// Int Param
        /// </summary>
        /// <param name="persianDate"></param>
        /// <returns></returns>
        public static DateTime ToMiladyDate(this int persianDate) => ToMiladyDate(ToPersianDate(persianDate));

        public static DateTime ToMiladyDate(this int persianDate, bool isBirthDate) => ToMiladyDate(ToPersianDate(persianDate, isBirthDate));
        /// <summary>
        /// تبدیل تاریخ میلادی به شمسی
        /// String Param
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToPersianDate(this DateTime date)
        {
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            if (date == null) return null;
            return (pc.GetYear(date).ToString("0000") + "/" + pc.GetMonth(date).ToString("00") + "/" + pc.GetDayOfMonth(date).ToString("00"));
        }
        /// <summary>
        /// تبدیل عدد صحیح به تاریخ شمسی
        /// Int Param
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToPersianDate(this int date, bool IsBirthDate)
        {
            if (date == 0) return null;
            if (date > 139801 && date < 149912)
            {
                if (byte.Parse(date.ToString().Substring(4, 2)) < 7)
                    date = date * 100 + 31;
                else if (byte.Parse(date.ToString().Substring(4, 2)) < 12)
                    date = date * 100 + 30;
                else
                    date = date * 100 + 29;
            }
            var strDate = date.ToString("000000");
            var year = short.Parse(strDate.Substring(0, 2));
            if (strDate.Length == 8)
                strDate = strDate.Substring(0, 4) + "/" + strDate.Substring(4, 2) + "/" + strDate.Substring(6, 2);
            else if (IsBirthDate)
                strDate = "13" + strDate.Substring(0, 2) + "/" + strDate.Substring(2, 2) + "/" + strDate.Substring(4, 2);
            if (year > 90 && year < 100 && !IsBirthDate)
                strDate = year.ToString("1300") + "/" + strDate.Substring(2, 2) + "/" + strDate.Substring(4, 2);
            if (year < 10 && IsBirthDate)
                strDate = year.ToString("1400") + "/" + strDate.Substring(2, 2) + "/" + strDate.Substring(4, 2);
            if (strDate.IsValidDate())
                return strDate;
            return "1300/01/01";
        }

        public static string ToPersianDate(this int date)
        {
            if (date > 139801 && date < 149912)
            {
                if (byte.Parse(date.ToString().Substring(4, 2)) < 7)
                    date = date * 100 + 31;
                else if (byte.Parse(date.ToString().Substring(4, 2)) < 12)
                    date = date * 100 + 30;
                else
                    date = date * 100 + 29;
            }
            var strDate = date.ToString("000000");
            var year = short.Parse(strDate.Substring(0, 2));
            if (strDate.Length == 8)
                strDate = strDate.Substring(0, 4) + "/" + strDate.Substring(4, 2) + "/" + strDate.Substring(6, 2);
            if (year > 90 && year < 100)
                strDate = year.ToString("1300") + "/" + strDate.Substring(2, 2) + "/" + strDate.Substring(4, 2);
            if (year < 10)
                strDate = year.ToString("1400") + "/" + strDate.Substring(2, 2) + "/" + strDate.Substring(4, 2);
            if (strDate.IsValidDate())
                return strDate;
            return "1300/01/01";
        }
        public static bool IsValidDate(this string date)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(date, @"^([1][3|4][0-9][0-9])[/]([0][1-9]|[1][012])[/]([0][1-9]|[1|2][0-9]|[3][01])$");
        }
        public static byte GetAge(this DateTime date1, DateTime date2)
        {
            byte age = 0;
            age = (byte)System.Math.Abs(date1.Year - date2.Year);
            if (date2 > date1.AddYears(age)) age--;
            return age;
        }
        public static bool IsValidNationalNumber(this long NationalNumber)
        {
            string Number = NationalNumber.ToString("0000000000");
            //رقم‌های کد ملی نباید یکسان باشد
            string[] allDigitEqual = new string[10] { "0000000000", "1111111111", "2222222222", "3333333333", "4444444444", "5555555555", "6666666666", "7777777777", "8888888888", "9999999999" };
            if (((IList) allDigitEqual).Contains(Number)) return false;
            //عملیات تشخیص صحت
            var chArray = Number.ToCharArray();
            var num1 = Convert.ToInt32(chArray[0].ToString()) * 10;
            var num2 = Convert.ToInt32(chArray[1].ToString()) * 9;
            var num3 = Convert.ToInt32(chArray[2].ToString()) * 8;
            var num4 = Convert.ToInt32(chArray[3].ToString()) * 7;
            var num5 = Convert.ToInt32(chArray[4].ToString()) * 6;
            var num6 = Convert.ToInt32(chArray[5].ToString()) * 5;
            var num7 = Convert.ToInt32(chArray[6].ToString()) * 4;
            var num8 = Convert.ToInt32(chArray[7].ToString()) * 3;
            var num9 = Convert.ToInt32(chArray[8].ToString()) * 2;
            var ControlCode = Convert.ToInt32(chArray[9].ToString());

            var remain = (num1 + num2 + num3 + num4 + num5 + num6 + num7 + num8 + num9) % 11;
            if ((remain < 2) && (ControlCode == remain)) return true;
            if ((remain >= 2) && ((11 - remain) == ControlCode)) return true;
            return false;
        }
        public static bool IsMobile(this long? mobile)
        {
            if (mobile == null) return false;
            if (mobile.ToString().Length < 10) return false;
            else return mobile.Value.ToString().StartsWith("9");
        }
        public static string GetPropertyList(this object obj)
        {
            string properties = "";
            var props = obj.GetType().GetProperties();
            foreach (var p in props)
            {
                properties = string.Join(p.GetValue(obj, null).ToString(), ",");
            }
            return properties;
        }

    }

}
