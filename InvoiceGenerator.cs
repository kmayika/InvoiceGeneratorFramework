using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace InvoiceGeneratorFramework
{
    public static class Invoice
    {
        public static Customer CustomerDetails => Get<Customer>();

        private static T Get<T>() where T : new()
        {
            var cls = new T();
            return cls;
        }
    }

    public class Customer
    {
        ///<summary>
        /// This method returns the Customers Name
        ///</summary>
        public string Get_CustomerName()
        {
           return Variables.Get<string>(Variables.VariableName.CustomerName.ToString());
        }

        ///<summary>
        /// This method returns the Customer Events Name
        ///</summary>
        public string Get_CustomerEvent()
        {
           return Variables.Get<string>(Variables.VariableName.EventName.ToString());
        }


    }

    public class Document
    {

    }


    public class Variables
    {
        #region  Variables
        public enum VariableName
        {
            CustomerName,
            EventName
        }
        #endregion
        public static Dictionary<string,object> variable = new Dictionary<string, object>();

        public static void Save(string key, object value)
        {
            if (variable.ContainsKey(key))
            {
                variable[key.ToLower()] = value;
            }
            else
            {
                variable.Add(key.ToLower(), value);
            }
        }

        public static T Get<T>(string key)
        {
            T value;

            if (!variable.ContainsKey(key.ToLower()))
            {

            }

            try
            {
                TypeConverter con = TypeDescriptor.GetConverter(typeof (T));
                value = (T)con.ConvertFrom(variable[key.ToLower()]);
            }
            catch (System.Exception e)
            {
                value = (T)System.Convert.ChangeType(variable[key.ToLower()], typeof(T));
            }

            return value;
        }
    }
}
