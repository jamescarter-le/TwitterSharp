﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using TwitterSharp.Client;
using TwitterSharp.Request.AdvancedSearch;

namespace TwitterSharp.UnitTests
{
    [TestClass]
    public class TestClient
    {
        [TestMethod]
        public async Task GetTweetByIdsAsync()
        {
            var client = new TwitterClient(Environment.GetEnvironmentVariable("TWITTER_TOKEN"));
            var answer = await client.GetTweetsByIdsAsync("1389189291582967809");
            Assert.IsTrue(answer.Length == 1);
            Assert.AreEqual("1389189291582967809", answer[0].Id);
            Assert.AreEqual("たのしみ！！\uD83D\uDC93 https://t.co/DgBYVYr9lN", answer[0].Text);
        }

        [TestMethod]
        public async Task GetTweetsByIdsAsync()
        {
            var client = new TwitterClient(Environment.GetEnvironmentVariable("TWITTER_TOKEN"));
            var answer = await client.GetTweetsByIdsAsync("1389330151779930113", "1389331863102128130");
            Assert.IsTrue(answer.Length == 2);
            Assert.AreEqual("1389330151779930113", answer[0].Id);
            Assert.AreEqual("ねむくなーい！ねむくないねむくない！ドタドタドタドタ", answer[0].Text);
            Assert.AreEqual("1389331863102128130", answer[1].Id);
            Assert.AreEqual("( - ω・ )", answer[1].Text);
        }

        [TestMethod]
        public async Task GetTweetsFromUserIdAsync()
        {
            var client = new TwitterClient(Environment.GetEnvironmentVariable("TWITTER_TOKEN"));
            var answer = await client.GetTweetsFromUserIdAsync("1109748792721432577");
            Assert.IsTrue(answer.Length == 10);
        }

        [TestMethod]
        public async Task GetUserAsync()
        {
            var client = new TwitterClient(Environment.GetEnvironmentVariable("TWITTER_TOKEN"));
            var answer = await client.GetUsersAsync("theindra5");
            Assert.IsTrue(answer.Length == 1);
            Assert.AreEqual("1022468464513089536", answer[0].Id);
            Assert.AreEqual("TheIndra5", answer[0].Username);
            Assert.AreEqual("TheIndra", answer[0].Name);
        }

        [TestMethod]
        public async Task GetUserWithOptionsAsync()
        {
            var client = new TwitterClient(Environment.GetEnvironmentVariable("TWITTER_TOKEN"));
            var answer = await client.GetUsersAsync(new[] { "theindra5" }, new[] { UserOption.Description, UserOption.Public_Metrics });
            Assert.IsTrue(answer.Length == 1);
            Assert.AreEqual("1022468464513089536", answer[0].Id);
            Assert.AreEqual("TheIndra5", answer[0].Username);
            Assert.AreEqual("TheIndra", answer[0].Name);
            Assert.IsNotNull(answer[0].Description);
            Assert.IsNotNull(answer[0].PublicMetrics);
            Assert.IsNull(answer[0].IsVerified);
        }
    }
}
