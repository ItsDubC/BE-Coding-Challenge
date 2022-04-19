using EtsErosApi.Models;
using System.Threading.Tasks;

namespace EtsErosApi.Data
{
    public interface ITreeRepository
    {
        /// <summary>
        /// Get a TreeNode w/ child hierarchies by TreeNode ID
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        Task<TreeNode> GetNodeByIdAsync(int nodeId);

        /// <summary>
        /// Persist a new TreeNode
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        Task<TreeNode> AddNodeAsync(TreeNode node);

        /// <summary>
        /// Update data on existing TreeNode
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        Task<TreeNode> UpdateNodeAsync(TreeNode node);

        /// <summary>
        /// Delete a TreeNode based on TreeNode ID
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        Task<bool> DeleteNode(int nodeId);

        /// <summary>
        /// Gets the entire tree starting from the root TreeNode
        /// </summary>
        /// <returns></returns>
        public Task<TreeNode> GetEntireTree();
    }
}
