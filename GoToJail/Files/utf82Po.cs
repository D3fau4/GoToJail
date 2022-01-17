using Yarhl.FileFormat;
using Yarhl.Media.Text;

namespace GoToJail
{
    internal class utf82Po : IConverter<utf8, Po>
    {
        public Po Convert(utf8 strings)
        {
            //Read the language used by the user' OS, this way the editor can spellcheck the translation. - Thanks Liquid_S por the code
            var currentCulture = System.Threading.Thread.CurrentThread.CurrentCulture;
            var po = new Po
            {
                Header = new PoHeader("Criminal Girls", "anyemailnot-d3fau4.com", currentCulture.Name)
                {
                    LanguageTeam = "Any"
                }
            };

            foreach (var key in strings.Keys)
            {

                string value = strings.GetValueOrDefault(key, "NULL");
                if (value == null || value == string.Empty)
                {
                    continue;
                }

                po.Add(new PoEntry(value)
                {
                    Context = key,
                });
            }

            return po;
        }
    }
}
