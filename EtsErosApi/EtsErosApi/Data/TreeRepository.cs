using EtsErosApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EtsErosApi.Data
{
    public class TreeRepository : ITreeRepository
    {
        private readonly DataContext _context;

        public TreeRepository(DataContext context)
        {
            this._context = context;
        }

        /// <inheritdoc />
        public async Task<TreeNode> GetNodeByIdAsync(int nodeId)
        {
            //return await _context.TreeNodes.FindAsync(nodeId);

            var nodes = await _context.TreeNodes.ToListAsync();
            nodes.ForEach(x => x.Children = nodes.Where(child => child.ParentId == x.Id).ToList());

            return nodes.FirstOrDefault(x => x.Id == nodeId);
        }

        /// <inheritdoc />
        public async Task<TreeNode> AddNodeAsync(TreeNode node)
        {
            _context.TreeNodes.Add(node);
            await _context.SaveChangesAsync();
            return node;
        }

        /// <inheritdoc />
        public async Task<TreeNode> UpdateNodeAsync(TreeNode node)
        {
            _context.Update(node);
            await _context.SaveChangesAsync();
            return node;
        }

        /// <inheritdoc />
        public async Task<bool> DeleteNode(int nodeId)
        {
            var node = GetNodeByIdAsync(nodeId);
            _context.Remove(node);
            var changeCount = await _context.SaveChangesAsync();
            return changeCount > 0;
        }

        /// <inheritdoc />
        public async Task<TreeNode> GetEntireTree()
        {
            var nodes = await _context.TreeNodes.ToListAsync();
            nodes.ForEach(x => x.Children = nodes.Where(child => child.ParentId == x.Id).ToList());

            // Assume only one root node...
            return nodes.FirstOrDefault(x => x.ParentId == null);
        }
    }
}
