using System;
using System.Collections.Generic;

using R5T.Magyar;

using R5T.T0048;

using Instances = R5T.T0048.Instances;


namespace System
{
    public static partial class IFileIndexOperatorExtensions
    {
        public static void AddEntryIdempotent(this IFileIndexOperator _,
            FileIndex index,
            string filePath)
        {
            index.FilePaths.Add(filePath); // HashSet<T> takes care of the idempotency.
        }

        public static void AddEntryNonIdempotent(this IFileIndexOperator _,
            FileIndex index,
            string filePath)
        {
            var hasEntry = _.HasEntry(index, filePath);
            if (hasEntry)
            {
                throw Instances.ExceptionGenerator.FileIndexEntryAlreadyExists(filePath);
            }

            _.AddEntryIdempotent(index, filePath);
        }

        /// <summary>
        /// Chooses <see cref="AddEntryIdempotent(IFileIndexOperator, FileIndex, string)"/> as the default.
        /// </summary>
        public static void AddEntry(this IFileIndexOperator _,
            FileIndex index,
            string filePath)
        {
            _.AddEntryIdempotent(index, filePath);
        }

        public static void AddEntriesIdempotent(this IFileIndexOperator _,
            FileIndex index,
            IEnumerable<string> filePaths)
        {
            index.FilePaths.AddRange(filePaths); // HashSet<T> takes care of the idempotency.
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="AddEntriesIdempotent(IFileIndexOperator, FileIndex, IEnumerable{string})"/>.
        /// </summary>
        public static void AddEntries(this IFileIndexOperator _,
            FileIndex index,
            IEnumerable<string> filePaths)
        {
            _.AddEntriesIdempotent(index, filePaths);
        }

        public static void ClearEntries(this IFileIndexOperator _,
            FileIndex index)
        {
            index.FilePaths.Clear();
        }

        public static WasFound<string> HasEntry(this IFileIndexOperator _,
            FileIndex index,
            string filePath)
        {
            var exists = index.FilePaths.Contains(filePath);

            var result = exists
                ? filePath
                : default
                ;

            var output = WasFound.From(exists, result);
            return output;
        }

        public static void ReplaceEntries(this IFileIndexOperator _,
            FileIndex index,
            IEnumerable<string> newFilePaths)
        {
            _.ClearEntries(index);

            _.AddEntries(index, newFilePaths);
        }
    }
}
