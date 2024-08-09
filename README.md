# Instruction on how to get WorkWave up and running

- Clone our repository by using the HTTPS clone link provided on our repository page. Navigate to the workspace on your local machine where you want the project repository to be placed then run "git clone linktoourrepo"
- Once the repository has been cloned follow the respective steps below to get the frontend and backend up and running.


## Frontend:
- Navigate to WorkWave/Application/frontend using the cd command in your respective script (we used bash and zsh)
- Then run the following command based on the architecture you are using to run your frontend:
npm run dev
### or
yarn dev
### or
pnpm dev
### or
bun dev
- Open http://localhost:3000 with your browser to see the result.

-You can start editing the page by modifying app/page.tsx. The page auto-updates as you edit the file.

## Backend:

- Once the repository has been cloned, navigate to "WorkWave/Application/WorkWave/Services" once in this direcotry you will want to add a connectionstring.env file that has the following "DefaultConnection:YOUR;Connection;String;Here;" and save the file.
- You will then need to ensure you have a docker container running with a valid connection to a SQL Server database system.
- Once the Docker container is running, and you are connected to your SQL Server, you can run the following command to get the database schema needed for WorkWave's backend to save: "dotnet ef database update".
- This will ensure that the migration available within our project files build the database schema according to the models provided to allow for full functionality.
- You will then need to navigate to the API layer "WorkWave/Application/WorkWave/API" and run "dotnet run".
- This will then launch the API on localhost:5012 (this may be different if that port is in use) where you can in browser add "/swagger" to see all the available endpoints to be used for API calls.
