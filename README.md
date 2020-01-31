# ggj2020
Project for Global Game Jam 2020

This will have something todo with racing





## Running the webserver

### Requirements
- Java 11 (recommended: [sdkman.io](https://sdkman.io)

### Commands

1. Build the Unity WebGL project.
2. Move the output of Step 1 to `comm-server/src/main/resources/static` so that Unity's index.html replaces the existing index.html and the other stuff is on the same level.
3. `cd` into the comm-server folder, and run `./gradlew bootRun`
4. Navigate in your browser to [localhost:8080](http://localhost:8080)
