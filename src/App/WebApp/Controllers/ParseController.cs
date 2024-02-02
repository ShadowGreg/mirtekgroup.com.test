using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class ParseController: ControllerBase {
    private CancellationToken cancellationToken = new CancellationToken();
    private bool _stop = false;
    
    [HttpOptions("Start")]
    public async Task StartAsync(string url) {
        while (!_stop) {
            foreach (var data in mailData) {
                bool isEmailSent = await _mailService.SendAsync(data);
                Console.WriteLine($"Email sent: {isEmailSent} at {DateTime.Now}");
            }
        }
    }
    
    [HttpOptions("Stop")]
    public async Task StopAsync() {
        _stop = true;
        Console.WriteLine("Stopping RabbitMQ listener...");
        _rabbitMqListener.Dispose();
    }


}