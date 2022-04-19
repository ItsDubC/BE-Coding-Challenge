using EtsErosApi.Services;
using System;
using Xunit;

namespace EtsErosApi.Test
{
    public class TreeServiceTest
    {
        private readonly ITreeService _treeService;

        public TreeServiceTest(ITreeService treeService)
        {
            this._treeService = treeService;
        }
        [Fact]
        public void Test1()
        {

        }
    }
}
