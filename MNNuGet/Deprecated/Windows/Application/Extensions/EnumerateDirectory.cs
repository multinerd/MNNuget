using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multinerd.Windows.Application.Extensions
{
    public static partial class Extensions
    {
        [Obsolete("This method has been deprecated and moved to 'Project Maya'.\n Please reference that project instead.")]
        static void DirSearch(string dir)
        {
            try
            {
                foreach (var f in Directory.GetFiles(dir))
                    System.Console.WriteLine(f);

                foreach (var d in Directory.GetDirectories(dir))
                    DirSearch(d);

            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        [Obsolete("This method has been deprecated and moved to 'Project Maya'.\n Please reference that project instead.")]
        static IEnumerable<string> GetFiles(string path)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(path);
            while (queue.Count > 0)
            {
                path = queue.Dequeue();
                try
                {
                    foreach (string subDir in Directory.GetDirectories(path))
                    {
                        queue.Enqueue(subDir);
                    }
                }
                catch (Exception ex)
                {
                    System.Console.Error.WriteLine(ex);
                }
                string[] files = null;
                try
                {
                    files = Directory.GetFiles(path);
                }
                catch (Exception ex)
                {
                    System.Console.Error.WriteLine(ex);
                }
                if (files != null)
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        yield return files[i];
                    }
                }
            }
        }
    }
}
