using System;
using System.Collections.Generic;
using System.Text;

namespace Pawel.Cms.Common.DTOs
{
    public class EmailDTO
    {       
        public string Subject { get; set; }
        public string FromAddress { get; set; }
        public string Content { get; set; }
    }
}
