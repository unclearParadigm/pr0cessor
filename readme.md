# pr0cessor

is a leightweight CLI tool, for downloading specific images and image-collecitons from pr0gramm.
pr0cessor is written with C# and .NET Core, which makes the CLI run on all platforms,
however testing happens on Linux only.  

## Features (as of now)

* Remember logged-in users (similar to being logged in with a Browser)
* Download favorites (liked images) of a specified user
* Download uploads of a specific user
* Filtering downloads for images-only, videos-only or everything

## Examples

```bash
# Authenticate as cha0s and downloads all favs of gamb into the current directory
pr0cessor favs -u cha0s -p stahlofen1 -f gamb -e
```

```bash
# Remember authentication locally, you do not have to reenter it everytime now
pr0cessor auth -u cha0s -p stahlofen1

# Download all images from gamb's favorites and store them into a given directory
pr0cessor favs -f gamb -i -d /path/to/my/pr0/favs

# Download all uploads of cha0s and store them on C: (e.g. on Windows)
pr0cessor uploads -f cha0s -e -d c://
```
