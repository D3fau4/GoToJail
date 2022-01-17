using System.Text;
using Yarhl.FileFormat;

namespace GoToJail
{
    internal class utf8 : IFormat
    {
        public List<string> Keys { get; set; }
        public List<string> Values { get; set; }
        public Dictionary<string, string> Dic { get; set; }
        public int bytesLength = 0;
        public utf8()
        {
            Keys = new List<string>();
            Values = new List<string>();
            Dic = new Dictionary<string, string>();
        }

        public void Add(string key, string value)
        {
            bytesLength += Encoding.UTF8.GetByteCount(value) + 1;
            Keys.Add(key);
            Values.Add(value);
            Dic.Add(key, value);
        }

        public string GetValueOrDefault(string key, string defaultv)
        {
            if (Keys.Contains(key))
                return Values[Keys.IndexOf(key)];

            return defaultv;
        }
    }
}
