using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ShellThumbs;
using System.Linq;

namespace ShellThumbsDemo
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click( object sender, EventArgs e )
		{
			var files = Directory.GetFiles(textBox1.Text);
			var folders = Directory.GetDirectories( textBox1.Text );
			files = folders.Concat(files).ToArray();

			var sizeX = Int32.Parse( comboBox2.Text );
			var sizeY = Int32.Parse( comboBox3.Text );

			// this demo only allows using one flag at a time, but you get combine them bitwise if needed
			ThumbnailOptions options = ThumbnailOptions.None;
			if( comboBox1.Text == "BiggerSizeOk" ) options = ThumbnailOptions.BiggerSizeOk;
			if( comboBox1.Text == "InMemoryOnly" ) options = ThumbnailOptions.InMemoryOnly;
			if( comboBox1.Text == "IconOnly" ) options = ThumbnailOptions.IconOnly;
			if( comboBox1.Text == "ThumbnailOnly" ) options = ThumbnailOptions.ThumbnailOnly;
			if( comboBox1.Text == "InCacheOnly" ) options = ThumbnailOptions.InCacheOnly;
			if( comboBox1.Text == "Win8CropToSquare" ) options = ThumbnailOptions.Win8CropToSquare;
			if( comboBox1.Text == "Win8WideThumbnails" ) options = ThumbnailOptions.Win8WideThumbnails;
			if( comboBox1.Text == "Win8IconBackground" ) options = ThumbnailOptions.Win8IconBackground;
			if( comboBox1.Text == "Win8ScaleUp" ) options = ThumbnailOptions.Win8ScaleUp;

			listView1.Clear();
			imageList1.Images.Clear();
			imageList1.ImageSize = new Size( sizeX, sizeY );

			foreach( var f in files )
			{
				Bitmap resultBitmap = WindowsThumbnailProvider.GetThumbnail( f, sizeX, sizeY, options );
				if( resultBitmap != null )
				{
					// The returned bitmap can be smaller than requested size if aspect ration does not match exatcly.
					// If so imageList will scale to specified icon size, which is unwanted.
					// To get around this I create a new bitmap with required size and paste the bitmap there.
					Bitmap squareBitmap = new Bitmap( sizeX, sizeY );
					Graphics g = Graphics.FromImage( squareBitmap );
					g.DrawImage( resultBitmap, new Point( 0, 0 ) );

					imageList1.Images.Add( f, squareBitmap );
					listView1.Items.Add( Path.GetFileName( f ), f );
				}
			}
		}
	}
}
