# Redis Demo 
This  application serves as a basic demo to adding Redis as a caching provider to a Blazor Server App application. 

For the purposes of running this application locally requires the set up of 

## Getting Started Locally  

1. Install and run Docker Desktop 
2. In the Command Prompt window run the following commands: 

A) Start the Redis Open Source server on our machine within a docker container: 
```docker run --name my-redis -p 5002:6379 -d redis```

--name sets the name of the container, 
-p sets the port mapping, in this case it maps the local port 5002 to the default redis port 6379, 
-d run in detached mode 



B) Connect to the server using redis-cli, which is a redis shell. You can run it from the Docker container: 

```docker exec -it my-redis sh```


C) Run command to enter the redis command line: 
```# redis-cli```

You can check you've successfully connected with the ```ping``` command, ```select 0``` to select the 1st db, ```scan 0``` to retrieve all keys 


## Getting Started in Dev 

Create a Redis cache via Azure, 
R-Click Project > Manage User Secrets to create a secrets.json file. This overrides the appsettings.json and safely stores the values only on the local computer.  

```
{
  "ConnectionStrings": {
    "Redis": "BlazorTest.redis.cache.windows.net:6380,password=etc"
  }
 
}

```


## Troubleshooting 
If you have problems launching docker, try opening the Docker Desktop UI 
