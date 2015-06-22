using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEASModel.POCOModel
{
    public class TreeNode
    {
        public TreeNode()
        {
            rows = new List<object>();
        }
        public int total { get; set; }
        public List<object> rows { get; set; }
    }
}
