using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuplicateCodeViewer.Core.Metadata;
using DuplicateCodeViewer.UI.Metadata;

namespace DuplicateCodeViewer.UI.Helper
{
    internal class AsyncLazyPropertiesLoader
    {
        private readonly List<FileInfo> _files;
        private readonly List<Duplicate> _duplicates;

        public AsyncLazyPropertiesLoader(List<FileInfo> files, List<Duplicate> duplicates)
        {
            _files = files.ToList();
            _duplicates = duplicates.ToList();
        }

        public event EventHandler OnItemUpdated;

        public void Execute()
        {
            var task = new Task(Work);
            task.Start();
        }

        private void Work()
        {
            foreach (var file in _files)
            {
                var cost = 0;
                var fragments = 0;
                var duplicates = new List<Duplicate>();
                foreach (var duplicate in _duplicates)
                {
                    if (duplicate.Fragments.Any(f => f.SourceFile == file.SourceFile))
                    {
                        fragments++;
                        cost += duplicate.Cost;
                        duplicates.Add(duplicate);
                    }
                }

                file.LazyCost = cost;
                file.LazyFragments = fragments;
                file.LazyDuplicates = duplicates.ToArray();
                OnItemUpdated?.Invoke(this, EventArgs.Empty);
            }
        }


    }
}
