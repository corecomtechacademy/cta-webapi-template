This is a template dotnet project that includes various common patterns and techniques

This is stored as a template in Azure DevOps. To use, do the following:

1. dotnet nuget add source "https://pkgs.dev.azure.com/corecomtechnologyacademy/AltiaTraining/_packaging/templates/nuget/v3/index.json" --name cta-templates

2. dotnet new install Cta.WebApi.Template


Then create a project from the template:

3. dotnet new cta-webapi -n MyApi