#!/bin/bash

# Windows Releases
dotnet publish --self-contained -r win-x86 -o ../release/win-x86 ../src/pr0cessor.csproj
zip -r ../release/win-x86.zip ../release/win-x86/

dotnet publish --self-contained -r win-x64 -o ../release/win-x64 ../src/pr0cessor.csproj
zip -r ../release/win-x64.zip ../release/win-x64/

# Linux Releases
dotnet publish --self-contained -r linux-x64 -o ../release/linux-x64 ../src/pr0cessor.csproj
zip -r ../release/linux-x64.zip ../release/linux-x64/

dotnet publish --self-contained -r linux-arm -o ../release/linux-arm ../src/pr0cessor.csproj
zip -r ../release/linux-arm.zip ../release/linux-arm/

dotnet publish --self-contained -r linux-musl-x64 -o ../release/linux-musl-x64 ../src/pr0cessor.csproj
zip -r ../release/linux-musl-x64.zip ../release/linux-musl-x64/

# Mac OSX Releases
dotnet publish --self-contained -r osx-x64 -o ../release/osx-x64 ../src/pr0cessor.csproj
zip -r ../release/osx-x64.zip ../release/osx-x64/
