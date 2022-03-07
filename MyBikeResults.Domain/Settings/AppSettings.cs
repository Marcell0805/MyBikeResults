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
        //This is the route of where the API will sit
        public string ApiBaseUrl { get; set; }
    }
}
