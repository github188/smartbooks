using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMusicStore.Models
{
    /// <summary>
    /// 唱片
    /// </summary>
    public class Genre
    {
        public int GenreId { get; set; }
        /// <summary>
        /// 唱片名称
        /// </summary>
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Album> Albums { get; set; }
    }
}