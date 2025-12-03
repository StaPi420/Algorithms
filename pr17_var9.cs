using System;
using System.Text;

namespace MutableStringClass
{
    public class MutableString
    {
        private StringBuilder line;

        public MutableString()
        {
            line = new StringBuilder();
        }

        public MutableString(string str)
        {
            line = new StringBuilder(str);
        }

        public MutableString(StringBuilder stringBuilder)
        {
            line = new StringBuilder(stringBuilder.ToString());
        }

        public MutableString(MutableString other) : this(other.line)
        {
        }

        public int CountSpaces()
        {
            int count = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == ' ')
                {
                    count++;
                }
            }
            return count;
        }

        public void ReplaceUpperToLower()
        {
            for (int i = 0; i < line.Length; i++)
            {
                if (char.IsUpper(line[i]))
                {
                    line[i] = char.ToLower(line[i]);
                }
            }
        }

        public override string ToString()
        {
            return line.ToString();
        }

        public override int GetHashCode()
        {
            return line.ToString().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is MutableString other)
            {
                return line.ToString().Equals(other.line.ToString());
            }
            return false;
        }

        public new Type GetType()
        {
            return typeof(MutableString);
        }

        public StringBuilder Line
        {
            get { return new StringBuilder(line.ToString()); }
            set { line = new StringBuilder(value.ToString()); }
        }

        public int Length
        {
            get { return line.Length; }
        }

        public char this[int index]
        {
            get
            {
                if (index < 0 || index >= line.Length){
                    Console.WriteLine("Недопустимый индекс");
                    return ' ';
                }
                else
                    return line[index];
            }
            set
            {
                if (index < 0 || index >= line.Length)
                    Console.WriteLine("Недопустимый индекс");
                else
                    line[index] = value;
            }
        }

        public static MutableString operator +(MutableString str)
        {
            MutableString result = new MutableString(str);
            for (int i = 0; i < result.line.Length; i++)
            {
                result.line[i] = char.ToLower(result.line[i]);
            }
            return result;
        }

        public static MutableString operator -(MutableString str)
        {
            MutableString result = new MutableString(str);
            for (int i = 0; i < result.line.Length; i++)
            {
                result.line[i] = char.ToUpper(result.line[i]);
            }
            return result;
        }

        public static bool operator true(MutableString str)
        {
            return str != null && str.line != null && str.line.Length > 0;
        }

        public static bool operator false(MutableString str)
        {
            return str == null || str.line == null || str.line.Length == 0;
        }

        public static bool operator &(MutableString str1, MutableString str2)
        {
            if (str1 == null || str2 == null)
                return false;

            if (str1.Length != str2.Length)
                return false;

            for (int i = 0; i < str1.Length; i++)
            {
                if (char.ToLower(str1[i]) != char.ToLower(str2[i]))
                    return false;
            }

            return true;
        }


        public static explicit operator StringBuilder(MutableString str)
        {
            return new StringBuilder(str.line.ToString());
        }

        public static explicit operator MutableString(StringBuilder stringBuilder)
        {
            return new MutableString(stringBuilder);
        }
    }
}
