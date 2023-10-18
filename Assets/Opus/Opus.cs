using System;
using System.Runtime.InteropServices;

namespace opus
{
    public class Opus
    {
        public const string _dllName = "libopus";

        public const int OPUS_OK = 0;
        public const int OPUS_BAD_ARG = -1;
        public const int OPUS_BUFFER_TOO_SMALL = -2;
        public const int OPUS_INTERNAL_ERROR = -3;
        public const int OPUS_INVALID_PACKET = -4;
        public const int OPUS_UNIMPLEMENTED = -5;
        public const int OPUS_INVALID_STATE = -6;
        public const int OPUS_ALLOC_FAIL = -7;

        public const int OPUS_AUTO = -1000;

        /**<Auto/default setting @hideinitializer*/
        public const int OPUS_BITRATE_MAX = -1;

        /**<Maximum bitrate @hideinitializer*/
        /** Best for most VoIP/videoconference applications where listening quality and intelligibility matter most
         * @hideinitializer */
        public const int OPUS_APPLICATION_VOIP = 2048;

        /** Best for broadcast/high-fidelity application where the decoded audio should be as close as possible to the input
         * @hideinitializer */
        public const int OPUS_APPLICATION_AUDIO = 2049;

        /** Only use when lowest-achievable latency is what matters most. Voice-optimized modes cannot be used.
         * @hideinitializer */
        public const int OPUS_APPLICATION_RESTRICTED_LOWDELAY = 2051;

        public const int OPUS_SIGNAL_VOICE = 3001;

        /**< Signal being encoded is voice */
        public const int OPUS_SIGNAL_MUSIC = 3002;

        /**< Signal being encoded is music */
        public const int OPUS_BANDWIDTH_NARROWBAND = 1101;

        /**< 4 kHz bandpass @hideinitializer*/
        public const int OPUS_BANDWIDTH_MEDIUMBAND = 1102;

        /**< 6 kHz bandpass @hideinitializer*/
        public const int OPUS_BANDWIDTH_WIDEBAND = 1103;

        /**< 8 kHz bandpass @hideinitializer*/
        public const int OPUS_BANDWIDTH_SUPERWIDEBAND = 1104;

        /**<12 kHz bandpass @hideinitializer*/
        public const int OPUS_BANDWIDTH_FULLBAND = 1105;

        /**<20 kHz bandpass @hideinitializer*/
        public const int OPUS_FRAMESIZE_ARG = 5000;

        /**< Select frame size from the argument (default) */
        /**< Use 2.5 ms frames */
        public const int OPUS_FRAMESIZE_2_5_MS = 5001;

        /**< Use 5 ms frames */
        public const int OPUS_FRAMESIZE_5_MS = 5002;

        /**< Use 10 ms frames */
        public const int OPUS_FRAMESIZE_10_MS = 5003;

        /**< Use 20 ms frames */
        public const int OPUS_FRAMESIZE_20_MS = 5004;

        /**< Use 40 ms frames */
        public const int OPUS_FRAMESIZE_40_MS = 5005;

        /**< Use 60 ms frames */
        public const int OPUS_FRAMESIZE_60_MS = 5006;

        /**< Use 80 ms frames */
        public const int OPUS_FRAMESIZE_80_MS = 5007;

        /**< Use 100 ms frames */
        public const int OPUS_FRAMESIZE_100_MS = 5008;

        /**< Use 120 ms frames */
        public const int OPUS_FRAMESIZE_120_MS = 5009;


        // public const int OPUS_RESET_STATE 4028

