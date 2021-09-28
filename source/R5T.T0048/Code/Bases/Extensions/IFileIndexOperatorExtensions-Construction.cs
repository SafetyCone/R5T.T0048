using System;
using System.Collections.Generic;

using R5T.T0048;


namespace System
{
    public static partial class IFileIndexOperatorExtensions
    {
        public static FileIndex From(this IFileIndexOperator _,
            IEnumerable<string> extensionMethodBaseFilePaths)
        {
            var output = _.New();

            _.AddEntries(output, extensionMethodBaseFilePaths);

            return output;
        }

        public static FileIndex New(this IFileIndexOperator _)
        {
            var output = new FileIndex();
            return output;
        }
    }
}
