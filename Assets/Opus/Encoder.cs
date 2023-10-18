using System;

namespace opus
{
    public class Encoder : IDisposable
    {
        private bool _disposed;
        private int _frequency;
        private int _numChannels;
        private Application _application;
        private IntPtr _ptr;

        public Encoder(int freq, int numChannels, Application application)
        {
            int error = 0;
            _ptr = Opus.opus_encoder_create(freq, numChannels, (int) application, out error);
        }

        public int Encode(float[] pcm, int frame_size, byte[] result, int max_data_bytes)
        {
            return Opus.opus_encode_float(
                _ptr,
                pcm,
                frame_size,
                result,
                max_data_bytes
            );
        }

        public int Encode(short[] pcm, int frame_size, byte[] result, int max_data_bytes)
        {
            return Opus.opus_encode(
                _ptr,
                pcm,
                frame_size,
                result,
                max_data_bytes
            );
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
                        Opus.opus_encoder_destroy(_ptr);
                        _ptr = IntPtr.Zero;
                    }
                }
            }
        }
    }
}