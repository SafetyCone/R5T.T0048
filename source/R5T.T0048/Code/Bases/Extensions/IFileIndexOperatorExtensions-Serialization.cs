using System;
using System.IO;

using R5T.Magyar;
using R5T.Magyar.Extensions;

using R5T.T0048;


namespace System
{
    public static partial class IFileIndexOperatorExtensions
    {
        public static void WriteToTextFileWithoutAlphabetization(this IFileIndexOperator _,
            string textFilePath,
            FileIndex index,
            bool overwrite = IOHelper.DefaultOverwriteValue)
        {
            FileHelper.WriteAllLines_Synchronous(
                textFilePath,
                index.FilePaths,
                overwrite);
        }

        public static void WriteToTextFile(this IFileIndexOperator _,
            string textFilePath,
            FileIndex index,
            bool overwrite = IOHelper.DefaultOverwriteValue)
        {
            var outputLines = index.FilePaths
                .OrderAlphabetically()
                ;

            FileHelper.WriteAllLines_Synchronous(
                textFilePath,
                outputLines,
                overwrite);
        }

        public static FileIndex LoadFromTextFile(this IFileIndexOperator _,
            string textFilePath)
        {
            var projectFilePaths = FileHelper.ReadAllLinesSynchronous(textFilePath);

            var output = _.From(projectFilePaths);
            return output;
        }
    }
}