        public const int OPUS_GET_SAMPLE_RATE_REQUEST = 4029;
        public const int OPUS_GET_FINAL_RANGE_REQUEST = 4031;
        public const int OPUS_GET_PITCH_REQUEST = 4033;
        public const int OPUS_SET_GAIN_REQUEST = 4034;
        public const int OPUS_GET_GAIN_REQUEST = 4045; /* Should have been 4035 */
        public const int OPUS_SET_LSB_DEPTH_REQUEST = 4036;
        public const int OPUS_GET_LSB_DEPTH_REQUEST = 4037;
        public const int OPUS_GET_LAST_PACKET_DURATION_REQUEST = 4039;
        public const int OPUS_SET_EXPERT_FRAME_DURATION_REQUEST = 4040;
        public const int OPUS_GET_EXPERT_FRAME_DURATION_REQUEST = 4041;
        public const int OPUS_SET_PREDICTION_DISABLED_REQUEST = 4042;

        public const int OPUS_GET_PREDICTION_DISABLED_REQUEST = 4043;

        /* Don't use 4045, it's already taken by OPUS_GET_GAIN_REQUEST */
        public const int OPUS_SET_PHASE_INVERSION_DISABLED_REQUEST = 4046;
        public const int OPUS_GET_PHASE_INVERSION_DISABLED_REQUEST = 4047;
        public const int OPUS_GET_IN_DTX_REQUEST = 4049;


        // Opus Encoder
        [DllImport(_dllName)]
        public static extern int opus_encoder_get_size(int channel);

        [DllImport(_dllName)]
        public static extern IntPtr opus_encoder_create(Int32 Fs, int channels, int application, out int error);

        [DllImport(_dllName)]
        public static extern int opus_encoder_init(IntPtr st, Int32 Fs, int channels, int application);

        [DllImport(_dllName)]
        public static extern int opus_encode(IntPtr st,
            [In, MarshalAs(UnmanagedType.LPArray)] short[] pcm,
            int framesize,
            [Out, MarshalAs(UnmanagedType.LPArray)]
            byte[] data,
            int max_data_bytes);

        [DllImport(_dllName)]
        public static extern int opus_encode_float(
            IntPtr st,
            [In, MarshalAs(UnmanagedType.LPArray)] float[] pcm,
            int frame_size,
            [Out, MarshalAs(UnmanagedType.LPArray)]
            byte[] data,
            int max_data_bytes
        );

        [DllImport(_dllName)]
        public static extern void opus_encoder_destroy(IntPtr st);

        [DllImport(_dllName)]
        public static extern int opus_encoder_ctl_set_complexity(IntPtr st, Int32 val);

        [DllImport(_dllName)]
        public static extern int opus_encoder_ctl_get_complexity(IntPtr st, out Int32 val);

        [DllImport(_dllName)]
        public static extern int opus_encoder_ctl_set_bitrate(IntPtr st, Int32 val);

        [DllImport(_dllName)]
        public static extern int opus_encoder_ctl_get_bitrate(IntPtr st, out Int32 val);

        [DllImport(_dllName)]
        public static extern int opus_encoder_ctl_set_vbr(IntPtr st, Int32 val);

        [DllImport(_dllName)]
        public static extern int opus_encoder_ctl_get_vbr(IntPtr st, out Int32 val);

        [DllImport(_dllName)]
        public static extern int opus_encoder_ctl_set_vbr_constraint(IntPtr st, Int32 val);

        [DllImport(_dllName)]
        public static extern int opus_encoder_ctl_get_vbr_constraint(IntPtr st, out Int32 val);

        [DllImport(_dllName)]
        public static extern int opus_encoder_ctl_set_force_channels(IntPtr st, Int32 val);

        [DllImport(_dllName)]
        public static extern int opus_encoder_ctl_get_force_channels(IntPtr st, out Int32 val);

        [DllImport(_dllName)]
        public static extern int opus_encoder_ctl_set_max_bandwidth(IntPtr st, Int32 val);

        [DllImport(_dllName)]
        public static extern int opus_encoder_ctl_get_max_bandwidth(IntPtr st, out Int32 val);

        [DllImport(_dllName)]
        public static extern int opus_encoder_ctl_set_bandwidth(IntPtr st, Int32 val);

