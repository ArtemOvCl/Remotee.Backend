using Microsoft.AspNetCore.Mvc;
using RemoteAccess.Services;
using QRCoder;
using Microsoft.AspNetCore.SignalR;
using RemoteAccess.Hubs;
using RemoteAccess.Interfaces;

namespace RemoteAccess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {

        public SessionController()
        {

        }

        [HttpPost("create")]
        public IActionResult CreateQrCodeForSession([FromBody] string sessionId)
        {

            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(sessionId, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new PngByteQRCode(qrCodeData);
            var qrCodeImage = qrCode.GetGraphic(20);

            return File(qrCodeImage, "image/png");
        }
    }
}
