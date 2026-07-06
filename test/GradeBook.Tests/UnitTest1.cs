using System;
using Xunit;

namespace GradeBook.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        //arrange

        var book = new Book("");
        book.AddGrade(89.1);
        book.AddGrade(90.5);
        book.AddGrade(77.3);

        //act

        var res = book.GetStatistics();

        //assert

        Assert.Equal(85.6, res.Average, 1);
        Assert.Equal(90.5, res.highGrade);
        Assert.Equal(77.3, res.lowGrade);
    }
}
