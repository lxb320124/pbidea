using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using pbidea;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using csharpapi;

namespace pbidea
{
    public class CPbideaAPI
    {
        public delegate void ChangeHandler(string value);
        public event ChangeHandler OnRequestChanged;
        private string _request;
        private string _response;
        private static string _result;
        public string name;
        public int age;
        public string address;

        public static string is_name = "pbidea.c#.caller";
        public string Hello(in string msg, ref string caption, out double num)
        {
            num = 8765543.21;
            caption = "modify: " + caption;
            //使用第三方库生成json
            string json = "{\"hello\":\"json from c#\"}";
            JObject js = JObject.Parse(json);
            string r = js.ToString();
            //显示C# form
            Form1 f1 = new Form1();
            f1.SetHello(msg + ", double: " + num.ToString());
            f1.ShowDialog();

            return r;
        }
        public string Hello(string msg)
        {
            string caption = "";
            double d = 0;
            return Hello(msg, ref caption, out d);
        }
        public string request
        {
            set
            {
                _request = value;
                Console.WriteLine("set request: {0}", _request);
                //OnRequestChanged(_request);
            }
            get
            {
                Console.WriteLine("get request: {0}", _request);
                return _request;
            }            
        }
        public string response
        {
            get
            {
                _response = "response for: " + _request;
                return _response;
            }
        }
        public static string dump(string src)
        {
            MessageBox.Show(src, "this is dump function");
            return src;
        }
        public static void ue_request(string src)
        {
            MessageBox.Show(src, "ue_request");
        }
        public static string result
        {
            set
            {
                _result = value;
                Console.WriteLine("set result: {0}", _result);
            }
            get
            {
                Console.WriteLine("get result: {0}", _result);
                return _result;
            }
        }
    }
}

