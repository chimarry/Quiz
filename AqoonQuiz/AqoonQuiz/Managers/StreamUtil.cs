using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AqoonQuiz.Managers
{
    public static class StreamUtil
    {
        public static Stream GetStream(string name)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            return assembly.GetManifestResourceStream(assembly.GetManifestResourceNames().First(x => x.Contains(name)));
        }
    }
}
