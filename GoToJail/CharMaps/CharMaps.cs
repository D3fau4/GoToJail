namespace GoToJail
{
    internal static class CharMaps
    {
        public static Dictionary<char, char> esES = new Dictionary<char, char>()
        {
            { 'á', 'ぁ' },
            { 'Á', 'あ' },
            { 'í', 'ぃ' },
            { 'Í', 'い' },
            { 'ú', 'ぅ' },
            { 'Ú', 'う' },
            { 'é', 'ぇ' },
            { 'É', 'え' },
            { 'ó', 'ぉ' },
            { 'Ó', 'お' },
            { 'ü', 'か' },
            { 'Ü', 'が' },
            { 'ñ', 'き' },
            { 'Ñ', 'ぎ' },
            { '¡', 'く' },
            { '¿', 'ぐ' },
            { '!', 'け' },
            { '?', 'げ' },
            { '«', '《' },
            { '»', '》' },
            { 'º', '~' }
        };

        public static Dictionary<char, char> GetMap(string lenguage)
        {
            switch (lenguage)
            {
                case "es-ES":
                default:
                    return esES;
                    break;
            }
        }
    }
}
