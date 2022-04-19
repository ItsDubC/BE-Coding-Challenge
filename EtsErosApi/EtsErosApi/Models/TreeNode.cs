using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EtsErosApi.Models
{
    public class TreeNode
    {
        public int Id { get; set; }
        [Required]
        public string Label { get; set; }
        public int? ParentId { get; set; }
        public List<TreeNode> Children { get; set; } = new List<TreeNode>();
    }
}
