RtspFuzzer
==========

This is a fuzzer for the RTSP network protocol, built with the [Peach fuzzing framework](http://www.peachfuzzer.com).

## Targets

This fuzzes programs that implement the RTSP client functionality. It fuzzes the responses to the following verbs:

* OPTIONS
* DESCRIBE
* SETUP
* PLAY
* PAUSE

## To Run

The RtspFuzzer is pre-configured to fuzz several common implementations of RTSP.

Fuzzing a different program is simple and easy. Take a look at the Test and Agent elements in rtsp.xml and copy a pair and replace the binary name with your own target binary.

### QuickTime

<pre>
peach --definedvalues=rtsp.conf.xml rtsp.xml QuickTime
</pre>

### VLC Media Player

<pre>
peach --definedvalues=rtsp.conf.xml rtsp.xml Vlc
</pre>

### OpenRTSP

<pre>
peach --definedvalues=rtsp.conf.xml rtsp.xml OpenRtsp
</pre>