        [DllImport(_dllName)]
        public static extern int opus_encoder_ctl_get_bandwidth(IntPtr st, out Int32 val);

        [DllImport(_dllName)]
        public static extern int opus_encoder_ctl_set_signal(IntPtr st, Int32 val);

        [DllImport(_dllName)]
        public static extern int opus_encoder_ctl_get_signal(IntPtr st, out Int32 val);

        [DllImport(_dllName)]
        public static extern int opus_encoder_ctl_set_application(IntPtr st, Int32 val);

        [DllImport(_dllName)]
        public static extern int opus_encoder_ctl_get_application(IntPtr st, out Int32 val);

        [DllImport(_dllName)]
        public static extern int opus_encoder_ctl_get_lookahead(IntPtr st, out Int32 val);

        [DllImport(_dllName)]
        public static extern int opus_encoder_ctl_set_inband_fec(IntPtr st, Int32 val);

        [DllImport(_dllName)]
        public static extern int opus_encoder_ctl_get_inband_fec(IntPtr st, out Int32 val);

        [DllImport(_dllName)]
        public static extern int opus_encoder_ctl_set_packet_loss_perc(IntPtr st, Int32 val);

        [DllImport(_dllName)]
        public static extern int opus_encoder_ctl_get_packet_loss_perc(IntPtr st, out Int32 val);

        [DllImport(_dllName)]
        public static extern int opus_encoder_ctl_set_dtx(IntPtr st, Int32 val);

        [DllImport(_dllName)]
        public static extern int opus_encoder_ctl_get_dtx(IntPtr st, out Int32 val);


        // Opus Decoder
        [DllImport(_dllName)]
        public static extern int opus_decoder_get_size(int channels);

        [DllImport(_dllName)]
        public static extern IntPtr opus_decoder_create(Int32 Fs, int channels, out int error);

        [DllImport(_dllName)]
        public static extern int opus_decoder_init(IntPtr st, Int32 Fs, int channels);

        [DllImport(_dllName)]
        public static extern int opus_decode(IntPtr st,
            [In, MarshalAs(UnmanagedType.LPArray)] byte[] data,
            Int32 len,
            [Out, MarshalAs(UnmanagedType.LPArray)]
            short[] pcm,
            int frame_size,
            int decode_fec);

        [DllImport(_dllName)]
        public static extern int opus_decode_float(
            IntPtr st,
            [In, MarshalAs(UnmanagedType.LPArray)] byte[] data,
            Int32 len,
            [Out, MarshalAs(UnmanagedType.LPArray)]
            float[] pcm,
            int frame_size,
            int decode_fec);

        [DllImport(_dllName)]
        public static extern int opus_decoder_ctl_reset_state(IntPtr st);

        [DllImport(_dllName)]
        public static extern int opus_decoder_ctl_get_final_range(IntPtr st, out UInt32 val);

        [DllImport(_dllName)]
        public static extern int opus_decoder_ctl_get_pitch(IntPtr st, out Int32 val);

        [DllImport(_dllName)]
        public static extern int opus_decoder_ctl_get_bandwidth(IntPtr st, out Int32 val);

        [DllImport(_dllName)]
        public static extern int opus_decoder_destroy(IntPtr st);

