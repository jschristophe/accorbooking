namespace AccorBooking.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    //using System.Data.Entity.Spatial;
    [Serializable]
    [Table("HumanResources.JobCandidate")]
    public partial class JobCandidate
    {
        public int JobCandidateID { get; set; }

        public int? BusinessEntityID { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string Resume { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
