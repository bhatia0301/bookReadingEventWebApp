•	Clone the repository – git clone https://github.com/bhatia0301/bookReadingEventWebApp.git

•	Open the WSL or CMD (Docker Desktop) and go to the directory where you have cloned the repository (book reading event application).

•	Now run the below command it will pull the images from the docker hub registry.
      -        --> docker compose up
      
•	After running docker compose up it will create the containers - SQL server, Book Reading Event, Volume (to persist the data after deleting the SQL server container).

•	If you want to delete the containers first press cltrl+c and then run the below command to remove all the containers except the volume. 
              --> docker compose down
              
•	If you want to delete the volume as well then run the below command.
              -->  docker compose down -v
              


              
If you want to run with docker commands only: -
1.	Build the image either locally or pull from docker hub: - 
                   docker build -t bookevents -f BookReadingWebApp/Dockerfile .
                  					or
                   docker pull bhatia0301/bookreadingevents:latest


   
3.	Create the network test: - 
                  docker network create test


   
5.	Create the SQL server container with the volume: - 
                  docker run --rm --name sqlserver -p 1433:1433 --network test -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Naman@123' -e 'MSSQL_PID=Express' 
                  -v sqlserver_data:/var/opt/mssql mcr.microsoft.com/mssql/server:2022-preview-ubuntu-22.04



4.	Create the container for the image bookevents or bhatia0301/bookreadingevents: -
                  docker run --rm -p 5000:80 --name bookreadingevent --network test -e 
                  'ConnectionStrings__DefaultConnection=Server=sqlserver,1433;Database=BookReadingEventDB;User Id=SA;Password=Naman@123;Encrypt=False' 
                   -e ASPNETCORE_ENVIRONMENT=Development bhatia0301/bookreadingevents
