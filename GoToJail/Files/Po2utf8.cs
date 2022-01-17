using Yarhl.FileFormat;
using Yarhl.Media.Text;

namespace GoToJail
{
    internal class Po2utf8 : IConverter<Po, utf8>
    {
        public utf8 Convert(Po po)
        {
            utf8 map = new utf8();

            Dictionary<char, char> charMap = CharMaps.GetMap(po.Header.Language);

            foreach (var entry in po.Entries)
            {

                foreach (char c in entry.Translated)
                {
                    if (charMap.ContainsKey(c))
                    {
                        entry.Translated = entry.Translated.Replace(c, charMap[c]);
                    }
                }

                if (entry.Translated == string.Empty)
                {
                    entry.Translated = entry.Original;
                }

                map.Add(entry.Context, entry.Translated);
            }

            return map;
        }
    }
}
