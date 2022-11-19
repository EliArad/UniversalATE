using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace GSkinLib
{
    public class ResourceManager
    {
        string m_fileName;
        Dictionary<string, Bitmap> m_dicRes = new Dictionary<string, Bitmap>();
        public ResourceManager(string fileName)
        {
            m_fileName = fileName;

        }
        public bool Load()
        {
            if (File.Exists(m_fileName) == false)
                return false;
            ResourceReader res = new ResourceReader(m_fileName);
            IDictionaryEnumerator dict = res.GetEnumerator();
            while (dict.MoveNext())
                m_dicRes.Add((string)dict.Key, (Bitmap)dict.Value);

            res.Close();
            return true;
        }
        public Bitmap GetBitmap(string name)
        {
            return m_dicRes[name];
        }
        Bitmap[] b = new Bitmap[10];
        public Bitmap [] GetBitmaps(string name)
        {
            try
            {
                b[0] = m_dicRes[name + "_normal"];
                b[1] = m_dicRes[name + "_enter"];
                b[2] = m_dicRes[name + "_press"];
                if (m_dicRes.ContainsKey(name + "_disable") == true)
                    b[3] = m_dicRes[name + "_disable"];
                else
                    b[3] = null;


                return b;
            }
            catch (Exception err)
            {
                b[0] = new Bitmap("btn1_normal.png");
                b[1] = new Bitmap("btn1_enter.png");
                b[2] = new Bitmap("btn1_press.png");
                b[3] = new Bitmap("btn1_disable.png");
                return b;
            }
        }

        public Bitmap[] GetOnOffBitmaps(string name)
        {
            try
            {
                b[0] = m_dicRes[name + "_on_press"];
                b[1] = m_dicRes[name + "_off_press"];
                b[2] = m_dicRes[name + "_on_enter"];
                b[3] = m_dicRes[name + "_off_enter"];

                if (m_dicRes.ContainsKey(name + "_on_disable") == true)
                    b[4] = m_dicRes[name + "_on_disable"];
                else
                    b[4] = null;

                if (m_dicRes.ContainsKey(name + "_off_disable") == true)
                    b[5] = m_dicRes[name + "_off_disable"];
                else
                    b[5] = null;

                return b;
            }
            catch (Exception err)
            {
                b[0] = new Bitmap("btn1_normal.png");
                b[1] = new Bitmap("btn1_enter.png");
                b[2] = new Bitmap("btn1_press.png");
                b[3] = new Bitmap("btn1_disable.png");
                b[4] = new Bitmap("btn1_disable.png");
                b[5] = new Bitmap("btn1_disable.png");
                return b;
            }
        }
        
        public Bitmap[] GetRadioBitmaps(string name)
        {
            try
            {
                b[0] = m_dicRes[name + "_normal"];
                b[1] = m_dicRes[name + "_press"];
                b[2] = m_dicRes[name + "_enter"];

                if (m_dicRes.ContainsKey(name + "_disable") == true)
                    b[3] = m_dicRes[name + "_disable"];
                else
                    b[3] = null;

                return b;
            }
            catch (Exception err)
            {
                b[0] = new Bitmap("btn1_normal.png");
                b[1] = new Bitmap("btn1_enter.png");
                b[2] = new Bitmap("btn1_press.png");
                b[3] = new Bitmap("btn1_disable.png");
                return b;
            }
        }

        public Bitmap[] GetMultiSelect2Bitmaps(string name)
        {
            b[0] = m_dicRes[name];           
            b[1] = m_dicRes[name + "_normal"];
            b[2] = m_dicRes[name + "_press"];
            b[3] = m_dicRes[name + "_enter"];
            b[4] = m_dicRes[name + "_disable"];

            return b;
        }
    }
}
