using System;

namespace opus
{
    public class Decoder : IDisposable
    {
        private bool _disposed;
        private int _frequency;
        private int _numChannels;
        private IntPtr _ptr;

        public Decoder(int freq, int numChannels, Application application)
        {
            int error = 0;
            _ptr = Opus.opus_decoder_create(freq, numChannels, out error);
        }

        public int Decode(byte[] compressed, int len, float[] result, int frame_size, int decode_fec)
        {
            return Opus.opus_decode_float(
                _ptr,
                compressed,
                len,
                result,
                frame_size, 
                decode_fec
            );
        }

        public int Decode(byte[] compressed, int len, short[] result, int frame_size, int decode_fec)
        {
            return Opus.opus_decode(
                _ptr,
                compressed,
                len,
                result,
                frame_size, 
                decode_fec
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
                        Opus.opus_decoder_destroy(_ptr);
                        _ptr = IntPtr.Zero;
                    }
                }
            }
        }
    }
}