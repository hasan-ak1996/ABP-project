using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpIoTest.Models
{
    public class EditFile
    {
        public IFormFile file { get; set; }
        public int id { get; set; }
    }
}
