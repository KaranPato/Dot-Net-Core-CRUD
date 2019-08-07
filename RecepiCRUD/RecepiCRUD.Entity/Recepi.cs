using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RecepiCRUD.Entity
{
    public class Recepi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecepiId { get; set; }
        public string RecepiName { get; set; }
        public string RecepiDesc { get; set; }
        public string RecepiImage { get; set; }
    }
}
