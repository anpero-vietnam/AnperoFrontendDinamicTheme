using System.Text.RegularExpressions;

namespace Anpero.Ultil
{
    public static class StringHelper
    {
        public static string ToUrl(this string str)
        {
            str = RemoveUnicodeToEng(str);
            str = RemoveSpecialCharacters(str);
            return str.Replace(' ', '-').Replace(@"--", "-");

        }
        public static string RemoveSpecialCharacters(string str)
        {
            return string.IsNullOrEmpty(str) ? string.Empty : Regex.Replace(str, "[^a-zA-Z0-9 _.]+", "", RegexOptions.Compiled);
        }
        public static string RemoveUnicodeToEng(string s)
        {
            string retVal = string.Empty;
            int pos;
            if (!string.IsNullOrEmpty(s))
            {
                for (int i = 0; i < s.Length; i++)
                {
                    pos = uniChars.IndexOf(s[i].ToString());
                    if (pos >= 0)
                        retVal += KoDauChars[pos];
                    else
                        retVal += s[i];
                }
            }

            return retVal;
        }
        #region const
        public const string uniChars =
          "àáảãạâầấẩẫậăằắẳẵặèéẻẽẹêềếểễệđìíỉĩịòóỏõọôồốổỗộơờớởỡợùúủũụưừứửữựỳýỷỹỵÀÁẢÃẠÂẦẤẨẪẬĂẰẮẲẴẶÈÉẺẼẸÊỀẾỂỄỆĐÌÍỈĨỊÒÓỎÕỌÔỒỐỔỖỘƠỜỚỞỠỢÙÚỦŨỤƯỪỨỬỮỰỲÝỶỸỴÂĂĐÔƠƯ";

        public const string KoDauChars = "aaaaaaaaaaaaaaaaaeeeeeeeeeeediiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAAEEEEEEEEEEEDIIIIIOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYYAADOOU";
        #endregion
    }
}
