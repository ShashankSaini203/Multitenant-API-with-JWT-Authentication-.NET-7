# Project Setup and Configuration Guide
Welcome to the setup guide for this application! To ensure a smooth running experience, please follow these steps:

1. **Select the Startup Project:**
   - Choose the `Multitenant.API` as the startup project.

2. **Ensure .NET 7 is Installed:**
   - Make sure that [.NET 7](https://dotnet.microsoft.com/download/dotnet/7.0) is installed on your machine.

3. **Update Local Database Connection:**
   - Update the Local DB connection in `appsettings.json` for Alpha & Beta Databases.
   - This application supports Hybrid Multitenancy, providing three databases: Alpha, Beta, and Shared.
   - If a DB Connection is not provided for a specific tenant, the default one (Shared) will be used.

4. **JWT Authentication Credentials:**
   - This application supports JWT Authentication. Use the following credentials to generate a token:
     - **Endpoint:** `/api/Authentication/Authenticate`
     - **Username:** "admin"
     - **Password:** "admin"

5. **Endpoint Access:**
   - Use any API platform such as "Postman" to send headers. Swagger is also implemented to list endpoints.
   - Headers required:
     - Header 'Tenant': `<Add Tenant Name - Alpha, Beta, Tom, Jerry>`
     - Authorization Type: Bearer Token
     - Token: `<Generated from Authenticate endpoint as mentioned in step 4>`

6. **Sample CURL Command (`/api/GetAll` Endpoint - GET):**
   ```bash
   curl --location 'https://localhost:5001/api/GetAll' \
   --header 'tenant: tom' \
   --header 'Authorization: Bearer <Token>'
   
Feel free to reach out if you need any support. You can contact me at Shashanksaini203@gmail.com or connect on [LinkedIn](https://in.linkedin.com/in/shashanksaini203).

Happy coding! 🚀
