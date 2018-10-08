//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.IO;
//using System.IO.Compression;
//using System.Linq;
//using System.Security.Cryptography;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;

//namespace UtilLib
//{
//    /// <summary>
//    /// 扩展
//    /// </summary>
//    public static partial class Util
//    {
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <returns></returns>
//        public static string GetNewToken()
//        {
//            return GetRandomString(40);
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="path"></param>
//        /// <returns></returns>
//        public static string ToJTokenPath(this string path)
//        {
//            if (path.StartsWith("$"))
//                return path;

//            var sb = new StringBuilder();
//            var parts = path.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
//            for (int i = 0; i < parts.Length; i++)
//            {
//                if (Char.IsNumber(parts[i][0]))
//                    sb.Append("[").Append(parts[i]).Append("]");
//                else
//                {
//                    sb.Append(parts[i]);
//                }

//                if (i < parts.Length - 1 && !Char.IsNumber(parts[i + 1][0]))
//                    sb.Append(".");
//            }

//            return sb.ToString();
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="length"></param>
//        /// <param name="allowedChars"></param>
//        /// <returns></returns>
//        public static string GetRandomString(int length, string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789")
//        {
//            if (length < 0)
//                throw new ArgumentOutOfRangeException(nameof(length), "length cannot be less than zero.");

//            if (string.IsNullOrEmpty(allowedChars))
//                throw new ArgumentException("allowedChars may not be empty.");

//            const int byteSize = 0x100;
//            var allowedCharSet = new HashSet<char>(allowedChars).ToArray();
//            if (byteSize < allowedCharSet.Length)
//                throw new ArgumentException($"allowedChars may contain no more than {byteSize} characters.");

//            using (var rng = new RNGCryptoServiceProvider())
//            {
//                var result = new StringBuilder();
//                var buf = new byte[128];

//                while (result.Length < length)
//                {
//                    rng.GetBytes(buf);
//                    for (var i = 0; i < buf.Length && result.Length < length; ++i)
//                    {
//                        var outOfRangeStart = byteSize - (byteSize % allowedCharSet.Length);
//                        if (outOfRangeStart <= buf[i])
//                            continue;
//                        result.Append(allowedCharSet[buf[i] % allowedCharSet.Length]);
//                    }
//                }

//                return result.ToString();
//            }
//        }

//        private static readonly Regex _splitNameRegex = new Regex(@"[\W_]+");
//        private static readonly Regex _properWordRegex = new Regex(@"([A-Z][a-z]*)|([0-9]+)");
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="password"></param>
//        /// <param name="salt"></param>
//        /// <returns></returns>
//        public static string ToSaltedHash(this string password, string salt)
//        {
//            byte[] passwordBytes = Encoding.Unicode.GetBytes(password);
//            byte[] saltBytes = Convert.FromBase64String(salt);

//            var hashStrategy = HashAlgorithm.Create("HMACSHA256") as KeyedHashAlgorithm;
//            if (hashStrategy.Key.Length == saltBytes.Length)
//                hashStrategy.Key = saltBytes;
//            else if (hashStrategy.Key.Length < saltBytes.Length)
//            {
//                var keyBytes = new byte[hashStrategy.Key.Length];
//                Buffer.BlockCopy(saltBytes, 0, keyBytes, 0, keyBytes.Length);
//                hashStrategy.Key = keyBytes;
//            }
//            else
//            {
//                var keyBytes = new byte[hashStrategy.Key.Length];
//                for (int i = 0; i < keyBytes.Length;)
//                {
//                    int len = Math.Min(saltBytes.Length, keyBytes.Length - i);
//                    Buffer.BlockCopy(saltBytes, 0, keyBytes, i, len);
//                    i += len;
//                }
//                hashStrategy.Key = keyBytes;
//            }
//            byte[] result = hashStrategy.ComputeHash(passwordBytes);
//            return Convert.ToBase64String(result);
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="values"></param>
//        /// <param name="delimiter"></param>
//        /// <returns></returns>
//        public static string ToDelimitedString<T>(this IEnumerable<T> values, string delimiter)
//        {
//            var sb = new StringBuilder();
//            foreach (var i in values)
//            {
//                if (sb.Length > 0)
//                    sb.Append(delimiter);
//                sb.Append(i.ToString());
//            }

