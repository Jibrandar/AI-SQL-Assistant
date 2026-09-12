using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.AI;
using OpenAI;
using System.ClientModel;

namespace AIAssistantSystem.Models
{
    internal class SQLAssistant
    {
        private readonly string _apiKey = Environment.GetEnvironmentVariable("GROQ_API_KEY");
        readonly ApiKeyCredential credential = null;
        readonly OpenAIClient groqClient = null;
        readonly OpenAIClientOptions options = null;
        readonly IChatClient client = null;

        public SQLAssistant()
        {
            credential = new ApiKeyCredential(_apiKey);
            options = new OpenAIClientOptions()
            {
                Endpoint = new Uri("https://api.groq.com/openai/v1")
            };

            groqClient = new OpenAIClient(credential, options);
            var chatClient = groqClient.GetChatClient("openai/gpt-oss-20b");
            client = chatClient.AsIChatClient();
        }

        public async Task<string> GenerateSelectQuery(string requirement)
        {
            string systemPrompt = "You are an SQL expert.You will get an select query in english. convert the english sentence into a sql select query and explain the query to the user. If any other query given dont generate anything and return with proper response";
            var response = await client.GetResponseAsync([
                new  (ChatRole.System,systemPrompt),
               new(ChatRole.User,requirement)
                ]);
            return response.Text;
        }


        public async Task<string> GenerateInsertQuery(string requirement)
        {
            string systemPrompt = "You are an SQL expert.You will get an insert query in english. convert the english sentence into a sql insert query and explain the query to the user. If any other query given dont generate anything and return with proper response";
            var response = await client.GetResponseAsync([
                new(ChatRole.System,systemPrompt),
                new(ChatRole.User,requirement)
                ]);

            return response.Text;
        }

        public async Task<string> GenerateDeleteQuery(string requirement)
        {
            string systemPrompt = "You are an SQL expert.You will get an Delete query in english. convert the english sentence into a sql Delete query and explain the query to the user. If any other query given dont generate anything and return with proper response";

            var response = await client.GetResponseAsync([
                new(ChatRole.System,systemPrompt),
                new(ChatRole.User,requirement)
                ]);

            return response.Text;
        }

        public async Task<string> GenerateUpdateQuery(string requirement)
        {
            string systemPrompt = "You are an SQL expert.You will get an Update query in english. convert the english sentence into a sql update query and explain the query to the user. If any other query given dont generate anything and return with proper response";
            var response = await client.GetResponseAsync([
                new(ChatRole.System,systemPrompt),
                new(ChatRole.User,requirement)
                ]);
            return response.Text;
        }
    }
}
