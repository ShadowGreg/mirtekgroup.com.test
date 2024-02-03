using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class ParseController: ControllerBase {
    private bool _stop = false;

    [HttpOptions("Start")]
    public async Task StartAsync(string url) {
        ParseService.ParseService parseService = new ParseService.ParseService();
        while (!_stop) {
            await parseService.Parse(url);
            Console.WriteLine($"Parse start at {DateTime.Now}");
        }
    }

    [HttpOptions("Stop")]
    public Task StopAsync() {
        _stop = true;
        Console.WriteLine("Stopping parse...");
        return Task.CompletedTask;
    }
}