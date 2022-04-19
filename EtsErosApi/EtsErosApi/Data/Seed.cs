using EtsErosApi.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EtsErosApi.Data
{
    public class Seed
    {
        public static async Task SeedTreeNodes(DataContext context)
        {
            if (await context.TreeNodes.AnyAsync())
                return;

            try
            {
                var nodeData = await System.IO.File.ReadAllTextAsync("Data/seedData.json");
                var nodes = JsonConvert.DeserializeObject<List<TreeNode>>(nodeData);

                await context.TreeNodes.AddRangeAsync(nodes);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                // TODO: Add exception logging
                throw;
            }
        }
    }
}
