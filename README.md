# Lightweight NetCore MVC Template

Net Core 1.1 MVC project with Bootstrap and JQuery, HTML, XML, CSS, JS minifiers, and profiles for multiple environments (dev, stg, prod)

## Suggested Repository Structure

```
- src (source code projects)
- tests (projects for unit testing)
- NuGet.config (sets the configuration for NuGet repositories)
- .gitignore (sets the ignorable files for git)
- README (file with information about the solution)
```

## Website Template

- The website uses .NET Core 1.1 MVC
- Since for .NET Core Local IIS is no longer required, for debugging the application uses IIS Express with 3 different profiles.
- Each one has a different value in the .NET Core required variable  **ASPNETCORE_ENVIRONMENT**
- This variable determines things like:
  - Developer Exception Page
  - Bundling and minifying .html, .css and .js files
- The configuration file where this is set is **launchSettings.json**

## Packages

- Back end packages are managed by **NuGet** using the **.csproj** for loading packages.
- Front end packages are managed by **bower** using the file **bower.json** for loading configuration.

## Minification

- BuildBundlerMinifier is installed in order to minify CSS and JS files located in **bundleconfig.json**
- WebMarkupMin.AspNetCore1 is installed in order to minify XML, HTML and add gzip compression to the pipeline.

## Icon

[Thanks to Oliviu Stoian from **the noun project** for the icon.](https://thenounproject.com/smashicons/)