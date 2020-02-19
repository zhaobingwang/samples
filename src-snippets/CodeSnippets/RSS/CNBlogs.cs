using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace CodeSnippets.RSS
{
    public class CNBlogs
    {
        // 十天推荐排行榜：http://wcf.open.cnblogs.com/blog/TenDaysTopDiggPosts/5
        // 48小时阅读排行榜：http://wcf.open.cnblogs.com/blog/48HoursTopViewPosts/5

        public static async Task<CNBlogsRSSModel> GetTenDaysTopDiggPostsAsync()
        {
            try
            {
                var url = "http://wcf.open.cnblogs.com/blog/TenDaysTopDiggPosts/5";

                XmlDocument xmlDocument = new XmlDocument();
                HttpClient httpClient = new HttpClient();
                var stream = await httpClient.GetStreamAsync(url);
                xmlDocument.Load(stream);

                using (StringReader reader = new StringReader(xmlDocument.InnerXml))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(CNBlogsRSSModel));
                    return (CNBlogsRSSModel)xs.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }

    [XmlRoot("feed",Namespace = "http://www.w3.org/2005/Atom")]
    public class CNBlogsRSSModel
    {
        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("id")]
        public string Id { get; set; }

        [XmlElement("updated")]
        public DateTime Updated { get; set; }

        [XmlElement("entry")]
        public List<CNBlogsRSSEntry> Entry { get; set; }
    }

    public class CNBlogsRSSEntry
    {
        [XmlElement("id")]
        public string Id { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("summary")]
        public string Summary { get; set; }

        [XmlElement("published")]
        public DateTime Published { get; set; }

        [XmlElement("updated")]
        public DateTime Updated { get; set; }

        [XmlElement("author")]
        public CNBlogsAuthor Author { get; set; }

        [XmlElement("link")]
        public string Link { get; set; }

        [XmlElement("diggs")]
        public string Diggs { get; set; }

        [XmlElement("views")]
        public string Views { get; set; }

        [XmlElement("comments")]
        public string Comments { get; set; }
    }

    public class CNBlogsAuthor
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("uri")]
        public string Uri { get; set; }

        [XmlElement("avatar")]
        public string Avatar { get; set; }
    }
}
