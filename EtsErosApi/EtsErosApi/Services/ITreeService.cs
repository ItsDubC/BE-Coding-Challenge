using EtsErosApi.DTOs;
using EtsErosApi.Models;
using System.Threading.Tasks;

namespace EtsErosApi.Services
{
    public interface ITreeService
    {
        Task<TreeNode> GetEntireTreeAsync();
        Task<TreeNode> GetNodeByIdAsync(int nodeId);

        Task<TreeNode> AddNodeAsync(AddNodeDto newNode);

        Task<bool> DeleteNodeAsync(int nodeId);

        Task<TreeNode> ChangeNodeParentAsync(int nodeId, UpdateNodeDto updateNode);

        Task<bool> CanDeleteNodeAsync(int nodeId);
    }
}
