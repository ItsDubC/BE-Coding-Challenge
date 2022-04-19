using EtsErosApi.DTOs;
using EtsErosApi.Models;
using System.Threading.Tasks;

namespace EtsErosApi.Services
{
    public interface ITreeService
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
        /// <param name="newNode"></param>
        /// <returns></returns>
        Task<TreeNode> AddNodeAsync(AddNodeDto newNode);

        /// <summary>
        /// Updates a TreeNode's parent.  Throws exception if either the target or parent TreeNode does not exist.
        /// </summary>
        /// <param name="nodeId"></param>
        /// <param name="updateNode"></param>
        /// <returns></returns>
        Task<TreeNode> ChangeNodeParentAsync(int nodeId, UpdateNodeDto updateNode);

        /// <summary>
        /// Delete a TreeNode based on TreeNode ID
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        Task<bool> DeleteNodeAsync(int nodeId);

        /// <summary>
        /// Determines whether a TreeNode for the given ID can be deleted.  
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns>True if the TreeNode exists and has no children.</returns>
        Task<bool> CanDeleteNodeAsync(int nodeId);

        /// <summary>
        /// Gets the entire tree starting from the root TreeNode
        /// </summary>
        /// <returns></returns>
        Task<TreeNode> GetEntireTreeAsync();
    }
}
