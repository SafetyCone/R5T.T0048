using System;

using R5T.Magyar.T002;


namespace System
{
    public static class IExceptionMessageGeneratorExtensions
    {
        public static string FileIndexEntryAlreadyExists(this IExceptionMessageGenerator _,
            string filePath)
        {
            var output = $"File index entry already exists:\n{filePath}";
            return output;
        }
    }
}
