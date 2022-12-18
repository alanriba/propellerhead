# Propellerhead code challenger
Corresponds to the API that returns API that allows a company to see customer information..

## Start 🚀
These instructions will allow you to get a copy of the project running on your local machine for development and testing purposes.

### Prerequisites 📋
The following software must be pre-installed on the PC.

  - [Microsoft Visual Studio Community 2019](https://visualstudio.microsoft.com/es/vs/community/) - Source code editor.
  - [SQL Server]: Sql Server preferably already installed, otherwise dockers and Azure Data Studio are used for its use.
  Reference: https://learn.microsoft.com/en-nz/sql/linux/quickstart-install-connect-docker?view=sql-server-ver16&pivots=cs1-bash
  
  
  
### Download Repository
```shell
eject git clone https://github.com/alanriba/propellerhead.git 
```

### Execution
1. Ejecute command Entity Framewoks
  Reference: https://learn.microsoft.com/en-nz/ef/core/cli/powershell
2. Run Visual Studio 2019.
3. Select Open Project or a Solution.
4. Browse to project directory and load file with extension **.sln** .
5. The port with which the application will be executed must be configured. To do this, in the _Solution Explorer_ window, select the object propellerhead and right click and then _Properties_. 
   Select _Debug_ and in option _Application URL_ add the necessary address(es) separated with semicolon (;). In this case, ports **5000** are set.
    
   Or you can configure the property file launchsettings.json
    
```json
{
  "profiles": {
    "Encora": {
      "commandName": "Project",
      "launchBrowser": true,
      "applicationUrl": "http://localhost:5000",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```

### Compilation 📦
To compile the project, it can be done from the menu _Compile > Compile Solution_ or _Recompile Solution_.

### Deployment
Each time the application needs to be started, just execute from menu _Debug > Start debugging_ or _Start without debugging_.

### Local Test
For local testing you can use Swagger's graphical interface

```url
http://localhost:5000/swagger/index.html
```
