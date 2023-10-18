namespace opus
{
    public enum Application
    {
        VOIP = Opus.OPUS_APPLICATION_VOIP,
        AUDIO = Opus.OPUS_APPLICATION_AUDIO,
        RESTRICTED_LOW_DELAY = Opus.OPUS_APPLICATION_RESTRICTED_LOWDELAY,
    }
}