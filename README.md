# DashboardStatusApp
Check the status of a client and show his information on a dashboard
This app is made with ASP.NET CORE 3.1 and Angular 8
A redis cache needs to be run in order to save the clients information. Download the server from here: https://github.com/microsoftarchive/redis/releases/tag/win-3.2.100

Use Postman or other form of posting method to send posts from clients.
The app checks every 5 seconds for updates. It gives a grace period of a minute from posting the status of a client to display that the client is online 
