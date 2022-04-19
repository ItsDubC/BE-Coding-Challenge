using EtsErosApi.DTOs;
using EtsErosApi.Models;
using EtsErosApi.Services;
using EtsErosApi.Util;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace EtsErosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreeController : ControllerBase
    {
        private readonly ITreeService _treeService;

        public TreeController(ITreeService treeService)
        {
            this._treeService = treeService;
        }

        [HttpGet]
        public async Task<ActionResult> GetEntireTree()
        {
            var tree = await _treeService.GetEntireTreeAsync();
            return Ok(ConvertToEtsJson(tree));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetNode(int id)
        {
            var node = await _treeService.GetNodeByIdAsync(id);
            return Ok(ConvertToEtsJson(node));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AddNodeDto newNodeDto)
        {
            if (ModelState.IsValid)
            {
                var newNode = await _treeService.AddNodeAsync(newNodeDto);
                return Created(newNode.Id.ToString(), ConvertToEtsJson(newNode));
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (await _treeService.CanDeleteNodeAsync(id))
            {
                await _treeService.DeleteNodeAsync(id);
                return Ok();
            }

            return BadRequest($"Unable to delete node {id} because it has children");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateNodeDto updateNodeDto)
        {
            if (ModelState.IsValid)
            {
                await _treeService.ChangeNodeParentAsync(id, updateNodeDto);
                return NoContent();
            }

            return BadRequest();
        }

        // TODO: Move out of controller
        private string ConvertToEtsJson(TreeNode node)
        {
            return JsonConvert.SerializeObject(node, Formatting.Indented, new ErosJsonConverter(typeof(TreeNode)));
        }
    }
}
