# Opus-Unity

Simple opus binding for Unity.

# How to build

```
cd Assets/Opus/Editor
zsh build.sh
```

this will download opus-1.4.tar.gz and apply patch. then build and copy dylib.

# Patch

add support for opus_encoder_ctl / opus_decoder_ctl functions.