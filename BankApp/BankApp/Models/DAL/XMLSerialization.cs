using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BankApp.Models.DAL
{
    public class XMLSerialization
    {
        public static T Deserialize<T>(string xml)
        {
            throw new NotImplementedException();
        }
        public static void Serialize<T>(T obj)
        {
            throw new NotImplementedException();
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextWriter writer = new StreamWriter(File.OpenWrite(string.Concat("{0}.txt", typeof(T).GetType().Name))))
            {
                serializer.Serialize(writer, obj);
            }
        }

        //private T ObjectFromXML<T>(string xml)
        //{
        //    StringReader strReader = null;
        //    XmlSerializer serializer = null;
        //    XmlTextReader xmlReader = null;
        //    T obj = default(T);
        //    try
        //    {
        //        strReader = new StringReader(xml);
        //        serializer = new XmlSerializer(typeof(T));
        //        xmlReader = new XmlTextReader(strReader);
        //        obj = (T)serializer.Deserialize(xmlReader);
        //    }
        //    catch (Exception exp)
        //    {
        //        //Handle Exception Code
        //    }
        //    finally
        //    {
        //        if (xmlReader != null)
        //        {
        //            xmlReader.Close();
        //        }
        //        if (strReader != null)
        //        {
        //            strReader.Close();
        //        }
        //    }
        //    return obj;
        //}

        //private static string GetXMLFromObject(object o)
        //{
        //    StringWriter sw = new StringWriter();
        //    XmlTextWriter tw = null;
        //    try
        //    {
        //        XmlSerializer serializer = new XmlSerializer(o.GetType());
        //        tw = new XmlTextWriter(sw);

        //        serializer.Serialize(tw, o);
        //    }
        //    catch (Exception ex)
        //    {
        //        //Handle Exception Code
        //    }
        //    finally
        //    {
        //        sw.Close();
        //        if (tw != null)
        //        {
        //            tw.Close();
        //        }
        //    }
        //    return sw.ToString();
        //}
    }

}
