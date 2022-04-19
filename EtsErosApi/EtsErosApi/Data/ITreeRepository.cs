using EtsErosApi.Models;
using System.Threading.Tasks;

namespace EtsErosApi.Data
{
    public interface ITreeRepository
    {
        Task<TreeNode> GetNodeByIdAsync(int nodeId);
        Task<TreeNode> AddNodeAsync(TreeNode node);
        Task<TreeNode> UpdateNodeAsync(TreeNode node);
        Task<bool> DeleteNode(int nodeId);
        public Task<TreeNode> BuildTree();
    }
}
