﻿using DataBase.Entity;
using Entity;
using Entity.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class SelectNewsController: ControllerBase {
    private readonly IRepository<NewsEntity> _newsRepository;

    public SelectNewsController(IRepository<NewsEntity> newsRepository) {
        _newsRepository = newsRepository;
    }

    [HttpGet("all")]
    public async Task<ActionResult<List<NewsEntity>>> GetAllNews() {
        var response = await _newsRepository.GetAllAsync();
        return Ok(response);
    }

    [HttpPost("EnterText")]
    public async Task<ActionResult<List<NewsEntity>>> GetNews(SelectEntity selections) {
        // var selections = new SelectEntity() {
        //     HeadText = head ?? "",
        //     MainText = text ?? ""
        // };
        var response = await _newsRepository.GetNewsByTextAsync(selections);
        return Ok(response);
    }
}