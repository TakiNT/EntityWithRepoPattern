using FFRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FFBackEnd.Models
{
    public class PostJsonModels
    {
        public int PId { get; set; }
        public string PTitle { get; set; }
        public string PContent { get; set; }
        public string PExcerpt { get; set; } 
        public string PAuthor { get; set; }
        public string PImage { get; set; }
        public string PTags { get; set; }
        public DateTime? PDate { get; set; }
        public byte? PAvailable { get; set; }

        public List<PostJsonModels> ListPost { get; set; }

        public PostJsonModels()
        {
            ListPost = new List<PostJsonModels>();
        }

        public void MapData2Model(Post entity)
        {
            PId = entity.pid;
            PTitle = entity.ptitle;
            PContent = entity.pcontent;
            PExcerpt = entity.pexcerpt;
            PAuthor = entity.Author != null ? entity.Author.aFirstName + " " + entity.Author.aLastName : "";
            PImage = entity.PostMedia != null ? entity.PostMedia.msource : "";
            PTags = entity.PostTag != null ? entity.PostTag.tiname : "";
            PDate = entity.pdate;
            PAvailable = entity.pavailable;
        }
                
    }
}