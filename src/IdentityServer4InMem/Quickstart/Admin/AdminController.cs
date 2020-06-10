using System.Linq;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer4InMem.Quickstart.Admin
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        [HttpPost]
        public IActionResult AddClient([FromBody] Client client)
        {
            if (Config.Clients.Any(c => c.ClientId == client.ClientId) == false)
            {
                Config.Clients.Add(client);
            }

            return new OkResult();
        }

        [HttpPost]
        public IActionResult RemoveClient([FromBody] string clientId)
        {
            var client = Config.Clients.FirstOrDefault(c => c.ClientId == clientId);
            if (client != null)
            {
                Config.Clients.Remove(client);
            }

            return new OkResult();
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] TestUser user)
        {
            if (Config.Users.Any(u => u.Username == user.Username) == false)
            {
                Config.Users.Add(user);
            }

            return new OkResult();
        }

        [HttpPost]
        public IActionResult RemoveUser([FromBody] string username)
        {
            var user = Config.Users.FirstOrDefault(u => u.Username == username);
            if (user != null)
            {
                Config.Users.Remove(user);
            }

            return new OkResult();
        }

        [HttpPost]
        public IActionResult AddApiResource([FromBody] ApiResource resource)
        {
            if (Config.Apis.Any(a => a.Name == resource.Name) == false)
            {
                Config.Apis.Add(resource);
            }

            return new OkResult();
        }

        [HttpPost]
        public IActionResult RemoveApiResource([FromBody] string name)
        {
            var resource = Config.Apis.FirstOrDefault(r => r.Name == name);
            if (resource != null)
            {
                Config.Apis.Remove(resource);
            }

            return new OkResult();
        }
    }
}