        [DllImport(_dllName)]
        public static extern int opus_packet_parse(
            [In, MarshalAs(UnmanagedType.LPArray)] byte[] data,
            int len,
            [Out] out byte out_toc,
            [Out] out IntPtr[] frames,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 48)]
            out short[] size,
            out int payload_offset
        );

        [DllImport(_dllName)]
        public static extern int opus_packet_get_bandwidth([In, MarshalAs(UnmanagedType.LPArray)] byte[] data);

        [DllImport(_dllName)]
        public static extern int opus_packet_get_samples_per_frame(
            [In, MarshalAs(UnmanagedType.LPArray)] byte[] data,
            int Fs
        );

        [DllImport(_dllName)]
        public static extern int opus_packet_get_nb_channels([In, MarshalAs(UnmanagedType.LPArray)] byte[] data);


        [DllImport(_dllName)]
        public static extern int opus_packet_get_nb_frames(
            [In, MarshalAs(UnmanagedType.LPArray)] byte[] packet,
            int len
        );

        [DllImport(_dllName)]
        public static extern int opus_packet_get_nb_samples(
            [In, MarshalAs(UnmanagedType.LPArray)] byte[] packet,
            Int32 len, Int32 Fs);

        [DllImport(_dllName)]
        public static extern int opus_decoder_get_nb_samples(
            IntPtr dec,
            [In, MarshalAs(UnmanagedType.LPArray)] byte[] packet,
            Int32 len);

        [DllImport(_dllName)]
        public static extern void opus_pcm_soft_clip(
            [In, Out, MarshalAs(UnmanagedType.LPArray)]
            float[] pcm,
            int frame_size,
            int channels,
            [In, Out, MarshalAs(UnmanagedType.LPArray)]
            float[] softclip_mem
        );

        // Repacketizer
        [DllImport(_dllName)]
        public static extern int opus_repacketizer_get_size();

        [DllImport(_dllName)]
        public static extern IntPtr opus_repacketizer_init(IntPtr rp);

        [DllImport(_dllName)]
        public static extern IntPtr opus_repacketizer_create();

        [DllImport(_dllName)]
        public static extern void opus_repacketizer_destroy(IntPtr rp);

        [DllImport(_dllName)]
        public static extern int opus_repacketizer_cat(
            IntPtr rp,
            [In, MarshalAs(UnmanagedType.LPArray)] byte[] data,
            int len
        );

        [DllImport(_dllName)]
        public static extern int opus_repacketizer_out_range(
            IntPtr rp,
            int begin,
            int end,
            [Out, MarshalAs(UnmanagedType.LPArray)]
            byte[] data,
            int maxlen
        );

        [DllImport(_dllName)]
        public static extern int opus_repacketizer_get_nb_frames(IntPtr rp);


        [DllImport(_dllName)]
        public static extern Int32 opus_repacketizer_out(
            IntPtr rp,
            [Out, MarshalAs(UnmanagedType.LPArray)]
            byte[] data,
            Int32 maxlen);

        [DllImport(_dllName)]
        public static extern int opus_packet_pad(
            [In, Out, MarshalAs(UnmanagedType.LPArray)]
            byte[] data,
            int len,
            int new_len
        );

        [DllImport(_dllName)]
        public static extern Int32 opus_packet_unpad(
            [In, Out, MarshalAs(UnmanagedType.LPArray)]
            byte[] data,
            Int32 len);


        [DllImport(_dllName)]
        public static extern int opus_multistream_packet_pad(
            [In, Out, MarshalAs(UnmanagedType.LPArray)]
            byte[] data,
            Int32 len,
            Int32 new_len,
            int nb_streams);

        [DllImport(_dllName)]
        public static extern Int32 opus_multistream_packet_unpad(
            [In, Out, MarshalAs(UnmanagedType.LPArray)]
            byte[] data,
            Int32 len,
            int nb_streams);

        // Opus Multistream API

        // Multistream encoder functions
        [DllImport(_dllName)]
        public static extern Int32 opus_multistream_encoder_get_size(int streams, int coupled_streams);

        [DllImport(_dllName)]
        public static extern Int32 opus_multistream_surround_encoder_get_size(int channels, int mapping_family);

        [DllImport(_dllName)]
        public static extern IntPtr opus_multistream_encoder_create(
            int Fs,
            int channels,
            int streams,
            int coupled_streams,
            [In, MarshalAs(UnmanagedType.LPArray)] byte[] mapping,
            int application,
            out int error
        );


        [DllImport(_dllName)]
        public static extern IntPtr opus_multistream_surround_encoder_create(
            int Fs,
            int channels,
            int mapping_family,
            out int streams,
            out int coupled_streams,
            [Out, MarshalAs(UnmanagedType.LPArray)]
            byte[] mapping,
            int application,
            out int error
        );


        [DllImport(_dllName)]
        public static extern int opus_multistream_encoder_init(
            IntPtr st,
            Int32 Fs,
            int channels,
            int streams,
            int coupled_streams,
            [Out, MarshalAs(UnmanagedType.LPArray)]
            byte[] mapping,
            int application);

        [DllImport(_dllName)]
        public static extern int opus_multistream_surround_encoder_init(
            IntPtr st,
            Int32 Fs,
            int channels,
            int mapping_family,
            out int streams,
            out int coupled_streams,
            [Out, MarshalAs(UnmanagedType.LPArray)]
            byte[] mapping,
            int application);

        [DllImport(_dllName)]
        public static extern int opus_multistream_encode(
            IntPtr st,
            [In, MarshalAs(UnmanagedType.LPArray)] short[] pcm,
            int frame_size,
            [Out, MarshalAs(UnmanagedType.LPArray)]
            byte[] data,
            int max_data_bytes
        );


        [DllImport(_dllName)]
        public static extern int opus_multistream_encode_float(
            IntPtr st,
            [In, MarshalAs(UnmanagedType.LPArray)] float[] pcm,
            int frame_size,
            [Out, MarshalAs(UnmanagedType.LPArray)]
            byte[] data,
            Int32 max_data_bytes);

        [DllImport(_dllName)]
        public static extern void opus_multistream_encoder_destroy(IntPtr st);

        //int opus_multistream_encoder_ctl (OpusMSEncoder *st, int request,...)

        //Multistream decoder functions

        [DllImport(_dllName)]
        public static extern Int32 opus_multistream_decoder_get_size(int streams, int coupled_streams);

        [DllImport(_dllName)]
        public static extern IntPtr opus_multistream_decoder_create(
            Int32 Fs,
            int channels,
            int streams,
            int coupled_streams,
            [Out, MarshalAs(UnmanagedType.LPArray)]
            byte[] mapping,
            out int error);

        [DllImport(_dllName)]
        public static extern int opus_multistream_decoder_init(
            IntPtr st,
            Int32 Fs,
            int channels,
            int streams,
            int coupled_streams,
            [Out, MarshalAs(UnmanagedType.LPArray)]
            byte[] mapping);

        [DllImport(_dllName)]
        public static extern int opus_multistream_decode(
            IntPtr st,
            [In, MarshalAs(UnmanagedType.LPArray)] byte[] data,
            int len,
            [Out, MarshalAs(UnmanagedType.LPArray)]
            short[] pcm,
            int frame_size,
            int decode_fec
        );

        [DllImport(_dllName)]
        public static extern int opus_multistream_decode_float(
            IntPtr st,
            [In, MarshalAs(UnmanagedType.LPArray)] byte[] data,
            Int32 len,
            [Out, MarshalAs(UnmanagedType.LPArray)]
            float[] pcm,
            int frame_size,
            int decode_fec);

        //opus_multistream_decoder_ctl (OpusMSDecoder *st, int request,...)

        [DllImport(_dllName)]
        public static extern void opus_multistream_decoder_destroy(IntPtr st);


        // Opus library information functions
        [DllImport(_dllName)]
        public static extern IntPtr opus_strerror(int error);

        [DllImport(_dllName)]
        public static extern IntPtr opus_get_version_string();


        // Utility methods
        public static string GetVersionString()
        {
            var ptr = opus_get_version_string();
            return Marshal.PtrToStringAnsi(ptr);
        }

        public static string StrError(int error)
        {
            var ptr = opus_strerror(error);
            return Marshal.PtrToStringAnsi(ptr);
        }
    }
}