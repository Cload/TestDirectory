using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace TestDirectory.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHostingEnvironment _environment;

        public IndexModel(ILogger<IndexModel> logger, IHostingEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        public string SerializedFolder { get; set; }

        public void OnGet()
        {
            var root = Path.Combine(this._environment.WebRootPath,  "static", "documenti");
            var result = Utils.GetAssets(root, this._environment.WebRootPath);
            this.SerializedFolder = Newtonsoft.Json.JsonConvert.SerializeObject(result);

        }
    }
}
