using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpIoTest.Models
{
    public class FileUpload
    {
        public IFormFileCollection Files { get; set; }
    }
}
