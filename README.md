# ggj2020
Project for Global Game Jam 2020

This will have something todo with racing





## Running the webserver

### Requirements
- Java 11 (recommended installer: [sdkman.io](https://sdkman.io))

### Commands

#### Playing in the local browser

1. Build the Unity WebGL project from Unity. Ensure that the output lands in `src/Ggj2020/build`, it will then we automatically symlinked into the webserver.
2. Run the webserver. For that, `cd` into the `src/comm-server` folder, and run `./gradlew clean bootRun --rerun-tasks`
3. Navigate in your browser to [localhost:8080](http://localhost:8080)


#### Deploying your own server

1. Ensure that the WEBGL project is built, see step 1 above
2. Build the webserver. For that, `cd` into the `src/comm-server` folder, and run `./gradlew clean build --rerun-tasks`. This will produce a `comm-server.jar` in `src/comm-server/build/libs/`. You can run this with Java 11 on your server or use the docker files  in `src/comm-server` to build and deploy a contaner to your own server.
