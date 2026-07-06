using System;
using Xunit;

namespace GradeBook.Tests;

public class TypeTests
{

    [Fact]
    public void ValueTypeAlsoPassByValue()
    {
        var x = GetInt();
        SetInt(ref x);

        Assert.Equal(42, x);
    }

    private void SetInt(ref int x)
    {
        x = 42;
    }

    private int GetInt()
    {
       return 3;
    }

    [Fact]
    public void CSharpCanPassByRef()
    {
        var book1 = GetBook(" Book 1 "); 
        GetBookSetName( ref book1, "NewName");

        Assert.Equal("NewName", book1.Name);
    }

    private void GetBookSetName(ref Book book, string name)
    {
        book = new Book(name);
    }

    // you can use either ref or out, the outcome is the same, 
    // the only difference is that you MUST init the value with out

    [Fact]
    public void CSharpIsPassByValue()
    {
        var book1 = GetBook(" Book 1 "); 
        GetBookSetName(book1, "NewName");

        Assert.Equal(" Book 1 ", book1.Name);
    }

    private void GetBookSetName(Book book, string name)
    {
        book = new Book(name);
        book.Name = name;
    }

    [Fact]
    public void CanSetNameFromRef()
    {
        var book1 = GetBook(" Book 1 "); 
        SetName(book1, "NewName");

        Assert.Equal("NewName", book1.Name);
    }

    private void SetName(Book book, string name)
    {
        book.Name = name;
    }

    [Fact]

    public void StringsBehaveLikeValueTypes()
    {
        string name = "Scott";
        var upper = MakeUppercase(name);

        Assert.Equal("Scot", name);
        Assert.Equal("SCOTT", upper);
    }

    private string MakeUppercase(string parm)
    {
        return parm.ToUpper();
    }

    [Fact]
    public void GetBookReturnDifferentObj()
    {
        var book1 = GetBook(" Book 1 "); 
        var book2 = GetBook(" Book 2 "); 

        Assert.Equal(" Book 1 ", book1.Name);
        Assert.Equal(" Book 2 ", book2.Name);

        Assert.NotSame(book1, book2);
    }

    [Fact]
    public void TwoVarsCanRefSameObj()
    {
        var book1 = GetBook(" Book 1 "); 
        var book2 = book1; 

        Assert.Equal(" Book 1 ", book1.Name);
        Assert.Equal(" Book 1 ", book1.Name);

        Assert.Same(book2, book1);

        Assert.True(Object.ReferenceEquals(book1, book2));
    }

    Book GetBook(string name)
    {
        return new Book(name);
    }
}
