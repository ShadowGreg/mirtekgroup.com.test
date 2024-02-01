using System.ServiceModel.Syndication;

namespace RssParse.Abstracts; 

public interface IPostGetter {
    public IEnumerable<SyndicationItem> GetPosts();
}