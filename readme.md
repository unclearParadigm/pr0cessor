# pr0cessor

is a leightweight CLI tool, for downloading specific images and image-collections from pr0gramm.
pr0cessor is written with C# and .NET Core, which makes the CLI run on all platforms.

## Features (as of now)

* Remember logged-in users (similar to being logged in with a Browser, a Session-Cookie is stored on your disk)
* Download favorites (liked images) of a specified user
* Download uploads of a specific user
* Filtering downloads for images-only, videos-only or everything

## Planned Features

* Filter downloads filterable by sfw, nsfw, nsfl
* Download all images for specific tags

## Commandline Options

| Commandline-Option         | Description                                       |
|:--------------------------:|:-------------------------------------------------:|
| -i --imagesOnly            | downloads only image-formats                      |
| -v --videosOnly            | downloads only video-formats                      |
| -e --everything            | downloads all formats                             |
| -u --username              | your pr0gramm username                            | 
| -p --password              | your pr0gramm password                            |
| -f --from                  | download things from specific user (by username)  |
| -d --destination           | directory where everything shall be downloaded to |


## Examples

```bash
# Authenticate as cha0s and download all favs of gamb into the current directory
pr0cessor favs -u cha0s -p stahlofen1 -f gamb -e
```

```bash
# Remember authentication locally, you do not have to re-enter it everytime now
pr0cessor auth -u cha0s -p stahlofen1

# Download only images from gamb's favorites and store them into the given directory
pr0cessor favs -f gamb -i -d /path/to/my/pr0/favs

# Download all uploads of cha0s and store them on C: (e.g. on Windows)
pr0cessor uploads -f cha0s -e -d c://
```

## Nice, but how do i get it?

you have two options - either you clone this repository and build it yourself (which is recommended for experienced users only), or you download the pre-compiled executables for your platform.


#### 1) The DIY-approch (recommended for developers and professionals only)

* Clone the repository locally ```git clone https://github.com/unclearParadigm/pr0cessor.git```
* Enter the src-folder of the Repository ```cd pr0cessor/src```
* Make sure you have dotnet-tooling and runtime installed. [Download SDK from here](https://dotnet.microsoft.com/download)
* Use dotnet-tooling to build it ```dotnet build```
* Or just run it directly ```dotnet run```

#### 2) Pre-compiled Releases (recommended for everyone)

* Download latest pre-compiled release for your platform from [Releases-Page](https://github.com/unclearParadigm/pr0cessor/releases)
* extract the downloaded file into a directory of your choice (e.g. ```C://Tools/pr0cessor```)
* add the path to the PATH-variable
* now you can use pr0cessor from any Shell (powershell, cmd, bash, zsh, whatever you prefer)
* refer to the examples above

# Contributions

any contributions are welcome! Feel free to send pull-requests!

# License GNU General Public License Version 3

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.