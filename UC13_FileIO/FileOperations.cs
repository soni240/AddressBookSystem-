using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UC13_FileIO
{
    public class FileOperations
    {
        public static void ReadFromStreamReader()
        {
            String path = @"D:\RFP.net\day9 Addressbooksystem\UC13_FileIO\Addresstext.txt";

            using (StreamReader sr = File.OpenText(path))
            {
                String s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }

        }

        public static void WriteUsingStreamWriter()
        {
            String path = @"D:\RFP.net\day9 Addressbooksystem\UC13_FileIO\Addresstext.txt";

            using (StreamWriter sr = File.AppendText(path))
            {
                sr.WriteLine("Hellow World - .Net is awesome1");
                sr.Close();
                Console.WriteLine(File.ReadAllText(path));
            }
        }
    }
}
