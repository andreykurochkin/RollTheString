using FluentAssertions;
using RollTheString.Src;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace RollTheString;

public class ArraysTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { new List<int> { 1, 2, 3 }, new List<int> { 3, 2, 1 } };
        yield return new object[] { new List<int> { 3, 2, 1 }, new List<int> { 3, 2, 1 } };
        yield return new object[] { new List<int> { 1, 1, 3, 4 }, new List<int> { 4, 2, 2, 1 } };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class ResultTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public ResultTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Theory]
    [ClassData(typeof(ArraysTestData))]
    public void RollOperations_ShouldReturnExpectedList(List<int> data, List<int> expected)
    {
        var result = Result.RollOperations(data);

        result.Should().Equal(expected);
        _testOutputHelper.WriteLine(String.Join(',', result));
    }
}