using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATECommon
{
    
    public class GenericSettings<T> where T: new()
    {
          
        private static readonly object padlock = new object();
        string m_fileName;

        public GenericSettings(string fileName)
        {
            m_fileName = fileName;
        }
          
        public bool Save(T t, out string outMessage)
        {
            try
            {
                
                string json = JsonConvert.SerializeObject(t);
                string jsonFormatted = JValue.Parse(json).ToString(Formatting.Indented);                    
                File.WriteAllText(m_fileName, jsonFormatted);
                outMessage = "Ok";
                return true;
            }
            catch (Exception err)
            {
                outMessage = err.Message;
                return false;
            }
        }
        
        public bool Load(out T t, out string outMessage)
        {
            try
            {
               
                if (File.Exists(m_fileName) == false)
                {
                    t = new T();
                    Save(t, out outMessage);
                    outMessage = "File not found";
                    return true;
                }
                string text = File.ReadAllText(m_fileName);
                t = JsonConvert.DeserializeObject<T>(text);
                if (t == null)
                {
                    t = new T();
                    Save(t , out outMessage);
                    return false;
                }
                else
                {
                    outMessage = "Ok";
                    return true;
                }

            }
            catch (Exception err)
            {
                t = new T();
                outMessage = err.Message;
                return false;
            }
        }
       
    }

}
