using System;


namespace R5T.T0048
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class FileIndexOperator : IFileIndexOperator
    {
        #region Static
        
        public static FileIndexOperator Instance { get; } = new();

        #endregion
    }
}