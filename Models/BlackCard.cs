﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace TheOmenDen.CrowsAgainstHumility.Importer.Models
{
    public partial class BlackCard
    {
        public Guid Id { get; set; }
        public string Message { get; set; } = null!;
        public int PickAnswersCount { get; set; }
        public Guid PackId { get; set; }

        public virtual Pack Pack { get; set; } = null!;
    }
}