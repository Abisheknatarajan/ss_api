using System;
using System.Collections.Generic;

namespace DatabaseModels;


public partial class SystemList
{
    public int Id { get; set; }

    public string? RemoteId { get; set; }

    public string? RemoteName { get; set; }
    public string? UserBy { get; set; }
}
