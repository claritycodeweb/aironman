using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;
using System.Web;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace AIronMan.Utility
{
    public class AppUtil
    {

        public static bool ValidateParameter(ref string param, bool checkForNull, bool checkIfEmpty, bool checkForCommas, int maxSize)
        {
            if (param == null)
            {
                return !checkForNull;
            }

            param = param.Trim();
            if ((checkIfEmpty && param.Length < 1) ||
                 (maxSize > 0 && param.Length > maxSize) ||
                 (checkForCommas && param.Contains(",")))
            {
                return false;
            }

            return true;
        }

        public static bool ValidateParameter(string param, bool checkForNull, bool checkIfEmpty, bool checkForCommas, int maxSize)
        {
            if (param == null)
            {
                return !checkForNull;
            }

            param = param.Trim();
            if ((checkIfEmpty && param.Length < 1) ||
                 (maxSize > 0 && param.Length > maxSize) ||
                 (checkForCommas && param.Contains(",")))
            {
                return false;
            }

            return true;
        }

        public static void CheckParameter(ref string param, bool checkForNull, bool checkIfEmpty, bool checkForCommas, int maxSize, string paramName)
        {
            if (param == null)
            {
                if (checkForNull)
                {
                    throw new ArgumentNullException(paramName);
                }

                return;
            }

            param = param.Trim();
            if (checkIfEmpty && param.Length < 1)
            {
                throw new ArgumentException("The parameter " + paramName + " must not be empty.");
            }

            if (maxSize > 0 && param.Length > maxSize)
            {
                throw new ArgumentException("The parameter " + paramName + " is too long: it must not exceed " + maxSize.ToString(CultureInfo.InvariantCulture) + " chars in length.");
            }

            if (checkForCommas && param.Contains(","))
            {
                throw new ArgumentException("The parameter " + paramName + " must not contain commas.");
            }
        }

        public static string GetString(string strString, string param1)
        {
            return string.Format(strString, param1);
        }

        public static Int32? ParseIntToNull(string value)
        {
            int val;
            return int.TryParse(value, out val) ? (int?)val : null;
        }

        public static DateTime? ParseDateTimeToNull(string value)
        {
            DateTime date;
            return DateTime.TryParse(value, out date) ? (DateTime?)date : null;
        }

        public static Char? ParseCharToNull(string value)
        {
            Char val;
            return Char.TryParse(value, out val) ? (Char?)val : null;
        }

        public static Int32? ParseInt32ToNull(string value)
        {
            Int32 val;
            return Int32.TryParse(value, out val) ? (Int32?)val : null;
        }

        public static object ToDBNull(object value)
        {
            if (null != value)
                return value;
            return DBNull.Value;
        }

        public static void RestartApplication()
        {
            File.SetLastWriteTime(HttpContext.Current.Request.MapPath("~\\Web.config"), System.DateTime.Now);
        }

        public static string Truncate(string input, int length)
        {
            if (String.IsNullOrEmpty(input)) return "";

            if (input.Length < length) return input;
            int index = input.IndexOf(' ', length);
            return input.Substring(0, length - 1) + "...";
        }

        public static string TruncateEnd(string input, int length)
        {
            if (String.IsNullOrEmpty(input)) return "";
            if (input.Length < length) return input;
            return "..." + input.Substring(input.Length - length);
        }

        const string HTML_TAG_PATTERN = "<.*?>";

        public static string StripHTML(string input)
        {
            if (String.IsNullOrEmpty(input)) return "";
            return Regex.Replace
              (input, HTML_TAG_PATTERN, string.Empty);
        }

        public static string Encrypt(string str)
        {
            string _result = string.Empty;
            char[] temp = str.ToCharArray();
            foreach (var _singleChar in temp)
            {
                var i = (int)_singleChar;
                i = i - 2;
                _result += (char)i;
            }
            return _result;
        }
        public static string Decrypt(string str)
        {
            string _result = string.Empty;
            char[] temp = str.ToCharArray();
            foreach (var _singleChar in temp)
            {
                var i = (int)_singleChar;
                i = i + 2;
                _result += (char)i;
            }
            return _result;
        }

        public static string ReplaceFirst(string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos >= 0)
            {
                return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
            }
            return text;
        }

        public static string UppercaseFirst(string word)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(word))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(word[0]) + word.Substring(1);
        }
    }
}
