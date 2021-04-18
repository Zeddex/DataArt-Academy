using System;
using System.Collections.Generic;
using System.Linq;
using Homework9.Entities;

namespace Homework9.Models
{
    public enum PollStatus
    {
        unpublished,
        published,
        complete
    }

    public class Core
    {
        public static readonly List<PollModel> polls = new();
        public static readonly List<User> user = new();

        public static PollModel GetById(int id)
        {
            return Core.polls.FirstOrDefault(x => x.Id == id);
        }

        public static PollModel AddVote(PollModel poll, int answerId)
        {
            int score = 0;

            if (poll.Votes == null)
            {
                poll.Votes = new Dictionary<int, int>();
                poll.Votes.Add(answerId, 1);
            }

            else
            {
                score = poll.Votes[answerId];
                score++;
            }

            if (score >= 1)
            {
                poll.Votes.Remove(answerId);
                poll.Votes.Add(answerId, score);
            }

            return poll;
        }

        public static string PasswordHandler (User user)
        {
            if (user == null)
            {
                return null;
            }

            string login = user.Login;
            string passwPattern = "pwd";
            string password = user.Password;
            int passwordPart;
            bool isOrg = false;

            if (password.EndsWith("!"))
            {
                password = password.TrimEnd('!');
                isOrg = true;
            }

            if (!password.StartsWith(passwPattern) ||
                !int.TryParse(password.Substring(3), out passwordPart) ||
                login.Length * 2 != passwordPart)
            {
                return null;
            }

            if (isOrg)
            {
                return "org";
            }

            return "user";
        }
    }
}
