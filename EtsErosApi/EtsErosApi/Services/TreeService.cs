using EtsErosApi.Data;
using EtsErosApi.DTOs;
using EtsErosApi.Models;
using System;
using System.Threading.Tasks;

namespace EtsErosApi.Services
{
    public class TreeService : ITreeService
    {
        private readonly ITreeRepository _repository;

        public TreeService(ITreeRepository repository)
        {
            this._repository = repository;
        }

        /// <inheritdoc />
        public async Task<TreeNode> GetNodeByIdAsync(int nodeId)
        {
            return await _repository.GetNodeByIdAsync(nodeId);
        }

        /// <inheritdoc />
        public async Task<TreeNode> AddNodeAsync(AddNodeDto newNode)
        {
            var parentNode = await _repository.GetNodeByIdAsync(newNode.Parent);

            if (parentNode == null)
                throw new Exception("Nonexistent parent");

            // TODO: Use AutoMapper to automagically map these fields from model -> DTO
            TreeNode node = new TreeNode
            {
                Label = newNode.Label,
                ParentId = newNode.Parent
            };

            return await _repository.AddNodeAsync(node);
        }

        /// <inheritdoc />
        public async Task<TreeNode> ChangeNodeParentAsync(int nodeId, UpdateNodeDto updateNode)
        {
            var parentNode = await _repository.GetNodeByIdAsync(updateNode.CurrentId);
            var targetNode = await _repository.GetNodeByIdAsync(nodeId);

            if (parentNode == null || targetNode == null)
                throw new Exception("Unable to change parent.  Node or parent node does not exist.");

            targetNode.ParentId = parentNode.Id;

            return await _repository.UpdateNodeAsync(targetNode);
        }

        /// <inheritdoc />
        public async Task<bool> DeleteNodeAsync(int nodeId)
        {
            return await _repository.DeleteNode(nodeId);
        }

        /// <inheritdoc />
        public async Task<bool> CanDeleteNodeAsync(int nodeId)
        {
            var node = await _repository.GetNodeByIdAsync(nodeId);

            if (node == null)
                return false;

            return node.Children.Count == 0;
        }

        /// <inheritdoc />
        public async Task<TreeNode> GetEntireTreeAsync()
        {
            return await _repository.GetEntireTree();
        }
    }
}
