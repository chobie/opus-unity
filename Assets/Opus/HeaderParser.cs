using System;
using System.Runtime.InteropServices;

namespace opus
{
    public class HeaderParser
    {
        public HeaderInfo ParseHeader(byte[] opusData)
        {
            if (opusData == null || opusData.Length == 0)
            {
                throw new ArgumentException("Invalid Opus data.");
            }

            HeaderInfo info = new HeaderInfo();
            int index = 0;
            byte firstByte = opusData[index];

            info.ConfigValue = (firstByte >> 3) & 0x1F;
            int stereo = (firstByte >> 2) & 0x01;
            info.Channels = stereo == 0 ? "Mono" : "Stereo";

            int frameCount = firstByte & 0x03;


            while (frameCount == 3)
            {
                index++;
                if (index >= opusData.Length)
                {
                    throw new Exception("Unexpected end of data while parsing TOC extensions.");
                }

                info.TocExtensions.Add(opusData[index]);

                frameCount = opusData[index] & 0x03;
            }

            info.FrameCountPerPacket = frameCount + 1;

            return info;
        }
    }
}