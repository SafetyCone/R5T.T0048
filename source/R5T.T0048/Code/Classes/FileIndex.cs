using System;
using System.Collections.Generic;


namespace R5T.T0048
{
    /// <summary>
    /// Index of unique file paths for general purposes.
    /// </summary>
    /// <remarks>
    /// File paths will be unique, so a <see cref="HashSet{T}"/> implementation makes sense.
    /// </remarks>
    public class FileIndex
    {
        public HashSet<string> FilePaths { get; } = new HashSet<string>();
    }
}