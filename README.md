# ShellThumbs

C# project for extracting thumbnails and icons for files using the Windows Shell API. You can get thumbnails/previews for images, videos, documents and other file types that have registered shell extensions. If not you get th file icon instead.

## About

Original from http://stackoverflow.com/questions/21751747/extract-thumbnail-for-any-file-in-windows

I took above code and packaged it, tweaked it and added some comments and other findings along the way

## Example

`Bitmap bm = ShellThumbs.WindowsThumbnailProvider.GetThumbnail( @"c:\temp\video.avi", 64, 64, ThumbnailOptions.None );`
