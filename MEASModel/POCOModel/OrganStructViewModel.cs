using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEASModel.POCOModel
{
    public class OrganStructViewModel
    {
        public int Id { get; set; }
        public int ParentId { get; set; }

        [Required(ErrorMessage="*")]
        public string Name { get; set; }

        public int Status { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
