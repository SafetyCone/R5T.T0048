using System;

using R5T.Magyar.T002;

using Instances = R5T.T0048.Instances;


namespace System
{
    public static class IExceptionGeneratorExtensions
    {
        public static InvalidOperationException FileIndexEntryAlreadyExists(this IExceptionGenerator _,
            string filePath)
        {
            var message = Instances.ExceptionMessageGenerator.FileIndexEntryAlreadyExists(filePath);

            var output = new InvalidOperationException(message);
            return output;
        }
    }
}
