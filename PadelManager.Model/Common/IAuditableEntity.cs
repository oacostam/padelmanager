﻿using System;

namespace PadelManager.Core.Common
{
    public interface IAuditableEntity
    {
        DateTime CreationdDate { get; set; }
        string CreatedBy { get; set; }
        DateTime UpdatedDate { get; set; }
        string UpdatedBy { get; set; }
    }
}