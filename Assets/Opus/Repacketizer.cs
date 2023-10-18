using System;

namespace opus
{
    public class Repacketizer : IDisposable
    {
        private bool _disposed;
        private int _frequency;
        private int _numChannels;
        private IntPtr _ptr;

        public Repacketizer()
        {
            int error = 0;
            _ptr = Opus.opus_repacketizer_create();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_ptr != IntPtr.Zero)
                    {
                        Opus.opus_repacketizer_destroy(_ptr);
                        _ptr = IntPtr.Zero;
                    }
                }
            }
        }
    }
}