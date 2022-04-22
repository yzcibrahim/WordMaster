using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace WordMaster.Helpers
{
    public class Helper
    {
        public static F Convert<F,B>(B param)
        {
            var text = JsonSerializer.Serialize(param);
            return JsonSerializer.Deserialize<F>(text);
        }
    }
}