//            return sb.ToString();
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="values"></param>
//        /// <returns></returns>
//        public static string ToDelimitedString(this IEnumerable<string> values)
//        {
//            return ToDelimitedString(values, ",");
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="values"></param>
//        /// <param name="delimiter"></param>
//        /// <returns></returns>
//        public static string ToDelimitedString(this IEnumerable<string> values, string delimiter)
//        {
//            var sb = new StringBuilder();
//            foreach (var i in values)
//            {
//                if (sb.Length > 0)
//                    sb.Append(delimiter);
//                sb.Append(i);
//            }

//            return sb.ToString();
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="value"></param>
//        /// <returns></returns>
//        public static string ToLowerUnderscoredWords(this string value)
//        {
//            var builder = new StringBuilder(value.Length + 10);
//            for (int index = 0; index < value.Length; index++)
//            {
//                char c = value[index];
//                if (Char.IsUpper(c))
//                {
//                    if (index > 0 && value[index - 1] != '_')
//                        builder.Append('_');

//                    builder.Append(Char.ToLower(c));
//                }
//                else
//                {
//                    builder.Append(c);
//                }
//            }

//            return builder.ToString();
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="value"></param>
//        /// <param name="patternsToMatch"></param>
//        /// <param name="ignoreCase"></param>
//        /// <returns></returns>
//        public static bool AnyWildcardMatches(this string value, IEnumerable<string> patternsToMatch, bool ignoreCase = false)
//        {
//            if (ignoreCase)
//                value = value.ToLower();

//            return patternsToMatch.Any(pattern => CheckForMatch(pattern, value, ignoreCase));
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="pattern"></param>
//        /// <param name="value"></param>
//        /// <param name="ignoreCase"></param>
//        /// <returns></returns>
//        private static bool CheckForMatch(string pattern, string value, bool ignoreCase = true)
//        {
//            bool startsWithWildcard = pattern.StartsWith("*");
//            if (startsWithWildcard)
//                pattern = pattern.Substring(1);

//            bool endsWithWildcard = pattern.EndsWith("*");
//            if (endsWithWildcard)
//                pattern = pattern.Substring(0, pattern.Length - 1);

//            if (ignoreCase)
//                pattern = pattern.ToLower();

//            if (startsWithWildcard && endsWithWildcard)
//                return value.Contains(pattern);

//            if (startsWithWildcard)
//                return value.EndsWith(pattern);

//            if (endsWithWildcard)
//                return value.StartsWith(pattern);

//            return value.Equals(pattern);
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="values"></param>
//        /// <param name="stringSelector"></param>
//        /// <returns></returns>
//        public static string ToConcatenatedString<T>(this IEnumerable<T> values, Func<T, string> stringSelector)
//        {
//            return values.ToConcatenatedString(stringSelector, String.Empty);
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="values"></param>
//        /// <param name="action"></param>
//        /// <param name="separator"></param>
//        /// <returns></returns>
//        public static string ToConcatenatedString<T>(this IEnumerable<T> values, Func<T, string> action, string separator)
//        {
//            var sb = new StringBuilder();
//            foreach (var item in values)
//            {
//                if (sb.Length > 0)
//                    sb.Append(separator);

//                sb.Append(action(item));
//            }

//            return sb.ToString();
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="s"></param>
//        /// <returns></returns>
//        public static string DefaultAndNormalize(this string s)
//        {
//            if (String.IsNullOrEmpty(s))
//                return String.Empty;

