using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace GlobleLibrary
{
    public static class StringExtention
    {
        static public string replicate(this string str, int n)
        {
            string ResultString = null;

            for (int i = 0; i < n; i++)
            {
                ResultString = ResultString + str; 
            }
            return ResultString;
        }

        /// <summary>
        /// Perform a deep Copy of the object. Class must be marked as Serializable in order to Perform a Deep Copy.
        /// </summary>
        /// <typeparam name="T">The type of object being copied.</typeparam>
        /// <param name="source">The object instance to copy.</param>
        /// <returns>The copied object.</returns>
        public static T Clone<T>(this T source)
        {
            if (!typeof(T).IsSerializable)
                throw new ArgumentException("The type must be serializable.", "source");

            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
                return default(T);

            System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            System.IO.Stream stream = new System.IO.MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, System.IO.SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }
        /// <summary>
        /// Convert datatable into string repersentation 
        /// </summary>       
        static public string DataTableToString(this DataTable dt)
        {
            string blankString = " ";
            int MaxSize = 20;
            StringBuilder sb = new StringBuilder();

            foreach (DataColumn dc in dt.Columns)
            {
                sb.AppendFormat(dc.ColumnName + blankString.replicate(MaxSize - dc.ColumnName.Length));
            }

            sb.Append("\n");

            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    string tempValue = (dr[dc.ColumnName] == Convert.DBNull) ? string.Empty : dr[dc.ColumnName].ToString();
                    sb.AppendFormat(tempValue + blankString.replicate(MaxSize - tempValue.Length));
                }

                sb.Append("\n");
            }
            return sb.ToString();          
        }
        static public string DataTableToString1(this DataTable dt)
        { 
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    sb.Append(dt.Columns[j].ColumnName);
                    sb.Append(":");
                    sb.Append("'" + dt.Rows[i][j].ToString() + "'");
                    sb.Append(",");
                }
            }
            return sb.ToString();

        }
        static public string CharListToString(List<char> lstChar)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < lstChar.Count; i++)
            {
                if (lstChar[i] == '\0')
                {
                    sb.Append(" ");
                }
                else
                {
                    sb.Append(lstChar[i].ToString());
                }
            }
            return sb.ToString();
        }
    }
}
