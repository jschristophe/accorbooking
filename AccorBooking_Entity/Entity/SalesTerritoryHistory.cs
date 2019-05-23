namespace AccorBooking.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    //using System.Data.Entity.Spatial;
    [Serializable]
    [Table("Sales.SalesTerritoryHistory")]
    public partial class SalesTerritoryHistory
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BusinessEntityID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TerritoryID { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual SalesPerson SalesPerson { get; set; }

        public virtual SalesTerritory SalesTerritory { get; set; }
    }
}