//            return s.RemoveNonAlphaNumeric().ToLowerInvariant();
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="s"></param>
//        /// <returns></returns>
//        public static string RemoveNonNumeric(this string s)
//        {
//            return new string(Array.FindAll(s.ToCharArray(), Char.IsDigit));
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="s"></param>
//        /// <returns></returns>
//        public static string RemoveNonAlphaNumeric(this string s)
//        {
//            return new string(Array.FindAll(s.ToCharArray(), Char.IsLetterOrDigit));
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="s"></param>
//        /// <returns></returns>
//        public static string RemoveWhiteSpace(this string s)
//        {
//            return new string(Array.FindAll(s.ToCharArray(), c => !Char.IsWhiteSpace(c)));
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="s"></param>
//        /// <param name="find"></param>
//        /// <param name="replace"></param>
//        /// <returns></returns>
//        public static string ReplaceFirst(this string s, string find, string replace)
//        {
//            var i = s.IndexOf(find);
//            if (i >= 0)
//            {
//                var pre = s.Substring(0, i);
//                var post = s.Substring(i + find.Length);
//                return String.Concat(pre, replace, post);
//            }

//            return s;
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="text"></param>
//        /// <returns></returns>
//        public static IEnumerable<string> SplitLines(this string text)
//        {
//            return text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Where(l => !String.IsNullOrWhiteSpace(l)).Select(l => l.Trim());
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="s"></param>
//        /// <returns></returns>
//        public static string StripInvisible(this string s)
//        {
//            return s
//                .Replace("\r\n", " ")
//                .Replace('\n', ' ')
//                .Replace('\t', ' ');
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="text"></param>
//        /// <param name="lineEnding"></param>
//        /// <returns></returns>
//        public static string NormalizeLineEndings(this string text, string lineEnding = null)
//        {
//            if (String.IsNullOrEmpty(lineEnding))
//                lineEnding = Environment.NewLine;

//            text = text.Replace("\r\n", "\n");
//            if (lineEnding != "\n")
//                text = text.Replace("\r\n", lineEnding);

//            return text;
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="text"></param>
//        /// <param name="keep"></param>
//        /// <returns></returns>
//        public static string Truncate(this string text, int keep)
//        {
//            if (String.IsNullOrEmpty(text))
//                return String.Empty;

//            string buffer = NormalizeLineEndings(text);
//            if (buffer.Length <= keep)
//                return buffer;

//            return String.Concat(buffer.Substring(0, keep - 3), "...");
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="text"></param>
//        /// <param name="length"></param>
//        /// <param name="ellipsis"></param>
//        /// <param name="keepFullWordAtEnd"></param>
//        /// <returns></returns>
//        public static string Truncate(this string text, int length, string ellipsis, bool keepFullWordAtEnd)
//        {
//            if (String.IsNullOrEmpty(text))
//                return String.Empty;

//            if (text.Length < length)
//                return text;

//            text = text.Substring(0, length);

//            if (keepFullWordAtEnd && text.LastIndexOf(' ') > 0)
//                text = text.Substring(0, text.LastIndexOf(' '));

//            return $"{text}{ellipsis}";
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="value"></param>
//        /// <param name="charsToRemove"></param>
//        /// <returns></returns>
//        public static string ToLowerFiltered(this string value, char[] charsToRemove)
//        {
//            var builder = new StringBuilder(value.Length);

//            for (int index = 0; index < value.Length; index++)
//            {
//                char c = value[index];
//                if (Char.IsUpper(c))
//                    c = Char.ToLower(c);

//                bool includeChar = true;
//                for (int i = 0; i < charsToRemove.Length; i++)
//                {
//                    if (charsToRemove[i] == c)
//                    {
//                        includeChar = false;
//                        break;
//                    }
//                }

//                if (includeChar)
//                    builder.Append(c);
//            }

//            return builder.ToString();
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="s"></param>
//        /// <param name="separator"></param>
//        /// <returns></returns>
//        public static string[] SplitAndTrim(this string s, params string[] separator)
//        {
//            if (s.IsNullOrEmpty())
//                return new string[0];

//            var result = ((separator == null) || (separator.Length == 0))
//                ? s.Split((char[])null, StringSplitOptions.RemoveEmptyEntries)
//                : s.Split(separator, StringSplitOptions.RemoveEmptyEntries);

