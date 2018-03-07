using System;
using Xunit;

namespace PrintNumber.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Exception_End_LessThan_Start()
        {
            Program p = new Program();
            var exception = Assert.Throws<ApplicationException>(() => p.print(100,11));
            Assert.Equal("start should be smaller than end", exception.Message);
        }

        [Theory]
        [InlineData(0, "0 Ansible Australia")]
        [InlineData(3, "3 Ansible")]
        [InlineData(5, "5 Australia")]
        [InlineData(10, "10 Australia")]
        [InlineData(15, "15 Ansible Australia")]
        [InlineData(21, "21 Ansible")]
        [InlineData(22, "22")]
        [InlineData(23, "23")]
        public void getline(int num, string str)
        {
            Program p = new Program();
          var s = p.getline(num);
            Assert.Equal(str,s);
        }
    }
}
