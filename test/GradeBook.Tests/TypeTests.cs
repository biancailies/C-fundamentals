using System;
using Xunit;

namespace GradeBook.Tests;

public delegate string WriteLogDelegate(string logMessage);


public class TypeTests
{
    int count = 0;
    [Fact]
    public void WriteLogDelegateCanPointToMethod()
    {
        WriteLogDelegate log2 = returnMessage;
        log2 += returnMessage;
        log2 += incrementCount;
        WriteLogDelegate log = new WriteLogDelegate(returnMessage); 

        var result = log("Hello!");
        Assert.Equal("Hello!", result);
        Assert.Equal(3, count);
    }

    string incrementCount(string Message)
    {
        return Message;
    }

    string returnMessage(string Message)
    {
        return Message;
    }

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

    private void GetBookSetName(ref InMemoryBook book, string name)
    {
        book = new InMemoryBook(name);
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

    private void GetBookSetName(InMemoryBook book, string name)
    {
        book = new InMemoryBook(name);
        book.Name = name;
    }

    [Fact]
    public void CanSetNameFromRef()
    {
        var book1 = GetBook(" Book 1 "); 
        SetName(book1, "NewName");

        Assert.Equal("NewName", book1.Name);
    }

    private void SetName(InMemoryBook book, string name)
    {
        book.Name = name;
    }

    [Fact]

    public void StringsBehaveLikeValueTypes()
    {
        string name = "Scott";
        var upper = MakeUppercase(name);

        Assert.Equal("Scott", name);
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

    InMemoryBook GetBook(string name)
    {
        return new InMemoryBook(name);
    }
}
