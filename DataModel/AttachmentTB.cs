using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DataModel
{
	public class AttachmentTB : SystemId
	{
        private string description;
        [System.ComponentModel.DataAnnotations.StringLength(500)]
        [Required(ErrorMessage = "requerido")]
        public string Description { get => description; set => SetProperty(ref description, value); }

        private string fileName;
        [System.ComponentModel.DataAnnotations.StringLength(500)]
        public string FileName { get => fileName; set => SetProperty(ref fileName, value); }


        private string absolutePath;
		[System.ComponentModel.DataAnnotations.StringLength(500)]
		public string AbsolutePath { get => absolutePath; set => SetProperty(ref absolutePath, value); }

		private string url;
		[System.ComponentModel.DataAnnotations.StringLength(500)]
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

        //Inspección
        private long? inspeccionId;
        public long? InspeccionId { get => inspeccionId; set => SetProperty(ref inspeccionId, value); }
        private AUD_InspeccionTB? inspeccion;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual AUD_InspeccionTB? Inspeccion { get => inspeccion; set => SetProperty(ref inspeccion, value); }
    }
}
