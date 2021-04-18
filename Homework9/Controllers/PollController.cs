using Homework9.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Homework9.Services;
using System.Threading.Tasks;

namespace Homework9.Controllers
{
    [Authorize]
    public class PollController : Controller
    {
        private IUserService _userService;

        public PollController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromHeader] AuthenticateModel model)
        {
            var user = await _userService.Authenticate(model.Login, model.Password);

            string userType = Core.PasswordHandler(user);

            if (user == null || userType == null)
                return BadRequest(new { message = "Login or password is incorrect" });

            if (userType == "org")
                User.IsInRole("Org");
            else
                User.IsInRole("User");
                  
            return Ok(user);
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Org")]
        public IActionResult Create(PollModel myPoll)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int currId = Core.polls.Count + 1;

            Core.polls.Add(new PollModel
            {
                Id = currId,
                Question = myPoll.Question,
                Answer = myPoll.Answer
            });
            return Ok();
        }

        public IActionResult Details(int id)
        {
            var poll = Core.GetById(id);

            if (poll == null)
                return NotFound("No such poll id");

            if (poll.Status == PollStatus.unpublished && User.IsInRole("User"))
            {
                return Unauthorized();
            }

            return Ok(poll);
        }

        [Authorize(Roles = "User")]
        public IActionResult Vote(int id, int answerId)
        {
            var poll = Core.GetById(id);

            if (poll == null)
                return NotFound("No such poll id");

            if (poll.Status == PollStatus.complete || poll.Status == PollStatus.unpublished)
            {
                return BadRequest("This poll is closed for voting");
            }

            if (answerId == 0 || answerId > poll.Answer.Count)
            {
                return BadRequest("No such answer number");
            }

            Core.AddVote(poll, answerId);

            return Ok();
        }

        public IActionResult Results(int id)
        {
            var poll = Core.GetById(id);

            if (poll == null)
                return NotFound("No such poll id");

            string result = string.Empty;

            for (int i = 0; i < poll.Answer.Count; i++)
            {
                result += $"Answer{i}: {poll.Answer[i]}\n";
            }

            result += $"Status: {poll.Status}, Votes: {poll.Votes}\n\n";

            return Content(result);
        }

        public IActionResult Status(int id)
        {
            var poll = Core.GetById(id);

            if (poll == null)
                return NotFound("No such poll id");

            return Content($"Poll Id: {poll.Id}, Status: {poll.Status}");
        }

        [Authorize(Roles = "Org")]
        public IActionResult Publish(int id)
        {
            var poll = Core.GetById(id);

            if (poll == null)
                return NotFound("No such poll id");

            poll.Status = PollStatus.published;

            return Ok();
        }

        [Authorize(Roles = "Org")]
        public IActionResult Complete(int id)
        {
            var poll = Core.GetById(id);

            if (poll == null)
                return NotFound("No such poll id");

            poll.Status = PollStatus.complete;

            return Ok();
        }

        [AllowAnonymous]
        public IActionResult ShowAll()
        {
            string result = string.Empty;

            foreach (var item in Core.polls)
            {
                result += $"Poll Id: {item.Id} - Question: {item.Question}\n";

                for (int i = 0; i < item.Answer.Count; i++)
                {
                    result += $"Answer{i}: {item.Answer[i]}\n";
                }

                result += $"Status: {item.Status}, Votes: {item.Votes}\n\n";
            }
            return Content(result);
        }
    }
}
