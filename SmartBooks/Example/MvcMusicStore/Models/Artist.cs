using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMusicStore.Models
{
    /// <summary>
    /// 艺术家
    /// </summary>
    public class Artist
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int ArtistId { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
    }
}