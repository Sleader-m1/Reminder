using System;
using System.Text;
using SQLite;

namespace AffairNamesps
{
    public class Affair
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [MaxLength(50), Unique, Column("affair_name")]
        public string affair_name { get; set; }

        [MaxLength(150), Column("affair_discription")]
        public string affair_discription { get; set; }
        public DateTime Date { get; set; }

        public string position { get; set; }

        public bool wasChecked{get;set;}

    }
}