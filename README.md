# C# Selenium Automation Framework

## Overview
This is a boilerplate project for building Selenium-based UI automation tests using **C#**, **NUnit**, and **VS Code**.  
Includes GitHub Actions CI and Docker support.

---

## Features
- Selenium WebDriver (Chrome)
- NUnit for testing
- Page Object Model (POM) structure
- Config via `appsettings.json`
- GitHub Actions CI/CD
- Docker support for isolated test execution

---
## wr
## Prerequisites
- **VS Code**
- **.NET 9 SDK or later**
- **Google Chrome**

---

## VS Code Setup

### 1. Install Extensions
- **C# (OmniSharp)**  
- **.NET Install Tool**  
- **Test Explorer UI** (optional for viewing tests in UI)

---

### 2. Install Dependencies
Open a terminal in the project folder:
```bash
dotnet restore
```

---

### 3. Run Tests in VS Code
```bash
dotnet test
```
Or use **Test Explorer UI** sidebar.

---

### 4. Debug Tests
Create a `.vscode/launch.json` file:
```json
{
  "version": "0.2.0",
  "configurations": [
    {
      "name": ".NET Core Launch Tests",
      "type": "coreclr",
      "request": "launch",
      "preLaunchTask": "build",
      "program": "${workspaceFolder}/bin/Debug/net6.0/CSharpSeleniumFramework.dll",
      "args": [],
      "cwd": "${workspaceFolder}",
      "stopAtEntry": false,
      "console": "integratedTerminal"
    }
  ]
}
```

---

## Running with Docker
Build and run tests inside a container:
```bash
docker build -t selenium-tests .
docker run --rm selenium-tests
```

---

## GitHub Actions CI
Workflow: `.github/workflows/ci.yml`  
Runs on `windows-latest` with Chrome + ChromeDriver pre-installed.  
Triggers on `push` and `pull_request`.

---

## Project Structure
```
CSharpSeleniumFramework/
├── Drivers/           # WebDriver binaries placeholder
├── Pages/             # Page Object Models
├── Tests/             # Test cases
├── Utils/             # Helper classes
├── appsettings.json   # Configurations
├── Dockerfile         # Containerized execution
├── .github/workflows/ci.yml # GitHub Actions pipeline
├── CSharpSeleniumFramework.csproj
└── CSharpSeleniumFramework.sln
```

---

## Adding New Tests
Example NUnit test:
```csharp
[Test]
public void VerifyPageTitle()
{
    driver.Navigate().GoToUrl("https://example.com");
    Assert.IsTrue(driver.Title.Contains("Example"));
}
```

---

## License
MIT License

---

## API Testing with RestSharp
This framework also supports **API tests** using RestSharp.

### Example API Test
```csharp
[Test]
public void VerifyApiStatus()
{
    var client = new RestClient("https://jsonplaceholder.typicode.com");
    var request = new RestRequest("/posts/1", Method.Get);
    var response = client.Execute(request);

    Assert.AreEqual(200, (int)response.StatusCode);
    Assert.IsTrue(response.Content.Contains("userId"));
}
```

Run all tests (UI + API):
```bash
dotnet test
```

---

## Running Tests by Category
You can run **only UI tests** or **only API tests** using NUnit categories.

Run **UI tests only**:
```bash
dotnet test --filter TestCategory=UI
```

Run **API tests only**:
```bash
dotnet test --filter TestCategory=API
```
