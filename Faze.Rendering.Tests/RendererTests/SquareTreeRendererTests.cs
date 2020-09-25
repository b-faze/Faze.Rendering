using Faze.Abstractions.Rendering;
using Faze.Rendering.TreeRenderers;
using Faze.Rendering.Tests.Utilities;
using System.Drawing.Imaging;
using Xunit;

namespace Faze.Rendering.Tests.RendererTests
{
    public class SquareTreeRendererTests
    {
        [Theory]
        [InlineData(1, 0, 0.1)]
        [InlineData(1, 1, 0.1)]
        [InlineData(1, 2, 0.1)]
        [InlineData(1, 3, 0.1)]
        [InlineData(1, 4, 0.1)]
        [InlineData(2, 0, 0.1)]
        [InlineData(2, 1, 0.1)]
        [InlineData(2, 2, 0.1)]
        [InlineData(2, 3, 0.1)]
        [InlineData(2, 4, 0.1)]
        [InlineData(3, 0, 0.1)]
        [InlineData(3, 1, 0.1)]
        [InlineData(3, 2, 0.1)]
        [InlineData(3, 3, 0.1)]
        [InlineData(3, 4, 0.1)]
        public void Test1(int squareSize, int depth, double borderProportion)
        {
            var rendererOptions = new SquareTreeRendererOptions(squareSize)
            {
                BorderProportions = borderProportion
            };
            var renderer = new SquareTreeRenderer(rendererOptions);
            var tree = TreeUtilities.CreateGreyPaintedSquareTree(squareSize, depth);
            var filename = FileUtilities.GetTestOutputPath(nameof(SquareTreeRendererTests), 
                $"Test1_{squareSize}_{depth}_{borderProportion}.png");

            using (var img = renderer.Draw(tree, 600))
            {
                img.Save(filename, ImageFormat.Png);
            }
            
        }        
        
        [Theory]
        [InlineData(1, 0, 0.1)]
        [InlineData(1, 1, 0.1)]
        [InlineData(1, 2, 0.1)]
        [InlineData(1, 3, 0.1)]
        [InlineData(1, 4, 0.1)]
        [InlineData(2, 0, 0.1)]
        [InlineData(2, 1, 0.1)]
        [InlineData(2, 2, 0.1)]
        [InlineData(2, 3, 0.1)]
        [InlineData(2, 4, 0.1)]
        [InlineData(3, 0, 0.1)]
        [InlineData(3, 1, 0.1)]
        [InlineData(3, 2, 0.1)]
        [InlineData(3, 3, 0.1)]
        [InlineData(3, 4, 0.1)]
        public void RainbowTests(int squareSize, int depth, double borderProportion)
        {
            var testName = nameof(RainbowTests);
            var rendererOptions = new SquareTreeRendererOptions(squareSize)
            {
                BorderProportions = borderProportion
            };
            var renderer = new SquareTreeRenderer(rendererOptions);
            var tree = TreeUtilities.CreateRainbowPaintedSquareTree(squareSize, depth);
            var filename = FileUtilities.GetTestOutputPath(nameof(SquareTreeRendererTests), 
                $"{testName}_{squareSize}_{depth}_{borderProportion}.png");

            using (var img = renderer.Draw(tree, 600))
            {
                img.Save(filename, ImageFormat.Png);
            }
            
        }

        [Theory]
        [InlineData(2, 3)]
        public void RainbowBorderTests(int squareSize, int depth)
        {
            var minBorder = 0;
            var maxBorder = 0.2;
            var steps = 10;
            for (var i = 0; i < steps; i++)
            {
                var borderProportion = minBorder + (maxBorder - minBorder) * ((double)i / steps);
                var testName = nameof(RainbowBorderTests);
                var rendererOptions = new SquareTreeRendererOptions(squareSize)
                {
                    BorderProportions = borderProportion
                };
                var renderer = new SquareTreeRenderer(rendererOptions);
                var tree = TreeUtilities.CreateRainbowPaintedSquareTree(squareSize, depth);
                var filename = FileUtilities.GetTestOutputPath(nameof(SquareTreeRendererTests),
                    $"{testName}_{squareSize}_{depth}_{i}.png");

                using (var img = renderer.Draw(tree, 600))
                {
                    img.Save(filename, ImageFormat.Png);
                }
            }


        }
    }
}

