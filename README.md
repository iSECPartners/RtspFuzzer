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

## Fuzzing Other Clients

See the [wiki](https://github.com/iSECPartners/RtspFuzzer/wiki/Fuzzing-a-new-RTSP-client) for information about fuzzing a non-built-in RTSP client implementation.

## Gotchas

Review the [wiki](https://github.com/iSECPartners/RtspFuzzer/wiki/Gotchas) for common issues that may arise when using RtspFuzzer.