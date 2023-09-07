using System.Text;
using System.Text.RegularExpressions;

namespace Tests.RunLogic.Attributes.Utilities;

public static class CoverletRunsettingsConfig
{
     internal static void UpdateCodeCoverletRunsettings(int homeworkNumber, string coverletRunsettingsPath = ".github/coverlet.runsettings", string studentExcludesPath = ".github/coverlet.runsettings.studentExcludes.txt")
    {
        var rootPath = TryGetSolutionDirectoryInfo().FullName;
        
        // get the coverlet.runsettings file content
        var coverletRunsettingsFullPath = Path.Combine(rootPath, coverletRunsettingsPath);
        if (!File.Exists(coverletRunsettingsFullPath))
        {
            throw new FileNotFoundException("coverlet.runsettings file not found.", coverletRunsettingsFullPath);
        }
        var coverletRunsettingsContent = File.ReadAllText(coverletRunsettingsFullPath);

        // Find the ExcludeByFile tag using a regular expression
        var match = Regex.Match(coverletRunsettingsContent, @"<ExcludeByFile>(.*?)<\/ExcludeByFile>", RegexOptions.Singleline);
        if (!match.Success)
        {
            throw new InvalidOperationException("ExcludeByFile tag not found in coverlet.runsettings file.");
        }
        
        // separate the ExcludeByFile tag into two parts: the tag itself and the content
        var excludeByFileTag = match.Groups[0].Value;
        var excludeByFileContent = match.Groups[1].Value;
        
        // get the studentExcludes file content
        var studentExcludesFullPath = Path.Combine(rootPath, studentExcludesPath);
        var studentCustomExcludesContent = File.Exists(studentExcludesFullPath) 
            ? File.ReadAllText(studentExcludesFullPath) : string.Empty;

        // Build the updated ExcludeByFile content based on the homework number
        var updatedExcludeByFileContentStr = GenerateUpdatedExcludesContent(studentCustomExcludesContent, homeworkNumber);
        if (excludeByFileContent == updatedExcludeByFileContentStr) return;
        
        // Construct the updated coverlet.runsettings file content
        var newCoverletRunsettingsContent = UpdateFileContent(coverletRunsettingsContent, excludeByFileTag, excludeByFileContent, updatedExcludeByFileContentStr);
        File.WriteAllText(coverletRunsettingsFullPath, newCoverletRunsettingsContent);

    }

    private static string UpdateFileContent(string fileFullContent, string olgTag, string oldTagContent, string newTagContent)
    {
        // Construct the updated ExcludeByFile tag
        var updatedTag = olgTag.Replace(oldTagContent, newTagContent);

        // Replace the old ExcludeByFile tag with the updated one in the file content
        var updatedFileContent = fileFullContent.Replace(olgTag, updatedTag);

        return updatedFileContent;
    }
    
    private static string GenerateUpdatedExcludesContent(string userCustomExcludes, int homeworkNumber)
    {
        var updatedExcludeByFileContent = new StringBuilder("**/Tests.RunLogic/**,**/*.cshtml,**/Hw*/Program.cs,**/Hw*/Program.fs");
        if (!string.IsNullOrWhiteSpace(userCustomExcludes))
            updatedExcludeByFileContent.Append(',');
        updatedExcludeByFileContent.Append(userCustomExcludes);
        
        var beginWith = (Homeworks)homeworkNumber == Homeworks.Init 
            ? homeworkNumber + 2 : homeworkNumber + 1;
        for (var i = beginWith; i < Enum.GetNames(typeof(Homeworks)).Length; i++)
        {
            updatedExcludeByFileContent.Append( $",**/Homework{i}/**");
        }

        return updatedExcludeByFileContent.ToString();
    }
    
    private static DirectoryInfo TryGetSolutionDirectoryInfo()
    {
        var directory = new DirectoryInfo(Directory.GetCurrentDirectory());
        while (directory != null && !directory.GetFiles("*.sln").Any())
        {
            directory = directory.Parent;
        }
        return directory;
    }
}