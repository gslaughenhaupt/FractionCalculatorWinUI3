using FractionCalculatorWinUI3.ViewModels;
namespace TestProject2;

[TestClass]
public class UnitTest1
{
    readonly MainViewModel vm = new();

    [TestMethod]
    [DataRow(0, 1, 4, 0, 1, 4, 0, 1, 2, ".5")]
    [DataRow(1, 1, 4, 2, 3, 4, 4, 0, 0, "4")]
    public void TestAddCalculation(int leftWhole, int leftTop, int leftBottom, 
                                int rightWhole, int rightTop, int rightBottom,
                                int expectedWhole, int expectedTop, int expectedBottom, string expectedResultDecimal)
    {
        vm.LeftWhole = leftWhole;
        vm.RightWhole = rightWhole;
        vm.LeftTop=leftTop; 
        vm.RightTop=rightTop;
        vm.LeftBottom=leftBottom;
        vm.RightBottom=rightBottom;
        vm.AddCommand.Execute(vm);
        Assert.AreEqual(expectedWhole, vm.ResultWhole);
        Assert.AreEqual(expectedTop, vm.ResultTop); 
        Assert.AreEqual(expectedBottom, vm.ResultBottom);
        Assert.AreEqual(vm.ResultAsDecimal, expectedResultDecimal);
    }
    [TestMethod]
    [DataRow(0, 1, 4, 0, 1, 4, 0, 0, 0, "0")]
    [DataRow(1, 1, 4, 2, 3, 4, 4, 0, 0, "4")]
    public void TestSubtractCalculation(int leftWhole, int leftTop, int leftBottom,
                            int rightWhole, int rightTop, int rightBottom,
                            int expectedWhole, int expectedTop, int expectedBottom, string expectedResultDecimal)
    {
        vm.LeftWhole = leftWhole;
        vm.RightWhole = rightWhole;
        vm.LeftTop = leftTop;
        vm.RightTop = rightTop;
        vm.LeftBottom = leftBottom;
        vm.RightBottom = rightBottom;
        vm.SubtractCommand.Execute(vm);
        Assert.AreEqual(expectedWhole, vm.ResultWhole);
        Assert.AreEqual(expectedTop, vm.ResultTop);
        Assert.AreEqual(expectedBottom, vm.ResultBottom);
        Assert.AreEqual(vm.ResultAsDecimal, expectedResultDecimal);
    }
}