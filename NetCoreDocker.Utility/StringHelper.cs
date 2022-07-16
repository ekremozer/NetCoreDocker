using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreDocker.Utility
{
    public static class StringHelper
    {
        public static string GetRandomFileName(string fileName)
        {
            var extension= Path.GetExtension(fileName);
            var randomFileName = Guid.NewGuid() + extension;
            return randomFileName;
        }
    }
}
