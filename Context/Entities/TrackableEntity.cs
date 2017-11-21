using System;
using System.ComponentModel.DataAnnotations;
using Infrastructure.Interface;

namespace Context.Entities
{
    public abstract class TrackableEntity : Entity, ITrackableEntity
    {
        [ScaffoldColumn(false)]
        public DateTime CreatedDate { get; set; }

        [MaxLength(256)]
        [ScaffoldColumn(false)]
        public string CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime UpdatedDate { get; set; }

        [MaxLength(256)]
        [ScaffoldColumn(false)]
        public string UpdatedBy { get; set; }

        public string OwnerId { get; set; }
    }
}