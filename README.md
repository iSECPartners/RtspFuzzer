RtspFuzzer
==========

This is a fuzzer for the RTSP network protocol, built with the [Peach fuzzing framework](http://www.peachfuzzer.com).

## To Run

The RtspFuzzer is pre-configured to fuzz several implementations of RTSP. Adding fuzz targets is easy and only requires a few lines of XML.

### QuickTime

<pre>
peach --definedvalues=rtsp.conf.xml rtsp.xml QuickTimeTest
</pre>

### VLC Media Player

<pre>
peach --definedvalues=rtsp.conf.xml rtsp.xml VlcTest
</pre>

### OpenRTSP

<pre>
peach --definedvalues=rtsp.conf.xml rtsp.xml OpenRtspTest
</pre>