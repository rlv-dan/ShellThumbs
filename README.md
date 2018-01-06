# ShellThumbs

C# project for extracting thumbnails and icons for files using the Windows Shell API. You can get thumbnails/previews for images, videos, documents and other file types that have registered shell extensions. If not you get th file icon instead.

Includes a demo project to toy around with to understand how it works and bahaves in different situations.

## About

Original from http://stackoverflow.com/questions/21751747/extract-thumbnail-for-any-file-in-windows

I took above code and packaged it together with some tweaks and enhancements, plus comments and other findings along the way.

## Examples

`Bitmap thumbnail_or_icon = ShellThumbs.WindowsThumbnailProvider.GetThumbnail( @"c:\temp\video.avi", 64, 64, ThumbnailOptions.None );`

`Bitmap thumbnail_or_null = ShellThumbs.WindowsThumbnailProvider.GetThumbnail( @"c:\temp\video.avi", 64, 64, ThumbnailOptions.ThumbnailOnly );`

`Bitmap icon = ShellThumbs.WindowsThumbnailProvider.GetThumbnail( @"c:\temp\video.avi", 64, 64, ThumbnailOptions.IconOnly );`

## Notes

Normally, GetThumbnail returns the thumbnail if available, else the file icon. If using the ThumbnailOnly flag, GetThumbnail will return null for files that does not have a thumbnail handler.