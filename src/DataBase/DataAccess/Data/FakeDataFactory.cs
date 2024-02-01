using DataBase.Entity;

namespace DataBase.Data;

public static class FakeDataFactory {
    public static List<NewsEntity> NewsEntities => new List<NewsEntity>()
    {
        new NewsEntity()
        {
            Id = 1,
            CreatedDate = DateTime.Parse("Thu, 01 Feb 2024 11:38:45 +0300"),
            Title = "Минфин заявил, что инициатива по проверке банками резидентства клиентов требует обсуждения",
            Description = "В ведомстве сообщили, что решения по этому вопросу не приняты",
            UrlSlug = "https://tass.ru/ekonomika/19874257"
        },
        new NewsEntity()
        {
            Id = 2,
            CreatedDate = DateTime.Parse("Thu, 01 Feb 2024 11:20:19 +0300"),
            Title = "Shell в 2023 году снизила добычу углеводородов на 5% на фоне продажи некоторых активов",
            Description =
                "В компании отметили, что рост добычи на новых проектах оказался больше, чем спад производства на старых месторождениях",
            UrlSlug = "https://tass.ru/ekonomika/19874123"
        },
    };
}