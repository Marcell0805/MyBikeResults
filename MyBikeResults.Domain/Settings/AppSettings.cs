using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBikeResults.Domain.Settings
{
    public class AppSettings
    {
        public ApplicationDetail ApplicationDetail { get; set; }
        public string ApiBaseUrl { get; set; }
    }
}
