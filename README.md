# Lightweight NetCore MVC Template

- Net Core 2.1 raw MVC project with Bootstrap, JQuery, Typescript configurated.
- Minification of HTML, XML, CSS, JS and bundling for Staging and Product integrated.
- HTTPS support for Dev and Staging with dev's certificate.

# Changes from previous version

- Adapted the code the be Net Core 2.1 compliance.
- Updated the external packages.
- No longer uses bower, now it uses npm.
- No longer uses appsettings, now it uses environment variables.
  - SSL_PORT now is inferred by the variable ASPNETCORE_URLS
  - Added library `envsafe` for checking required environment variables.

# How to setup environment variables for development

- VisualStudio: Properties/launchSettings.json
- Rider: From Run/Debug Configurations (it will be saved to a hidden folder .idea in the root of the sln)

# How to setup environment variables for releasing

- Docker: docker-compose/environment
- Kubernetes: deployment.yaml/env or deployment.yaml/envFrom

## Suggested repository structure

```
- src (source code projects)
- tests (projects for unit testing)
- NuGet.config (sets the configuration for NuGet repositories)
- .gitignore (sets the ignorable files for git)
- .dockerignore (for creating a docker image)
- README (file with information about the solution)
```

## Website template

- The website uses .NET Core 2.1 MVC.
- Uses Kestrel to run the application, no more buggy IIS Express.
- Uses Environment Variables instead of appsettings.json

## Packages

- Back end packages are managed by **NuGet** using the **.csproj** for loading packages.
- Front end packages are managed by **npm** using the file **packages.json** for loading configuration.

## Minification

- BuildBundlerMinifier is installed in order to minify CSS and JS files located in **bundleconfig.json**
- WebMarkupMin.AspNetCore2 is installed in order to minify XML, HTML and add gzip compression to the pipeline.

## Icon

[Thanks to Oliviu Stoian from **the noun project** for the icon.](https://thenounproject.com/smashicons/)