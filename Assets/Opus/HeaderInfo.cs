using System.Collections.Generic;

namespace opus
{
    public class HeaderInfo
    {
        public int ConfigValue { get; set; }
        public string Channels { get; set; }
        public List<byte> TocExtensions { get; set; } = new List<byte>();
        public int FrameCountPerPacket { get; set; }

        public override string ToString()
        {
            return
                $"Config Value: {ConfigValue}\nChannels: {Channels}\nNumber of TOC Extension Bytes: {TocExtensions.Count}\nFrame Count per Packet: {FrameCountPerPacket}";
        }
    }
}