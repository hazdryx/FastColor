using Xunit;

namespace Hazdryx.Drawing.FastColorTests
{
    /// <summary>
    ///     A test class for argb32 operations in <code>FastColor</code>.
    /// </summary>
    public class Argb32Test
    {
        #region Explode Tests
        [Theory]
        [InlineData(unchecked ((int) 0xFF000000), 0xFF)]
        [InlineData(unchecked ((int) 0x8C5F77AD), 0x8C)]
        [InlineData(0, 0)]
        public void Explode_OutputsCorrectAlpha(int color, int expected)
        {
            FastColor.Explode(color, out int a, out _, out _, out _);
            Assert.Equal(expected, a);
        }
        [Theory]
        [InlineData(0xFF0000, 0xFF)]
        [InlineData(unchecked((int) 0x8C5F77AD), 0x5F)]
        [InlineData(0, 0)]
        public void Explode_OutputsCorrectRed(int color, int expected)
        {
            FastColor.Explode(color, out _, out int r, out _, out _);
            Assert.Equal(expected, r);
        }
        [Theory]
        [InlineData(0xFF00, 0xFF)]
        [InlineData(unchecked((int) 0x8C5F77AD), 0x77)]
        [InlineData(0, 0)]
        public void Explode_OutputsCorrectGreen(int color, int expected)
        {
            FastColor.Explode(color, out _, out _, out int g, out _);
            Assert.Equal(expected, g);
        }
        [Theory]
        [InlineData(0xFF, 0xFF)]
        [InlineData(unchecked((int) 0x8C5F77AD), 0xAD)]
        [InlineData(0, 0)]
        public void Explode_OutputsCorrectBlue(int color, int expected)
        {
            FastColor.Explode(color, out _, out _, out _, out int b);
            Assert.Equal(expected, b);
        }
        #endregion

        #region Implode Tests
        [Theory]
        [InlineData(0xFF, 0xFF, 0xFF, 0xFF, unchecked((int) 0xFFFFFFFF))]
        [InlineData(0, 0, 0, 0, 0)]
        [InlineData(0x8C, 0x5F, 0x77, 0xAD, unchecked((int) 0x8C5F77AD))]
        public void Implode_ReturnsCorrectValue(int a, int r, int g, int b, int expected)
        {
            int color = FastColor.Implode(a, r, g, b);
            Assert.Equal(expected, color);
        }
        #endregion

        #region Reverse Tests
        [Theory]
        [InlineData(0, 0)]
        [InlineData(unchecked((int) 0xFF000000), 0x000000FF)]
        [InlineData(0x00FF0000, 0x0000FF00)]
        [InlineData(0x0000FF00, 0x00FF0000)]
        [InlineData(0x000000FF, unchecked((int) 0xFF000000))]
        [InlineData(unchecked((int) 0x8C5F77AD), unchecked((int) 0xAD775F8C))]
        public void Reverse_ReturnsCorrectValue(int color, int expected)
        {
            Assert.Equal(expected, FastColor.Reverse(color));
        }
        #endregion

        #region SetAlpha Tests
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 0xFF, unchecked((int) 0xFF000000))]
        [InlineData(unchecked((int) 0x8C5F77AD), 0xCC, unchecked((int) 0xCC5F77AD))]
        public void SetAlpha_ReturnsCorrectValue(int color, int alpha, int expected)
        {
            int newColor = FastColor.SetAlpha(color, alpha);
            Assert.Equal(expected, newColor);
        }
        #endregion

        #region Math Operation Tests
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(unchecked((int) 0xFFFFFFFF), unchecked((int) 0xFFFFFFFF), unchecked((int) 0xFFFFFFFF))]
        [InlineData(unchecked((int) 0x8C5F77AD), unchecked((int) 0xCC375D5F), unchecked((int) 0xFF96D4FF))]
        [InlineData(unchecked((int) 0xCC375D5F), unchecked((int) 0x8C5F77AD), unchecked((int) 0xFF96D4FF))]
        public void Add_CalculatesCorrectly(int color1, int color2, int expected)
        {
            int result = FastColor.Add(color1, color2);
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(unchecked((int) 0xFFFFFFFF), unchecked((int) 0xFFFFFFFF), 0)]
        [InlineData(unchecked((int) 0x8C5F77AD), unchecked((int) 0xCC375D5F), 0x40000000)]
        [InlineData(unchecked((int) 0xCC375D5F), unchecked((int) 0x8C5F77AD), 0x00281A4E)]
        public void Sub_CalculatesCorrectly(int color1, int color2, int expected)
        {
            int result = FastColor.Sub(color1, color2);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(unchecked((int) 0xFFFFFFFF), unchecked((int) 0xFFFFFFFF), unchecked((int) 0xFFFFFFFF))]
        [InlineData(unchecked((int) 0x8C5F77AD), unchecked((int) 0xCC375D5F), 0x70142B40)]
        [InlineData(unchecked((int) 0xCC375D5F), unchecked((int) 0x8C5F77AD), 0x70142B40)]
        public void Mul_CalculatesCorrectly(int color1, int color2, int expected)
        {
            int result = FastColor.Mul(color1, color2);
            Assert.Equal(expected, result);
        }
        #endregion
    }
}