//            for (int i = 0; i < result.Length; i++)
//                result[i] = result[i].Trim();

//            return result;
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="s"></param>
//        /// <param name="separator"></param>
//        /// <returns></returns>
//        public static string[] SplitAndTrim(this string s, params char[] separator)
//        {
//            if (s.IsNullOrEmpty())
//                return new string[0];

//            var result = s.Split(separator, StringSplitOptions.RemoveEmptyEntries);
//            for (int i = 0; i < result.Length; i++)
//                result[i] = result[i].Trim();

//            return result;
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="value"></param>
//        /// <param name="anyCharOf"></param>
//        /// <returns></returns>
//        public static string HexEscape(this string value, params char[] anyCharOf)
//        {
//            if (string.IsNullOrEmpty(value)) return value;
//            if (anyCharOf == null || anyCharOf.Length == 0) return value;

//            var encodeCharMap = new HashSet<char>(anyCharOf);

//            var sb = new StringBuilder();
//            var textLength = value.Length;
//            for (var i = 0; i < textLength; i++)
//            {
//                var c = value[i];
//                if (encodeCharMap.Contains(c))
//                {
//                    sb.Append('%' + ((int)c).ToString("x"));
//                }
//                else
//                {
//                    sb.Append(c);
//                }
//            }
//            return sb.ToString();
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="hexstr"></param>
//        /// <returns></returns>
//        public static int HexToInt(string hexstr)
//        {
//            int num = 0;
//            hexstr = hexstr.ToUpper();
//            char[] chArray = hexstr.ToCharArray();
//            for (int index = chArray.Length - 1; index >= 0; --index)
//            {
//                if ((int)chArray[index] >= 48 && (int)chArray[index] <= 57)
//                    num += ((int)chArray[index] - 48) * (int)Math.Pow(16.0, (double)(chArray.Length - 1 - index));
//                else if ((int)chArray[index] >= 65 && (int)chArray[index] <= 70)
//                {
//                    num += ((int)chArray[index] - 55) * (int)Math.Pow(16.0, (double)(chArray.Length - 1 - index));
//                }
//                else
//                {
//                    num = 0;
//                    break;
//                }
//            }
//            return num;
//        }


//        /// <summary>
//        /// Converts a string to use camelCase.
//        /// </summary>
//        /// <param name="value">The value.</param>
//        /// <returns>The to camel case. </returns>
//        public static string ToCamelCase(this string value)
//        {
//            if (string.IsNullOrEmpty(value))
//                return value;

//            string output = ToPascalCase(value);
//            if (output.Length > 2)
//                return char.ToLower(output[0]) + output.Substring(1);

//            return output.ToLower();
//        }
//        /// <summary>
//        /// Converts a string to use PascalCase.
//        /// </summary>
//        /// <param name="value">Text to convert</param>
//        /// <returns>The string</returns>
//        public static string ToPascalCase(this string value)
//        {
//            return value.ToPascalCase(_splitNameRegex);
//        }

//        /// <summary>
//        /// Converts a string to use PascalCase.
//        /// </summary>
//        /// <param name="value">Text to convert</param>
//        /// <param name="splitRegex">Regular Expression to split words on.</param>
//        /// <returns>The string</returns>
//        public static string ToPascalCase(this string value, Regex splitRegex)
//        {
//            if (string.IsNullOrEmpty(value))
//                return value;

//            var mixedCase = value.IsMixedCase();
//            var names = splitRegex.Split(value);
//            var output = new StringBuilder();

//            if (names.Length > 1)
//            {
//                foreach (string name in names)
//                {
//                    if (name.Length > 1)
//                    {
//                        output.Append(char.ToUpper(name[0]));
//                        output.Append(mixedCase ? name.Substring(1) : name.Substring(1).ToLower());
//                    }
//                    else
//                    {
//                        output.Append(name);
//                    }
//                }
//            }
//            else if (value.Length > 1)
//            {
//                output.Append(char.ToUpper(value[0]));
//                output.Append(mixedCase ? value.Substring(1) : value.Substring(1).ToLower());
//            }
//            else
//            {
//                output.Append(value.ToUpper());
//            }

