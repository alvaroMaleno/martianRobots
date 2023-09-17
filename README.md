# Martian Robots API

### Handling robots envy to Mars surface

The Martian Robots API was created to simulate the envy of robots to Mars.
It has been raised as REST api. In addition, scientific teams could require
stats to grasp how successful is their development.

Nothing is perfect, hence sand waves could delete the application memory
removing its docker redis image. Life is hard...

### Rules

- Robots receive a two pair coodinates where to start.
- Robots receive a set of instructions with three possible values {R, L, F}
  - R -> Turns on 90 degrees right
  - L -> Turns on 90 degrees left
  - F -> Go on 1 step over
- Robots receive an orientation. Possible values are {N, S, E, W}
- System receives a max and min field coordinates where robots can move on
- Max coordinate value is 50
- Max instruction length is 100

## Requirements

- .Net Core 6.0.414

## Swagger Page

- <http://localhost:5000/index.html>

## Set up docker compose

    - docker build -t martianrobots:latest .
    - docker compose up
    - navigate to http://localhost:5000/index.html

## Unit testing testing

It is launched automatically when the docker image is built. In case of any error
the build is not going to be completed.

## E2E testing

### Requirements for E2E testing

    - node >= v16.16.0

### Setting up E2E testing

    - Set up docker compose 
    - Open a console and go to E2E/Testing/MartianRobots
    - Execute npm install
    - Execute node martianRobotsControllerTesting.js

## Usage

The application is self docummented via OpenApi and Swagger. Please, run on it
and navigate to <http://localhost:5000/index.html>.

In addition, the list of endpoints available is:

- POST to /MartianRobots -> Send a list of robots to Mars and get their last result.
- GET to /api/MartianRobotsInputs -> Obtain the historic of all robots sent.
- GET to /api/MartianRobotsInputsWithResult -> Obtain the historic of all robots sent with their results.
- GET to /api/MarsCoordinatesVisited -> Obtain a list of each visited coordinate of Mars surface.
- GET to /api/MarsStats -> Obtain a set of statistics related to robots sent {
  "totalOks": 36,
  "totalLosts": 4,
  "totalEnvies": 40,
  "oksPercentage": 90,
  "lostsPercentage": 10,
  "totalCoordinates": 52
}.
