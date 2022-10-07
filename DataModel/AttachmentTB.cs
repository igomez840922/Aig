using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DataModel
{
	public class AttachmentTB : SystemId
	{
		private string absolutePath;
		[System.ComponentModel.DataAnnotations.StringLength(250)]
		public string AbsolutePath { get => absolutePath; set => SetProperty(ref absolutePath, value); }

		private string url;
		[System.ComponentModel.DataAnnotations.StringLength(250)]
		public string Url { get => url; set => SetProperty(ref url, value); }

		private string base64;
		public string Base64 { get => base64; set => SetProperty(ref base64, value); }


		[System.ComponentModel.DataAnnotations.Schema.NotMapped]
		public string PictureData
		{
			get
			{
				if (!string.IsNullOrEmpty(Base64))
				{ return Base64; }

				if (!string.IsNullOrEmpty(Url))
				{ return Url; }

				return "";
			}
			set { }
		}

		//public void SetImageSize()
		//{
		//	try
		//	{
		//		var imagePath = System.Web.HttpContext.Current.Server.MapPath("~" + Url);
		//		using (var fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read, FileShare.Read))
		//		{
		//			using (var image = Image.FromStream(fileStream, false, false))
		//			{
		//				Height = image.Height;
		//				Width = image.Width;
		//			}
		//		}
		//	}
		//	catch { }

		//}

		//[System.ComponentModel.DataAnnotations.Schema.NotMapped]
		//public int Height { get; set; }

		//[System.ComponentModel.DataAnnotations.Schema.NotMapped]
		//public int Width { get; set; }

	}
}
