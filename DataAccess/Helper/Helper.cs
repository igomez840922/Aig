using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Helper
{
    public static class Helper
    {
        public static string JsonValue(string column, [NotParameterized] string path)
    => throw new NotSupportedException();

        public static string JsonQuery(string column, [NotParameterized] string path) =>
            throw new NotSupportedException();

    }
}
