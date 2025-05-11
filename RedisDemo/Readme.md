# Redis Demo 
This application serves as a practice to adding Redis as a caching provider to a blazor application. 

## Steps 

1. Install and run Docker Desktop 
2. In the Command Prompt window run command to create a redis instance within a docker container: 
```docker run --name my-redis -p 5002:6379 -d redis```

Local port 5002 maps to the redis port 6379. 



3. Run command to initiate a redis shell: 
```docker exec -it my-redis sh```


4. Run command to enter the redis command line: 
```# redis-cli```