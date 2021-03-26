using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;

namespace AccountMicroservice
{
    public class Info : OpenApiInfo
    {
        public new string Title { get; set; }
        public new string Version { get; set; }
        public new string Description { get; set; }
        public new string TermsOfService { get; set; }
    }
}
