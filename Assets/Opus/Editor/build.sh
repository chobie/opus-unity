#!/bin/zsh

curl -L https://downloads.xiph.org/releases/opus/opus-1.4.tar.gz -o opus-1.4.tar.gz
tar zxf opus-1.4.tar.gz
cd opus-1.4
patch -p1 < ../opus1.4.patch
./configure
make -j8
cd ..
cp opus-1.4/.libs/libopus.0.dylib ../MacOS/arm64/libopus.dylib
