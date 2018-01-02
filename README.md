# ShellThumbs

Extract thumbnails and icons for files using the Windows Shell API

## About

Original from http://stackoverflow.com/questions/21751747/extract-thumbnail-for-any-file-in-windows

I took above code and packaged it, tweaked it and added some comments and other findings along the way

## Usage

Bitmap bm = ShellThumbs.WindowsThumbnailProvider.GetThumbnail( @"c:\temp\video.avi", 64, 64, ThumbnailOptions.None );