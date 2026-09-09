# AI SQL Assistant

A small C# project I built while learning how to integrate Generative AI into .NET applications.

The idea is simple: instead of writing an SQL query manually, you describe what you want in normal English and the AI generates the SQL Server query for you.

For example:

> Find all employees whose salary is greater than 50000 and whose department is IT.

The application can generate:

```sql
SELECT *
FROM employees
WHERE salary > 50000
  AND department = 'IT';
```

## What it can do

The application currently supports four types of SQL operations:

* SELECT
* INSERT
* UPDATE
* DELETE

There is also a small confirmation step before generating DELETE queries.

The application runs through a simple console menu:

```text
1. Select Query
2. Insert Query
3. Update Query
4. Delete Query
5. Exit
```

## Technologies

* C#
* .NET
* Microsoft.Extensions.AI
* IChatClient
* OpenAI .NET SDK
* Groq API

## How it works

The C# application handles the menu and decides which type of SQL query the user wants.

The selected operation is then sent to the AI along with the user's requirement.

For example:

```text
User
  ↓
Select "SELECT"
  ↓
Enter requirement
  ↓
SQLAssistant
  ↓
IChatClient
  ↓
Groq
  ↓
SQL query + explanation
```

I used different system prompts for the different SQL operations so that the AI stays focused on the selected operation.

## API Key

The API key is not stored directly in the source code.

The application reads it from the following environment variable:

```text
GROQ_API_KEY
```

On Windows, you can create it using PowerShell:

```powershell
[Environment]::SetEnvironmentVariable("GROQ_API_KEY", "your_api_key", "User")
```

After setting the variable, restart Visual Studio before running the project.

## Running the project

Clone the repository:

```bash
git clone <repository-url>
```

Open the project in Visual Studio and make sure the `GROQ_API_KEY` environment variable is configured.

Then run the application.

## What I learned from this project

This project helped me understand how an LLM can be integrated into a normal C# application rather than just calling an API and printing the response.

While building it, I practiced:

* Working with `IChatClient`
* Creating `ChatMessage` objects
* Using system and user messages
* Writing system prompts
* Using `async/await` for AI requests
* Using environment variables for API keys
* Using C# classes and methods to organize the application
* Combining normal C# logic with an LLM

## Current limitations

This is a learning project, so it currently only generates SQL. It does not connect to or execute queries against an actual database.

The generated SQL should always be reviewed before being used on a real database.

## What's next

I'm continuing to learn Generative AI with C# and .NET. Some of the things I plan to explore next are:

* Chat history
* Streaming responses
* Structured outputs
* Tool/function calling
* RAG
* Agentic AI

---

Built while learning **C#, .NET and Generative AI**.