//            return output.ToString();
//        }

//        /// <summary>
//        /// Takes a NameIdentifier and spaces it out into words "Name Identifier".
//        /// </summary>
//        /// <param name="value">The value to convert.</param>
//        /// <returns>The string</returns>
//        public static string ToTitle(this string value)
//        {
//            if (string.IsNullOrEmpty(value))
//                return value;

//            value = ToPascalCase(value);

//            MatchCollection words = _properWordRegex.Matches(value);
//            var spacedName = new StringBuilder();
//            foreach (Match word in words)
//            {
//                spacedName.Append(word.Value);
//                spacedName.Append(' ');
//            }

//            // remove last space
//            spacedName.Length = spacedName.Length - 1;
//            return spacedName.ToString();
//        }

//        /// <summary>
//        /// Does string contain both uppercase and lowercase characters?
//        /// </summary>
//        /// <param name="s">The value.</param>
//        /// <returns>True if contain mixed case.</returns>
//        public static bool IsMixedCase(this string s)
//        {
//            if (s.IsNullOrEmpty())
//                return false;

//            var containsUpper = s.Any(Char.IsUpper);
//            var containsLower = s.Any(Char.IsLower);

//            return containsLower && containsUpper;
//        }
//        /// <summary>
//        /// Compares a string against a wildcard pattern.
//        /// </summary>
//        /// <param name="input">The string to match.</param>
//        /// <param name="mask">The wildcard pattern.</param>
//        /// <returns><c>true</c> if the pattern is matched; otherwise <c>false</c></returns>
//        public static bool Like(this string input, string mask)
//        {
//            var inputEnumerator = input.GetEnumerator();
//            var maskEnumerator = mask.GetEnumerator();

//            return Like(inputEnumerator, maskEnumerator);
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="inputEnumerator"></param>
//        /// <param name="maskEnumerator"></param>
//        /// <returns></returns>
//        private static bool Like(CharEnumerator inputEnumerator, CharEnumerator maskEnumerator)
//        {
//            while (maskEnumerator.MoveNext())
//            {
//                switch (maskEnumerator.Current)
//                {
//                    case '?':
//                        if (!inputEnumerator.MoveNext())
//                            return false;

//                        break;

//                    case '*':
//                        do
//                        {
//                            var inputTryAhead = (CharEnumerator)inputEnumerator.Clone();
//                            var maskTryAhead = (CharEnumerator)maskEnumerator.Clone();
//                            if (Like(inputTryAhead, maskTryAhead))
//                                return true;
//                        } while (inputEnumerator.MoveNext());

//                        return false;

//                    case '\\': // escape
//                        maskEnumerator.MoveNext();
//                        goto default;
//                    default:
//                        if (!inputEnumerator.MoveNext() || inputEnumerator.Current != maskEnumerator.Current)
//                            return false;

//                        break;
//                }
//            }

//            return !inputEnumerator.MoveNext();
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="value"></param>
//        /// <returns></returns>
//        public static bool IsJson(this string value)
//        {
//            return value.GetJsonType() != JsonType.None;
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="value"></param>
//        /// <returns></returns>
//        public static JsonType GetJsonType(this string value)
//        {
//            if (String.IsNullOrEmpty(value))
//                return JsonType.None;

//            for (int i = 0; i < value.Length; i++)
//            {
//                if (Char.IsWhiteSpace(value[i]))
//                    continue;

//                if (value[i] == '{')
//                    return JsonType.Object;

//                if (value[i] == '[')
//                    return JsonType.Array;

//                break;
//            }

//            return JsonType.None;
//        }
//    }
//    /// <summary>
//    /// 
//    /// </summary>
//    public enum JsonType : byte
//    {
//        /// <summary>
//        /// 
//        /// </summary>
//        None,
//        /// <summary>
//        /// 
//        /// </summary>
//        Object,
//        /// <summary>
//        /// 
//        /// </summary>
//        Array
//    }
//}
