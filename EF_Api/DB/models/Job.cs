using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EF_Api.DB.models
{
    public partial class Job
    {
        public short JobId { get; set; }
        public string JobDesc { get; set; }
    }
}
