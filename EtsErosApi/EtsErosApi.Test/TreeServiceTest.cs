using EtsErosApi.Data;
using EtsErosApi.DTOs;
using EtsErosApi.Models;
using EtsErosApi.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace EtsErosApi.Test
{
    public class TreeServiceTest
    {
        private readonly DataContext _context;
        private readonly ITreeService _treeService;

        public TreeServiceTest(DataContext context, ITreeService treeService)
        {
            this._treeService = treeService;
            this._context = context;
        }

        [Fact]
        public async Task GetNodeById_ValidId_Success()
        {
            int nodeId = 1;
            _context.TreeNodes.Add(new TreeNode { Id = nodeId, Label = "TestNode" });
            await _context.SaveChangesAsync();

            var node = _treeService.GetNodeByIdAsync(nodeId);

            Assert.NotNull(node);
        }

        [Fact]
        public async Task GetNodeById_InvalidId_ReturnsNull()
        {
            int nodeId = 20;
            _context.TreeNodes.Add(new TreeNode { Id = nodeId, Label = "TestNode" });
            await _context.SaveChangesAsync();

            var node = await _treeService.GetNodeByIdAsync(nodeId + 1);

            Assert.Null(node);
        }

        [Fact]
        public async Task AddNode_ValidNode_Success()
        {
            int nodeCount = await _context.TreeNodes.CountAsync();

            await _treeService.AddNodeAsync(new AddNodeDto
            {
                Parent = 1,
                Label = "wombat"
            });

            Assert.Equal(nodeCount + 1, await _context.TreeNodes.CountAsync());
        }

        [Fact]
        public async Task DeleteNode()
        {
            _context.TreeNodes.Add(new TreeNode { Id = 1, Label = "TestNode" });
            await _context.SaveChangesAsync();
            await _treeService.DeleteNodeAsync(1);

            Assert.Empty(_context.TreeNodes);
        }

        [Fact]
        public async Task CanDeleteNode_NodeWithChildren_Fail()
        {
            int parentId = 30;
            TreeNode parent = new TreeNode { Id = parentId, Label = "hamster" };
            TreeNode child = new TreeNode { Id = 10, Label = "lemur", ParentId = parentId };

            await _context.TreeNodes.AddRangeAsync(new List<TreeNode> { parent, child });
            await _context.SaveChangesAsync();

            Assert.False(await _treeService.CanDeleteNodeAsync(parentId));
        }
    }
}
