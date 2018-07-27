# Changelog

### Version 3.0.0

- Date 27/07/2018
- Release notes:
  - Updated to .NET Core 2.1
  - Adapted the code the be Net Core 2.1 compliance.
  - Updated the external packages.
  - No longer uses bower, now it uses npm.
  - No longer uses appsettings, now it uses environment variables.
    - SSL_PORT now is inferred by the variable ASPNETCORE_URLS
    - Added library `envsafe` for checking required environment variables.

### Version 2.0.0

- Date 30/08/2017
- Release notes:
  - Updated to .NET Core 2.0
  - Added HTTPS with dev certificate for Dev and Staging environments.

### Version 1.0.0

- Date 21/07/2017
- Release notes:
  - Creation of template.