Frontend: 







Backend:
Once the repository has been cloned, navigate to "WorkWave/Application/WorkWave/Services" once in this direcotry you will want to add a connectionstring.env file that has the following "DefaultConnection:YOUR;Connection;String;Here;" and save the file.
You will then need to ensure you have a docker container running with a valid connection to a SQL Server database system. Once the Docker container is running, and you are connected to your SQL Server, you can run the following command to get the database schema needed for WorkWave's backend to save: "dotnet ef database update". This will ensure that the migration available within our project files build the database schema according to the models provided to allow for full functionality.
