FROM adoptopenjdk:11-jdk-hotspot
MAINTAINER napster@npstr.space

WORKDIR /opt/comm-server

EXPOSE 8080

ENTRYPOINT ["java", "-Xmx512m", "-jar", "comm-server.jar"]

COPY build/libs/comm-server.jar /opt/comm-server/comm-server.jar
