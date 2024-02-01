namespace DataBase.Entity;

public class NewsEntity {
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? UrlSlug { get; set; }
    public string? Description { get; set; }
    public DateTime? CreatedDate { get; set; }
}