using System;

namespace Demo.MusicLibrary.Api.DataAccess.Database
{
    internal class DataProvider : IDisposable
    {
        private readonly bool _dispose;

        public DataProvider(MusicLibraryContext context)
        {
            _dispose = context == null;
            Context = context ?? new MusicLibraryContext();
        }

        public MusicLibraryContext Context { get; private set; }

        public void Dispose()
        {
            if (!_dispose) return;
            Context?.Dispose();
            Context = null;
        }
    }
}
