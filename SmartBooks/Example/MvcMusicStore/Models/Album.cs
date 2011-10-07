using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcMusicStore.Models
{
    /// <summary>
    /// 专辑
    /// </summary>
    [Bind(Exclude="AlbumId")]
    public class Album
    {
        [ScaffoldColumn(false)]
        public int AlbumId { get; set; }

        [DisplayName("Genre")]
        public int GenreId { get; set; }

        [DisplayName("Artist")]
        public int ArtistId { get; set; }
        
        /// <summary>
        /// 专辑标题
        /// </summary>
        [Required(ErrorMessage="An Album Title is Required")]
        [StringLength(160)]
        public string Title { get; set; }

        [Required(ErrorMessage="Price is required")]
        [Range(0.01, 100.00,ErrorMessage="Price must be between 0.01 and 100.00")]
        public decimal Price { get; set; }

        [DisplayName("Album art URL")]
        [StringLength(1024)]
        public string AlbumArtUrl { get; set; }

        /// <summary>
        /// 唱片
        /// </summary>
        public Genre Genre { get; set; }
        public Artist Artist { get; set; }
    }
}