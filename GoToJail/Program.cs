using System.Text;
using Yarhl.FileSystem;
using Yarhl.IO;
using Yarhl.Media.Text;

namespace GoToJail // Note: actual namespace depends on the project name.
{
    public class Program
    {
        public static void Main(string[] args)
        {
            switch (args[0])
            {
                case "--extract":
                    var stream = DataStreamFactory.FromFile(args[1], FileOpenMode.Read);
                    var reader = new DataReader(stream);
                    int size = reader.ReadInt32();
                    utf8 map = new utf8();
                    int cont = 0;
                    try
                    {
                        while (true)
                            map.Add(Path.GetFileName(args[1]) + "_" + cont++, reader.ReadString(Encoding.UTF8));
                    }
                    catch (Exception ex)
                    {

                    }
                    utf82Po po = new utf82Po();
                    var meme = po.Convert(map);
                    Po2Binary po2Binary = new Po2Binary();
                    var binary = po2Binary.Convert(meme);
                    var node1 = new Node(Path.GetFileName(Path.GetFileName(args[1]) + ".po"), binary);

                    if (!Directory.Exists("OUT_PO"))
                        Directory.CreateDirectory("OUT_PO");
                    node1.Stream.WriteTo(Path.Combine("OUT_PO", Path.GetFileName(args[1]) + ".po"));
                    break;
                case "--build":
                    var stream1 = DataStreamFactory.FromMemory();
                    var writer = new DataWriter(stream1);
                    var node = NodeFactory.FromFile(args[1]).TransformWith(new Binary2Po()).TransformWith(new Po2utf8()).GetFormatAs<utf8>();
                    writer.Write(node.bytesLength);
                    foreach (var str in node.Values)
                    {
                        writer.Write(str, true, Encoding.UTF8);
                    }
                    writer.WritePadding(0x0, 16);

                    if (!Directory.Exists("OUT_UTF8"))
                        Directory.CreateDirectory("OUT_UTF8");
                    writer.Stream.WriteTo(Path.Combine("OUT_UTF8", Path.GetFileName(args[1]).Replace(".po", "")));
                    break;
                default:
                    Console.WriteLine("--extract [UTF8 file]");
                    Console.WriteLine("--build [Generated PO]");
                    break;
            }
        }
    }
}