namespace ClassSplitter.Tests;
using Xunit;
using System.Reflection;

public class SplitInterfacesStructTests
{
    [Fact]
    public void Given_OneFile_With_OneClass_And_OneInterface_Should_Create_Two_Files()
    {
        // Arrange      
        var fullPathLocationTestAssembly = new DirectoryInfo(Assembly.GetExecutingAssembly().Location);
        if(fullPathLocationTestAssembly.Parent == null) Assert.Fail("Executing Assembly directory not exists");

        var sourceFileDirectoryPath = fullPathLocationTestAssembly.Parent.FullName;
        var sourcefilePath =  Path.Combine(fullPathLocationTestAssembly.Parent.FullName, "SmallFile.cs");
        var destinationDirectoryPath = Path.Combine(fullPathLocationTestAssembly.Parent.FullName, "SplitSmallFile");
        
        //Act 
        Program.Main([sourceFileDirectoryPath]);

        //Arrange
        Assert.True(File.Exists(sourcefilePath));
        Assert.Equal(2, Directory.GetFiles(destinationDirectoryPath, "*_Splitted.cs").Length);
    }

    [Fact]
    public void Given_OneFile_With_OneClass_And_Struct_Should_Create_Two_Files()
    {
        // Arrange      
        var fullPathLocationTestAssembly = new DirectoryInfo(Assembly.GetExecutingAssembly().Location);
        if(fullPathLocationTestAssembly.Parent == null) Assert.Fail("Executing Assembly directory not exists");

        var sourceFileDirectoryPath = fullPathLocationTestAssembly.Parent.FullName;
        var sourcefilePath =  Path.Combine(fullPathLocationTestAssembly.Parent.FullName, "SmallFileWithStruct.cs");
        var destinationDirectoryPath = Path.Combine(fullPathLocationTestAssembly.Parent.FullName, "SplitSmallFile");
        
        //Act 
        Program.Main([sourceFileDirectoryPath]);

        //Arrange
        Assert.True(File.Exists(sourcefilePath));
        Assert.Equal(2, Directory.GetFiles(destinationDirectoryPath, "*_Splitted.cs").Length);
    }
}