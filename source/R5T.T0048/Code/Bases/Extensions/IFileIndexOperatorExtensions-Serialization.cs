using System;
using System.IO;
using System.Linq;

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
            FileHelper.WriteAllLinesSynchronous(
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

            FileHelper.WriteAllLinesSynchronous(
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
