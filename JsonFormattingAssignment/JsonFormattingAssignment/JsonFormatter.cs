
using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace JsonFormattingAssignment
{
    public static class JsonFormatter
    {
        public static string Convert(object obj)
        {
            return SerializeValue(obj);
        }

        private static string SerializeValue(object obj)
        {
            if (obj == null) 
                return "null"; 

            Type type = obj.GetType();
            if (type == typeof(string))
            {
                return $"\"{(obj.ToString())}\"";
            }

            // BOOLEAN
            if (type == typeof(bool))
            {
                return obj.ToString().ToLower();
            }

            // NUMBERS
            if (type == typeof(int))
                return obj.ToString();

            if (type == typeof(double))
                return ((double)obj).ToString();

            if (type == typeof(decimal))
                return ((decimal)obj).ToString();

            // DATETIME 
            if (type == typeof(DateTime))
            {
                return $"\"{((DateTime)obj).ToString("M/d/yyyy h:mm:ss tt")}\"";
            }

            // LIST OR ARRAY
            if (typeof(IEnumerable).IsAssignableFrom(type) && type != typeof(string))
            {
                return SerializeArray((IEnumerable)obj);
            }

            // OBJECT
            return SerializeObject(obj);
        }

        private static string SerializeObject(object obj)
        {
            StringBuilder json = new StringBuilder();
            json.Append("{");

            PropertyInfo[] properties = obj.GetType().GetProperties();

            for (int i = 0; i < properties.Length; i++)
            {
                PropertyInfo prop = properties[i];
                if(prop.Name=="Id")
                    continue;
                if (!prop.CanRead)
                    continue;

                string name = prop.Name;
                object value = prop.GetValue(obj);

                json.Append(($"\"{name}\":").ToString()).Append(SerializeValue(value)); // RECURSION

                if (i < properties.Length - 1)
                    json.Append(",");
            }

            json.Append("}");
            return json.ToString();
        }

        private static string SerializeArray(IEnumerable list)
        {
            StringBuilder json = new StringBuilder();
            json.Append("[");

            bool first = true;

            foreach (var item in list)
            {
                if (!first)
                    json.Append(",");

                json.Append(SerializeValue(item)); // RECURSION
                first = false;
            }

            json.Append("]");
            return json.ToString();
        }

        
    }
}