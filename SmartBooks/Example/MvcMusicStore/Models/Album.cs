using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMusicStore.Models
{
    /// <summary>
    /// 专辑
    /// </summary>
    public class Album
    {
        /// <summary>
        /// 专辑标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 唱片
        /// </summary>
        public Genre Genre { get; set; }
    }
}